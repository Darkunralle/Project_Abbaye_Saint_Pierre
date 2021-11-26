using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour
{

    public int id;
    Group_Controller control;
    GameController game;

    // Up, Right, Down, Left
    List<bool> check = new List<bool> { false, false, false, false };


    public void OnMouseDown()
    {
        Debug.Log("Pick");
        UpdateMove(game.check(id, check));
        control.directionOn(check, id);
        resetCheck();
    }

    public void updateall()
    {
        UpdateMove(game.check(id, check));
        control.directionOn(check, id);
        resetCheck();
    }

    // Getter & Setter 
    public List<bool> getCheck()
    {
        return check;
    }

    public void resetCheck()
    {
        check = new List<bool> { false, false, false, false };
        
    }

    public void UpdateMove(List<bool> _check)
    {
        for (int i = 0; i < 4; i++)
        {
            check[i] = _check[i];
        }
    }

    public void translate(string direction)
    {
        if (direction == "up")
        {
            transform.Translate(0,0,-1);
        }
        else if(direction == "right")
        {
            transform.Translate(-1,0,0);
        }
        else if(direction == "down")
        {
            transform.Translate(0,0,1);
        }
        else if(direction == "left")
        {
            transform.Translate(1,0,0);
        }

        control.directionOff();

        game.matriceUpdate(direction, id);

        updateall();

        

        
    }

    private void Start()
    {
        control = FindObjectOfType<Group_Controller>();
        game = FindObjectOfType<GameController>();
    }

}
