using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{
    public float maxbatteryCharge = 100f;
    public float batteryCharge;
    //public Text chargeText;
    public bool isCharging = false;
    public float regenAmount = 1.0f;
    public float decreasingAmount = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        batteryCharge = maxbatteryCharge;
        //InvokeRepeating("Battery", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Battery();
        
        Debug.Log(batteryCharge);
        //chargeText.text = batteryCharge.ToString();

        if (batteryCharge > 0)
        {
            gameObject.GetComponent<InputHandling>().isCharged = true;
            
        } else
        {
            gameObject.GetComponent<InputHandling>().isCharged = false;
        }

    }

    void Battery()
    {
        if (isCharging)
        {
            if (batteryCharge < maxbatteryCharge)
            {
                batteryCharge += regenAmount * Time.deltaTime;
            }
        } else
        {
            if (batteryCharge > 0)
            {
                batteryCharge -= decreasingAmount * Time.deltaTime; ;
            }
        }
 
    }

   
}
