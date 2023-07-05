using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMentManager : MonoBehaviour
{
 

    public EquipMent[] currentEquipment;

    public delegate void OnEquipmentChanged(EquipMent newItem, EquipMent oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public event Action<EquipMent[]> onItemEquip;


    Inventory inventory;

    public void Init(Inventory heroInventory)
    {
        int numSlots = System.Enum.GetNames(typeof(TypeEquipMent)).Length;
        currentEquipment = new EquipMent[numSlots];
        inventory = heroInventory;
    }

    public void Equip(EquipMent newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        EquipMent oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }


        currentEquipment[slotIndex] = newItem;
        onItemEquip?.Invoke(currentEquipment);
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            EquipMent oldItem = currentEquipment[slotIndex];
            inventory.AddItem(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

}
