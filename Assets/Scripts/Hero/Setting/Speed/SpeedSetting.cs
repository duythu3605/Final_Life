using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Info/Speed", fileName = "speedSetting")]
public class SpeedSetting : ScriptableObject
{
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, SpeedLevelSetting> levelSettings;
}
