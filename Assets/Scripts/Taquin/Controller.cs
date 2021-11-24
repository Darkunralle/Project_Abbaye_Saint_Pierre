using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    public string name;
    public List<GameObject> piece;
    int id;

    public void setId(int _id)
    {
        id = _id;
    }

    public void OnMouseDown()
    {
        piece[id-1].GetComponent<Object>().translate(name);
    }

}
