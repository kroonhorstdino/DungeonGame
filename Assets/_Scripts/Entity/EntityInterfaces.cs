using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Entity
{


    public interface IAnimated
    {
        void SetAnimationVariables();
    }


    public interface IHasGameObject
    {
        GameObject GetGameObject();
    }
}