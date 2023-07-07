using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEquipMent : MonoBehaviour
{
    public Button ItemButton;
    public Image iconItem;

    private EquipMent _equipMent;

    public void AddItemEquipMent(EquipMent equipMent, int index)
    {
        _equipMent = equipMent;
        if (equipMent != null)
        {
            iconItem.sprite = equipMent.itemLevelSetting[index].Icon;
        }
    }
    public void RemoveItemEquipMent()
    {
        
    }


    public void ClearSlots()
    {
        iconItem.sprite = null;
    }
}
