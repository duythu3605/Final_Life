using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float _speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;
    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        Vector2 direction = new Vector2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical).normalized;
        OnMove(direction);
    }

    private void OnMove(Vector2 direction)
    {
        //_animator.Play("Move");

        transform.rotation = Quaternion.Euler(new Vector3(0, direction.x < 0 ? -180 : 0, 0));
        //rb.MovePosition(rb.position + direction * _speed * Time.fixedDeltaTime);
        rb.velocity = direction * _speed * Time.fixedDeltaTime;
    }
}
