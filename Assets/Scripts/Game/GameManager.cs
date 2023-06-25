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
    public ListIconUI _ListIconUI;

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

        _ListIconUI = GameObject.Find(nameof(ListIconUI)).GetComponent<ListIconUI>();
        _ListIconUI.Init();

        heroController.InitEvent();
    }
}
