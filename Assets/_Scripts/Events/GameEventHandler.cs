using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketRaptor.Events
{

    public class GameEventHandler : MonoBehaviour
    {
        Dictionary<GameEvents, List<Action<IGameEvent>>> listeners;


        [SerializeField] int _numEvt;

        private void Awake()
        {
            listeners = new Dictionary<GameEvents, List<Action<IGameEvent>>>();
        }

        private void Update()
        {
            _numEvt = listeners.Count;
        }

        /// <summary>
        /// Add action to listeners 
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="eventName"></param>
        public void AddListener(Action<IGameEvent> listener, GameEvents eventName)
        {
            //When this kind of game event has not yet been subscribed, generate a new list.
            if (!listeners.ContainsKey(eventName))
            {
                listeners.Add(eventName, new List<Action<IGameEvent>>());
            }

            try
            {
                //Add listener to list of listeners for this event
                listeners[eventName].Add(listener);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Remove action from listeners
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(Action<IGameEvent> listener)
        {
            //Go through each list and delete listener if found
            foreach (GameEvents eventName in listeners.Keys)
            {
                //If desired action is found, remove and break
                if (listeners[eventName].Remove(listener))
                {
                    if (listeners[eventName].Count == 0)
                    {
                        listeners.Remove(eventName);
                    }
                    else
                    {
                        //TODO: Neccessary? Correct?
                        listeners[eventName].TrimExcess();
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// TODO: Remove all listeners of one object
        /// </summary>
        public void RemoveListenerOfObserver(IEventObserver observer)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="gameEvent"></param>
        public void Trigger(GameEvents eventName, IGameEvent gameEvent)
        {
            List<Action<IGameEvent>> eventListeners;

            if (listeners.TryGetValue(eventName, out eventListeners))
            {
                foreach (Action<IGameEvent> listener in eventListeners)
                {
                    listener.Invoke(gameEvent);
                }
            }
            else
            {
                //Do nothing
            }
        }
    }

    public interface IEventObserver
    {
    }

}
