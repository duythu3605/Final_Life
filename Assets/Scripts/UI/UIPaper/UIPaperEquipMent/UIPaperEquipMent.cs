using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPaperEquipMent : MonoBehaviour
{
    private Inventory _inventory;

    public Transform ItemsParent;

    private ItemCard[] slots;

    //EquipMentUI

    private EquipMentManager _equipMent;

    private ItemEquipMent[] slotsEquip;

    public Transform EquipParent;

    [Header("Top")]
    public SliderBar _healthBar;
    public SliderBar _manaBar;
    [SerializeField]
    private Image _avatar;
    [SerializeField]
    public TMP_Text  _pontentialPoint;

    public void Init(HeroController heroController)
    {
        _inventory = heroController._inventory;
        _equipMent = heroController._equipMentManager;

        _inventory.onItemChangedCallBack += UpdateUIInventory;

        _equipMent.onItemEquip += UpdateEquipSlots;
        slots = ItemsParent.GetComponentsInChildren<ItemCard>();
        slotsEquip = EquipParent.GetComponentsInChildren<ItemEquipMent>();

        if (heroController.healthController)
        {
            heroController.healthController.onMaxHealthChange += _healthBar.SetMaxValue;
            heroController.healthController.onHealthChange += _healthBar.SetValue;
        }

        if (heroController.manaController)
        {
            heroController.manaController.onMaxManaChange += _manaBar.SetMaxValue;
            heroController.manaController.onManaChange += _manaBar.SetValue;
        }

        SetValuePP(heroController.potentialPointController.CurrentPPoint);
        heroController.potentialPointController.OnPPointChance += SetValuePP;
        
        _avatar.sprite = heroController.heroInfoSetting.Avatar;
    }

    private void SetValuePP(int value)
    {
        _pontentialPoint.text = value.ToString();
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
