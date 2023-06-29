using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackRangeSkillLevel
{
    private AttackRangeSkillSetting _skillSetting;
    private AttackRangeSkillLevelSetting _levelSetting => _skillSetting.skillLevelSetting[Index];
    public int Index;

    public AttackRangeSkillLevel(AttackRangeSkillSetting skillSetting, int levelIndex)
    {
        _skillSetting = skillSetting;
        Index = levelIndex;
    }

    public float damage => _levelSetting.damage;

    public float critical => _levelSetting.critical;

    public float range => _levelSetting.range;
    public float manaExpend => _levelSetting.manaExpend;
    public float coolDownTime => _levelSetting.coolDownTime;

    public AttackRangeSkillLevel NextLevel => new AttackRangeSkillLevel(_skillSetting, Index + 1);

}
