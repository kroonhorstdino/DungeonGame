using UnityEngine;

namespace Raptor.Entity
{
    /// <summary>
    /// An object to classify an entity
    /// </summary>
    public abstract class EntityClassifier : ScriptableObject
    {
        [SerializeField] protected string displayName;
        [SerializeField] protected string identifier;

        public string DisplayName { get => displayName; }
        public string Identifier { get => identifier; }
    }

    /// <summary>
    /// Classifies entity as a member of a race
    /// 
    public class RaceEntityClassifier : EntityClassifier
    {

    }

    /// <summary>
    /// Classfies object as with a certain function
    /// </summary>
    public class ObjectEntityClassifier : EntityClassifier
    {
    }

}