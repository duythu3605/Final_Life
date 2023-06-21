using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Skill/AttackMeleeSkill", fileName = "AttackMeleeSkill")]
public class AttackMeleeSkillSetting : AbstractSkillSetting
{
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, AttackMeleeSkillLevelSetting> skillLevelSetting;

    public override int Id => (nameof(AttackMeleeSkillSetting) + Name).GetHashCode();
}

