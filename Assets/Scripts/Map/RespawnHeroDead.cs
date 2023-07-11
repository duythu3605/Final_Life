using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHeroDead : MonoBehaviour
{
    public Transform _reSpawn;

    public void Init(HeroController heroController)
    {
        heroController.transform.position = _reSpawn.position;
    }
}
