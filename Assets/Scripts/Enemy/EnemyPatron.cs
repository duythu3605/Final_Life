using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatron : MonoBehaviour
{  
    private EnemyController _enemyController;
    public void Init(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }

    public Vector2 Patron()
    {
        Vector2 vector = Vector2.zero;
        int index = Random.Range(1,4);
        switch (index)
        {
            case 1:
                vector = Vector2.up;
                break;
            case 2:
                vector = Vector2.down;
                break;
            case 3:
                vector = Vector2.right;
                break;
            case 4:
                vector = Vector2.left;
                break;
        }

        return vector;
    }


}
