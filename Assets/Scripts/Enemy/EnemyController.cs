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

    private Vector2 _direction => (_target == null) ? Vector2.zero : (_target.transform.position - transform.position).normalized;
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
    
    public EnemySetting enemySetting;
    public int Points;
    public bool isStep = false;
    public float radius = 5;
    public float _argoRange = 2;
    private GameManager _gameManager;
    public EnemyState CurrentState { get; set; }

    private void Update()
    {        
        State(CurrentState);
    }

    private void State(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.Patron:
                _target = null;
                enemyMove.OnMove(_direction);
                if (FindAround())
                {                        
                    CurrentState = EnemyState.Chasing;
                }
                else
                {                   
                    CurrentState = EnemyState.Patron;
                }
                break;
            case EnemyState.Chasing:
                Chasing(_target);
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Dead:
                OnDead();
                break;
        }
    }

    public bool FindAround()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius);
        if (collider != null && collider.gameObject.CompareTag("Hero"))
        {
            _target = collider.transform;
            return true;
        }
        return false;
    }

    private void Attack()
    {
        if (FindAround())
        {
            AttackEvent.NotifyObservers(manaController);
            CurrentState = EnemyState.Attack;
        }
        else
        {
            CurrentState = EnemyState.Chasing;
        }
    }

    private void Chasing(Transform target)
    {
        float distance =  Vector2.Distance(target.position, transform.position);
        
        enemyMove.OnMove(_direction);
        if(distance < _argoRange)
        {
            CurrentState = EnemyState.Attack;
        }
        else
        {
            if (FindAround())
            {
                CurrentState = EnemyState.Chasing;
            }
            else
            {
                CurrentState = EnemyState.Patron;
            }
        }
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
        GameManager.Instance.heroController.potentialPointController.OnPPIncrease(Points);
        GetComponent<Animator>().Play("Dead");       
        Destroy(gameObject, 2);
    }
}
