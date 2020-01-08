using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Improve documentation
/// <summary>
/// Base class for items in game
/// Interface for data changing during gameplay.
/// </summary>
[System.Serializable]
public class ItemBase
{
    [SerializeField] ItemBaseData _dataObject;

    [SerializeField] StatFloat _value;
    [SerializeField] EntityBase _owner;

    public StatFloat Value { get => _value; set => _value = value; }

    public ItemBase(ItemBaseData dataObject)
    {
    }
}

[CreateAssetMenu(fileName = "ItemBaseData", menuName = "HellGame/Item/ItemBaseData", order = 0)]
public class ItemBaseData : ScriptableObject
{
    Sprite _sprite;
    string _identifier;
    string _displayName;

    [TextArea]
    string _description;

    /// <summary>
    /// ItemBase object with reference to this
    /// </summary>
    /// <returns></returns>
    public virtual ItemBase CreateItemInstance()
    {
        return new ItemBase(this);
    }
}
