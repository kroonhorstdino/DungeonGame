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
        DungeonFloorRules _floorRules;
        DungeonGraph _graph;

        public void Init(DungeonLayout layout, DungeonFloorRules floorRules)
        {
            _floorRules = floorRules;
            _graph = new DungeonGraph(layout._rooms);
        }

        public void Execute()
        {
        }
    }
}
