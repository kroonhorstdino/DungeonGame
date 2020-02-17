using UnityEngine;
using System.Collections.Generic;

using Raptor.Entity;

namespace Raptor.Combat
{
    [CreateAssetMenu(fileName = "Spell", menuName = "_Combat/Spell/Spell", order = 1)]
    public class SpellData : ScriptableObject
    {
        [SerializeField] List<EffectData> _effects;

        public List<EffectData> Effects { get => _effects; }

        /// <summary>
        /// Called every frame
        /// </summary>
        public void Apply()
        {
        }

        /// <summary>
        /// Called at casting of the spell
        /// </summary>
        virtual protected void OnCast()
        {

        }

        void OnFinish()
        {

        }

        bool IsFinished()
        {
            return true;
        }

        public Spell CreateSpell(EntityBase target)
        {
            return new Spell(this);
        }
    }

    public class Spell
    {
        SpellData _data;
        List<Effect> _effects;

        public List<Effect> Effects { get => _effects; }

        public Spell(SpellData data)
        {
            _data = data;
            _effects = data.Effects.ConvertAll(d => d.CreateEffect());
        }
    }
}