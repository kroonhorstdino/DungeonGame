using System.Collections;
using System.Collections.Generic;
using RocketRaptor.Events;
using UnityEngine;

namespace RocketRaptor.Events
{

    public enum GameEvents
    {
        Default
    }

    public interface IGameEvent
    {
    }

    public class GameEventBase : IGameEvent
    {
        public readonly IEventObserver sender;
        public readonly float time;

        public GameEventBase(IEventObserver sender)
        {
            this.sender = sender;
            this.time = Time.time;
        }
    }

    public class DamageEvent : GameEventBase
    {
        public readonly EntityBase target;
        public readonly float damage;

        public DamageEvent(IEventObserver sender, EntityBase target) : base(sender)
        {
            this.target = target;
        }
    }

    public class DeathEvent : GameEventBase
    {
        public DeathEvent(IEventObserver sender) : base(sender)
        {
        }
    }

}
