using System;

using UnityEngine;

namespace Raptor.Utility
{
    /// <summary>
    /// NOTE: May be important some day. Or not. Depend on if this is what is even neccesary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class OriginalObject<T>
    {
        [SerializeField] protected T _original;

        public T Original { get => _original; }


    }

    [Serializable]
    public class OriginalScriptableObject : OriginalObject<ScriptableObject>
    {

    }
}