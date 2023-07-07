using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[CreateAssetMenu(menuName = "Info/Mana", fileName = "manaSetting")]
public class ManaSetting : ScriptableObject
{
    public Sprite iconMana;
    public string Name;
    public string introMana;
    [SerializedDictionary("Level Index", "Value")]
    public SerializedDictionary<int, ManaLevelSetting> levelSettings;
}
