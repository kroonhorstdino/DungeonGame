using System.Collections.Generic;

using Raptor.Utility.Graph;
using Raptor.Dungeon;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Generates neccesary graphs from dungeon floor rooms
    /// </summary>
    public class GraphGenAgent : ILayoutGeneratorAgent
    {
        FloorRules _floorRules;
        DungeonGraph _graph;
        DungeonLayout _layout;

        public GraphGenAgent(DungeonLayout layout, FloorRules floorRules)
        {
            _floorRules = floorRules;
            _graph = new DungeonGraph(layout._rooms);
            _layout = layout;
        }

        public void Execute()
        {
            _graph.GenerateConnectedRoomGraph();
            _layout.Graph = _graph;
        }
    }
}
