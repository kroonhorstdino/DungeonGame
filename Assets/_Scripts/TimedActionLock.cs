using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimedActionLock
{
    [SerializeField] float _lastActionLock;
    [Tooltip("The duration in which this action cannot be executed")]
    [SerializeField] float _lockInterval;

    public TimedActionLock(float lockInterval)
    {
        _lockInterval = lockInterval;
    }

    public void Lock()
    {
        _lastActionLock = Time.time;
    }

    public bool IsUnlocked()
    {
        return Time.time - _lastActionLock > _lockInterval;
    }

}
