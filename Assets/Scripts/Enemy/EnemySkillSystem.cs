using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillSystem : MonoBehaviour
{
    //private MoveSkillBehavior _moveSKillBehavior;

    [SerializedDictionary("Skill", "Skill Behavior"), SerializeField]
    public SerializedDictionary<CharacterSkills, AbstractSkillBehavior> skillBehaviors;

    public void Init(EnemyController enemyController)
    {
        //_moveSKillBehavior = GetComponent<MoveSkillBehavior>();
        //_moveSKillBehavior.Init(enemyController.enemySetting.moveSkillSetting,
                                //(int)enemyController.enemySetting.moveLevelIndex);

        //InitSkillsBehaviour(enemyController.enemySetting);

        //enemyController.MoveStream.AddObserver(_moveSKillBehavior);
        //enemyController.AttackEvent.AddObserver(skillBehaviors[CharacterSkills.Attack]);
    }
    private void InitSkillsBehaviour(EnemySetting enemySetting)
    {
        foreach (CharacterSkills skill in skillBehaviors.Keys)
        {
            skillBehaviors[skill].Init(enemySetting.skillSettings[skill], 1, 100);
        }
    }

}
