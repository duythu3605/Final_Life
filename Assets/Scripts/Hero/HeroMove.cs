using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public void OnMove(float horizontial, float vertical, float speed)
    {
        //_animator.Play("Move");
        Vector2 direction = new Vector2(horizontial, vertical).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, direction.x < 0 ? -180 : 0, 0));
        //rb.MovePosition(rb.position + direction * _speed * Time.fixedDeltaTime);
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
