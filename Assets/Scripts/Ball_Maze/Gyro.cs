using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    private bool gyroEnable;
    private Gyroscope gyro;

    private float xrot;
    private float zrot;

    private bool starting = true;

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
        if (starting)
        {
            if (gyroEnable == true)
            {
                xrot = WrapAngle(plat.transform.localEulerAngles.x);
                zrot = WrapAngle(plat.transform.localEulerAngles.z);

                if (IsBetween(WrapAngle(zrot), -15.05f, 15.05f) && IsBetween(WrapAngle(xrot), -15.05f, 15.05f))
                {
                    plat.transform.Rotate(Mathf.Clamp(gyro.rotationRate.x, -0.8f, 0.8f) * Time.deltaTime * speed * -1, 0f, Mathf.Clamp(gyro.rotationRate.y, -0.8f, 0.8f) * Time.deltaTime * speed * 3 * -1);
                }
                else if (zrot < -15)
                {
                    plat.transform.rotation = Quaternion.Euler(xrot, 0f, -15f);
                }
                else if (zrot > 15)
                {
                    plat.transform.rotation = Quaternion.Euler(xrot, 0f, 15f);
                }
                else if (xrot < -15)
                {
                    plat.transform.rotation = Quaternion.Euler(-15f, 0f, zrot);
                }
                else if (xrot > 15)
                {
                    plat.transform.rotation = Quaternion.Euler(15f, 0f, zrot);
                }
            }
            else { Debug.Log("Gyro not detected"); }
        }
        
    }

    private bool IsBetween(float toComp, float min, float max)
    {
        if (toComp < max && toComp > min)
        {
            return true;
        }
        return false;
    }
    private float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }


}
