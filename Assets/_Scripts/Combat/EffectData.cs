using UnityEngine;
using System;

using Raptor.Events;
using Raptor.Entity;
using Raptor.Combat;

namespace Raptor.Combat
{

    /// <summary>
    /// Everything about effect that is determined before runtime
    /// </summary>
    [CreateAssetMenu(fileName = "Effect", menuName = "_Combat/Effect/Effect", order = 1)]
    public class EffectData : ScriptableObject
    {
        [Tooltip("Unique identifier of this effect")]
        public string _identifier;

        /// <summary>
        /// Called the moment the effect is supposed to start
        /// </summary>
        /// <param name="caster"></param>
        /// <param name="target"></param>
        public virtual void Apply(CombatHandler caster, EntityBase target)
        {

        }

        public virtual void OnStart(CombatHandler caster, EntityBase target)
        {

        }

        public virtual void OnEnd(CombatHandler caster, EntityBase target)
        {

        }

        public virtual bool IsTargetValid(CombatHandler target)
        {
            return true;
        }

        public Effect CreateEffect()
        {
            return new Effect(this);
        }
    }

    /// <summary>
    /// Runtime encapsulation of effect data
    /// </summary>
    public class Effect
    {
        EffectData _data;

        public Effect(EffectData data)
        {
            _data = data;
        }

        public Action<CombatHandler, EntityBase> Apply()
        {
            return _data.Apply;
        }
    }

    [CreateAssetMenu(fileName = "DamageEffect", menuName = "_Combat/Effect/DamageEffect", order = 0)]
    public class DamageEffect : EffectData
    {
        [SerializeField] float _amount;

        public override void Apply(CombatHandler caster, EntityBase target)
        {
            (target as IDamagable).DealDamage(caster, _amount);
        }

        public override bool IsTargetValid(CombatHandler target)
        {
            throw new NotImplementedException();
        }

        public override void OnStart(CombatHandler caster, EntityBase target)
        {
            throw new NotImplementedException();
        }

        public override void OnEnd(CombatHandler caster, EntityBase target)
        {
            throw new NotImplementedException();
        }
    }

    public class VisualEffect : EffectData
    {
        public override void Apply(CombatHandler caster, EntityBase target)
        {
            throw new NotImplementedException();
        }

        public override bool IsTargetValid(CombatHandler target)
        {
            throw new NotImplementedException();
        }

        public override void OnEnd(CombatHandler caster, EntityBase target)
        {
            throw new NotImplementedException();
        }

        public override void OnStart(CombatHandler caster, EntityBase target)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Sets entity on fire
    /// </summary>
    public class FireEffect : VisualEffect
    {

    }

}