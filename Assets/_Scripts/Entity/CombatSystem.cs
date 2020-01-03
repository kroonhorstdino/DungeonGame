using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script handling the combo system for a player
/// </summary>
public class CombatSystem : MonoBehaviour, IAnimated
{
    [SerializeField] TimedActionLock _punchActionLock;
    [SerializeField] TimedActionLock _kickAnimationLock;

    [SerializeField] CombatAction _testAction;

    Animator _animator;
    PlayerInputActions _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Ingame.Enable();

        /// <summary>
        /// PUNCH SIMPLE INPUT
        /// </summary>
        /// <returns></returns>
        _inputActions.Ingame.PunchSimple.started += ctx => OnPunchStarted(ctx);
        _inputActions.Ingame.PunchSimple.canceled += ctx => OnPunch(ctx);
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

    private void FixedUpdate()
    {
        //SetAnimationTriggers();
    }

    public void SetAnimationVariables()
    {
        _animator.SetBool("inCombat", IsInCombatAnimation());
    }

    /// <summary>
    /// Is player executing a combat animation right now?
    /// </summary>
    /// <returns></returns>
    bool IsInCombatAnimation()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsTag("Combat");
    }

    void OnPunchStarted(InputAction.CallbackContext ctx)
    {

    }

    void OnPunch(InputAction.CallbackContext ctx)
    {
        Debug.Log("Testo");
        _animator.Play(_testAction.AnimationStateName, 0);
    }
}
