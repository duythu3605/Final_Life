using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotentialPointController : MonoBehaviour
{
    public event Action<int> OnPPointChance;

    private int _pPoints;

    public int CurrentPPoint { get => _pPoints; private set { _pPoints = value; OnPPointChance?.Invoke(_pPoints); } }

    public void Init()
    {
        if (GetValuePP() == 0)
        {
            CurrentPPoint = _pPoints = 0;
        }
        else
        {
            CurrentPPoint = _pPoints = GetValuePP(); 
        }
    }
    public void OnPPIncrease(int value)
    {
        CurrentPPoint += value;
        SetValuePlayer(CurrentPPoint);
    }

    public void OnPPDecrease(int value)
    {
        CurrentPPoint -= value;
        SetValuePlayer(CurrentPPoint);
    }

    private void SetValuePlayer(int value)
    {
        PlayerPrefs.SetInt("PPoints", value);
    }

    private int GetValuePP()
    {
        return PlayerPrefs.GetInt("PPoints");
    }
}
