using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    private HeroController _heroController;
    public void Init(HeroController heroController)
    {
        _heroController = heroController;
    }

    public void SetValueSkill(string title, int index)
    {
        if (index <= 7)
        {
            PlayerPrefs.SetInt(title, index);
        }
    }

    public int GetValueSkill(string title)
    {
       return PlayerPrefs.GetInt(title);
    }
}
