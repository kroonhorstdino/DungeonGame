using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Raptor.Events;
using Raptor.Combat;

namespace Raptor.Entity
{
    [RequireComponent(typeof(GameEventHandler))]
    public class EntityBase : MonoBehaviour, IHasGameEventHandler
    {
        [SerializeField] StatFloat _health;

        [SerializeField] GameEventHandler _eventHandler;
        [SerializeField] int _id;

        [SerializeField] List<IEntityComponent> _components;

        public StatFloat Health { get => _health; private set => _health = value; }
        public GameEventHandler EventHandler { get; private set; }

        private void Awake()
        {
            _eventHandler = GetComponent<GameEventHandler>();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        void AddListeners()
        {
            _eventHandler.OnDamage += CheckHealth;

            _eventHandler.OnDeath += OnDeath;
            AddListenersAddtitional();
        }

        void RemoveListeners()
        {

            RemoveListenersAdditional();
        }

        /// <summary>
        /// Adds more listeners from derived classes
        /// </summary>
        protected virtual void AddListenersAddtitional()
        {

        }

        /// <summary>
        /// Removes additional listeners from derived classes
        /// </summary>
        protected virtual void RemoveListenersAdditional()
        {

        }

        public void DealDamage(CombatHandler actor, float damage)
        {
            _health.Current -= damage;
            _eventHandler.Invoke(_eventHandler.OnDamage, new OnDamageArgs(actor, this, damage));
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        void CollectComponents()
        {
            _components = GetComponents<IEntityComponent>().ToList();
        }

        public bool TryGetEntityComponent<T>(out T component) where T : IEntityComponent
        {
            component = (T)_components.Find(c => c.GetType() == typeof(T));

            if (component == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets IEntityComponent attached to EntityBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T TryGetEntityComponent<T>() where T : IEntityComponent
        {
            T component;
            TryGetEntityComponent<T>(out component);
            return component;
        }

        public void CheckHealth(OnDamageArgs args)
        {
            if (Health.Current <= Health.Min)
            {
                OnDeathArgs newArgs = new OnDeathArgs(this, args);
                _eventHandler.OnDeath.Invoke(newArgs);
            }
        }

        protected IEnumerator Die()
        {
            yield return null;
        }

        #region Events

        protected void OnDeath(OnDeathArgs eventInfo)
        {
            StartCoroutine(Die());
        }

        #endregion
    }

    /// <summary>
    /// Component belonging to a gameObject with an EntityBase class
    /// </summary>
    public interface IEntityComponent
    {
        EntityBase Entity { get; }
    }

    public class EntityData : ScriptableObject
    {
        [SerializeField] string _identifier;
        [SerializeField] string _displayName;
    }
}