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
    public class DungeonRules : ScriptableObject, IDefaultGameObjectOverride
    {
        /// <summary>
        /// Number of floors in dungeon
        /// </summary>
        public Range _numFloors;

        [SerializeField] private GameObject _defaultRoomObject;
        [Tooltip("Overrides default room object if not null")]
        [SerializeField] private GameObject _overrideRoomObject;

        [SerializeField] FloorRules _defaultRules;
        [SerializeField] DungeonFloorRulesDict _overrideFloorRules;

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
        /// TODO: If override rules exist, return that instead of default rules
        /// NOTE: Returns a new instance every time it is called!
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public FloorRules GenerateFloorRules(int floor)
        {
            FloorRules floorRules = Instantiate(_defaultRules);
            return floorRules;
        }

    }

    [System.Serializable]
    public class DungeonFloorRulesDict : SerializableDictionaryBase<int, FloorRules> { };

    /// <summary>
    /// This class has a default GameObject, however it can be overriden by a custom value.
    /// Supposed to be used for DungeonRules, FloorRules, RoomRules
    /// </summary>
    public interface IDefaultGameObjectOverride
    {
        GameObject DefaultGameObject { get; set; }
        GameObject CorrectGameObject { get; }
    }


}
