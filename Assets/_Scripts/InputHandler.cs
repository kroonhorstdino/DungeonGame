using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Raptor.Events;


namespace Raptor.UI
{
    /// <summary>
    /// Handles everything about player input and proper binding of buttons to actions
    /// Should keep track of the mode the game is in right now (e.g Inventory, Menu, Gameplay, etc.)
    /// </summary>
    [RequireComponent(typeof(GameEventHandler), typeof(Raptor.Utility.DontDestroy))]
    public class InputHandler : MonoBehaviour, IEventObserver
    {
        static PlayerInputActions _playerInputActions;
        public static PlayerInputActions PlayerInputActions
        {
            get => _playerInputActions;
        }

        static public InputHandler Instance
        {
            get;
            private set;
        }

        public GameEventHandler EventHandler
        {
            get;
            private set;
        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            EventHandler = GetComponent<GameEventHandler>();
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void FixedUpdate()
        {

        }

        public void AddListeners()
        {
            EventHandler.OnGameplayStarted += OnGameplayStarted;
        }

        public void RemoveListeners()
        {
            EventHandler.OnGameplayEnded -= OnGameplayEnded;
        }

        void OnGameplayStarted(EventArgs args)
        {
            _playerInputActions.Ingame.Enable();
        }

        void OnGameplayEnded(EventArgs args)
        {
            _playerInputActions.Ingame.Disable();
        }
    }
}