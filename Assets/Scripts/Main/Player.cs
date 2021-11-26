using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    protected FixedJoystick joystick;
    public int speed;
    float xrotation = 0f;

    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float xrot = joystick.Horizontal *speed* Time.deltaTime;
        float yrot = joystick.Vertical * speed * Time.deltaTime;

        xrotation -= yrot;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);


        body.Rotate(Vector3.up * xrot);
    }
}
