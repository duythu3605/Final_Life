using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EquipMent", fileName = "New EquipMent")]
public class EquipMent : ItemSetting
{
    public TypeEquipMent equipSlot;

    public override void Use()
    {
        base.Use();

        GameManager.Instance.heroController._equipMentManager.Equip(this);
        RemoveFromInventory();
    }
}
public enum TypeEquipMent
{
    Hat, Armor, Weapon, Lung, Leg, Hand
}