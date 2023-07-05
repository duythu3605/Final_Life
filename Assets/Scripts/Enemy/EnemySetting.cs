using AYellowpaper.SerializedCollections;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Enemy", fileName = "enemySetting")]
public class EnemySetting : AbstractEntitySetting
{
    public enum MoveLevel
    {
        None = 0,
        Slow = 1,
        Medium = 2,
        Fast = 3,
    }

    [Header("Stats")]
    public HealthSetting healthSetting;
    public ManaSetting manaSetting;   
    public SpeedSetting speedLevelIndex;
    public int Point;

    [Header("Skill"), SerializedDictionary("Skill", "Skill Setting")]
    public SerializedDictionary<CharacterSkills, AbstractSkillSetting> skillSettings;
}
