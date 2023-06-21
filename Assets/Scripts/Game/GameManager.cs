using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameSingleton<GameManager>
{

    #region Player
    [HideInInspector]
    public HeroController heroController;
    #endregion

    [HideInInspector]
    public GamePlayingUI GamePlayingUI;
    protected override void OnAwake()
    {
        GameObject player = GameObject.FindWithTag("Hero");

        heroController = player.GetComponent<HeroController>();
        heroController.InitComponent();

        GamePlayingUI = GameObject.Find(nameof(GamePlayingUI)).GetComponent<GamePlayingUI>();
        GamePlayingUI.Init(heroController.healthController, heroController.manaController);


        heroController.InitEvent();
    }
}
