using System;
using UnityEngine;
using UnityEngine.Tilemaps;

using Raptor.Dungeon;

namespace Raptor.Utility
{
    public static class GridUtility
    {
        /// <summary>
        /// Snaps room position to left bottom corner of cell
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="room"></param>
        public static void SnapToCell(Grid grid, DungeonRoom room)
        {
            room.transform.position = SnapToCell(grid, room.transform.position);
        }

        /// <summary>
        /// Returns position to left bottom corner of cell
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="room"></param>
        public static Vector3 SnapToCell(Grid grid, Vector3 position)
        {
            Vector3Int cellPosition = grid.WorldToCell(position);
            return grid.CellToWorld(cellPosition);
        }

        /// <summary>
        /// Snaps room position to center position of its cell (logical center)
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="room"></param>
        public static void SnapToCellCenter(Grid grid, DungeonRoom room)
        {
            room.transform.position = SnapToCellCenter(grid, room.transform.position);
        }

        /// <summary>
        /// Returns Vector3 snapped to the proper cell center position (logical center)
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Vector3 SnapToCellCenter(Grid grid, Vector3 position)
        {
            Vector3Int cellPosition = grid.WorldToCell(position);
            return grid.GetCellCenterWorld(cellPosition);
        }

        /// <summary>
        /// Get Vector2 of one of 8 possible directions as normalized vector
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Vector2</returns>
        public static Vector2 GetNormalizedDirectionVector(GridDirection direction)
        {
            /*
            * Rotate vector around in 45 degree steps. There are 8 possible directions (0 to 7) => 360 / 8 == 45
            * 2 * 45° == 90° (2 is East direction)
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
    /// NOTE: DO NOT CHANGE ORDER!
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
