using UnityEngine;


namespace Raptor.Entity
{
    [RequireComponent(typeof(EntityBase), typeof(Rigidbody2D))]
    public class MovementBase : MonoBehaviour, IEntityComponent
    {
        [Header("Movement")]
        [Tooltip("Velocity measured in Tiles/sec")]
        [SerializeField] protected float _velocityDefault;
        [SerializeField] protected float _velocityMax;

        [Header("Debug")]
        [SerializeField] protected Vector2 _curMovementInputValue;
        [SerializeField] protected Vector2 d_debugVelocity;
        [SerializeField] protected bool _isWalking;

        //PlayerInputActions _inputActions;
        protected Animator _animator;
        protected SpriteRenderer _spriteRenderer;
        protected Rigidbody2D _rb;

        public bool IsWalking { get => _isWalking; }

        public EntityBase Entity { get; private set; }

        private void Awake()
        {
        }

        private void Start()
        {
            Entity = GetComponent<EntityBase>();
            _rb = GetComponent<Rigidbody2D>();
        }


        protected void FixedUpdate()
        {
            d_debugVelocity = _rb.velocity;
            Flip();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual void SetIsMoving()
        {
            _isWalking = _rb.velocity.x != 0 || _rb.velocity.y != 0;
        }

        /// <summary>
        /// Flips player when neccesary
        /// </summary>
        protected void Flip()
        {
            if (_rb.velocity.x == 0f) return; //Don't flip at zero velocity

            if (Mathf.Sign(_rb.velocity.x) == -1) //Movement towards right, don't flip
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
}
