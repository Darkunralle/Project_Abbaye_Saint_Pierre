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
        //piece[id].translate(id);
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
