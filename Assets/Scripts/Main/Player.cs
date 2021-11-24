using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    protected Joystick joystick;
    public int speed;

    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float xrot = joystick.Horizontal *speed* Time.deltaTime;
        body.Rotate(Vector3.up * xrot);
    }
}
