using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillSystem : MonoBehaviour
{
    [SerializedDictionary("Skill", "Skill Behavior"), SerializeField]
    public SerializedDictionary<CharacterSkills, AbstractSkillBehavior> skillBehaviors;

    public void Init(EnemyController enemyController)
    {       
        InitSkillsBehaviour(enemyController.enemySetting);       
        enemyController.AttackEvent.AddObserver(skillBehaviors[CharacterSkills.Attack]);
    }
    private void InitSkillsBehaviour(EnemySetting enemySetting)
    {
        foreach (CharacterSkills skill in skillBehaviors.Keys)
        {
            skillBehaviors[skill].Init(enemySetting.skillSettings[skill], 1, 0);
        }
    }

}
