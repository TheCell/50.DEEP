using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{

    public ResourceType type;

    public void DoInteraction(GameObject player)
    {
        player.GetComponent<PlayerInventory>().AddItem(type);
        GetComponent<AudioSource>().Play();
    }
}
