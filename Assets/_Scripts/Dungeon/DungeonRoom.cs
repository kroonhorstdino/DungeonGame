using UnityEngine;
using System.Collections.Generic;

namespace Raptor.Dungeon
{
    [ExecuteInEditMode]
    public class DungeonRoom : MonoBehaviour
    {
        [SerializeField] int id;
        static int currentID = -1;

        [SerializeField] Collider2D _collider;
        [SerializeField] Rigidbody2D _rb;

        /// <summary>
        /// NOTE: Normal rigidbody velocity doesn't work for some reason
        /// </summary>
        Vector3 _lastFixedFramePosition;
        [SerializeField] Vector3 _velocity;

        public int ID { set => id = value; get => id; }
        public Collider2D Collider { get => _collider; }
        public Rigidbody2D Rb { get => _rb; }
        public float Speed { get => Vector3.Magnitude(_velocity); }

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
        }
    }

}