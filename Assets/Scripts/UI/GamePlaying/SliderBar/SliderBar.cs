using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxValue(float value)
    {
        _slider.maxValue = value;
        _slider.value = value;
    }
    public void SetValue(float value)
    {
        _slider.value = value;
    }
}
