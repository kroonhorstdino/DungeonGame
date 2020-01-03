using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectData : ScriptableObject
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    public virtual bool OnUpdate(GameObject target)
    {
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="other"></param>
    public virtual void OnMeeleOnOther(GameObject origin, GameObject other)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="other"></param>
    public virtual void OnMeeleOnOrigin(GameObject origin, GameObject other)
    {

    }
}



[CreateAssetMenu(fileName = "Knockback", menuName = "Effect/Knockback", order = 0)]
public class EffectKnockback : EffectData
{
    [SerializeField] float _knockbackDistance;

    public override void OnMeeleOnOther(GameObject origin, GameObject other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
    }
}


[CreateAssetMenu(fileName = "SimpleDamage", menuName = "Effect/SimpleDamage", order = 0)]
public class EffectSimpleDamage : EffectData
{
    [SerializeField] float _damage;

    public override void OnMeeleOnOther(GameObject origin, GameObject other)
    {
        IDamageDealer dealer = other.GetComponent<IDamageDealer>();
        IDamagable damagable = other.GetComponent<IDamagable>();

        damagable.DealDamage(dealer, _damage);
    }
}
