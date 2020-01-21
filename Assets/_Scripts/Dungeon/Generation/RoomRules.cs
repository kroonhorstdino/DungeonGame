using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Utility;
using Raptor;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Template rules used for generating room
    /// </summary>
    [CreateAssetMenu(fileName = "DungeonRoomRules", menuName = "Dungeon/RoomRules", order = 0)]
    public class RoomRules : ScriptableObject, IDefaultGameObjectOverride
    {
        public RuleTile _groundTile;
        public RuleTile _wallTile;

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
                if (_overrideRoomObject == null)
                {
                    return _defaultRoomObject;
                }

                return _overrideRoomObject;
            }
        }


        /// <summary>
        /// Size on x-axis including walls 
        /// </summary>
        [Tooltip("Size on x-axis including walls")]
        public Range _xSize;

        /// <summary>
        /// Size on y-axis including walls 
        /// </summary>
        [Tooltip("Size on y-axis including walls")]
        public Range _ySize;

        /// <summary>
        /// Surface area of each room
        /// </summary>
        public Range _roomSurfaceArea;

        //REVIEW: Not used yet
        public RoomShape _shape;
    }

    /// <summary>
    /// Shape of the room
    /// </summary>
    [System.Flags]
    public enum RoomShape
    {
        Rectangular,
        RectangularAdditive,
        Irregular
    }
}