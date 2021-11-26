using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadTaquin()
    {
        SceneManager.LoadScene(1);
    }
}
