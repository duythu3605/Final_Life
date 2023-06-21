using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeSkillLevel
{
    private AttackMeleeSkillSetting _skillSetting;
    private AttackMeleeSkillLevelSetting _levelSetting => _skillSetting.skillLevelSetting[Index];
    public int Index;

    public AttackMeleeSkillLevel(AttackMeleeSkillSetting skillSetting, int levelIndex)
    {
        _skillSetting = skillSetting;
        Index = levelIndex;
    }

    public float damage => _levelSetting.damage;

    public float critical => _levelSetting.critical;

    public float range => _levelSetting.range;
    public float manaExpend => _levelSetting.manaExpend;
    public float coolDownTime => _levelSetting.coolDownTime;

    public AttackMeleeSkillLevel NextLevel => new AttackMeleeSkillLevel(_skillSetting, Index + 1);
}
