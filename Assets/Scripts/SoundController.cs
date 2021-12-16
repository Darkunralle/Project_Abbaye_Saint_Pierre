using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource tutop2;
    public AudioSource fourObj;

    public void playTutoP2()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        tutop2.Play();

    }

    public void play4Obj()
    {
        fourObj.Play();
    }
}
