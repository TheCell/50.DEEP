using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChargerController : MonoBehaviour
{
    public UnityEvent startCharging;
    public UnityEvent stopCharging;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        startCharging.Invoke();
        //gameObject.GetComponent<Animator>().SetBool("isRecharging", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopCharging.Invoke();
        //gameObject.GetComponent<Animator>().SetBool("isRecharging", false);
    }
}
