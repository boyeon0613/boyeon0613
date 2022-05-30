using System;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public bool isDetected;
    public LayerMask wallLayer;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (1 << other.gameObject.layer == wallLayer)
        {
            isDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if( 1 << other.gameObject.layer == wallLayer)
        {
            isDetected = false;
        }
    }
}

