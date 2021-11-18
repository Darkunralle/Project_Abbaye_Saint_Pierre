using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour, IPointerClickHandler
{

    public int id;
    Group_Controller control;
    GameController game;

    // Up, Right, Down, Left
    List<bool> check = new List<bool> { false, false, false, false };

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        UpdateMove(game.check(id, check));
        control.directionOn(check, id);
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
        for(int i = 0; i < 4; i++)
        {
            check[i] = _check[i];
        }
    }

    public void translate(string direction)
    {
        if (direction == "up")
        {
            transform.Translate(transform.position.x, transform.position.y, transform.position.z-1);
        }
        else if(direction == "right")
        {
            transform.Translate(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        else if(direction == "down")
        {
            transform.Translate(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        else if(direction == "left")
        {
            transform.Translate(transform.position.x + 1, transform.position.y, transform.position.z);
        }
    }

    private void Start()
    {
        control = FindObjectOfType<Group_Controller>();
        game = FindObjectOfType<GameController>();
    }
}
