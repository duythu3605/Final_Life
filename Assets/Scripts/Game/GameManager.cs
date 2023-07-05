using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameSingleton<GameManager>
{

    #region Player
    [HideInInspector]
    public HeroController heroController;
    #endregion

    #region UI
    [HideInInspector]
    public GameInputUI GameInputUI;

    [HideInInspector]
    public GamePlayingUI GamePlayingUI;

    [HideInInspector]
    public UIManager _uiManager;

    #endregion
    protected override void OnAwake()
    {
        GameObject player = GameObject.FindWithTag("Hero");

        heroController = player.GetComponent<HeroController>();
        heroController.InitComponent();

        GameInputUI = GameObject.Find(nameof(GameInputUI)).GetComponent<GameInputUI>();
        GameInputUI.Init();

        GamePlayingUI = GameObject.Find(nameof(GamePlayingUI)).GetComponent<GamePlayingUI>();
        GamePlayingUI.Init(heroController.healthController, heroController.manaController);

        _uiManager = GameObject.Find(nameof(UIManager)).GetComponent<UIManager>();
        _uiManager.Init(heroController);

        heroController.InitEvent();
    }
}
