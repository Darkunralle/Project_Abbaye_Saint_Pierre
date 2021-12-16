using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbayeController : MonoBehaviour
{
    public MeshCollider door1;
    public MeshCollider door2;
    public MeshCollider door3;

    protected int taquin = 0;
    protected int ballMaze = 0;

    protected bool openFinalDoor = false;
    private bool doorOpen = false;

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
        
        if (openFinalDoor && doorOpen == false)
        {
            door3.transform.position = new Vector3(door3.transform.position.x, door3.transform.position.y + 3f, door3.transform.position.z);
            doorOpen = true;
        }
    }

}
