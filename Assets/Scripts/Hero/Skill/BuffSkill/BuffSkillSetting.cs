using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Skill/BuffSkill", fileName = "BuffSkill")]
public class BuffSkillSetting : AbstractSkillSetting
{
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, BuffSkillLevelSetting> skillLevelSetting;

    public override int Id => (nameof(BuffSkillSetting) + Name).GetHashCode();
}
