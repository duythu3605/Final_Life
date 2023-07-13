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

    public UINotice _uINotice;

    public void Init(HeroController heroController, UINotice uINotice)
    {
        _uINotice = uINotice;
        var health = Instantiate(_itemSkillCard, _skillParent);
        var mana = Instantiate(_itemSkillCard, _skillParent);
        //var damage = Instantiate(_itemSkillCard, _skillParent);
        var speed = Instantiate(_itemSkillCard, _skillParent);
        
        //Skill
        for (int i = 0; i < heroController.heroInfoSetting.skillSettings.Count; i++)
        {
            CharacterSkills characterSkills = (CharacterSkills)i;
            var skillCard = Instantiate(_itemSkillCard, _skillParent);
            skillCard.Init(heroController,this);
            skillCard.SetData(heroController.heroInfoSetting.skillSettings.GetValueOrDefault(characterSkills), 1, characterSkills);
            
        }
        health.Init(heroController, this);
        mana.Init(heroController, this);
        //damage.Init(heroController, this);
        speed.Init(heroController, this);

        health.SetData(heroController.heroInfoSetting.healthSetting, heroController._dataPlayer.GetValueSkill("Health"));
        mana.SetData(heroController.heroInfoSetting.manaSetting, heroController._dataPlayer.GetValueSkill("Mana"));
        //damage.SetData(heroController.heroInfoSetting.damageSetting, 1);
        speed.SetData(heroController.heroInfoSetting.speedSetting, heroController._dataPlayer.GetValueSkill("Speed"));
    }

    public void SetInfo(AbstractSkillSetting skillSetting)
    {
        _AvatarSkill.sprite = skillSetting.Avatar;
        _nameSkill.text = skillSetting.Name;
        _description.text = skillSetting.Description;
    }
    public void SetInfo(HealthSetting healthSetting)
    {
        _AvatarSkill.sprite = healthSetting.iconHealth;
        _nameSkill.text = healthSetting.Name;
        _description.text = healthSetting.introHealth;
    }
    public void SetInfo(ManaSetting manaSetting)
    {
        _AvatarSkill.sprite = manaSetting.iconMana;
        _nameSkill.text = manaSetting.Name;
        _description.text = manaSetting.introMana;
    }
    public void SetInfo(DamageSetting damageSetting)
    {
        _AvatarSkill.sprite = damageSetting.iconDamage;
        _nameSkill.text = damageSetting.Name;
        _description.text = damageSetting.introDamage;
    }
    public void SetInfo(SpeedSetting speedSetting)
    {
        _AvatarSkill.sprite = speedSetting.iconSpeed;
        _nameSkill.text = speedSetting.Name;
        _description.text = speedSetting.introSpeed;
    }

}
