using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartScreenController : MonoBehaviour
{
    public GameObject pageOne;
    public GameObject pageTwo;
    public GameObject startScreen;

    void Start()
    {
        pageTwo.SetActive(false);
        pageOne.SetActive(true);
    }

    public void goToTwo()
    {
        pageOne.SetActive(false);
        pageTwo.SetActive(true);
    }

    public void play()
    {
        startScreen.SetActive(false);
    }
}
