using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject startScreen;
    public Gyro gyro;

    private void OnTriggerEnter(Collider ball)
    {
        winScreen.SetActive(true);
    }

    private void Start()
    {
        winScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void play()
    {
        startScreen.SetActive(false);

    }

    public void mainScene()
    {
        SceneManager.LoadScene(0);
    }
}
