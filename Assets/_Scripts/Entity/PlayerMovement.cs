using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    [Tooltip("Velocity measured in Tiles/sec")]
    [SerializeField] float _velocityDefault;
    [SerializeField] Vector2 _curMovementInputValue;
    [SerializeField] float _velocityMax;

    [Header("Debug")]
    [SerializeField] Vector2 d_debugVelocity;
    [SerializeField] bool _isWalking;

    PlayerInputActions _inputActions;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb;

    public bool IsWalking { get => _isWalking; }

    private void Awake()
    {
        _inputActions = new PlayerInputActions();

    }

    private void OnEnable()
    {
        _inputActions.Ingame.Enable();
        //_inputActions.Ingame.Jump.started += ctx => _ = Time.time;
        //_inputActions.Ingame.Jump.canceled += ctx => HandleMovement(ctx);
    }

    private void OnDisable()
    {
        _inputActions.Ingame.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Read current player inputs every frame
        _curMovementInputValue = _inputActions.Ingame.Movement.ReadValue<Vector2>();

        //SetIsWalking();

        HandleMovement();

        d_debugVelocity = _rb.velocity;

        //ANIMATION
        //SetAnimationTriggers();

        Flip();

    }

    /// <summary>
    /// Flips player when neccesary
    /// </summary>
    void Flip()
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

    /// <summary>
    /// 
    /// </summary>
    void SetAnimationTriggers()
    {
        //If a state has begun and animation state machine is not in state, set the appropiate trigger

        //IS WALKING
        _animator.SetBool("isWalking", _isWalking);
        if (_isWalking && !_animator.GetCurrentAnimatorStateInfo(0).IsTag("Walking"))
        {
            _animator.SetTrigger("startWalking");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public void SetIsWalking()
    {
        _isWalking = _rb.velocity.x != 0 || _rb.velocity.y != 0;
    }

    void HandleMovement()
    {
        Vector2 actualMovement = _curMovementInputValue;
        actualMovement.Normalize();
        _rb.MovePosition((Vector2)transform.position + (actualMovement * _velocityDefault * Time.fixedDeltaTime));
    }

    private void OnDrawGizmosSelected()
    {
        // GROUND DETECTION
        Gizmos.color = Color.red;
    }
}
