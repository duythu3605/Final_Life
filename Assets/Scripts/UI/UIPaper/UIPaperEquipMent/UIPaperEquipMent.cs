using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPaperEquipMent : MonoBehaviour
{
    private Inventory _inventory;

    public Transform ItemsParent;

    private ItemCard[] slots;

    //EquipMentUI

    private EquipMentManager _equipMent;

    private ItemEquipMent[] slotsEquip;

    public Transform EquipParent;

    public void Init(Inventory inventory , EquipMentManager equipMentManager)
    {
        _inventory = inventory;
        _equipMent = equipMentManager;

        inventory.onItemChangedCallBack += UpdateUIInventory;

        _equipMent.onItemEquip += UpdateEquipSlots;
        slots = ItemsParent.GetComponentsInChildren<ItemCard>();
        slotsEquip = EquipParent.GetComponentsInChildren<ItemEquipMent>();
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

    private void UpdateEquipSlots(EquipMent[] equipMents)
    {
        for (int i = 0; i < equipMents.Length; i++)
        {
            if (equipMents[i] != null)
                slotsEquip[i].AddItemEquipMent(equipMents[i], 1);
        }
    }
}
