using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Hero/Info", fileName ="InfoHero")]
public class HeroInfoSetting : ScriptableObject
{
    [Header("Information Hero")]
    public Sprite Avatar;
    public string Name;
    public float potentialPoint;
    public float Speed;
    
    [Header("Type Hero")]
    public HeroType heroType;

    [Header("Health/Mana")]
    public HealthSetting healthSetting;
    public ManaSetting manaSetting;

    //[Header("Skill")]

}
