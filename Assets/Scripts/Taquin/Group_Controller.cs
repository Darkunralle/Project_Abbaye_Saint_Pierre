using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group_Controller : MonoBehaviour
{
    Vector3 pos;
    int objectId;

    public void setObjectId(int _id)
    {
        objectId = _id;
    }

    public void setPos(Vector3 _pos)
    {
        pos = _pos;
        transform.Translate(pos.x,pos.y,pos.z);
    }

}
