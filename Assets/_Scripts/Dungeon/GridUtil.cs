using System;
using UnityEngine;

using Raptor.Dungeon;

namespace Raptor.Utility.Grid
{
    public static class GridUtility
    {
        /// <summary>
        /// Snaps room center to closest grid point
        /// </summary>
        /// <param name="room"></param>
        public static void SnapToGrid(DungeonRoom room)
        {
            room.transform.position = Vector3Int.RoundToInt(room.transform.position);
        }

        /// <summary>
        /// Get direction vector of cardinal direction as normalized vector
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector2 GetNormalizedDirectionVector(GridDirection direction)
        {
            /*
            * Rotate vector around in 45 degree steps. There are 8 possible directions (0 to 7) => 360 / 8 == 45
            * 2 * 45° == 90° (2 is East direction)
            * 
            * 0 degrees is North direction
            */

            //Correct angle is counter-clockwise, while directions are ordered clockwise
            float correctAngle = 45 * (int)direction * -1;

            //Angle for direction
            Quaternion angle = Quaternion.AngleAxis(correctAngle, Vector3.forward);
            Vector2 angledVector = Vector2Int.RoundToInt(angle * Vector2.up);

            //Return angeld normalized vector
            return angledVector.normalized;
        }

        public static GridDirection GetOppositeDirection(GridDirection direction)
        {
            return direction + 4 % 7;
        }
    }

    /// <summary>
    /// 8 possible directions in game.
    /// 4 cardinal directions + 4 in between directions.
    /// Directions from 0 to 7 sorted clockwise.
    /// To get the opposite direction, add 4 (Implemented in GridUtility.GetOppositeDirection)
    /// </summary>
    public enum GridDirection
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
}
