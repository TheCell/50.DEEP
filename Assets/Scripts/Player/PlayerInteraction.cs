using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //private InputManager controls;
    public GameObject interactableObject = null;
    private AudioSource audioSource;
    public AudioClip shortcut;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Vent"))
        {
            Debug.Log(other.name);
            interactableObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Vent"))
        {
            if(other.gameObject == interactableObject)
            {
                //Debug.Log(other.name);
                interactableObject = null;
            }
        }
    }

    IEnumerator Teleport()
    {
        //Debug.Log(interactableObject);
        GameObject[] vents = GameObject.FindGameObjectsWithTag("Vent");

        GameObject exitVent = null;
        for (int i = 0; i < vents.Length; i++)
        {
            if (vents[i].gameObject != interactableObject)
            {
                exitVent = vents[i].gameObject;
            }
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        audioSource.PlayOneShot(shortcut);
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.position = exitVent.transform.position;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

    void OnInteract()
    {
        if (interactableObject)
        {
            if (interactableObject.CompareTag("Vent"))
            {
                StartCoroutine(Teleport());
            } else if (interactableObject.CompareTag("Interactable"))
            {
                
                interactableObject.SendMessage("DoInteraction", gameObject);
            }

        }
    }

    //private void Awake()
    //{
    //    controls = new InputManager();
    //    controls.Player.Interact.performed += ctx => Interact();
    //}

    //private void OnEnable()
    //{
    //    controls.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.Disable();
    //}
}
