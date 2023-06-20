using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    #region HealthInfor
    [SerializeField]
    private HealthSetting _healthSetting;

    private HealthLevelSetting _levelSetting => _healthSetting.levelSettings[LevelIndex];

    public int LevelIndex { get; private set; }

    public float health => _levelSetting.Health;

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

    public void Init(HealthSetting manaSetting, int levelIndex)
    {
        _healthController = new HealthController(manaSetting, levelIndex);

        CurrentHealth = MaxHealth = _healthController.health;
    }

    public void OnManaIncrease(float value) => CurrentHealth += value;

    public void OnManaDecrease(float value) => CurrentHealth -= value;

    public void LevelUp()
    {
        _healthController = _healthController.healthNextLevel;
    }
}
