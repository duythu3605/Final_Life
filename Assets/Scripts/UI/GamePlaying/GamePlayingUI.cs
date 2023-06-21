using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingUI : MonoBehaviour
{
    [SerializeField]
    private SliderBar _healthBar, _manaBar;

    [SerializeField]
    private Image _avatar;

    public void Init(HealthController healthController, ManaController manaController)
    {
        if (healthController)
        {
            healthController.onMaxHealthChange += _healthBar.SetMaxValue;
            healthController.onHealthChange += _healthBar.SetValue;
        }

        if (manaController)
        {
            manaController.onMaxManaChange += _manaBar.SetMaxValue;
            manaController.onManaChange += _manaBar.SetValue;
        }
       
    }
}
