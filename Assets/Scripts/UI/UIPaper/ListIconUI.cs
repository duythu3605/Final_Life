using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListIconUI : MonoBehaviour
{
    [Header("Icon Button")]
    public Button _uiPaper;

    [Header("Panel UI")]
    public GameObject _panelUIPaper;


    [HideInInspector]
    private UIPaperBehavior UIPaper;

    public void Init()
    {
        UIPaper = GameObject.Find(nameof(UIPaper)).GetComponent<UIPaperBehavior>();
        UIPaper.Init();
        _panelUIPaper.SetActive(false);
        _uiPaper.onClick.AddListener(UIPaperShow);

        
    }

    private void UIPaperShow()
    {
        _panelUIPaper.SetActive(true);
    }
}
