using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

using RocketRaptor.Dungeon;

namespace RocketRaptor.Dungeon.Generation
{

    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] Grid worldGrid;
        [SerializeField] Tilemap groundTilemap;
        [SerializeField] Tilemap obstacleTilemap;

        public void TestGenerate()
        {
            Debug.Log("Generate test dungeon");
        }

        public void GenerateBlueprint()
        {

        }

        public void ResetDungeon()
        {
            Debug.Log("Resetting dungeon");
        }
    }

    /// <summary>
    /// Crawls through Dungeon and executes some action on the map layout
    /// Placing, modifying, enhancing dungeon tiles etc...
    /// </summary>
    public abstract class CrawlerAgent
    {
        abstract public void Execute(DungeonFloor floor);

        /// <summary>
        /// Find origin point for Agent
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        abstract public Vector3Int FindOriginPoint(Grid grid);
    }

    public class FloorExitPlacerAgent : CrawlerAgent
    {
        public override void Execute(DungeonFloor floor)
        {
            throw new NotImplementedException();
        }

        public override Vector3Int FindOriginPoint(Grid grid)
        {
            throw new NotImplementedException();
        }
    }

    public class DoorPlacerAgent : CrawlerAgent
    {
        public override void Execute(DungeonFloor floor)
        {
            throw new NotImplementedException();
        }

        public override Vector3Int FindOriginPoint(Grid grid)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemPlacer : CrawlerAgent
    {
        public override void Execute(DungeonFloor floor)
        {
            throw new NotImplementedException();
        }

        public override Vector3Int FindOriginPoint(Grid grid)
        {
            throw new NotImplementedException();
        }
    }
}
