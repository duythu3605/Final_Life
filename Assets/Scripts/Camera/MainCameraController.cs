using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    private float _smoothSpeed = 1;
    private Vector3 _offset = new Vector3(0, 0, -10);


    private void LateUpdate()
    {
        Vector3 desiredPosition = _playerTransform.position + _offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        smoothedPostion.z = -1;
        transform.position = smoothedPostion;
    }
}
