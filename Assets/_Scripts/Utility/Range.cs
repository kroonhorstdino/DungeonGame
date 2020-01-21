using UnityEngine;

namespace Raptor.Utility
{
    [System.Serializable]
    public class Range
    {
        [SerializeField] AnimationCurve _weightedDistribution;
        [SerializeField] public float min, max;
    }
}
