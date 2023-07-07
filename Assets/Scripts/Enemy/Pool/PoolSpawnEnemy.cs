using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawnEnemy : MonoBehaviour
{
    public GameObject _enemySpawn;

    public float _numberSpawn;
    public float _timeSpawn;

    public List<Transform> _positionPatron;
    private List<GameObject> _poolObject;
    private void Start()
    {
        _poolObject = new List<GameObject>();
    }
    public void Init()
    {

    }

    public void SpawnEnemy()
    {

    }
}
