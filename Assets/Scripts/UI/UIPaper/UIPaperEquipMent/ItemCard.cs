using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour
{
    private ItemSetting item;
    private int _levelItem;
    [SerializeField]
    private Image IconItem;

    public Button removeButton;

    private UIPaperItem _uiPaperItem;

    private void Start()
    {
        _uiPaperItem = FindAnyObjectByType<UIPaperItem>();
    }

    public void AddItem(ItemSetting newItem, int levelItem)
    {
        item = newItem;
        IconItem.sprite = item.itemLevelSetting[levelItem].Icon;
        IconItem.enabled = true;
        removeButton.interactable = true;
        _levelItem = levelItem;
    }
    public void ChearSlot()
    {
        item = null;

        IconItem.sprite = null;
        IconItem.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        GameManager.Instance.heroController._inventory.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void ShowInforItem()
    {
        if(item != null)
        {
            _uiPaperItem.onupdateUI.Invoke(item,_levelItem);
        }
    }
    
}
