using System;
using System.Collections.Generic;
using UnityEngine;
namespace Raptor.Events
{
    /// <summary>
    /// Handles event for and entity or object with components attached to it
    /// USE INVOKE, don't call directly
    /// </summary>
    public class GameEventHandler : MonoBehaviour
    {
        #region Events
        Action<OnDamageArgs> _onDamage;
        Action<OnDeathArgs> _onDeath;

        Action<OnSpawnArgs> _onEntitySpawned;

        Action<OnSpellHitArgs> _onSpellHit;
        Action<OnSpellHitArgs> _onSpellApplied;
        Action<OnSpellRemovedArgs> _onSpellRemoved;
        Action<EventArgs> _onLevelStarted; //TODO:
        Action<EventArgs> _onLevelEnded; //TODO:
        Action<EventArgs> _onGameplayStarted; //TODO:
        Action<EventArgs> _onGameplayEnded; //TODO:

        /// <summary>
        ///When entity is actually damaged
        /// </summary>
        /// <value></value>
        public Action<OnDamageArgs> OnDamage { get => _onDamage; set => _onDamage = value; }
        /// <summary>
        /// An entity has died
        /// </summary>
        /// <value></value>
        public Action<OnDeathArgs> OnDeath { get => _onDeath; set => _onDeath = value; }
        public Action<OnSpellHitArgs> OnSpellHit { get => _onSpellHit; set => _onSpellHit = value; }
        public Action<OnSpellRemovedArgs> OnSpellRemoved { get => _onSpellRemoved; set => _onSpellRemoved = value; }
        public Action<EventArgs> OnGameplayStarted { get => _onGameplayStarted; set => _onGameplayStarted = value; }
        public Action<EventArgs> OnGameplayEnded { get => _onGameplayEnded; set => _onGameplayEnded = value; }

        #endregion

        public void Invoke<T>(Action<T> action, T args)
        {
            action?.Invoke(args);
        }

    }

    public interface IEventObserver : IHasGameEventHandler
    {
        void AddListeners();
        void RemoveListeners();
    }
}
