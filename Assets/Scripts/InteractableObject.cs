using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

}
