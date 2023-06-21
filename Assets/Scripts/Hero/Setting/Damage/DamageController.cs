using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    #region DamageInfor
    private DamageSetting _damageSetting;

    private DamageLevelSetting _levelSetting => _damageSetting.levelSettings[LevelIndex];

    public int LevelIndex { get; private set; }

    public float damage => _levelSetting.Damage;

    public DamageController(DamageSetting damageSetting, int levelIndex)
    {
        _damageSetting = damageSetting;
        LevelIndex = levelIndex;
    }

    public DamageController damageNextLevel => new DamageController(_damageSetting, LevelIndex + 1);

    #endregion

    #region Event
    public event Action<float> onDamageChange;
    public event Action<float> onMaxDamageChange;
    #endregion

    private DamageController _damageController;

    private float _currentDamage;
    public float CurrentDamage { get => _currentDamage; private set { _currentDamage = value; onDamageChange?.Invoke(_currentDamage); } }

    private float _maxDamage;
    public float MaxDamage { get => _maxDamage; private set { _maxDamage = value; onMaxDamageChange?.Invoke(_maxDamage); } }

    public void Init(DamageSetting damageSetting, int levelIndex)
    {
        _damageController = new DamageController(damageSetting, levelIndex);

        CurrentDamage = MaxDamage = _damageController.damage;
    }

    public void OnDamageIncrease(float value) => CurrentDamage += value;

    public void OnDamageDecrease(float value) => CurrentDamage -= value;

    public void LevelUp()
    {
        _damageController = _damageController.damageNextLevel;
    }
}
