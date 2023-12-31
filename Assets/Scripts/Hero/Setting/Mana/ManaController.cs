using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    #region ManaInfor
    private ManaSetting _manaSetting;

    private ManaLevelSetting _levelSetting => _manaSetting.levelSettings[LevelIndex];

    public int LevelIndex { get; private set; }

    public float mana => _levelSetting.Mana;

    public ManaController(ManaSetting manaSetting, int levelIndex)
    {
        _manaSetting = manaSetting;
        LevelIndex = levelIndex;
    }

    public ManaController manaNextLevel => new ManaController(_manaSetting, LevelIndex + 1);

    #endregion

    #region Event
    public event Action<float> onManaChange;
    public event Action<float> onMaxManaChange;
    #endregion

    private ManaController _manaController;

    private float _currentMana;
    public float CurrentMana { get => _currentMana; private set { _currentMana = value; onManaChange?.Invoke(_currentMana); if(CurrentMana < MaxMana) StartCoroutine(RecoveringMana()); } }

    private float _maxMana;
    public float MaxMana { get => _maxMana; private set { _maxMana = value; onMaxManaChange?.Invoke(_maxMana); } }

    private bool isRecoverMana = false;

    public void Init(ManaSetting manaSetting, int levelIndex)
    {
        _manaController = new ManaController(manaSetting, levelIndex);

        CurrentMana = MaxMana = _manaController.mana;
    }

    public void OnManaIncrease(float value) => CurrentMana += value;

    public void OnManaDecrease(float value) => CurrentMana -= value;

    public void LevelUp()
    {
        _manaController = _manaController.manaNextLevel;
        CurrentMana = MaxMana = _manaController.mana;
    }

    public void CheckCurrentMana()
    {
        if (CurrentMana < MaxMana)
        {
            isRecoverMana = true;
        }
    }

    private IEnumerator RecoveringMana()
    {
        CheckCurrentMana();
        yield return new WaitForSeconds(5);
        while (isRecoverMana)
        {
            yield return new WaitForSeconds(0.5f);
            
            CurrentMana += 5;
            if(CurrentMana >= MaxMana)
            {
                isRecoverMana = false;
            }
        }
    }
}
