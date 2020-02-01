using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PickupController : MonoBehaviour
{

    //private InputManager controls;
    //private bool pickupAllowed = false;

    //private void Update()
    //{
        
    //}

    //private void Awake()
    //{
    //    controls = new InputManager();
    //    controls.Player.Interact.performed += ctx => Pickup();
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("enter pickup");
    //        pickupAllowed = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("exit pickup");
    //        pickupAllowed = false;
    //    }
    //}

    //private void Pickup()
    //{
    //    if (pickupAllowed)
    //    {
    //        Debug.Log("pickup");
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnEnable()
    //{
    //    controls.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.Disable();
    //}
}
