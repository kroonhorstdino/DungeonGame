using UnityEngine;

namespace Raptor.Utility.Graph
{
    [System.Serializable]
    public class Edge<V> where V : new()
    {
        [SerializeField] public bool _isDirected;
        [SerializeField] public (V, V) _edge;

        float _length;
        public float Length { get => _length; }

        /// <summary>
        /// Construct edge with a pair of vertices
        /// Calculates and sets length
        /// </summary>
        public Edge((V, V) edge, bool isDirected = false)
        {
            this._isDirected = isDirected;
            this._edge = edge;

            SetLength();
        }

        public Edge(V a, V b, bool isDirected = false) : this((a, b), isDirected)
        {
        }

        #region Length methods

        /// <summary>
        /// Sets length of edge and returns new length
        /// </summary>
        /// <returns></returns>
        public float SetLength()
        {
            _length = CalcLength();
            return _length;
        }

        public virtual float CalcLength()
        {
            return 1f;
        }

        #endregion
    }
}
