using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Dungeon;
using Raptor.Utility;

namespace Raptor.Dungeon.Generation
{

    //TODO: Set size of initialbounds in Editor
    // TODO: Set amount of inital rooms in Editor
    /// <summary>
    /// Handles generation of the entire dungeon
    /// </summary>
    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] Dungeon _dungeon;
        [Header("Simulation")]
        [SerializeField] DungeonRules _testRules;

        [SerializeField] int seed;
        public Randomizer _random;

        private void Awake()
        {
            _random = new Randomizer(seed);
        }

        private void Update()
        {
            if (_dungeon.Layout._rooms.Count > 0) Debug.Log("Are rooms moving: " + IsGenerationBodySimulationActive());
        }

        public void TestGenerate()
        {
            int floor = 0;
            DungeonRules dungeonRules = _testRules;

            Debug.Log("Generate test dungeon floor");
            StartGenerateFloor(dungeonRules.GenerateFloorRules(floor));
        }

        public void StartGenerateFloor(FloorRules floorRules)
        {
            StartCoroutine(GenerateFloor(floorRules));
        }

        public IEnumerator GenerateFloor(FloorRules floorRules)
        {
            //Create room placer for this floor and generate rooms with correctly shaped colliders
            InitialRoomPlacerAgent roomPlacer = new InitialRoomPlacerAgent(ref _random, floorRules);
            _dungeon.Layout.AddRooms(roomPlacer.GenerateRooms());

            //Rooms have rigidbodies and are being simulated
            Debug.Log("Simulating rooms...");

            //Wait for simulation to end
            yield return new WaitForFixedUpdate();
            yield return WaitForBodySimulationEnd();

            //Convert to trigger, end simulation of bodies
            _dungeon.Layout.ApplyToEachRoom((DungeonRoom r) => r.Collider.isTrigger = true);
            //Then snap all rooms to the grid (overlap should not happen)
            _dungeon.Layout.ApplyToEachRoom((DungeonRoom r) => GridUtility.SnapToCell(_dungeon.WorldGrid, r));

            yield return new WaitForFixedUpdate();
            yield return WaitForBodySimulationEnd();

            //NOTE: Possibly check if rooms overlap?
            Debug.Log("Physical simulation of dungeon rooms complete...");

            //Search and set neighbours of the rooms
            NeighbourSearchAgent neighbourSearcher = new NeighbourSearchAgent(_dungeon.Layout);
            neighbourSearcher.SetNeighboursAllRooms();

            TilePlacer tilePlacer = new TilePlacer(_dungeon.GroundTilemap, _dungeon.ObstacleTilemap);
            _dungeon.Layout.ApplyToEachRoom(r => tilePlacer.TileStructure(r));

            //Generate graph of connected rooms
            GraphGenAgent graphGen = new GraphGenAgent(_dungeon.Layout, floorRules);
            graphGen.Execute();
        }

        /// <summary>
        /// Shorthand, used when waiting for end of body simulation
        /// </summary>
        /// <returns></returns>
        WaitWhile WaitForBodySimulationEnd()
        {
            return new WaitWhile(() => IsGenerationBodySimulationActive());
        }

        /// <summary>
        /// Checks if rooms are moving
        /// </summary>
        /// <returns></returns>
        bool IsGenerationBodySimulationActive()
        {
            //Is there any room that is still moving?
            return _dungeon.Layout._rooms.Any(r => r.Speed > 0f);
        }

        /// <summary>
        /// Completely remove the entire dungeon floor
        /// </summary>
        public void ResetDungeon()
        {
            Debug.Log("Resetting dungeon");

            _dungeon.Layout.DestroyRooms();
            _random.Reset(seed);
            DungeonRoom.ResetNextID();
        }

        /// <summary>
        /// Reset seeds and ID of rooms. Should go back to same, deterministic state as before
        /// </summary>
        public void ResetGenerator()
        {
            _random.Reset(seed);
            DungeonRoom.ResetNextID();
        }

        public float GetRandFloatTest()
        {
            return _random.Pick(0f, 10f);
        }
    }
}
