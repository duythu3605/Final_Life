using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public abstract class AbstractEntitySetting : ScriptableObject
{
    [Header("Information")]
    public string Name;

#if UNITY_EDITOR
    private void OnValidate()
    {
        Name = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
    }
#endif
}
