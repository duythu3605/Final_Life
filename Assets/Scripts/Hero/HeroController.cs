using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    #region Setting
    public HeroInfoSetting heroInfoSetting;

    public DynamicJoystick dynamicJoystick;
    
    #endregion

    [HideInInspector]
    public HealthController healthController;

    [HideInInspector]
    public ManaController manaController;

    [HideInInspector]
    public HeroMove heroMove;
    [HideInInspector]
    public void InitComponent()
    {
        //heroSkillSystem = GetComponent<HeroSkillSystem>();
        healthController = GetComponent<HealthController>();
        manaController = GetComponent<ManaController>();
        heroMove = GetComponent<HeroMove>();
        //potentialPointController = GetComponent<PotentialPointController>();
        //heroInteract = GetComponent<HeroInteractItem>();
    }

    private void InitData()
    {
        //heroSkillSystem.Init(this);
        healthController.Init(heroInfoSetting.healthSetting, 1);
        manaController.Init(heroInfoSetting.manaSetting, 1);
        //potentialPointController.Init(heroSetting);
    }


    public void FixedUpdate()
    {
        
        float horizontial = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        heroMove.OnMove(horizontial,vertical, heroInfoSetting.Speed);
    }
}
