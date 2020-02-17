using UnityEngine;

using Raptor.Utility;
using RotaryHeart.Lib.SerializableDictionary;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Rules for a dungeon floor
    /// </summary>
    [CreateAssetMenu(fileName = "DungeonFloorRules", menuName = "Dungeon/DungeonFloorRules", order = 0)]
    public class FloorRules : ScriptableObject
    {
        [SerializeField] GameObjectOverride roomObject;

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

        public GameObjectOverride RoomObject { get => roomObject; }
    }

    [System.Serializable]
    public class WeightedRoomRulesDict : SerializableDictionaryBase<float, RoomRules>
    {

    };

    ///TODO: Override rules (Issue #21)
}
