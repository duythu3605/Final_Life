using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int Space = 20;

    public List<ItemSetting> items = new List<ItemSetting>();


    public bool AddItem(ItemSetting itemsetting)
    {
        if (!itemsetting.isDefautItem)
        {
            if (items.Count >= Space)
            {
                Debug.Log("not enough room!");
                return false;
            }
            items.Add(itemsetting);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(ItemSetting itemsetting)
    {
        items.Remove(itemsetting);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
