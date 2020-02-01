using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrillController : MonoBehaviour
{
    //[Header("Events")]
    //[Space]
    //public UnityEvent foundOre;

    private int caramel = 0;
    private int kaese = 0;
    private int kaugummi = 0;
    private int salat = 0;
    private int zucker = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
            switch (rl.typeOfResource)
            {
                case ResourceType.Caramel:
                    caramel += 1;
                    break;
                case ResourceType.Kaese:
                    kaese += 1;
                    break;
                case ResourceType.Kaugummi:
                    kaugummi += 1;
                    break;
                case ResourceType.Salat:
                    salat += 1;
                    break;
                case ResourceType.Zucker:
                    zucker += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
