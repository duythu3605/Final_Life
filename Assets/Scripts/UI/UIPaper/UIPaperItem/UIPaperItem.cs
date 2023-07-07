using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPaperItem : MonoBehaviour
{
    private Inventory _inventory;

    public Transform ItemsParent;

    private ItemCard[] slots;


    [Header("Top")]
    public Image _iconItem;
    public TMP_Text _nameItem;
    public TMP_Text _descriptionItem;

    public delegate void OnupdateUITop(ItemSetting itemSetting, int level);
    public OnupdateUITop onupdateUI;

    public void Init(HeroController heroController)
    {
        _inventory = heroController._inventory;        
        _inventory.onItemChangedCallBack += UpdateUIInventory;

        slots = ItemsParent.GetComponentsInChildren<ItemCard>();

        onupdateUI += UpdateUITOP;
    }

    private void UpdateUIInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < _inventory.items.Count)
            {
                slots[i].AddItem(_inventory.items[i], 1);
            }
            else
            {
                slots[i].ChearSlot();
            }
        }
    }

    public void UpdateUITOP(ItemSetting item ,int level)
    {
        _iconItem.sprite = item.itemLevelSetting.GetValueOrDefault(level).Icon;
        _nameItem.text = item.NameItem;
        _descriptionItem.text = item.itemLevelSetting.GetValueOrDefault(level).Description;
    }

}
