using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractionButton : MonoBehaviour
{
    public Inventory inventaire;
    public List<InterractiveObject> items;
    public GameObject player;
    public AbbayeController ctrl;

    private List<InterractiveObject> collectible;
    
    private float distanceGet = 2.5f;
    private float distance;
    private int compteur = 0;
    private void Awake()
    {
        foreach (InterractiveObject item in items)
        {
            if((item.id>0 && item.id < 5 ) && item.typeObject == "Collectible")
            {
                collectible.Add(item);
            }
        }
        if (PlayerPrefs.HasKey("Taquin"))
        {
            if (PlayerPrefs.GetInt("Taquin") == 1)
            {
                foreach (InterractiveObject item in items)
                {
                    
                    if (item.typeObject == "Taquin")
                    {
                        item.inactive();
                    }
                }
            }
        }
        else if (PlayerPrefs.HasKey("Maze"))
        {
            if (PlayerPrefs.GetInt("Maze") == 1)
            {
                foreach (InterractiveObject item in items)
                {
                    foreach (InterractiveObject colect in collectible)
                    {
                        if (item.id == colect.id && item.typeObject == "Pillar")
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 1f, item.transform.position.z);
                        }
                        else if (item.id == 2)
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 0.75f, item.transform.position.z);
                        }
                        else if (item.id == 3)
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 0.25f, item.transform.position.z);
                            colect.transform.rotation = new Quaternion(-90, 0, 0, 0);
                        }
                        else if (item.id == 4)
                        {
                            colect.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - 1f, item.transform.position.z);
                        }
                    }
                    if (item.typeObject == "Maze" || (item.id >0 && item.id < 5))
                    {
                        item.inactive();
                    }
                }
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
}
