using AYellowpaper.SerializedCollections;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Item", fileName = "ItemSetting")]
public class ItemSetting : AbstractItemSetting
{
    public bool isDefautItem = false;
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, ItemLevelSetting> itemLevelSetting;

    public override int Id => (nameof(ItemSetting) + NameItem).GetHashCode();

    public virtual void Use()
    {
        Debug.Log("Use item " + NameItem);
    }

    public void RemoveFromInventory()
    {
        GameManager.Instance.heroController._inventory.Remove(this);
    }
}
