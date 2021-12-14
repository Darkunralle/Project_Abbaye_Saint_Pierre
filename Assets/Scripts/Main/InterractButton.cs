using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InterractButton : MonoBehaviour , IPointerClickHandler
{
    public List<Interract> objectList;
    [SerializeField]
    protected int id;
    public void OnPointerClick(PointerEventData eventData)
    {
        objectList[id].buttonInteract();
    }

    public void setId(int _id)
    {
        id = _id;
    }

    public int getId()
    {
        return id;
    }
}
