using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaquinInterract : MonoBehaviour
{

    bool ifClicked = false;
    float range = 5f;
    public GameObject _player;
    public GameObject button;

    private void Update()
    {
        Debug.Log(ifClicked);
        if ((Mathf.Abs(Vector3.Distance(this.transform.position, _player.transform.position)) < range)&& (ifClicked == false))
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
    public void loadTaquin()
    {
        SceneManager.LoadScene(1);
    }

    public void clicked()
    {
        ifClicked = true;
    }
}
