using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Following: https://youtu.be/S3pjBQObC90
public class RotateModel : MonoBehaviour
{
    float rotSpeed = 20;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        transform.RotateAround(transform.up, -rotX);
    }
}
