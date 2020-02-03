﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Player.GetComponent<PlayerMovement>().isGrounded = true;
            Player.GetComponent<PlayerMovement>().PlayLandingSound();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
