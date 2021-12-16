using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractionButton : MonoBehaviour
{
    public Inventory inventaire;
    public List<InterractiveObject> items;
    public GameObject player;
    public AbbayeController ctrl;
    public SoundController sound;
    public List<InterractiveObject> collectible;
    
    private float distanceGet = 4f;
    private float distance;
    [SerializeField]
    private int compteur = 0;
    private void Awake()
    {
        foreach (InterractiveObject row in items)
        {
            row.initalPos = row.transform.position;
            row.initalRot = row.transform.rotation;
        }
        if (PlayerPrefs.HasKey("Taquin"))
        {
            if (PlayerPrefs.GetInt("Taquin") == 1)
            {
                Debug.Log("Taquin 1");
                foreach (InterractiveObject item in items)
                {
                    
                    if (item.typeObject == "Taquin")
                    {
                        item.inactive();
                    }
                }
                
            }
            if(PlayerPrefs.GetInt("Maze") != 1)
            {
                sound.playTutoP2();
            }
            
        }
        if (PlayerPrefs.HasKey("Maze"))
        {
            if (PlayerPrefs.GetInt("Maze") == 1)
            {
                Debug.Log("Maze 1");
                foreach (InterractiveObject item in items)
                {
                    foreach (InterractiveObject colect in collectible)
                    {
                        if (item.id ==  1 && colect.id == 1 && item.typeObject == "Pillar")
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 1f, item.transform.position.z);
                        }
                        else if (item.id == 2 && colect.id == 2 && item.typeObject == "Pillar")
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 0.75f, item.transform.position.z);
                        }
                        else if (item.id == 3 && colect.id == 3 && item.typeObject == "Pillar")
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 0.25f, item.transform.position.z);
                            colect.transform.rotation = new Quaternion(-90, 0, 0, 0);
                        }
                        else if (item.id == 4 && colect.id == 4 && item.typeObject == "Pillar")
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 1f, item.transform.position.z);
                        }
                    }
                    if (item.typeObject == "Maze" || (item.id >0 && item.id < 5))
                    {
                        item.inactive();
                    }
                }
                compteur = 4;
            }
        }

        if (PlayerPrefs.HasKey("PlayerX"))
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        }

    }

    public void buttonPress()
    {
        foreach (InterractiveObject item in items)
        {
            distance = Vector3.Distance(item.transform.position,player.transform.position);

            if(distance < distanceGet)
            {
                Debug.Log(inventaire.isEmpty());
                if(item.typeObject == "Collectible" && inventaire.isEmpty() && item.getState())
                {
                    sound.playGetEffect();
                    item.collect();
                    inventaire.changeBagState(false);
                    inventaire.manageInventory(item);
                }
                else if(item.typeObject == "Pillar" && inventaire.isEmpty() == false && item.getState())
                {
                    if (item.collectReturn(inventaire.getItem()))
                    {
                        inventaire.dropInventory();
                        inventaire.changeBagState(true);
                        compteur++;
                        if(compteur == 1)
                        {
                            sound.playNara1();
                        }
                        else if (compteur == 2)
                        {
                            sound.playNara2();
                        }
                        else if (compteur == 3)
                        {
                            sound.playNara3();
                        }
                        else if (compteur == 4)
                        {
                            sound.play4Obj();
                        }
                    }
                    else { Debug.Log("Pas le bon pillier"); }
                }else if(item.typeObject == "Taquin" &&  item.getState())
                {
                    setPosPlayer();
                    ctrl.setTaquin();
                    item.collect();
                }
                else if (item.typeObject == "Maze" && item.getState() && compteur == 4)
                {
                    setPosPlayer();
                    ctrl.setMaze();
                    item.collect();
                }
            }
        }
    }

    private void Update()
    {
        if (compteur == 6)
        {
            ctrl.setFinalDoorState();
        }
    }

    public void setPosPlayer()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
    }

    private void restart()
    {
        player.transform.position = new Vector3(58.5f, -0.9f, -19.5f);
        foreach (InterractiveObject row in items)
        {
            row.transform.position = row.initalPos;
            row.transform.rotation = row.initalRot;
            row.activate();
            compteur = 0;
        }
    }
}
