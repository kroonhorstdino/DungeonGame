using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Utility;

namespace Raptor.Dungeon.Generation
{
    /// <summary>
    /// Template rules used for generating room
    /// </summary>
    [CreateAssetMenu(fileName = "RoomTileset", menuName = "Dungeon/RoomTileset", order = 0)]
    public class DungeonRoomRules : ScriptableObject
    {
        public RuleTile _groundTile;
        public RuleTile _wallTile;

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