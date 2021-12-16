using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource tutop2;
    public AudioSource fourObj;
    public AudioSource enter;
    public AudioSource voiceFinal;
    public AudioSource nara1;
    public AudioSource nara2;
    public AudioSource nara3;
    public AudioSource getEffect;

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

    public void playEnter()
    {
        enter.Play();
    }
    public void playFinal()
    {
        voiceFinal.Play();

    }
    public void playNara1()
    {
        nara1.Play();

    }
    public void playNara2()
    {
        nara2.Play();

    }
    public void playNara3()
    {
        nara3.Play();

    }
    public void playGetEffect()
    {
        getEffect.Play();

    }

}
