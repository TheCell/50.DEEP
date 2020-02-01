using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrillController : MonoBehaviour
{
    //[Header("Events")]
    //[Space]
    //public UnityEvent foundOre;

    private DrillResources dr;

    // Start is called before the first frame update
    void Start()
    {
        dr = new DrillResources();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ResourceLogic rl = other.gameObject.GetComponent<ResourceLogic>();

        if(rl != null)
        {
            dr.AddRessource(rl.typeOfResource);
        }
    }
}
