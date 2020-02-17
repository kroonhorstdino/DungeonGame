using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Raptor.Combat;

namespace Raptor.Entity
{
    public interface IDamagable : IEntityComponent
    {
        void DealDamage(CombatHandler actor, float damage);
    }

    public interface IDamageDealer : IEntityComponent
    {

    }
}