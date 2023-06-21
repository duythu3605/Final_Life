using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName ="Hero/Info", fileName ="InfoHero")]
public class HeroInfoSetting : ScriptableObject
{
    [Header("Information Hero")]
    public Sprite Avatar;
    public string Name;
    public float potentialPoint;    
    
    [Header("Type Hero")]
    public HeroType heroType;

    [Header("Health/Mana")]
    public HealthSetting healthSetting;
    public ManaSetting manaSetting;

    [Header("Damage/Speed")]
    public DamageSetting damageSetting;
    public SpeedSetting speedSetting;

    [Header("Skill"), SerializedDictionary("Skill", "Skill Setting")]
    public SerializedDictionary<CharacterSkills, AbstractSkillSetting> skillSettings;
}
