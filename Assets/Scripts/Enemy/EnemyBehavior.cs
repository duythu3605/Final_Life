using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float argoRange = 2;

    

    private EnemyController _enemyController;

    public void Init(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }



    
    public Transform Target(Transform target)
    {
        return target;
    }

    public void Chasing(Transform target)
    {
        float distanceToTarget = Vector2.Distance(target.position, transform.position);

        if(distanceToTarget < argoRange)
        {
            Debug.Log("gan"); // Attack
        }
        else
        {
            Debug.Log("xa");// chasing
        }
    }

}
