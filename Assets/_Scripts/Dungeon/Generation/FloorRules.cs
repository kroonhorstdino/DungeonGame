using UnityEngine;

using Raptor.Utility;
using RotaryHeart.Lib.SerializableDictionary;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Rules for a dungeon floor
    /// </summary>
    [CreateAssetMenu(fileName = "DungeonFloorRules", menuName = "Dungeon/DungeonFloorRules", order = 0)]
    public class FloorRules : ScriptableObject, IDefaultGameObjectOverride
    {
        [SerializeField] GameObject _defaultRoomObject;
        [Tooltip("Overrides default room object if not null")]
        [SerializeField] GameObject _overrideRoomObject;

        public GameObject DefaultGameObject
        {
            get { return _defaultRoomObject; }
            set
            {
                _defaultRoomObject = value;
            }
        }

        public GameObject CorrectGameObject
        {
            get
            {
                return _overrideRoomObject ?? _defaultRoomObject;
            }
        }

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
    public class WeightedRoomRulesDict : SerializableDictionaryBase<float, RoomRules>
    {

    };

    ///TODO: Override rules (Issue #21)
}
