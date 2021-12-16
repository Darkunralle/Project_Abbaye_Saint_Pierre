using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void restart()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("aaaa");
        SceneManager.LoadScene(0);
    }
}
