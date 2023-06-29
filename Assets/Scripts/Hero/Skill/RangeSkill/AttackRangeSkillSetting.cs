using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/AttackRange", fileName = "AttackRangeSkillSetting")]
public class AttackRangeSkillSetting : AbstractSkillSetting
{
    public override int Id => (nameof(AttackRangeSkillSetting) + Name).GetHashCode();
    public GameObject bullet;

    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, AttackRangeSkillLevelSetting> skillLevelSetting;
}

