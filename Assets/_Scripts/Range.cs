using UnityEngine;

namespace Raptor.Utility
{
    [System.Serializable]
    public class Range
    {
        [SerializeField] AnimationCurve _weightedDistribution;
        [SerializeField] public float min, max;

        /// <summary>
        /// Pick a value between min and max
        /// </summary>
        /// <returns></returns>
        public float PickFloat()
        {
            return Random.Range(min, max);
        }

        public int PickInt()
        {
            return Random.Range((int)min, (int)max);
        }

        public int PickRoundedInt()
        {
            return RoundDownToEvenInt(Random.Range((int)min, (int)max));
        }

        bool IsEvenInt(int number)
        {
            return number % 2 == 0;
        }

        int RoundDownToEvenInt(int number)
        {
            if (!IsEvenInt(number))
            {
                return number - 1;
            }

            return number;
        }
    }
}
