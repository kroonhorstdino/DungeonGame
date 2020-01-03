using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatAction", menuName = "Combat/CombatAction", order = 0)]
public class CombatAction : ScriptableObject
{
    [SerializeField] string _displayName;
    [SerializeField] string _animationStateName;
    [SerializeField] List<EffectData> _effects;

    public string AnimationStateName { get => _animationStateName; private set => _animationStateName = value; }

    public override string ToString()
    {
        return _displayName;
    }
}
