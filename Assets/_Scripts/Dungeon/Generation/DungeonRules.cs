using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Utility;

using RotaryHeart.Lib.SerializableDictionary;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Rules applying for every floor of the dungeon
    /// </summary>
    [CreateAssetMenu(fileName = "DungeonRules", menuName = "Dungeon/DungeonRules", order = 0)]
    public class DungeonRules : ScriptableObject
    {
        /// <summary>
        /// Number of floors in dungeon
        /// </summary>
        public Range _numFloors;

        [SerializeField] DungeonFloorRules _defaultRules;
        [SerializeField] DungeonFloorRulesDict _overrideFloorRules;

        /// <summary>
        /// TODO: If override rules exist, return that instead of default rules
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public DungeonFloorRules GetDungeonFloorRules(int floor)
        {
            return _defaultRules;
        }

    }

    [System.Serializable]
    public class DungeonFloorRulesDict : SerializableDictionaryBase<int, DungeonFloorRules> { };

    /// <summary>
    /// Rules for a dungeon floor
    /// </summary>
    [CreateAssetMenu(fileName = "DungeonFloorRules", menuName = "Dungeon/DungeonFloorRules", order = 0)]
    public class DungeonFloorRules : ScriptableObject
    {

        /// <summary>
        /// Number of desired rooms per floor
        /// </summary>
        public Range _numRoomsPerFloor;

        /// <summary>
        /// Rules for rooms for all floors with weights for picking
        /// </summary>
        public WeightedRoomRulesDict _weightedRoomRules;

        /// <summary>
        ///  Bounds of each dungeon floor
        /// </summary>
        public BoundsInt _bounds;
    }

    [System.Serializable]
    public class WeightedRoomRulesDict : SerializableDictionaryBase<float, DungeonRoomRules>
    {

    };

    ///TODO: Override rules (Issue #21)
}
