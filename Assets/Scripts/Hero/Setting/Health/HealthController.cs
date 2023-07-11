using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    #region HealthInfor    
    public HealthSetting _healthSetting;

    private HealthLevelSetting _levelSetting => _healthSetting.levelSettings[LevelIndex];

    public int LevelIndex { get; private set; }

    public float health => _levelSetting.Health;
    private Animator _animator;
    public HealthController(HealthSetting healthSetting, int levelIndex)
    {
        _healthSetting = healthSetting;
        LevelIndex = levelIndex;
    }

    public HealthController healthNextLevel => new HealthController(_healthSetting, LevelIndex + 1);

    #endregion

    #region Event
    public event Action<float> onHealthChange;
    public event Action<float> onMaxHealthChange;
    #endregion

    private HealthController _healthController;

    private float _currentHealth;
    public float CurrentHealth { get => _currentHealth; private set { _currentHealth = value; onHealthChange?.Invoke(_currentHealth); if (CurrentHealth < MaxHealth && transform.gameObject.CompareTag("Hero") && !isDead) StartCoroutine(RecoveringHealth()); } }

    private float _maxHealth;
    public float MaxHealth { get => _maxHealth; private set { _maxHealth = value; onMaxHealthChange?.Invoke(_maxHealth); } }

    private bool isRecoverHealth = false;

    public bool isDead = false;
    public Transform _respawnPos;

    public void Init(HealthSetting healthSetting, int levelIndex)
    {
        _healthController = new HealthController(healthSetting, levelIndex);

        CurrentHealth = MaxHealth = _healthController.health;
        _animator = GetComponent<Animator>();
    }

    public void OnHealthIncrease(float value) => CurrentHealth += value;

    public void OnHealthDecrease(float value) {
        _animator.Play("Hurt");
        CurrentHealth -= value; 

        if(CurrentHealth <= 0)
        {
            isDead = true;
            OnDead();
        }
    }


    public void LevelUp()
    {
        _healthController = _healthController.healthNextLevel;
        CurrentHealth = MaxHealth = _healthController.health;
    }

    public void CheckCurrentHealth()
    {
        if (CurrentHealth < MaxHealth)
        {
            isRecoverHealth = true;
        }
    }
    public void OnDead()
    {
        _animator.Play("Dead");
        StartCoroutine(Disappear());
    }
    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (gameObject.CompareTag("Hero"))
        {
            transform.position = _respawnPos.position;
            StartCoroutine(Appear());
        }
    }
    private IEnumerator Appear()
    {
        isDead = false;
        yield return new WaitForSeconds(1);
        CurrentHealth = MaxHealth;
        transform.position = _respawnPos.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        _animator.Play("Idle");
    }
    private IEnumerator RecoveringHealth()
    {

        CheckCurrentHealth();
        yield return new WaitForSeconds(5);
        while (isRecoverHealth)
        {
            yield return new WaitForSeconds(0.5f);

            CurrentHealth += 5;
            if (CurrentHealth >= MaxHealth)
            {
                isRecoverHealth = false;
            }
        }
    }
}
