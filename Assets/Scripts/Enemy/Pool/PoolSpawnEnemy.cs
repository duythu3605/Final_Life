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
        Init();
    }
    public void Init()
    {
        InitPool();
        StartCoroutine(Run());
    }

    public void InitPool()
    {
        for(int i = 0; i< _numberSpawn; i++)
        {
            GameObject enemy = Instantiate(_enemySpawn, transform.Find("Pool"));
            enemy.SetActive(false);
            enemy.GetComponent<EnemyController>().Init(this);

            _poolObject.Add(enemy);
        }
    }

    public Transform PositionPatron()
    {
        int index = Random.Range(0, _positionPatron.Count);
        Transform _target = _positionPatron[index];        
        return _target;
    }
    private IEnumerator Run()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeSpawn);

            for (int i = 0; i < _poolObject.Count; i++)
            {
                if (!_poolObject[i].activeInHierarchy)
                {
                    _poolObject[i].SetActive(true);
                    _poolObject[i].transform.position = _positionPatron[Random.RandomRange(0, _positionPatron.Count)].transform.position;
                }
            }
        }
    }

}
