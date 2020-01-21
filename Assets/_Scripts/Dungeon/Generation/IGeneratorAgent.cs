
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
    public interface ILayoutGeneratorAgent : IGeneratorAgent
    {
    }

    /// <summary>
    /// Crawlers operating on bounds and colliders without placed tiles
    /// </summary>
    public interface ILayoutCrawlerAgent : IGeneratorAgent
    {
    }

    //TODO: Do stuff based on generated tree in dungeonLayout class
    public class StartExitRoomPicker : ILayoutGeneratorAgent
    {
    }

    /// <summary>
    /// Crawls through tilemap dungeon and executes some generation method...
    /// Placing, modifying, enhancing dungeon tiles etc...
    /// </summary>
    public interface ITilemapCrawlerAgent : IGeneratorAgent
    {
    }

    public class FloorExitPlacerAgent : ILayoutGeneratorAgent
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
