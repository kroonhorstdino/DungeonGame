using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagable : IActor
{
    void DealDamage(IDamageDealer actor, float damage);
}

public interface IDamageDealer : IActor
{
}

public interface IActor
{
    GameObject GetGameObject();
}