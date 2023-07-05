using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillCard : MonoBehaviour
{
    public Image _iconSkill;
    public TMP_Text _nameSkill;
    public TMP_Text _levelSkill;
    public Button _upSkill;

    public void SetData(AbstractSkillSetting skill, int indexLevel)
    {
        _iconSkill.enabled = true;
        _iconSkill.sprite = skill.Avatar;
        _nameSkill.text = skill.Name;
        _upSkill.onClick.RemoveAllListeners();
        _upSkill.onClick.AddListener(() =>
        {
            //if(GameManager.Instance.heroController.potentialPointController.CurrentPPoint >= skill.)

            _levelSkill.text = (Int32.Parse(_levelSkill.text) + 1).ToString();
        });
    }
}
