using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        self.SetActive(false);
    }

    public void continuer()
    {
        self.SetActive(false);
    }

    public void menu()
    {
        self.SetActive(true);
    }

    public void restart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
