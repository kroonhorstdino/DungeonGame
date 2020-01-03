using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageDealer, IDamagable
{
    [SerializeField] float _health;

    Animator _animator;
    PlayerMovement _playerMovement;
    CombatSystem _comboSystem;

    public float Health { get => _health; private set => _health = value; }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _comboSystem = GetComponent<CombatSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetAnimationTriggers();
    }

    void SetAnimationTriggers()
    {
        _animator.SetBool("isIdle", IsIdle());
        if (IsIdle() && !_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            _animator.SetTrigger("startIdle");
        }
    }

    public bool IsIdle()
    {
        return !_playerMovement.IsWalking;
    }

    public void DealDamage(IDamageDealer actor, float damage)
    {
        _health -= damage;
    }

    public void StartDeath()
    {
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        yield return null;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
