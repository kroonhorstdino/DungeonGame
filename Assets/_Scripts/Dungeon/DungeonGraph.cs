using System;
using System.Collections.Generic;

namespace Raptor.Utility.Graph
{
    using Raptor.Dungeon;

    [Serializable]
    public class DungeonGraph : Graph<DungeonRoom>
    {
        public DungeonGraph() : base()
        {
        }

        public DungeonGraph(List<DungeonRoom> vertices) : base(vertices)
        {
        }

        /// <summary>
        /// Generates full graph, which connects all rooms, regardless of proximity or completes incomple graph if one is present already
        /// </summary>
        public void GenerateFullGraph()
        {

        }

        //TODO: Display graph
        public void GenerateConnectedRoomGraph()
        {
            foreach (DungeonRoom room in _vertices)
            {
                //Add all room / neighbour pairs as edges into graph
                room.Neighbours.ForEach(other => AddEdge(new Edge<DungeonRoom>(room, other)));
            }
        }
    }
}
