using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINotice : MonoBehaviour
{
    public Transform _parentBox;

    public BoxNotice boxNotice;

    public delegate void OnShowNotice(string value);
    public OnShowNotice showNotice;

    public void Init()
    {
        showNotice += SetNotice;
    }

    public void SetNotice(string value)
    {
        var notice = Instantiate(boxNotice, _parentBox);
        notice.SetData(value);
    }
}
