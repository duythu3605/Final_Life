using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillCard : MonoBehaviour
{
    private UIPaperSkill _uIPaperSkill;
    [Header("Infor Button")]
    public Image _iconSkill;
    public TMP_Text _nameSkill;
    public TMP_Text _levelSkill;
    public Button _upSkill;
    private HeroController _heroController;
    [Header("Button show")]
    public Button _showInfor;

    public void Init(HeroController heroController, UIPaperSkill uIPaperSkill)
    {
        _heroController = heroController;
        _uIPaperSkill = uIPaperSkill;
    }
    public void SetData(HealthSetting healthSetting, int indexLevel)
    {
        _iconSkill.enabled = true;
        _iconSkill.sprite = healthSetting.iconHealth;
        _nameSkill.text = healthSetting.introHealth;
        _upSkill.onClick.RemoveAllListeners();
        _upSkill.onClick.AddListener(() => {
            if (Int32.Parse(_levelSkill.text) < healthSetting.levelSettings.Count)
            {
                int pointupSkill = healthSetting.levelSettings.GetValueOrDefault(Int32.Parse(_levelSkill.text)).PotentialUp;

                if (_heroController.potentialPointController.CurrentPPoint >= pointupSkill)
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Point Lost: " + pointupSkill);
                    _heroController.potentialPointController.OnPPDecrease(pointupSkill);
                    _levelSkill.text = (Int32.Parse(_levelSkill.text) + indexLevel).ToString();                    
                    _heroController.healthController.LevelUp();
                }
                else
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Not Enough Point! Need more " + pointupSkill + " points to up Skill.");
                }
            }
            else
            {
                _uIPaperSkill._uINotice.showNotice.Invoke("MaxSkill");
            }
        });
        _showInfor.onClick.RemoveAllListeners();
        _showInfor.onClick.AddListener(() =>
        {
            _uIPaperSkill.SetInfo(healthSetting);
        });
    }
    public void SetData(ManaSetting manaSetting, int indexLevel)
    {
        _iconSkill.enabled = true;
        _iconSkill.sprite = manaSetting.iconMana;
        _nameSkill.text = manaSetting.introMana;
        _upSkill.onClick.RemoveAllListeners();
        _upSkill.onClick.AddListener(() => {
            if (Int32.Parse(_levelSkill.text) < manaSetting.levelSettings.Count)
            {
                int pointupSkill = manaSetting.levelSettings.GetValueOrDefault(Int32.Parse(_levelSkill.text)).PotentialUp;

                if (_heroController.potentialPointController.CurrentPPoint >= pointupSkill)
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Point Lost: " + pointupSkill);
                    _heroController.potentialPointController.OnPPDecrease(pointupSkill);
                    _levelSkill.text = (Int32.Parse(_levelSkill.text) + indexLevel).ToString();
                    
                    _heroController.manaController.LevelUp();
                }
                else
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Not Enough Point! Need more " + pointupSkill + " points to up Skill.");
                }
            }
            else
            {
                _uIPaperSkill._uINotice.showNotice.Invoke("MaxSkill");
            }
        });
        _showInfor.onClick.RemoveAllListeners();
        _showInfor.onClick.AddListener(() =>
        {
            _uIPaperSkill.SetInfo(manaSetting);
        });
    }
    //public void SetData(DamageSetting damageSetting, int indexLevel)
    //{
    //    _iconSkill.enabled = true;
    //    _iconSkill.sprite = damageSetting.iconDamage;
    //    _nameSkill.text = damageSetting.introDamage;
    //    _upSkill.onClick.RemoveAllListeners();
    //    _upSkill.onClick.AddListener(() => {
    //    if (Int32.Parse(_levelSkill.text) < damageSetting.levelSettings.Count)
    //    {
    //            int pointupSkill = damageSetting.levelSettings.GetValueOrDefault(Int32.Parse(_levelSkill.text)).PotentialUp;

    //            if (_heroController.potentialPointController.CurrentPPoint >= pointupSkill)
    //            {
    //                _heroController.potentialPointController.OnPPDecrease(pointupSkill);
    //                _levelSkill.text = (Int32.Parse(_levelSkill.text) + indexLevel).ToString();
    //                 _heroController.damageController.LevelUp();
    //                else
    //                {
    //                    _uIPaperSkill._uINotice.showNotice.Invoke("Not Enough Point! ");
    //                }
    //            }
    //        else
    //        {
    //            _uIPaperSkill._uINotice.showNotice.Invoke("MaxSkill");
    //        }
    //    });
    //    _showInfor.onClick.RemoveAllListeners();
    //    _showInfor.onClick.AddListener(() =>
    //    {
    //        _uIPaperSkill.SetInfo(damageSetting);
    //    });
    //}
    public void SetData(SpeedSetting speedSetting, int indexLevel)
    {
        _iconSkill.enabled = true;
        _iconSkill.sprite = speedSetting.iconSpeed;
        _nameSkill.text = speedSetting.introSpeed;
        _upSkill.onClick.RemoveAllListeners();
        _upSkill.onClick.AddListener(() => {
            if (Int32.Parse(_levelSkill.text) < speedSetting.levelSettings.Count)
            {
                int pointupSkill = speedSetting.levelSettings.GetValueOrDefault(Int32.Parse(_levelSkill.text)).PotentialUp;

                if (_heroController.potentialPointController.CurrentPPoint >= pointupSkill)
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Point Lost: " + pointupSkill);
                    _heroController.potentialPointController.OnPPDecrease(pointupSkill);
                    _levelSkill.text = (Int32.Parse(_levelSkill.text) + indexLevel).ToString();
                    
                    _heroController.speedController.LevelUp();
                }
                else
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Not Enough Point! Need more " + pointupSkill +" points to up Skill.");
                }
            }
            else
            {
                _uIPaperSkill._uINotice.showNotice.Invoke("MaxSkill");
            }
        });
        _showInfor.onClick.RemoveAllListeners();
        _showInfor.onClick.AddListener(() =>
        {
            _uIPaperSkill.SetInfo(speedSetting);
        });
    }
    public void SetData(AbstractSkillSetting skill, int indexLevel, CharacterSkills characterSkills)
    {
        _iconSkill.enabled = true;
        _iconSkill.sprite = skill.Avatar;
        _nameSkill.text = skill.Name;
        _upSkill.onClick.RemoveAllListeners();
        _upSkill.onClick.AddListener(() =>
        {
            if (Int32.Parse(_levelSkill.text) < _heroController.heroInfoSetting.skillSettings[characterSkills].Level)
            {                
                int pointUpSkill = skill.PotentialPoint;
                int pointLost = pointUpSkill * Int32.Parse(_levelSkill.text) + (pointUpSkill * 30 / 100);
                
                if (_heroController.potentialPointController.CurrentPPoint >= pointLost)
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Point Lost: " + pointLost);
                    _heroController.potentialPointController.OnPPDecrease(pointLost);
                    _levelSkill.text = (Int32.Parse(_levelSkill.text) + indexLevel).ToString();
                    _heroController.heroSkillSystem.UpSkill(_heroController.heroInfoSetting, characterSkills, Int32.Parse(_levelSkill.text));
                    
                }
                else
                {
                    _uIPaperSkill._uINotice.showNotice.Invoke("Not Enough Point! Need more  " + pointLost +" point to up Skill.");
                } 
            }
            else
            {
                _uIPaperSkill._uINotice.showNotice.Invoke("MaxSkill");
            }
        });

        _showInfor.onClick.RemoveAllListeners();
        _showInfor.onClick.AddListener(() =>
        {
            _uIPaperSkill.SetInfo(skill);
        });
    }

    
}
