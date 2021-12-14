using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interract : MonoBehaviour
{
    [SerializeField]
    bool ifClicked = false;
    float range = 2.5f;
    public GameObject _player;
    public GameObject button;
    public InterractButton interract;
    public int id;
    public string type = "none";

    public AbbayeController abbaye;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Taquin"))
        {
            if (PlayerPrefs.GetInt("Taquin") == 1 && type == "taquin")
            {
                ifClicked = true;
            }
        }
        else if (PlayerPrefs.HasKey("Maze"))
        {
            if (PlayerPrefs.GetInt("Maze") == 1 && (id != 5 && id != 6))
            {
                ifClicked = true;
            }
        }

        if (PlayerPrefs.HasKey("PlayerX"))
        {
            _player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        }
        
    }
    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        if (ifClicked == false)
        {
            if (type != "pillar")
            {
                calcul();
            }
            else
            {/*
                if (id == 0 && abbaye.getItem1() == 1)
                {
                    calcul();
                }
                if (id == 1 && abbaye.getItem2() == 1)
                {
                    calcul();
                }
                if (id == 2 && abbaye.getItem3() == 1)
                {
                    calcul();
                }
                if (id == 3 && abbaye.getItem4() == 1)
                {
                    calcul();
                }
                if (id == 10 && abbaye.getLastItem1() == 1)
                {
                    calcul();
                }
                if (id == 11 && abbaye.getLastItem2() == 1)
                {
                    calcul();
                }*/
            }
        }
        
        

    }

    public void calcul()
    {
        if ((Mathf.Abs(Vector3.Distance(this.transform.position, _player.transform.position)) < range) && (ifClicked == false))
        {
            button.SetActive(true);
            interract.setId(id);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void setPosPlayer()
    {
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", _player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", _player.transform.position.z);
    }

    public void buttonInteract()
    {
        if (ifClicked == false)
        {
            if (type == "taquin")
            {
                ifClicked = true;
                abbaye.setTaquin();
                setPosPlayer();
                SceneManager.LoadScene(1);
            }
            else if (type == "maze")
            {
                ifClicked = true;
                abbaye.setMaze();
                setPosPlayer();
                SceneManager.LoadScene(2);
            }
            else if (type == "collect")
            {
                if (id == 0)
                {
                    abbaye.setItem1();
                    abbaye.itemMoveDown(id);
                }
                if (id == 1)
                {
                    abbaye.setItem2();
                    abbaye.itemMoveDown(id);
                }
                if (id == 2)
                {
                    abbaye.setItem3();
                    abbaye.itemMoveDown(id);
                }
                if (id == 3)
                {
                    abbaye.setItem4();
                    abbaye.itemMoveDown(id);
                }
                if (id == 10)
                {
                    abbaye.setLastItem1();
                    abbaye.itemMoveDown(id);
                }
                if (id == 11)
                {
                    abbaye.setLastItem2();
                    abbaye.itemMoveDown(id);
                }

                ifClicked = true;
            }
            else if (type == "pillar")
            {
                if (id == 1 && abbaye.getItem1() == 1)
                {
                    abbaye.setItem1();
                    abbaye.itemMove(id, this.transform.position);
                }
                else if (id == 2 && abbaye.getItem2() == 1)
                {
                    abbaye.setItem2();
                    abbaye.itemMove(id, this.transform.position);
                }
                else if (id == 3 && abbaye.getItem3() == 1)
                {
                    abbaye.setItem3();
                    abbaye.itemMove(id, this.transform.position);
                }
                else if (id == 4 && abbaye.getItem4() == 1)
                {
                    abbaye.setItem4();
                    abbaye.itemMove(id, this.transform.position);
                }
                else if (id == 5 && abbaye.getLastItem1() == 1)
                {
                    abbaye.setLastItem1();
                    abbaye.itemMove(id, this.transform.position);
                }
                else if (id == 6 && abbaye.getLastItem2() == 1)
                {
                    abbaye.setLastItem2();
                    abbaye.itemMove(id, this.transform.position);
                }

                ifClicked = true;
            }
            else if (type == "none")
            {
                Debug.Log("Un type n'a pas �tait d�fini !");
            }
            button.SetActive(false);
        }
        

        
    }
}
