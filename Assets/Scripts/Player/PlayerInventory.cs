using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory: MonoBehaviour
{

    public GameObject inventory = null;


    public void AddItem(GameObject item)
    {
        inventory = item;
    }

    public void RemoveItem()
    {
        inventory = null;
    }
}
