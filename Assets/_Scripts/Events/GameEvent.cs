using System;
using System.Collections;
using System.Collections.Generic;
using Raptor.Events;
using UnityEngine;

using Raptor.Entity;
using Raptor.Combat;

using Object = UnityEngine.Object;

namespace Raptor.Events
{

    public class GameEventArgs<T> : EventArgs
    {
        public readonly T sender;
        public readonly float time;

        public GameEventArgs(T sender)
        {
            this.sender = sender;
            this.time = Time.time;
        }
    }

    public class OnDamageArgs : GameEventArgs<CombatHandler>
    {
        public readonly EntityBase target;
        public readonly float damage;

        public OnDamageArgs(CombatHandler sender, EntityBase target, float damage) : base(sender)
        {
            this.target = target;
            this.damage = damage;
        }
    }

    public class OnSpellHitArgs : GameEventArgs<CombatHandler>
    {
        public readonly EntityBase target;
        public readonly Spell spell;

        public OnSpellHitArgs(CombatHandler sender, EntityBase target, Spell spell) : base(sender)
        {
            this.target = target;
            this.spell = spell;
        }
    }

    public class OnSpellRemovedArgs : GameEventArgs<CombatHandler>
    {
        public readonly EntityBase target;

        public OnSpellRemovedArgs(CombatHandler sender) : base(sender)
        {
        }
    }

    public class OnDeathArgs : GameEventArgs<EntityBase>
    {
        public readonly OnDamageArgs damageEventArgs;

        public OnDeathArgs(EntityBase sender, OnDamageArgs damageEventArgs) : base(sender)
        {
            this.damageEventArgs = damageEventArgs;
        }
    }

    public class OnSpawnArgs : GameEventArgs<EntityBase>
    {
        public readonly EntityBase spawner;
        public readonly EntityBase spawned;

        public OnSpawnArgs(EntityBase sender, EntityBase spawnerEntity, EntityBase spawnedEntity) : base(sender)
        {
            this.spawner = spawnerEntity;
            this.spawned = spawnedEntity;
        }
    }
}
