using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Raptor.UI;

namespace Raptor.Entity
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MovementBase
    {
        PlayerInputActions _inputActions;
        EventHandler<Vector2> _onMovementInput;

        #region Inputs_Ingame

        InputAction _planeMovement;

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            _inputActions = InputHandler.PlayerInputActions;
            InitPlayerInputActions();


            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected new void FixedUpdate()
        {
            //Read current player inputs every frame
            _curMovementInputValue = _planeMovement.ReadValue<Vector2>();
            HandleMovement();

            base.FixedUpdate();
        }

        /// <summary>
        /// Intializes local variables with input actions as shorthand
        /// </summary>
        void InitPlayerInputActions()
        {
            _planeMovement = _inputActions.Ingame.PlaneMovement;

            //_inputActions.Ingame.Jump.started += ctx => _ = Time.time;
            //_inputActions.Ingame.Jump.canceled += ctx => HandleMovement(ctx);
        }

        /// <summary>
        /// Move based on player input
        /// </summary>
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
}
