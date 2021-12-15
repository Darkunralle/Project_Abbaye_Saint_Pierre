using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HZ : MonoBehaviour
{
    public GameObject spawn;
    private void OnTriggerEnter(Collider ball)
    {
        Debug.Log("Bonk");
        ball.transform.position = spawn.transform.position;
    }
}
