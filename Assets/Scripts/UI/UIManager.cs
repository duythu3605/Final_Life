using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Icon Button")]
    public Button _uiPaper;

    [Header("Panel UI")]
    public GameObject _panelUIPaper;

    [Header("Script UI")]
    public UIPaperBehavior UIPaper;
    public UIPaperEquipMent _uIPaperEquipMent;   
    public UIPaperSkill _uIPaperSkill;
    public UIPaperItem _uIPaperItem;

    public void Init(HeroController heroController)
    {
        UIPaper.Init();
        _uIPaperEquipMent.Init(heroController);        
        _uIPaperSkill.Init(heroController);
        _uIPaperItem.Init(heroController);

        _panelUIPaper.SetActive(false);
        _uiPaper.onClick.AddListener(UIPaperShow);


    }

    private void UIPaperShow()
    {
        _panelUIPaper.SetActive(true);
    }
}
