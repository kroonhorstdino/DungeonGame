using System;

using UnityEngine;

namespace Raptor.Utility.Graph
{
    using Raptor.Dungeon;

    /// <summary>
    /// Edge in graph with DungeonNodes
    /// </summary>
    [Serializable]
    public class DungeonEdge : Edge<DungeonRoom>
    {
        public DungeonEdge((DungeonRoom, DungeonRoom) edge, bool isDirected = false) : base(edge, isDirected)
        {
        }

        public DungeonEdge(DungeonRoom a, DungeonRoom b, bool isDirected = false) : this((a, b), isDirected)
        {
        }

        #region Length methods

        /// <summary>
        /// Sets and returns distance between center point of rooms
        /// </summary>
        /// <returns></returns>
        public override float CalcLength()
        {
            //NOTE: Use intelligent or naive solution? TODO:
            return CalcLengthNaive();
        }

        public float CalcLengthNaive()
        {
            return Vector3.Distance(_edge.Item1.transform.position, _edge.Item2.transform.position);
        }

        /// <summary>
        /// Gets length of edge by calculating shortest walkable way between centers
        /// Walkable in this implementation refers to being inside a collider
        /// </summary>
        /// <returns></returns>
        public float CalcLengthIntelligent()
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        #endregion
    }
}
