using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInputUI : MonoBehaviour
{
    [SerializeField]
    private Button _attackButton, _firstSkillButton, _secondSkillButton, _thirdSkillButton;

    [Header("Ability")]
    [SerializeField] private Image[] _abilityButton;

    public bool isStartSkill = false;

    public void Init()
    {
        for (int i = 0; i < _abilityButton.Length; i++)
        {
            _abilityButton[i].fillAmount = 0;
        }
    }


    public void SetEventHandler(Action onAttack, Action onFirstSkill, Action onSecondSkill, Action onThirdSkill , ManaController manaController)
    {
        var heroActionSkillBehavior = GameManager.Instance.heroController.heroSkillSystem.skillBehaviors;


        _attackButton.onClick.AddListener(() => onAttack?.Invoke());

        _firstSkillButton.onClick.AddListener(() =>
        {           
            onFirstSkill?.Invoke();
            StartCoroutine(StartAbility(heroActionSkillBehavior[CharacterSkills.FirstSkill].coolDownTime, _abilityButton[0], _firstSkillButton));
        });

        _secondSkillButton.onClick.AddListener(() =>
        {            
            onSecondSkill?.Invoke();
            StartCoroutine(StartAbility(heroActionSkillBehavior[CharacterSkills.SecondSkill].coolDownTime, _abilityButton[1], _secondSkillButton));                   
        });

        _thirdSkillButton.onClick.AddListener(() =>
        {            
            onThirdSkill?.Invoke();
            StartCoroutine(StartAbility(heroActionSkillBehavior[CharacterSkills.ThirdSkill].coolDownTime, _abilityButton[2], _thirdSkillButton));
        });
    }


    private IEnumerator StartAbility(float time, Image abilityImage, Button button)
    {
        abilityImage.fillAmount = 1;

        button.interactable = false;

        while (abilityImage.fillAmount != 0)
        {
            yield return null;

            abilityImage.fillAmount -= 1 / time * Time.deltaTime;

            if (abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
            }
        }
        isStartSkill = false;
        button.interactable = true;
    }
}
