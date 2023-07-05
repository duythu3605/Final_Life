using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : Interactable
{
    public ItemSetting _itemSetting;

    public SpriteRenderer _sprite;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _itemSetting.itemLevelSetting[1].Icon;
    }
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        bool wasPickup = GameManager.Instance.heroController._inventory.AddItem(_itemSetting);
        if (wasPickup)
            Destroy(gameObject);
    }
}
