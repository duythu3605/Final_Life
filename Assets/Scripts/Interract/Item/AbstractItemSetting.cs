using UnityEngine;
using System;


public abstract class AbstractItemSetting : ScriptableObject
{
    public abstract int Id { get; }
    public string NameItem;
}
