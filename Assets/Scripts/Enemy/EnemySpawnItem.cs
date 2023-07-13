using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnItem : MonoBehaviour
{
    public List<GameObject> _items; 
    public void SpawnItem()
    {
        float percent = Random.Range(0.0f, 1.0f);
        Debug.Log(percent);
        if(percent > 0.5)
        {
            int i = Random.Range(0, _items.Count);
            var itemobj = Instantiate(_items[i]);
            itemobj.transform.position = transform.position;
        }       
    }
}
