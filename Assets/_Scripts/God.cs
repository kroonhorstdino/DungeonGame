using System;
using UnityEngine;

using Raptor.Events;

namespace Raptor.Utility
{
    /// <summary>
    /// It who brings all the things into motion
    /// Handles changes between major states in the game (e.g Menu, Levels)
    /// </summary>
    /// 
    [RequireComponent(typeof(GameEventHandler))]
    public class God : MonoBehaviour
    {
        static public God Instance
        {
            get;
            private set;
        }

        public GameEventHandler EventHandler
        {
            get;
            private set;
        }

        private void Awake()
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
        }

        private void Start()
        {
            //FIXME: TODO: Trigger to enable controls
            EventHandler.Invoke(EventHandler.OnGameplayStarted, EventArgs.Empty);
        }
    }
}