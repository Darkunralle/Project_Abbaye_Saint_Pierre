using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group_Controller : MonoBehaviour
{
    public List<GameObject> controllerList;

    private void Start()
    {
        for(int i = 0; i < controllerList.Count; i++)
        {
            controllerList[i].SetActive(false);
        }
        
    }

    public void directionOn(List<bool> directionList, int id)
    {
        for(int i = 0; i < directionList.Count; i++)
        {
            if(directionList[i] == true)
            {
                controllerList[i].SetActive(true);
                //controllerList[i].setId(id);
            }
        }
    }

}
