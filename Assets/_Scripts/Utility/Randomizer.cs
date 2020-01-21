using UnityEngine;
using System;
using Random = System.Random;
using System.Collections.Generic;
using System.Linq;

namespace Raptor.Utility
{
    /// <summary>
    /// Custom randomizer class implementation with convenience functions for Raptor framework 
    /// Utilizes Unity.Random
    /// </summary>
    public class Randomizer
    {
        Random _crystal;

        public Randomizer(int seed)
        {
            Reset(seed);
        }

        public Randomizer(string seed)
        {
            Reset(seed);
        }

        /// <summary>
        /// Initialize with numeric seed
        /// </summary>
        /// <param name="seed"></param>
        public void Reset(int seed)
        {
            _crystal = new Random(seed);
        }

        /// <summary>
        /// Initialize with string seed
        /// </summary>
        /// <param name="seed"></param>
        public void Reset(string seed)
        {
            //TODO: Implement conversion from string to int for use as seed (more sophisticated than conversion to HashCode())
            Reset(seed.GetHashCode());
        }

        /// <summary>
        /// Pick random point within bounds
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public Vector3Int PickPointInBounds(BoundsInt b)
        {
            int x = Pick(b.min.x, b.max.x);
            int y = Pick(b.min.y, b.max.y);

            Vector3Int randomPos = new Vector3Int(x, y, 0);

            return randomPos;
        }

        /// <summary>
        /// Gives random number between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public float Pick(float min, float max)
        {
            return (float)_crystal.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Gives random number between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int Pick(int min, int max)
        {
            return _crystal.Next(min, max);
        }

        /// <summary>
        /// Picks a float value of from a Raptor.Range
        /// For int values use PickIntFromRange()
        /// </summary>
        /// <returns></returns>
        public float Pick(Range range)
        {
            return Pick(range.min, range.max);
        }

        public int PickIntFromRange(Range range)
        {
            return Pick((int)range.min, (int)range.max);
        }

        //NOTE: Look at https://github.com/tucano/UnityRandom for more advanced implementations
        /// <summary>
        /// From a dictionary with (weight, option) pairs, pick an option based on weights.
        /// </summary>
        /// <param name="optionWeightedPair"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T PickOptionWeighted<T>(IDictionary<float, T> optionWeightedPair)
        {
            return optionWeightedPair.Values.ElementAt(PickWeightedIndex(optionWeightedPair.Keys));
        }

        /// <summary>
        /// Same as PickOptionWeighted, but only picks index
        /// </summary>
        /// <param name="weights"></param>
        /// <returns></returns>
        public int PickWeightedIndex(ICollection<float> weights)
        {
            List<float> values = new List<float>();
            int lastIndex = 0;
            float lastValue = 0;

            int loopIndex = 0;

            foreach (var weight in weights)
            {
                float currentValue = weight * Pick(0, 1);

                if (currentValue > lastValue)
                {
                    lastValue = currentValue;
                    lastIndex = loopIndex;
                }

                loopIndex++;
            }

            return lastIndex;
        }

        /// <summary>
        /// Pick random option from Collection
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T PickOption<T>(ICollection<T> options)
        {
            throw new NotImplementedException();
        }
    }
}

namespace Raptor.Utility.Math
{
    static public class MathUtil
    {
        static public int FloorToIntEven(int number)
        {
            if (!IsEven(number))
            {
                return number - 1;
            }

            return number;
        }

        static public int CeilToIntEven(int number)
        {
            if (!IsEven(number))
            {
                return (int)number + 1;
            }

            return number;
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static bool IsEven(float number)
        {
            return number % 2 == 0;
        }
    }
}
