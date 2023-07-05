using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AYellowpaper.SerializedCollections;

public class UIPaperSkill : MonoBehaviour
{
    [Header("Top")]
    public Image _AvatarSkill;
    public TMP_Text _nameSkill;
    public TMP_Text _description;

    [Header("Bottom")]
    public Transform _skillParent;
    public SkillCard _itemSkillCard;


    public void Init(HeroInfoSetting heroInfoSetting)
    {
        for (int i = 0; i < heroInfoSetting.skillSettings.Count; i++)
        {
            CharacterSkills characterSkills = (CharacterSkills)i;
            var skillCard = Instantiate(_itemSkillCard, _skillParent);
            skillCard.SetData(heroInfoSetting.skillSettings.GetValueOrDefault(characterSkills), 1);
        }
    }

    private void SetInfo()
    {

    }

}
