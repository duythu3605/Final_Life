using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSkillKnightBulletBehavior : MonoBehaviour
{
    protected float _damage;

    private int objCount = 0;

    public void Init(float damage)
    {
        _damage = damage;
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objCount++;
        Debug.Log(objCount);
        TakeDamage(collision, _damage);
       if(objCount >= 5)
        {
            Destroy(gameObject);
        }
    }

    protected void TakeDamage(Collider2D collision, float damage)
    {
        HealthController healthController = collision?.GetComponent<HealthController>();
      
        if (healthController == null) return;
        
        healthController.OnHealthDecrease(damage);
    }

}
