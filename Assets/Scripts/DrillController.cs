using System;
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
    private int sugarAmount = 100;

    private void Start()
    {
        dr = new DrillResources();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(sugarAmount > 0)
        {
            this.transform.position = (Vector2)this.transform.position + direction.normalized * Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        RotateTowardsDirection();
    }

    private void RotateTowardsDirection()
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

        Vector2 newGravity = direction.normalized * 9.81f;
        Physics2D.gravity = newGravity;
        // Debug.DrawLine(transform.position, Physics2D.gravity * 2);
        // Debug.Log(Physics2D.gravity);
    }

    IEnumerator BurnSugar()
    {
        while (true)
        {
            sugarAmount -= 1;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddSugar(int amount)
    {
        sugarAmount += amount;
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
