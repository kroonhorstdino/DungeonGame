using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Dungeon;
using Raptor.Utility;

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

            //Wait until rooms stop moving
            yield return new WaitForSeconds(2f);
            yield return new WaitWhile(() => IsGenerationBodySimulationActive());

            //Snap every room to the grid and wait until simulation is complete
            _dungeon.Layout.ApplyToEachRoom((DungeonRoom r) => _dungeon.SnapToGrid(r));
            yield return new WaitWhile(() => IsGenerationBodySimulationActive());

            AdjustColliderSizeAgent adjuster = new AdjustColliderSizeAgent(_dungeon.Layout);
            adjuster.AdjustColliderSizes();

            Debug.Log("Generation of dungeon rooms is finished");
        }

        public IEnumerator GenerateFloor(int floor)
        {
            //TODO: Production logic
            yield return null;
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
