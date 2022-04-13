using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target;
    private Transform cameratr;
    private void Awake()
    {
        cameratr = GetComponent<Transform>();
    }
    private void Update()
    {
        cameratr.position = new Vector3(target.position.x, target.position.y + 3f, target.position.z-2f);
        cameratr.LookAt(target);
    }
}
