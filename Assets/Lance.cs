using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lance : MonoBehaviour
{
    private float distanceGet = 2.5f;
    private float distance;
    public SoundController sound;

    public GameObject player;
    public GameObject lance;
    public GameObject ui;

    public void button()
    {
        distance = Vector3.Distance(lance.transform.position, player.transform.position);
        if (distance < distanceGet)
        {
            ui.SetActive(true);
            sound.playFinal();
        }
    }
}
