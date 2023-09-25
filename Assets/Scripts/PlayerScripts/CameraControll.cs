using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraOffset;
    [SerializeField]
    private Transform target;

    private void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.position + cameraOffset;
        }
    }
}
