using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raptor.Utility
{
    /// <summary>
    /// Wrapper class for UnityEngine.Random and System.Random with extra functionality
    /// </summary>
    public static class Randomizer
    {
        public static void Init(int seed)
        {
            UnityEngine.Random.InitState(seed);
        }

        public static void Init(string seed)
        {
            //TODO: Implement conversion from string to int for use as seed
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pick random point within bounds
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3Int PickPointInt(BoundsInt b)
        {
            int x = UnityEngine.Random.Range(b.min.x, b.max.x);
            int y = UnityEngine.Random.Range(b.min.y, b.max.y);

            Vector3Int randomPos = new Vector3Int(x, y, 0);

            return randomPos;
        }

        public static T PickWeightedOption<T>(IDictionary<float, T> optionWeightedPair)
        {
            return optionWeightedPair.Values.ElementAt(PickWeightedIndex(optionWeightedPair.Keys));
        }

        public static int PickWeightedIndex(ICollection<float> weights)
        {
            List<float> values = new List<float>();
            int lastIndex = 0;
            float lastValue = 0;

            int loopIndex = 0;

            foreach (var weight in weights)
            {
                float currentValue = weight * UnityEngine.Random.Range(0, 1);

                if (currentValue > lastValue)
                {
                    lastValue = currentValue;
                    lastIndex = loopIndex;
                }

                loopIndex++;
            }

            return lastIndex;
        }

        public static T Pick<T>(ICollection<T> options)
        {
            throw new NotImplementedException();
        }

        public static void Reset(int seed)
        {
            UnityEngine.Random.InitState(seed);
        }
    }
}
