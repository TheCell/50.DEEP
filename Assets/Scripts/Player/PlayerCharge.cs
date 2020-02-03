using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sleepySprite;
    public float maxbatteryCharge = 100f;
    public float batteryCharge;
    private bool isCharging = false;
    public float regenAmount = 1.0f;
    public float decreasingAmount = 1.0f;
    public GameObject charger;
    private AudioSource audioSource;
    public AudioClip sleep;

    // Start is called before the first frame update
    void Start()
    {
        batteryCharge = maxbatteryCharge;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (batteryCharge > 0)
        {
            batteryCharge -= decreasingAmount * Time.deltaTime;
        }

        DisplaySleepyness();
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

    void OnInteract()
    {
        if (isCharging)
        {
            StartCoroutine(Charging());
        }
    }

    IEnumerator Charging()
    {
        //Debug.Log(batteryCharge);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        charger.GetComponent<Animator>().SetBool("isRecharging", true);
        audioSource.PlayOneShot(sleep);
        yield return new WaitForSeconds(3.5f);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        charger.GetComponent<Animator>().SetBool("isRecharging", false);
        batteryCharge = maxbatteryCharge;
        //Debug.Log(batteryCharge);

    }

    private void DisplaySleepyness()
    {
        if (sleepySprite == null)
        {
            return;
        }
        Color spriteColor = sleepySprite.color;

        if (batteryCharge < 70f)
        {
            spriteColor.a = 1f;
        }
        else
        {
            spriteColor.a = 0f;
        }

        sleepySprite.color = spriteColor;
    }
}
