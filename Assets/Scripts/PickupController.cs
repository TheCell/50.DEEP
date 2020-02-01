using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupController : MonoBehaviour
{
    public UnityEvent enterPickupRange;
    public UnityEvent exitPickupRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterPickupRange.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitPickupRange.Invoke();
    }

}
