using UnityEngine;

namespace Raptor.Utility
{
    public abstract class Overridable<T>
    {
        [SerializeField] protected T _default;
        [SerializeField] protected T _override;

        /// <summary>
        /// Returns correct object based on override settings
        /// </summary>
        /// <value></value>
        public T Correct
        {
            get
            {
                return IsOverrideValid() ? _override : _default;
            }
        }

        /// <summary>
        /// Checks if there is an valid override
        /// </summary>
        /// <returns></returns>
        protected bool IsOverrideValid()
        {
            return !_override.Equals(null);
        }
    }

    [System.Serializable]
    public class GameObjectOverride : Overridable<GameObject>
    {
    }
}