using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private InputManager controls;
    public GameObject interactableObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log(other.name);
            interactableObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if(other.gameObject == interactableObject)
            {
                Debug.Log(other.name);
                interactableObject = null;
            }
        }
    }

    void Interact()
    {
        if (interactableObject)
        {
            Debug.Log(interactableObject);
            gameObject.GetComponent<PlayerInventory>().AddItem(interactableObject);
            interactableObject.SendMessage("DoInteraction");
        }
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
