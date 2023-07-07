using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    #region SpeedInfor
    private SpeedSetting _speedSetting;

    private SpeedLevelSetting _levelSetting => _speedSetting.levelSettings[LevelIndex];

    public int LevelIndex { get; private set; }

    public float speed => _levelSetting.Speed;

    public SpeedController(SpeedSetting speedSetting, int levelIndex)
    {
        _speedSetting = speedSetting;
        LevelIndex = levelIndex;
    }

    public SpeedController speedNextLevel => new SpeedController(_speedSetting, LevelIndex + 1);

    #endregion

    #region Event
    public event Action<float> onSpeedChange;
    public event Action<float> onMaxSpeedChange;
    #endregion

    private SpeedController _speedController;

    private float _currentSpeed;
    public float CurrentSpeed { get => _currentSpeed; private set { _currentSpeed = value; onSpeedChange?.Invoke(_currentSpeed); } }

    private float _maxSpeed;
    public float MaxSpeed { get => _maxSpeed; private set { _maxSpeed = value; onMaxSpeedChange?.Invoke(_maxSpeed); } }

    public void Init(SpeedSetting speedSetting, int levelIndex)
    {
        _speedController = new SpeedController(speedSetting, levelIndex);

        CurrentSpeed = MaxSpeed = _speedController.speed;
    }

    public void OnSpeedIncrease(float value) => CurrentSpeed += value;

    public void OnSpeedDecrease(float value) => CurrentSpeed -= value;

    public void LevelUp()
    {
        _speedController = _speedController.speedNextLevel;
        CurrentSpeed = MaxSpeed = _speedController.speed;
    }
}
