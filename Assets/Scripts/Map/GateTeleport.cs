using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateTeleport : MonoBehaviour
{
    public Transform _connectGate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            collision.transform.position = _connectGate.position;
        }
    }

}
