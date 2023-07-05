using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemEquipMent : MonoBehaviour
{
    public Button ItemButton;
    public Image iconItem;

    public void AddItemEquipMent(EquipMent equipMent, int index)
    {
        if (equipMent != null)
        {
            iconItem.sprite = equipMent.itemLevelSetting[index].Icon;
        }
    }

    public void ClearSlots()
    {
        iconItem.sprite = null;
    }
}
