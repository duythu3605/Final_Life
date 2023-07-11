using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    private Animator _animator;
    public Rigidbody2D _rb2D;
    private HeroController _heroController;
    private EnemyController _enemyController;

    public void Init(HeroController heroController)
    {
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
        _heroController = heroController;
    }
    public void Init(EnemyController enemyController)
    {
        _enemyController = enemyController;
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
    } 

    public void OnMove(Vector2 vector)
    {
        if(_rb2D.velocity.magnitude < 0.1f)
        {
            _rb2D.velocity = Vector2.zero;
        }
        _animator.Play("Run");
        Vector2 direction = vector.normalized;
        float speed = 0;
        if (transform.CompareTag("Hero"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, direction.x < 0 ? 180 : 0, 0));
            speed = _heroController.speedController.CurrentSpeed;
        }
        if (transform.CompareTag("Enemy"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, direction.x > 0 ? 180 : 0, 0));
            speed = _enemyController.speedController.CurrentSpeed;
        }


        _rb2D.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
