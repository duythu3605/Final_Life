using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkillLevel
{
    private BuffSkillSetting _skillSetting;
    private BuffSkillLevelSetting _levelSetting => _skillSetting.skillLevelSetting[Index];
    public int Index;

    public BuffSkillLevel(BuffSkillSetting skillSetting, int levelIndex)
    {
        _skillSetting = skillSetting;
        Index = levelIndex;
    }

    public float damage => _levelSetting.damageUseFul;

    public float healthExpend => _levelSetting.healthUseFul;

    public float speed => _levelSetting.speedUseFul;
    public float range => _levelSetting.range;
    public float timeUseful => _levelSetting.timeUseFul;

    public float manaExpend => _levelSetting.manaExpend;
    public float coolDownTime => _levelSetting.coolDownTime;

    public BuffSkillLevel NextLevel => new BuffSkillLevel(_skillSetting, Index + 1);
}
