using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour
{
    private InputManager controls;
    public float maxbatteryCharge = 100f;
    public float batteryCharge;
    //public Text chargeText;
    private bool isCharging = false;
    public float regenAmount = 1.0f;
    public float decreasingAmount = 1.0f;
    public GameObject charger;

    // Start is called before the first frame update
    void Start()
    {
        batteryCharge = maxbatteryCharge;
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryCharge > 0)
        {
            batteryCharge -= decreasingAmount * Time.deltaTime;

        }

        //Debug.Log(batteryCharge);
        //chargeText.text = batteryCharge.ToString();

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Charger"))
        {
            isCharging = true;
            charger = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Charger"))
        {
            isCharging = false;
            charger = null;
        }
    }

    void Interact()
    {
        if (isCharging)
        {
            StartCoroutine(Charging());
        }
    }

    IEnumerator Charging()
    {
        Debug.Log(batteryCharge);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<InputHandling>().enabled = false;
        charger.GetComponent<Animator>().SetBool("isRecharging", true);
        yield return new WaitForSeconds(4.0f);
        gameObject.GetComponent<InputHandling>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        charger.GetComponent<Animator>().SetBool("isRecharging", false);
        batteryCharge = maxbatteryCharge;
        Debug.Log(batteryCharge);

    }


    private void Awake()
    {
        controls = new InputManager();
        controls.Player.Interact.performed += ctx => Interact();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


}
