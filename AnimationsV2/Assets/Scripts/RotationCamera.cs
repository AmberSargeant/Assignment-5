using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        transform.LookAt(target);
    }
}