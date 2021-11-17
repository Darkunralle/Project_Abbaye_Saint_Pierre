using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour, IPointerClickHandler
{

    public int id;
    Group_Controller control;

    public void OnPointerClick(PointerEventData eventData)
    {
        control.setObjectId(id);
        Vector3 _pos
        control.setPos(_pos);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
