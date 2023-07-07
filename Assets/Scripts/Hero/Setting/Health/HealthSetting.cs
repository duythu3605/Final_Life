using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Info/Health", fileName = "healthSetting")]
public class HealthSetting : ScriptableObject
{
    public Sprite iconHealth;
    public string Name;
    public string introHealth;
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, HealthLevelSetting> levelSettings;
}
