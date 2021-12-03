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
        int _id=0;
        int _id_temp=0;
        for(int i = 0; i < directionList.Count; i++)
        {
            if(directionList[i] == true)
            {
                controllerList[i].SetActive(true);
                controllerList[i].GetComponent<Controller>().setId(id);
                _id = controllerList[i].GetComponent<Controller>().getId();
                _id_temp = controllerList[i].GetComponent<Controller>().getIdTemp();
            }
        }

        for (int a = 0; a < directionList.Count; a++)
        {
            controllerList[a].GetComponent<Controller>().forceIdUp(_id, _id_temp);
        }
    }

    public void directionOff()
    {
        for (int i = 0; i < controllerList.Count; i++)
        {
            controllerList[i].SetActive(false);
        }
    }

}
