using UnityEngine;
using System.Collections.Generic;

using Raptor.Dungeon.Generation;

namespace Raptor.Dungeon
{
    [ExecuteInEditMode]
    public class DungeonRoom : MonoBehaviour
    {
        [SerializeField] int _id;
        static int currentID = -1;

        //For simulation
        [SerializeField] Collider2D _collider;
        [SerializeField] Rigidbody2D _rb;
        Vector3 _lastFixedFramePosition;
        [SerializeField] Vector3 _velocity;

        [Header("Neighbourhood")]
        [SerializeField] List<DungeonRoom> _neighbours;

        [Header("Rules")]
        [SerializeField] public RoomRules _rules;

        public int ID { set => _id = value; get => _id; }
        public Collider2D Collider { get => _collider; }
        public Rigidbody2D Rb { get => _rb; }
        public float Speed { get => Vector3.Magnitude(_velocity); }
        public List<DungeonRoom> Neighbours { get => _neighbours; }

        public void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();

            _lastFixedFramePosition = transform.position;
        }

        private void FixedUpdate()
        {
            SetVelocity();
        }

        /// <summary>
        /// Sets velocity based on former position
        /// </summary>
        public void SetVelocity()
        {
            _velocity = transform.position - _lastFixedFramePosition;
            _lastFixedFramePosition = transform.position;
        }

        public void SetNeighbourhood(List<DungeonRoom> neighbours)
        {
            _neighbours = neighbours;
        }

        public void SetName()
        {
            gameObject.name = "Room " + _id.ToString();
        }

        public static int GetNextID()
        {
            //I know I can just do ++currentID, but readable code is better!
            currentID++;
            return currentID;
        }

        public static void ResetNextID()
        {
            currentID = -1;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(transform.position, new Vector3(1, 1, 0));
            Gizmos.DrawWireCube(_collider.bounds.center, _collider.bounds.size);

            foreach (DungeonRoom room in _neighbours)
            {
                Gizmos.DrawLine(transform.position, room.transform.position);
            }
        }
    }
}