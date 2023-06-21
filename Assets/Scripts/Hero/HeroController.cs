using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    #region Setting
    public HeroInfoSetting heroInfoSetting;

    public DynamicJoystick dynamicJoystick;
    public bool IsJoytickDragging => dynamicJoystick.Direction != Vector2.zero;
    #endregion

    [HideInInspector]
    public HealthController healthController;

    [HideInInspector]
    public ManaController manaController;
    [HideInInspector]
    public DamageController damageController;
    [HideInInspector]
    public SpeedController speedController;

    [HideInInspector]
    public HeroMove heroMove;
    [HideInInspector]
    public void InitComponent()
    {
        //heroSkillSystem = GetComponent<HeroSkillSystem>();
        healthController = GetComponent<HealthController>();
        manaController = GetComponent<ManaController>();
        damageController = GetComponent<DamageController>();
        speedController = GetComponent<SpeedController>();
        heroMove = GetComponent<HeroMove>();
        //potentialPointController = GetComponent<PotentialPointController>();
        //heroInteract = GetComponent<HeroInteractItem>();
    }
    public void InitEvent()
    {
        InitData();
    }

    private void InitData()
    {
        //heroSkillSystem.Init(this);
        heroMove.Init(heroInfoSetting.speedSetting,1);
        healthController.Init(heroInfoSetting.healthSetting, 1);
        manaController.Init(heroInfoSetting.manaSetting, 1);
        damageController.Init(heroInfoSetting.damageSetting, 1);
        speedController.Init(heroInfoSetting.speedSetting, 1);
        //potentialPointController.Init(heroSetting);
    }


    public void FixedUpdate()
    {       
        float horizontial = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        if (IsJoytickDragging == false) return;
        heroMove.OnMove(horizontial,vertical);
    }
}
