using System;

using UnityEngine;

using Raptor.Dungeon;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Any agent that leads to change of physical properties of the rooms
    /// </summary>
    public interface ISimulationAgent
    {
    }

    /// <summary>
    /// Adjust colliders of rooms
    /// </summary>
    public class AdjustColliderSizeAgent : ISimulationAgent
    {
        static float s_sizeReduction = -0.3f;
        DungeonLayout _layout;

        public AdjustColliderSizeAgent(DungeonLayout layout)
        {
            _layout = layout;
        }

        /// <summary>
        /// Adjusts colliders for all rooms, to prevent miniscule overspill of bounds into neighbouring tiles
        /// </summary>
        /// <param name="layout"></param>
        public void AdjustColliderSizes()
        {
            _layout.ApplyToEachRoom((DungeonRoom r) => AdjustColliderSize(r));
        }

        /// <summary>
        /// Adjusts size of one collider of one room
        /// Uses different functions based on type of collider
        /// </summary>
        /// <param name="r"></param>
        void AdjustColliderSize(DungeonRoom r)
        {
            if (r.Collider.GetType() == typeof(BoxCollider2D))
            {
                AdjustColliderSizeSimple(r);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        void AdjustColliderSizeSimple(DungeonRoom r)
        {
            Bounds b = r.Collider.bounds;

            b.Expand(s_sizeReduction);

            //Put size
            ((BoxCollider2D)(r.Collider)).size = b.size;
        }
    }

    /// <summary>
    /// Crawlers operating on bounds and colliders without placed tiles
    /// </summary>
    public interface ILayoutGeneratorAgent
    {
        //TODO: Dungeon or dungeonlayout?
        void Init(DungeonLayout layout, DungeonRules rules);
        void Execute();
    }

    /// <summary>
    /// Generates graphs based on rooms
    /// </summary>
    public class GraphGeneratorCrawlerAgent : ILayoutGeneratorAgent
    {
        public void Execute()
        {

        }

        public void Init(Dungeon dungeon, DungeonRules data)
        {
        }

        public void Init(DungeonLayout layout, DungeonRules rules)
        {
            throw new System.NotImplementedException();
        }
    }

    //TODO: Do stuff based on generated tree in dungeonLayout class
    public class ExitRoomPickerCrawlerAgent : ILayoutGeneratorAgent
    {
        public void Init(DungeonLayout layout, DungeonRules rules)
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
    public interface ITilemapCrawlerAgent : ISimulationAgent
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
