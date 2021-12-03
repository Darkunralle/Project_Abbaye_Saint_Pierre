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

                Vector3 pos = plat.transform.position;

                // make sure X lies between 0 and 100
                pos.x = Mathf.Clamp(pos.x, 0f, 10f);
                pos.y = Mathf.Clamp(pos.y, 0f, 10f);

                transform.position = pos;

                plat.transform.Rotate(gyro.rotationRate.x * Time.deltaTime * speed * -1, 0f, gyro.rotationRate.y * Time.fixedDeltaTime * speed * 2 * -1);
            }
            

        
            Debug.Log(plat.transform.rotation);

        }
        else { Debug.Log("Gyro no detect"); }
    }

    
}
