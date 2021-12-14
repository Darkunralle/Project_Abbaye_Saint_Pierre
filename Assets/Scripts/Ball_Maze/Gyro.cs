using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    private bool gyroEnable;
    private Gyroscope gyro;

    private float xrot = 0f;
    private float zrot = 0f;

    public float speed;
    public GameObject plat;

    void Start()
    {
        gyroEnable = enableGyro();
    }

    public bool IsBetween(float toComp, float min, float max)
    {
        if (toComp < max && toComp > min)
        {
            return true;
        }
        return false;
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
        if(gyroEnable == true)
        {
            if (IsBetween(gyro.rotationRate.x,-0.01f,0.01f)  && IsBetween(gyro.rotationRate.y, -0.01f, 0.01f))
            {
                //plat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                /*if (IsBetween(plat.transform.localEulerAngles.z,WrapAngle(),) )
                {
                    plat.transform.Rotate(gyro.rotationRate.x * Time.deltaTime * speed * -1, 0f, gyro.rotationRate.y * Time.fixedDeltaTime * speed * 2 * -1);
                }else if (IsBetween(plat.transform.localEulerAngles.z,14.5f,20f)) {
                    plat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }*/
                

                Debug.Log(plat.transform.localEulerAngles.z);
                
                
            }
            

        
           Debug.Log(WrapAngle(150));

        }
        else { Debug.Log("Gyro no detect"); }
    }

    private float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }


}
