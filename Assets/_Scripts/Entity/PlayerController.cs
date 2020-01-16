using System.Collections;
using System.Collections.Generic;
using Raptor.Events;
using UnityEngine;

[RequireComponent(typeof(GameEventHandler))]
public class PlayerController : EntityBase, IDamageDealer, IDamagable, IEventObserver
{
    [SerializeField] StatFloat _health;
    [SerializeField] StatFloat _otherHealth;

    Animator _animator;
    PlayerMovement _playerMovement;
    CombatSystem _comboSystem;

    public StatFloat Health { get => _health; private set => _health = value; }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _comboSystem = GetComponent<CombatSystem>();

        GetComponent<GameEventHandler>().AddListener(OnDeath, GameEvents.Default);
    }

    void Test()
    {
        GetComponent<GameEventHandler>().Trigger(GameEvents.Default, new GameEventBase(this));
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
        _health.Current -= damage;
    }

    public void OnDeath(IGameEvent eventInfo)
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
