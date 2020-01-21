using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Utility.Math
{
    /// <summary>
    /// Extensions for Unity Bounds structs/classes
    /// </summary>
    static public class BoundsUtil
    {
        /// <summary>
        /// Returns a BoundsInt object
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        static public BoundsInt ToInt(this Bounds b)
        {
            return new BoundsInt((int)b.min.x, (int)b.min.y, 0, (int)b.size.x, (int)b.size.y, 1);
        }
    }

    /// <summary>
    /// Extensions for Unity Vector classes
    /// </summary>
    static public class VectorUtil
    {
        /// <summary>
        /// Returns a Vector3Int with rounded vectors. Syntactic sugar
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static public Vector3Int ToInt(this Vector3 v)
        {
            return Vector3Int.RoundToInt(v);
        }
    }
}