using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButttonController : MonoBehaviour
{
    public Sprite buttonPressed;
    public UnityEvent ButtonPressed;

    private Sprite ButtonUp;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        ButtonUp = sr.sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.sprite = buttonPressed;
            ButtonPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sr.sprite = ButtonUp;
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
