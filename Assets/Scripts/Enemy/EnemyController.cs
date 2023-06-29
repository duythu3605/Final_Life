using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region DataStream
    public Observable<ManaController> AttackEvent;
    #endregion

    [SerializeField]
    private Transform _target;
   
    #region UI
    [SerializeField]
    private SliderBar _healthBar;
    #endregion

    #region Controller
    private EnemySkillSystem _enemySkillSystem;
    [HideInInspector]
    public HealthController healthController;
    [HideInInspector]
    public ManaController manaController;
    [HideInInspector]
    public SpeedController speedController;

    [HideInInspector]
    public MoveMent enemyMove;
    #endregion

    private EnemyPatron enemyPatron;
    private bool isFindedHero = false;
    public EnemySetting enemySetting;

    public EnemyState CurrentState { get; set; }

    private void Update()
    {
        if (!isFindedHero)
        {
            
        }
    }

    private void State(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Patron:
                enemyMove.OnMove(enemyPatron.Patron());
                if (!isFindedHero)
                {
                    CurrentState = EnemyState.Patron;
                }
                break;
            case EnemyState.Chasing:

                break;
            case EnemyState.Attack:
                AttackEvent.NotifyObservers(manaController);
                break;
            case EnemyState.Dead:
                OnDead();
                break;
        }
    }


    private void DetectToAttack()
    {
        Collider2D collider = Physics2D.Raycast(transform.position, transform.right, 1.0f, LayerMask.GetMask("Hero")).collider;
        CurrentState = collider ? EnemyState.Attack : EnemyState.Chasing;
        
    }

    private void Start()
    {
        InitComponent();
        InitDataStream();
        IniEvent();
        InitData();       
    }
    private void InitComponent()
    {
        _enemySkillSystem = GetComponent<EnemySkillSystem>();
        healthController = GetComponent<HealthController>();
        manaController = GetComponent<ManaController>();
        speedController = GetComponent<SpeedController>();
        enemyMove = GetComponent<MoveMent>();
        enemyPatron = GetComponent<EnemyPatron>();
    }

    private void InitData()
    {
       _enemySkillSystem.Init(this);
        healthController.Init(enemySetting.healthSetting, 1);
        manaController.Init(enemySetting.manaSetting, 1);
        speedController.Init(enemySetting.speedLevelIndex, 1);
        enemyMove.Init(enemySetting.speedLevelIndex, 1);
        CurrentState = EnemyState.Patron;
    }

    private void IniEvent()
    {
        healthController.onHealthChange += _healthBar.SetValue;
        healthController.onMaxHealthChange += _healthBar.SetMaxValue;

        healthController.onHealthChange += (currentHealth) =>
        {
            if (currentHealth <= 0) CurrentState = EnemyState.Dead;
        };
    }

    private void InitDataStream()
    {
        
        AttackEvent ??= new Observable<ManaController>();
    }

    private void OnDead()
    {
        GetComponent<Animator>().Play("Dead");       
        Destroy(gameObject, 2);
    }
}
