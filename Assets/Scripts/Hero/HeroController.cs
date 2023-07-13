using System;
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
    #region Events
    public event Action AttackAction;
    public event Action FirstSkillAction;
    public event Action SecondSkillAction;
    public event Action ThirdSkillAction;
    #endregion
    #region DataStream
    public Observable<ManaController> AttackEvent;
    public Observable<ManaController> FirstSkillEvent;
    public Observable<ManaController> SecondSkillEvent;
    public Observable<ManaController> ThirdSkillEvent;
    #endregion


    #region Input
    private GameInputUI _gameInputUI => GameManager.Instance.GameInputUI;
    #endregion

    [HideInInspector]
    public PotentialPointController potentialPointController;
    [HideInInspector]
    public HealthController healthController;

    [HideInInspector]
    public ManaController manaController;
    [HideInInspector]
    public DamageController damageController;
    [HideInInspector]
    public SpeedController speedController;
    [HideInInspector]
    public HeroSkillSystem heroSkillSystem;
    [HideInInspector]
    public Inventory _inventory;
    [HideInInspector]
    public EquipMentManager _equipMentManager;
    [HideInInspector]
    public MoveMent heroMove;
    [HideInInspector]
    public DataPlayer _dataPlayer;
    public void InitComponent()
    {
        heroSkillSystem = GetComponent<HeroSkillSystem>();
        healthController = GetComponent<HealthController>();
        manaController = GetComponent<ManaController>();
        damageController = GetComponent<DamageController>();
        speedController = GetComponent<SpeedController>();
        heroMove = GetComponent<MoveMent>();
        potentialPointController = GetComponent<PotentialPointController>();
        _inventory = GetComponent<Inventory>();
        _equipMentManager = GetComponent<EquipMentManager>();
        _dataPlayer = GetComponent<DataPlayer>();
        //heroInteract = GetComponent<HeroInteractItem>();
    }
    public void InitEvent()
    {
        InitDataStream();
        InitData();
        SubscribeEvent();

        _gameInputUI.SetEventHandler(AttackAction, FirstSkillAction, SecondSkillAction, ThirdSkillAction, manaController);
    }

    private void InitData()
    {
        heroSkillSystem.Init(this);
        heroMove.Init(this);
        _equipMentManager.Init(_inventory);

        _dataPlayer.SetValueSkill("Health", 1);
        _dataPlayer.SetValueSkill("Mana", 1);
        _dataPlayer.SetValueSkill("Damage", 1);
        _dataPlayer.SetValueSkill("Speed", 1);
        healthController.Init(heroInfoSetting.healthSetting, _dataPlayer.GetValueSkill("Health"));
        manaController.Init(heroInfoSetting.manaSetting, _dataPlayer.GetValueSkill("Mana"));
        damageController.Init(heroInfoSetting.damageSetting, _dataPlayer.GetValueSkill("Damage"));
        speedController.Init(heroInfoSetting.speedSetting, _dataPlayer.GetValueSkill("Speed"));
        potentialPointController.Init();
        
    }

    private void InitDataStream()
    {        
        AttackEvent ??= new Observable<ManaController>();
        FirstSkillEvent ??= new Observable<ManaController>();
        SecondSkillEvent ??= new Observable<ManaController>();
        ThirdSkillEvent ??= new Observable<ManaController>();
    }
    private void SubscribeEvent()
    {
        AttackAction += () => AttackEvent.NotifyObservers(manaController);
        FirstSkillAction += () => FirstSkillEvent.NotifyObservers(manaController);
        SecondSkillAction += () => SecondSkillEvent.NotifyObservers(manaController);
        ThirdSkillAction += () => ThirdSkillEvent.NotifyObservers(manaController);
    }
    public void FixedUpdate()
    {       
        float horizontial = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector2 vectorDirection = new Vector2(horizontial, vertical);
        if (IsJoytickDragging == false) return;
        heroMove.OnMove(vectorDirection);
    }
}
