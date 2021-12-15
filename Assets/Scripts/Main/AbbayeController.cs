using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbayeController : MonoBehaviour
{
    public MeshCollider door1;
    public MeshCollider door2;
    public MeshCollider door3;
    
    public GameObject maze;
    protected int taquin = 0;

    protected int ballMaze = 0;

    protected int item1 = 0;
    protected int item2 = 0;
    protected int item3 = 0;
    protected int item4 = 0;

    protected bool openFinalDoor = false;

    public List<MeshCollider> item;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Taquin"))
        {
            taquin = PlayerPrefs.GetInt("Taquin");
        }
        if (PlayerPrefs.HasKey("Maze"))
        {
            ballMaze = PlayerPrefs.GetInt("Maze");
        }
    }

    // setter
    public void setItem1()
    {
        item1++;
    }
    public void setItem2()
    {
        item2++;
    }
    public void setItem3()
    {
        item3++;
    }
    public void setItem4()
    {
        item4++;
    }
    public void setTaquin()
    {
        taquin++;
    }
    public void setMaze()
    {
        ballMaze++;
    }

    public void setFinalDoorState()
    {
        openFinalDoor = true;
    }

    public void itemMove(int id, Vector3 obj)
    {
        item[id].transform.Translate(obj);  
    }

    public void resetPref()
    {
        PlayerPrefs.DeleteAll();
    }

    void Update()
    { 
        if (taquin == 1)
        {
            door1.transform.position = new Vector3(door1.transform.position.x, door1.transform.position.y + 3f, door1.transform.position.z);
            Debug.Log("glonk");
            taquin = 2;
        }

        if (ballMaze == 1)
        {
            door2.transform.position = new Vector3(door2.transform.position.x, door2.transform.position.y + 3f, door2.transform.position.z);
            Debug.Log("glank");
            ballMaze = 2;
        }
        
        if (openFinalDoor)
        {
            door3.transform.position = new Vector3(door3.transform.position.x, door3.transform.position.y + 3f, door3.transform.position.z);
        }
    }

}
