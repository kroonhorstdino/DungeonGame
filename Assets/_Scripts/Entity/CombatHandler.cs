using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Raptor.Entity;
using Raptor.Combat;

/// <summary>
/// Script handling the combo system for a player
/// </summary>
public class CombatHandler : MonoBehaviour, IEntityComponent
{
    [SerializeField] TimedActionLock _punchActionLock;
    [SerializeField] TimedActionLock _kickAnimationLock;

    [SerializeField] AbilityData _TEST_abilityData;
    [SerializeField] Ability _TEST_ability;

    [SerializeField] EntityBase _TEST_targetEntity;

    Animator _animator;
    PlayerInputActions _inputActions;

    public EntityBase Entity { get; private set; }

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _TEST_ability = _TEST_abilityData.CreateAbility(Entity);
    }

    private void OnEnable()
    {
        Entity = GetComponent<EntityBase>();
        _inputActions.Ingame.Enable();

        /// <summary>
        /// PUNCH SIMPLE INPUT
        /// </summary>
        /// <returns></returns>
        _inputActions.Ingame.MeleeAttack.started += ctx => OnMeleeStarted(ctx);
        _inputActions.Ingame.MeleeAttack.canceled += ctx => OnMelee(ctx);
    }

    private void OnDisable()
    {
        _inputActions.Ingame.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnMeleeStarted(InputAction.CallbackContext ctx)
    {
        _TEST_ability.Cast(_TEST_targetEntity);
    }

    void OnMelee(InputAction.CallbackContext ctx)
    {
        Debug.Log("Testo");
    }
}
