using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    private bool gyroEnable;
    private Gyroscope gyro;

    public float speed;
    public GameObject plat;

    void Start()
    {
        gyroEnable = enableGyro();
    }

    private bool enableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }

    void Update()
    {
        plat.transform.Rotate(gyro.rotationRate.x * Time.deltaTime * speed, gyro.rotationRate.y * Time.fixedDeltaTime * speed, gyro.rotationRate.z * Time.fixedDeltaTime * speed);
    }
}
