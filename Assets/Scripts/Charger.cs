using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Charge>().isCharging = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Charge>().isCharging = false;
    }
}
