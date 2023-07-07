using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSkillSystem : MonoBehaviour
{

    [SerializedDictionary("Skill", "Skill Behavior"), SerializeField]
    public SerializedDictionary<CharacterSkills, AbstractSkillBehavior> skillBehaviors;

    public void Init(HeroController heroController)
    {
        InitSkillsBehaviour(heroController.heroInfoSetting);


        heroController.AttackEvent.AddObserver(skillBehaviors[CharacterSkills.Attack]);
        heroController.FirstSkillEvent.AddObserver(skillBehaviors[CharacterSkills.FirstSkill]);
        heroController.SecondSkillEvent.AddObserver(skillBehaviors[CharacterSkills.SecondSkill]);
        heroController.ThirdSkillEvent.AddObserver(skillBehaviors[CharacterSkills.ThirdSkill]);

    }

    private void InitSkillsBehaviour(HeroInfoSetting heroSetting)
    {
        foreach (CharacterSkills heroAction in skillBehaviors.Keys)
        {
            skillBehaviors[heroAction].Init(heroSetting.skillSettings[heroAction], 1 , 0);
        }
    }
    private void InitedSkillsBehaviour(HeroInfoSetting heroSetting)
    {
        foreach (CharacterSkills heroAction in skillBehaviors.Keys)
        {
            skillBehaviors[heroAction].Init(heroSetting.skillSettings[heroAction], PlayerPrefs.GetInt(heroAction.ToString()), 0);
        }
    }

    public void UpSkill(HeroInfoSetting heroSetting, CharacterSkills characterSkills, int level)
    {
            skillBehaviors[characterSkills].Init(heroSetting.skillSettings[characterSkills], level, 0);
            PlayerPrefs.SetInt(characterSkills.ToString(), level);
    }
}
