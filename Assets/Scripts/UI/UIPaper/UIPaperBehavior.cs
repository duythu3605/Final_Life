using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPaperBehavior : MonoBehaviour
{
    [Header("Button paper")]
    public Button _equipmentButton;
    public Button _itemButton;
    public Button _taskButton;
    public Button _skillButton;
    public Button _exitButton;

    [Header("List Paper")]
    public GameObject _panelUIEquipMent;
    public GameObject _panelUIITem;
    public GameObject _panelUISkill;
    public GameObject _panelUITask;

    public void Init()
    {
        _panelUIITem.SetActive(false);
        _panelUISkill.SetActive(false);
        _panelUITask.SetActive(false);
        _equipmentButton.onClick.AddListener(TurnOnUIEquipMent);
        _itemButton.onClick.AddListener(TurnOnUIItem);
        _taskButton.onClick.AddListener(TurnOnUISkill);
        _skillButton.onClick.AddListener(TurnOnUITask);
        _exitButton.onClick.AddListener(TurnOffUIPaper);
    }

    private void TurnOffUIPaper()
    {
        gameObject.SetActive(false);
    }

    private void TurnOnUIEquipMent()
    {
        _panelUIITem.SetActive(false);
        _panelUISkill.SetActive(false);
        _panelUITask.SetActive(false);
        _panelUIEquipMent.SetActive(true);
    }
    private void TurnOnUIItem()
    {
        _panelUIITem.SetActive(true);
        _panelUISkill.SetActive(false);
        _panelUITask.SetActive(false);
        _panelUIEquipMent.SetActive(false);
    }
    private void TurnOnUISkill()
    {
        _panelUIITem.SetActive(false);
        _panelUISkill.SetActive(true);
        _panelUITask.SetActive(false);
        _panelUIEquipMent.SetActive(false);
    }
    private void TurnOnUITask()
    {
        _panelUIITem.SetActive(false);
        _panelUISkill.SetActive(false);
        _panelUITask.SetActive(true);
        _panelUIEquipMent.SetActive(false);
    }
}
