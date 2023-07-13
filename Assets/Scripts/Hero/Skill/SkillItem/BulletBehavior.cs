using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    protected float _damage;

    public void Init(float damage)
    {
        _damage = damage;
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(collision, _damage);
            collision.GetComponent<EnemyController>()._healthLost.healthLost.Invoke(_damage);
        }
        Destroy(gameObject);
    }

    protected void TakeDamage(Collider2D collision, float damage)
    {
        HealthController healthController = collision?.GetComponent<HealthController>();
        if (healthController == null) return;
        //HealLost.instance.onReciveDamage.Invoke(damage);
        healthController.OnHealthDecrease(damage);
    }

}
