
using System;
using System.Collections.Generic;

using UnityEngine;

using Raptor.Item;
using Raptor.Entity;

namespace Raptor.Combat
{
    [CreateAssetMenu(fileName = "Ability", menuName = "_Combat/Ability/Ability", order = 1)]
    public class AbilityData : ScriptableObject
    {
        string _identifier;
        int id;

        Sprite _image;

        [Tooltip("Conditions for when")]
        [SerializeField] List<SpellData> _spells;

        public List<SpellData> Spells { get => _spells; }

        /// <summary>
        /// Executes ability and applies spell with given method
        /// </summary>
        /// <param name="spells"></param>
        public virtual void Execute(List<Spell> spells)
        {

        }

        /// <summary>
        /// Creates ability class object
        /// </summary>
        /// <returns></returns>
        public virtual Ability CreateAbility(EntityBase caster)
        {
            return new Ability(this, caster);
        }
    }

    /// <summary>
    /// Conditions for a target.
    /// Determines wheter or not a target is valid
    /// Can accept a position (Vec2, Vec3, etc.), EntityBase or a kind of Tile
    /// </summary>
    [System.Serializable]
    public class TargetingCondition : ScriptableObject
    {
    }

    /// <summary>
    /// Encapsulates Ability behavior during runtime
    /// </summary>
    public class Ability
    {
        AbilityData _data;
        List<Spell> _spells;

        EntityBase _caster;

        public Ability(AbilityData data, EntityBase caster)
        {
            _data = data;
            _caster = caster;
        }

        /// <summary>
        /// Cast ability
        /// Creates spell and effect objects with proper targets
        /// </summary>
        public void Cast(EntityBase target)
        {
            _spells = _data.Spells.ConvertAll(d => d.CreateSpell(target));
        }

        /// <summary>
        /// Can cast this ability?
        /// </summary>
        /// <returns></returns>
        public bool CanCast(EntityBase target)
        {
            return IsValidTarget(target);
        }

        public bool CanCast(Vector2 target)
        {
            return IsValidTarget(target);
        }

        public bool IsValidTarget(EntityBase target)
        {
            return true;
        }

        public bool IsValidTarget(Vector2 target)
        {
            return true;
        }
    }
}