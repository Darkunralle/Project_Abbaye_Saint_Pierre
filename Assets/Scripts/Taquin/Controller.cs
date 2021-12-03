using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IPointerClickHandler
{
    public string name;
    public List<GameObject> piece;
    int id = 7;
    int id_temp = 7;

    private void Start()
    {
        /*
        for (int i = 0; i < piece.Count; i++)
        {
            piece[i].GetComponent<Object>().resetColor();
        }
        */
    }

    public int getId()
    {
        return id;
    }
    public int getIdTemp()
    {
        return id_temp;
    }

    public void forceIdUp(int _id, int _id_temp)
    {
        id = _id;
        id_temp = _id_temp;
    }
    public void setId(int _id)
    {
        id = _id;
        Debug.Log(id + " / " + id_temp);
        if (id != id_temp)
        {
            piece[id_temp - 1].GetComponent<Object>().resetColor();
        }
        id_temp = id;
        Debug.Log(id + " / " + id_temp);



        //Debug.Log(piece[id_temp - 1].GetComponent<Object>().id);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        piece[id - 1].GetComponent<Object>().translate(name);
    }
}
