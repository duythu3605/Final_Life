using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameSingleton<GameManager>
{

    #region Player
    [HideInInspector]
    public HeroController heroController;
    #endregion
    protected override void OnAwake()
    {
        GameObject player = GameObject.FindWithTag("Hero");

        heroController = player.GetComponent<HeroController>();
        heroController.InitComponent();
    }
}
