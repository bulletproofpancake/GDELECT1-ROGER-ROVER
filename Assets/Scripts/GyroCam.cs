using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Following: https://answers.unity.com/questions/970891/rotating-a-camera-using-the-gyroscope.html
public class GyroCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0);
    }
}
