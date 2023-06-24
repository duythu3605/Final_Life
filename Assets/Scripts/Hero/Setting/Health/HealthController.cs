using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    #region HealthInfor    
    private HealthSetting _healthSetting;

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
    public float CurrentHealth { get => _currentHealth; private set { _currentHealth = value; onHealthChange?.Invoke(_currentHealth); } }

    private float _maxHealth;
    public float MaxHealth { get => _maxHealth; private set { _maxHealth = value; onMaxHealthChange?.Invoke(_maxHealth); } }

    private bool isRecoverHealth = false;

    public void Init(HealthSetting manaSetting, int levelIndex)
    {
        _healthController = new HealthController(manaSetting, levelIndex);

        CurrentHealth = MaxHealth = _healthController.health;
        _animator = GetComponent<Animator>();
    }

    public void OnHealthIncrease(float value) => CurrentHealth += value;

    public void OnHealthDecrease(float value) {
        _animator.Play("Hurt");
        CurrentHealth -= value; 
    }


    public void LevelUp()
    {
        _healthController = _healthController.healthNextLevel;
    }

    public void CheckCurrentHealth()
    {
        Debug.Log("Health: " +CurrentHealth);
        StartCoroutine(RecoveringHealth());
    }

    private IEnumerator RecoveringHealth()
    {
        if (CurrentHealth < MaxHealth)
        {
            Debug.Log("can");
            isRecoverHealth = true;
        }
        else if (CurrentHealth >= MaxHealth)
        {
            Debug.Log("ko can");
            isRecoverHealth = false;
        }
        yield return new WaitForSeconds(5.0f);
        while (isRecoverHealth)
        {
            Debug.Log("Bat dau");
            CurrentHealth += 5;
            CheckCurrentHealth();
        }
    }
}
