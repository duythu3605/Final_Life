using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSkillSetting : ScriptableObject
{
    public abstract int Id { get; }

    [Header("Information")]
    public Sprite Avatar;
    public string Name;
    public string Description;
    public int PotentialPoint;
    public int Level;
}
