using System;

using UnityEngine;
using System.Collections.Generic;

using Raptor.Utility.Graph;

namespace Raptor.Dungeon
{

    /// <summary>
    /// All operations made on the dungeon rooms and their layout.
    /// Including rooms, dungeon graph, etc.
    /// </summary>
    [Serializable]
    public class DungeonLayout
    {
        [SerializeField] public List<DungeonRoom> _rooms;
        [SerializeField] private DungeonGraph graph;

        public DungeonGraph Graph { get => graph; set => graph = value; }

        public DungeonLayout()
        {
            _rooms = new List<DungeonRoom>();
        }

        public void AddRooms(List<DungeonRoom> rooms)
        {
            _rooms.AddRange(rooms);
        }

        public void DestroyRooms()
        {
            foreach (DungeonRoom room in _rooms)
            {
                MonoBehaviour.Destroy(room.gameObject);
            }

            _rooms.Clear();
        }

        /// <summary>
        /// Applies the given action to each dungeon room
        /// </summary>
        /// <param name="action"></param>
        public void ApplyToEachRoom(Action<DungeonRoom> action)
        {
            foreach (DungeonRoom room in _rooms)
            {
                action(room);
            }
        }

        public void OnDestroy()
        {
            _rooms.Clear();
        }
    }
}

namespace Raptor.Utility.Graph
{
    using Raptor.Dungeon;
    public abstract class Graph<V> where V : new()
    {
        //Edges
        [SerializeField] protected List<Edge<V>> _edges;
        //Vertices (Nodes)
        protected List<V> _vertices;

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

    [Serializable]
    public class DungeonGraph : Graph<DungeonRoom>
    {
        public DungeonGraph() : base()
        {
        }

        public DungeonGraph(List<DungeonRoom> vertices) : base(vertices)
        {
        }

        /// <summary>
        /// Generates full graph, which connects all rooms, regardless of proximity or completes incomple graph if one is present already
        /// </summary>
        public void GenerateFullGraph()
        {

        }

        //TODO: Display graph
        public void GenerateConnectedRoomGraph()
        {
            foreach (DungeonRoom room in _vertices)
            {
                //Add all room / neighbour pairs as edges into graph
                room.Neighbours.ForEach(other => AddEdge(new Edge<DungeonRoom>(room, other)));
            }
        }
    }

    public class Edge<V> where V : new()
    {
        public readonly bool _isDirected;
        public readonly (V, V) _edge;

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

    /// <summary>
    /// Edge in graph with DungeonNodes
    /// </summary>
    [Serializable]
    public class DungeonEdge : Edge<DungeonRoom>
    {
        public DungeonEdge((DungeonRoom, DungeonRoom) edge, bool isDirected = false) : base(edge, isDirected)
        {
        }

        public DungeonEdge(DungeonRoom a, DungeonRoom b, bool isDirected = false) : this((a, b), isDirected)
        {
        }

        #region Length methods

        /// <summary>
        /// Sets and returns distance between center point of rooms
        /// </summary>
        /// <returns></returns>
        public override float CalcLength()
        {
            //NOTE: Use intelligent or naive solution? TODO:
            return CalcLengthNaive();
        }

        public float CalcLengthNaive()
        {
            return Vector3.Distance(_edge.Item1.transform.position, _edge.Item2.transform.position);
        }

        /// <summary>
        /// Gets length of edge by calculating shortest walkable way between centers
        /// Walkable in this implementation refers to being inside a collider
        /// </summary>
        /// <returns></returns>
        public float CalcLengthIntelligent()
        {
            //TODO: Implement
            throw new NotImplementedException();
        }

        #endregion
    }
}
