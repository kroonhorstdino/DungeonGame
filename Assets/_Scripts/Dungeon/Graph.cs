
using UnityEngine;
using System.Collections.Generic;

namespace Raptor.Utility.Graph
{
    [System.Serializable]
    public abstract class Graph<V> where V : new()
    {
        //Edges
        [SerializeField] protected List<Edge<V>> _edges;
        //Vertices (Nodes)
        [SerializeField] protected List<V> _vertices;

        public Graph()
        {
            _edges = _edges ?? new List<Edge<V>>();
            _vertices = _vertices ?? new List<V>();
        }

        public Graph(List<V> vertices) : this()
        {
            _vertices = vertices;
        }

        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public bool AddEdge(Edge<V> edge)
        {
            //If edge is not present add it, if succesful return true
            if (!HasEdge(edge))
            {
                return true;
            }
            //Otherwise do nothing and return false
            else
            {
                return false;
            }
        }

        #region IsEdge overrides

        public bool HasEdge(V a, V b, bool isDirected = false)
        {
            return HasEdge((a, b), isDirected);
        }

        public bool HasEdge((V, V) vertPair, bool isDirected = false)
        {
            return HasEdge(new Edge<V>(vertPair, isDirected));
        }

        public bool HasEdge(Edge<V> edge, bool isDirected = false)
        {
            //Construct the edge and 
            return _edges.Contains(edge);
        }

        #endregion
    }
}
