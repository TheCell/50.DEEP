﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrillController : MonoBehaviour
{
    //[Header("Events")]
    //[Space]
    //public UnityEvent foundOre;
    public static DrillResources dr;

    private Vector2 direction = Vector2.down;
    private Rigidbody2D rb;

    private void Start()
    {
        dr = new DrillResources();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.transform.position = (Vector2)this.transform.position + direction.normalized * Time.fixedDeltaTime;
    }

    private void Update()
    {
        RotateTowardsDirection();
    }

    private void RotateTowardsDirection()
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        Physics.gravity = direction.normalized * -9.81f;
        Debug.Log(Physics.gravity);
    }

    public void Steer(float dir)
    {
        direction.x += dir * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResourceLogic rl = other.gameObject.GetComponent<ResourceLogic>();

        if(rl != null)
        {
            dr.AddResource(rl.drillResources);
            Destroy(other.gameObject);
        }

    }
}
