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

    private void Start()
    {
        dr = new DrillResources();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResourceLogic rl = other.gameObject.GetComponent<ResourceLogic>();

        if(rl != null)
        {
            dr.AddResource(rl.drillResources);
        }

        Destroy(other.gameObject);
    }
}
