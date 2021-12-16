using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool empty = true;
    private InterractiveObject item;

    // getter
    public bool isEmpty()
    {
        return empty;
    }
    public InterractiveObject getItem()
    {
        return item;
    }

    // setter
    public void changeBagState(bool newState)
    {
        empty = newState;
    }
    public void manageInventory(InterractiveObject newItem)
    {
        item = newItem;
    }
    public void dropInventory()
    {
        item = null;
    }
}
