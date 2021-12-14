using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbayeController : MonoBehaviour
{
    public MeshCollider door1;
    public MeshCollider door2;
    public MeshCollider door3;

    public GameObject maze;
    [SerializeField]
    protected int taquin = 0;

    protected int ballMaze = 0;

    protected int item1 = 0;
    protected int item2 = 0;
    protected int item3 = 0;
    protected int item4 = 0;

    protected bool collectAll = false;

    protected int lastItem1 = 0;
    protected int lastItem2 = 0;

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
        if (PlayerPrefs.HasKey("Collect"))
        {
            if(PlayerPrefs.GetInt("Collect") == 1)
            {
                collectAll = true;
                itemMoveDown(1);
                itemMoveDown(2);
                itemMoveDown(3);
                itemMoveDown(4);
            }
        }
    }

    // getter
    public int getItem1()
    {
        return item1;
    }
    public int getItem2()
    {
        return item2;
    }
    public int getItem3()
    {
        return item3;
    }
    public int getItem4()
    {
        return item4;
    }
    public int getLastItem1()
    {
        return lastItem1;
    }
    public int getLastItem2()
    {
        return lastItem2;
    }
    public int getTaquin()
    {
        return taquin;
    }
    public int getMaze()
    {
        return ballMaze;
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
    public void setLastItem1()
    {
        lastItem1++;
    }
    public void setLastItem2()
    {
        lastItem2++;
    }
    public void setTaquin()
    {
        taquin++;
    }
    public void setMaze()
    {
        ballMaze++;
    }

    private void Start()
    {
        maze.SetActive(false);
        if (collectAll)
        {
            item1 = 2;
            item2 = 2;
            item3 = 2;
            item4 = 2;
        }
    }

    public void itemMoveDown(int id)
    {
        item[id - 1].transform.Translate(0, -15, 0);
    }

    public void itemMove(int id, Vector3 obj)
    {
        item[id - 1].transform.Translate(obj);  
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
            Debug.Log("bup");
            taquin = 2;
        }

        if (ballMaze == 1)
        {
            door2.transform.localPosition.Set(door2.transform.localPosition.x, door2.transform.localPosition.y + 3f, door2.transform.localPosition.z);
            ballMaze = 2;
        }

        if (item1 == 2 && item2 == 2 && item3 == 2 && item4 ==2)
        {
            maze.SetActive(true);
        }

        if (lastItem1 == 2 && lastItem2 == 2)
        {
            door3.transform.localPosition.Set(door3.transform.localPosition.x, door3.transform.localPosition.y + 1, door3.transform.localPosition.z);
        }
    }

}
