using System;
using System.Collections;
using System.Collections.Generic;
using Raptor.Events;
using UnityEngine;

using Raptor.Entity;
using Raptor.Combat;

[RequireComponent(typeof(GameEventHandler))]
public class PlayerController : EntityBase
{
    PlayerInputActions _inputActions;
    Animator _animator;
    PlayerMovement _playerMovement;
    CombatHandler _comboSystem;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _comboSystem = GetComponent<CombatHandler>();

        Debug.Log("Removing it");
    }

    void Test(int a)
    {
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

    protected override void AddListenersAddtitional()
    {

    }

    protected override void RemoveListenersAdditional()
    {

    }
}
