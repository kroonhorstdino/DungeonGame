using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Dungeon.Generation
{
    public class TilePlacerCrawlerAgentBase : ILayoutGeneratorAgent
    {
        List<DungeonRoom> _rooms;


        public void Init(DungeonLayout layout, DungeonFloorRules rules)
        {
            _rooms = layout._rooms;
        }

        public void Execute()
        {
        }

        protected virtual void PlaceTiles(DungeonRoom room)
        {
            //room.Collider.bounds.
        }
    }
}
