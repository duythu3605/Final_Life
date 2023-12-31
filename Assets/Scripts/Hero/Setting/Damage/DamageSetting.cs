using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Info/Damage", fileName = "damageSetting")]
public class DamageSetting : ScriptableObject
{
    public Sprite iconDamage;
    public string Name;
    public string introDamage;
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, DamageLevelSetting> levelSettings;
}
