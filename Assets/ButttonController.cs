using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButttonController : MonoBehaviour
{
    public UnityEvent ButtonPressed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ButtonPressed.Invoke();
        }
    }

    // Just some debugging stuff
    //private void Update()
    //{
    //    if (Keyboard.current.gKey.isPressed)
    //    {
    //        ButtonPressed.Invoke();
    //    }
    //}
}
