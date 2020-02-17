using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Utility
{
    /// <summary>
    /// Script that prevents the attached GameObject from being destroyed on scene transition
    /// </summary>
    public class DontDestroy : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
