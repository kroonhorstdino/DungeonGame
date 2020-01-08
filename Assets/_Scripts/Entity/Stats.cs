using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Class incapsulating all logic related to character statistics
/// </summary>
/// <typeparam name="T"></typeparam>
public class Stat<T> where T : struct, IComparable<float>
{
    [SerializeField] protected T _current;
    [SerializeField] protected T _min;
    [SerializeField] protected T _max;

    protected float _timeLastChanged;

    public T Current
    {
        get => _current;
        set
        {
            _current = CapValue(value);
            _timeLastChanged = Time.time;
        }
    }
    public T Min { get => _min; set => _min = value; }
    public T Max { get => _max; set => _min = _max; }

    public Stat()
    {
    }

    /// <summary>
    /// Caps value using min and max attributes
    /// </summary>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public virtual T CapValue(T newValue)
    {
        return newValue;
    }
}

[Serializable]
public class StatFloat : Stat<float>
{
    public override float CapValue(float newValue)
    {
        return Mathf.Clamp(newValue, _min, _max);
    }
}