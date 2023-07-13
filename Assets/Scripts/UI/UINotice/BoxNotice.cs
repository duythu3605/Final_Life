using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxNotice : MonoBehaviour
{
    public TMP_Text description;

    private void Start()
    {
        Destroy(gameObject, 3);
    }
    public void SetData(string value)
    {
        description.text = value;
    }
}
