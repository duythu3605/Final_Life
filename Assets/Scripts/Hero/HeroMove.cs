using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    private Animator _animator;
    public Rigidbody2D _rb2D;
    public SpeedController _speedController;

    public void Init(SpeedSetting speedSetting , int index)
    {
        _animator = GetComponent<Animator>();
        _rb2D = GetComponent<Rigidbody2D>();
        _speedController = new SpeedController(speedSetting, index);
    }

    public void OnMove(float horizontial, float vertical)
    {
        if(_rb2D.velocity.magnitude < 0.1f)
        {
            _rb2D.velocity = Vector2.zero;
        }
        _animator.Play("Run");
        Vector2 direction = new Vector2(horizontial, vertical).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, direction.x < 0 ? -180 : 0, 0));       
        _rb2D.velocity = direction * _speedController.speed * Time.fixedDeltaTime;
    }
}
