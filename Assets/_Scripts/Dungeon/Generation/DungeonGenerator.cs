using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Dungeon;
using Raptor.Utility;
using Raptor.Utility.Grid;

namespace Raptor.Dungeon.Generation
{

    /// <summary>
    /// Handles generation of the entire dungeon
    /// </summary>
    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] Dungeon _dungeon;
        [Header("Testing")]
        [SerializeField] DungeonRules _testRules;

        [SerializeField] int seed;

        private void Awake()
        {
            Randomizer.Init(seed);

            //TODO: Work on layout generation
            //Parent gameobject for all room gameobjects
            //_dungeon.DungeonRoomHolder = Instantiate(new GameObject("DungeonRoomHolder"), Vector3Int.zero, Quaternion.identity);
            //_director = new JollyJennyDirector(_testRules);
        }

        private void Update()
        {
            if (_dungeon.Layout._rooms.Count > 0) Debug.Log("Are rooms moving: " + IsGenerationBodySimulationActive());
        }

        public void TestGenerate()
        {
            Debug.Log("Generate test dungeon floor");
            StartGenerateFloor(0);
        }

        public void StartGenerateFloor(int floor)
        {
            StartCoroutine(GenerateFloorTest(floor));
        }

        public IEnumerator GenerateFloorTest(int floor)
        {
            //Create room placer for this floor and generate rooms with correctly shaped colliders
            InitialRoomPlacerAgent testRoomPlacer = new InitialRoomPlacerAgent(_testRules.GetDungeonFloorRules(floor));
            _dungeon.Layout.AddRooms(testRoomPlacer.GenerateRooms());

            //Rooms have rigidbodies and are being simulated
            Debug.Log("Simulating rooms...");
            yield return new WaitForFixedUpdate();
            yield return WaitForBodySimulationEnd();

            //Convert to trigger, end simulation of bodies
            _dungeon.Layout.ApplyToEachRoom((DungeonRoom r) => r.Collider.isTrigger = true);
            //Then snap all rooms to the grid (overlap should be impossible)
            _dungeon.Layout.ApplyToEachRoom((DungeonRoom r) => GridUtility.SnapToGrid(r));

            //NOTE: Possibly check if rooms overlap?


            //Search and set neighbours of the rooms
            NeighbourSearchAgent adjuster = new NeighbourSearchAgent(_dungeon.Layout);
            adjuster.SetNeighboursAllRooms();

            Debug.Log("Physical simulation of dungeon room rigidbodies complete...");

            /**
             * GENERATE GRAPH OF DUNGEON ROOMS
             * */

            // TODO: Generate neighbourhood graph

            // TODO: 
        }

        public IEnumerator GenerateFloor(int floor)
        {
            //TODO: Production logic
            yield return null;
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
        }

        /// <summary>
        /// Reset seeds and ID of rooms. Should go back to same, deterministic state as before
        /// </summary>
        public void ResetGenerator()
        {
            Randomizer.Reset(seed);
            DungeonRoom.ResetNextID();
        }
    }
}
