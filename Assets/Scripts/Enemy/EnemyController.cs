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

    private Vector2 _direction;
    #region UI
    [SerializeField]
    private SliderBar _healthBar;
    [HideInInspector]
    public HealthLost _healthLost;

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

    private EnemySpawnItem _spawnItem;
    public EnemySetting enemySetting;
    public int Points;
    public float radius = 5;
    public float _argoRange = 2;

    private float moveInterval = 4f;
    private float timer;

    //private float holdState = 3f;
    //private float timerWait;
    //private bool isDead = false;

    private Animator animator;
    public EnemyState CurrentState { get; set; }

    

    private void Update()
    {       
        FindAround();
        State(CurrentState);
    }

    private void State(EnemyState enemyState)
    {
        switch (enemyState)
        {
            case EnemyState.None:
                timer -= Time.deltaTime;
                if (FindAround())
                {
                    CurrentState = EnemyState.Chasing;
                }
                if (timer <= 0)
                {
                    timer = moveInterval;
                    _target = null;
                    CurrentState = EnemyState.Patron;
                }
                break;
            case EnemyState.Patron:
                _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                enemyMove.OnMove(_direction);
                if (FindAround())
                {
                    CurrentState = EnemyState.Chasing;
                }
                else
                {
                    CurrentState = EnemyState.None;
                }
                break;
            case EnemyState.Chasing:
                _direction = (_target.position - transform.position).normalized ;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("Hero"))
            {
                timer = moveInterval;
                _target = collider.transform;
                return true;    
            }
        }
        return false;
    }

    private void Attack()
    {       
        AttackEvent.NotifyObservers(manaController);
        CurrentState = EnemyState.None;
    }

    private void Chasing(Transform target)
    {
        float distance = Vector2.Distance(target.position, transform.position);
        enemyMove.OnMove(_direction);
        if (distance <= _argoRange)
        {
            Debug.Log("Attack");
            CurrentState = EnemyState.Attack;
        }
        if(distance > _argoRange)
        {
            CurrentState = EnemyState.None;
        }
    }



    public void Init(PoolSpawnEnemy poolSpawnEnemy)
    {
        InitComponent();
        InitDataStream();
        IniEvent();
        InitData();
        timer = moveInterval;
        //timerWait = holdState;
    }
    private void InitComponent()
    {
        _enemySkillSystem = GetComponent<EnemySkillSystem>();
        healthController = GetComponent<HealthController>();
        manaController = GetComponent<ManaController>();
        speedController = GetComponent<SpeedController>();
        enemyMove = GetComponent<MoveMent>();
        animator = GetComponent<Animator>();
        _spawnItem = GetComponent<EnemySpawnItem>();
        _healthLost = GetComponent<HealthLost>();
    }

    private void InitData()
    {
       _enemySkillSystem.Init(this);
        healthController.Init(enemySetting.healthSetting, 1);
        manaController.Init(enemySetting.manaSetting, 1);
        speedController.Init(enemySetting.speedLevelIndex, 1);
        enemyMove.Init(this);
        _healthLost.Init();
        CurrentState = EnemyState.Patron;
    }

    private void IniEvent()
    {
        healthController.onHealthChange += _healthBar.SetValue;
        healthController.onMaxHealthChange += _healthBar.SetMaxValue;

        healthController.onHealthChange += (currentHealth) =>
        {
            if (currentHealth <= 0) CurrentState= EnemyState.Dead;
        };
    }

    private void InitDataStream()
    {
        
        AttackEvent ??= new Observable<ManaController>();
    }

    private void OnDead()
    {           
        animator.Play("Dead");
        GameManager.Instance.heroController.potentialPointController.OnPPIncrease(Points);
        _spawnItem.SpawnItem();
        CurrentState = EnemyState.None;
        gameObject.SetActive(false);
        //isDead = true;
        InitData();
    }
}
