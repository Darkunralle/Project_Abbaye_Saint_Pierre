using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour, IPointerClickHandler
{
    public string name;
    public List<GameObject> piece;
    int id;

    public void setId(int _id)
    {
        id = _id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        piece[id - 1].GetComponent<Object>().translate(name);
    }
}
