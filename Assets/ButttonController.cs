using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButttonController : MonoBehaviour
{
    public Sprite buttonPressed;
    public UnityEvent ButtonPressed;
    public AudioClip buttonUp;
    public AudioClip buttonDown;

    private Sprite ButtonUp;
    private SpriteRenderer sr;
    private AudioSource audioSource;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        audioSource = this.GetComponent<AudioSource>();
        ButtonUp = sr.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(buttonDown);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.sprite = buttonPressed;
            ButtonPressed.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sr.sprite = ButtonUp;
            audioSource.PlayOneShot(buttonUp);
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
