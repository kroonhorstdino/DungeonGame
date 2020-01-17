
using UnityEngine;

using Raptor.Dungeon;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// All classes included in the generation process (Not really relevant right now :shrug:)
    /// </summary>
    public interface IGeneratorAgent
    {

    }

    /// <summary>
    /// Any agent that manipulates some physical properties of the room gameobject or collider
    /// </summary>
    public interface IIntializerAgent : IGeneratorAgent
    {
    }

    /// <summary>
    /// Crawlers operating on bounds and colliders without placed tiles
    /// </summary>
    public interface ILayoutGeneratorAgent : IGeneratorAgent
    {
        //TODO: Dungeon or dungeonlayout?
        void Init(DungeonLayout layout, DungeonFloorRules floorRules);
        void Execute();
    }

    //TODO: Do stuff based on generated tree in dungeonLayout class
    public class StartExitRoomPicker : ILayoutGeneratorAgent
    {
        public void Init(DungeonLayout layout, DungeonFloorRules rules)
        {

        }
        public void Execute()
        {
        }
    }

    /// <summary>
    /// Crawls through tilemap dungeon and executes some generation method...
    /// Placing, modifying, enhancing dungeon tiles etc...
    /// </summary>
    public interface ITilemapCrawlerAgent : IIntializerAgent
    {
        void Execute(Dungeon dungeon);

        /// <summary>
        /// Starting point for the agent
        /// May be at different points in the grid, even on empty tiles
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        Vector3Int FindOriginPoint(Grid grid);
    }

    public class FloorExitPlacerAgent : ITilemapCrawlerAgent
    {
        public void Execute(Dungeon dungeon)
        {

        }

        public Vector3Int FindOriginPoint(Grid grid)
        {
            return Vector3Int.zero;


        }
    }

    public class DoorPlacerAgent : ITilemapCrawlerAgent
    {
        public void Execute(Dungeon dungeon)
        {
        }

        public Vector3Int FindOriginPoint(Grid grid)
        {
            return Vector3Int.zero;

        }
    }

    public class ItemPlacer : ITilemapCrawlerAgent
    {
        public void Execute(Dungeon dungeon)
        {
        }

        public Vector3Int FindOriginPoint(Grid grid)
        {
            return Vector3Int.zero;
        }
    }
}
