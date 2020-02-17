using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Raptor.Entity;
using Raptor.Combat;
using Raptor.Item;

namespace Raptor.Item
{
    //TODO: Improve documentation
    /// <summary>
    /// Base class for items in game
    /// Interface for data changing during gameplay.
    /// </summary>
    [System.Serializable]
    public class ItemBase
    {
        [SerializeField] ItemBaseData _dataObject;

        [SerializeField] StatFloat _value;
        [SerializeField] EntityBase _owner;

        public StatFloat Value { get => _value; set => _value = value; }

        public ItemBase(ItemBaseData dataObject)
        {
        }
    }

    [CreateAssetMenu(fileName = "ItemBaseData", menuName = "HellGame/Item/ItemBaseData", order = 0)]
    public class ItemBaseData : ScriptableObject
    {
        [SerializeField] Sprite _sprite;
        /// <summary>
        /// Backend unique identifier
        /// </summary>
        /// <value></value>
        [SerializeField] string _identifier;
        [SerializeField] string _displayName;

        [TextArea]
        [SerializeField] string _description;

        [Header("Abilities")]
        [SerializeField] List<AbilityData> _abilities;

        public Sprite Sprite { get => _sprite; }
        public string Identifier { get => _identifier; }
        public string DisplayName { get => _displayName; }
        public string Description { get => _description; }
        public List<AbilityData> Abilities { get => _abilities; }

        /// <summary>
        /// ItemBase object with reference to this
        /// </summary>
        /// <returns></returns>
        public virtual ItemBase CreateItemInstance()
        {
            return new ItemBase(this);
        }
    }
}

namespace Raptor.Combat
{
    /// <summary>
    /// Handles weapon mechanics and application of abilities
    /// </summary>
    public class WeaponBase : ItemBase
    {
        CombatHandler _owner;

        /// <summary>
        /// Called when weapon has hit a target
        /// </summary>
        /// <value></value>
        public Action<Collision2D> OnWeaponHit { get; private set; }
        public CombatHandler Owner { get => _owner; set => _owner = value; }

        public WeaponBase(WeaponBaseData dataObject) : base(dataObject)
        {
        }
    }

    public class WeaponBaseData : ItemBaseData
    {
        [Header("Ability")]
        /// <summary>
        /// Which abilities does this weapon add?
        /// </summary>
        List<Ability> _abilities;
    }
}
