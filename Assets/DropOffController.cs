using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffController : MonoBehaviour
{

    public void DoInteraction(GameObject player)
    {
        player.GetComponent<PlayerInventory>().RemoveItem(gameObject);

    }
}
