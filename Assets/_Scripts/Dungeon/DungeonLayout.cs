using System;

using UnityEngine;
using System.Collections.Generic;

namespace Raptor.Dungeon
{

    /// <summary>
    /// All operations made on the dungeon rooms and their layout.
    /// Including rooms, dungeon graph, etc.
    /// </summary>
    [Serializable]
    public class DungeonLayout
    {
        [SerializeField] public List<DungeonRoom> _rooms;

        public DungeonLayout()
        {
            _rooms = new List<DungeonRoom>();
        }

        public void AddRooms(List<DungeonRoom> rooms)
        {
            _rooms.AddRange(rooms);
        }

        public void DestroyRooms()
        {
            foreach (DungeonRoom room in _rooms)
            {
                MonoBehaviour.Destroy(room.gameObject);
            }

            _rooms.Clear();
        }

        /// <summary>
        /// Applies the given action to each dungeon room
        /// </summary>
        /// <param name="action"></param>
        public void ApplyToEachRoom(Action<DungeonRoom> action)
        {
            foreach (DungeonRoom room in _rooms)
            {
                action(room);
            }
        }

        public void OnDestroy()
        {
            _rooms.Clear();
        }
    }
}
