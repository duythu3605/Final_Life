using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Info/Mana", fileName = "manaSetting")]
public class ManaSetting : ScriptableObject
{
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, ManaLevelSetting> levelSettings;
}
