using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateTeleport : MonoBehaviour
{
    public Transform _connectGate;
    private GameObject _camMain;
    private GameObject _camMini;

    private void Start()
    {
        _camMain = GameObject.Find("Main Camera");
        _camMini = GameObject.Find("MiniMapCamera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            collision.transform.position = _connectGate.position;
            _camMain.transform.position = _connectGate.position;
            _camMini.transform.position = _connectGate.position;
        }
    }

}
