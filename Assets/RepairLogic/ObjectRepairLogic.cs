using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRepairLogic : MonoBehaviour
{
    [SerializeField] private ResourceType typeOfResourceForRepair;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float minimumTimeBetweenDamage = 5f;
    [SerializeField] private float maximumTimeBetweenDamage = 15f;
    private DrillResources currentObjectResource;
    private SpriteRenderer spriteRenderer;
    private float nextDamageTime;

    private void Start()
    {
        currentObjectResource = new DrillResources();
        spriteRenderer = GetComponent<SpriteRenderer>();

        switch(typeOfResourceForRepair)
        {
            case ResourceType.Antrieb:
                currentObjectResource.Antrieb = 100;
                break;
            case ResourceType.Baumaterial:
                currentObjectResource.Baumaterial = 100;
                break;
            case ResourceType.Wasser:
                currentObjectResource.Wasser = 100;
                break;
            default:
                break;
        }
        
        UpdateNextDamageTime();
    }

    private void Update()
    {
        if (Time.time > nextDamageTime)
        {
            GetDamaged();
            UpdateSprites();
            UpdateNextDamageTime();
        }

        // manual testing
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            GetDamaged();
            UpdateSprites();
        }

        // manual testing
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.LogError("todo: call this from event");
            Repair();
            UpdateSprites();
        }
    }

    private void UpdateNextDamageTime()
    {
        float randomSeconds = Random.Range(minimumTimeBetweenDamage, maximumTimeBetweenDamage);
        this.nextDamageTime = Time.time + randomSeconds;
    }

    private void Repair()
    {
        switch (typeOfResourceForRepair)
        {
            case ResourceType.Antrieb:
                DrillController.dr.Antrieb -= (100 - currentObjectResource.Antrieb);
                currentObjectResource.Antrieb = 100;
                break;
            case ResourceType.Baumaterial:
                DrillController.dr.Baumaterial -= (100 - currentObjectResource.Baumaterial);
                currentObjectResource.Baumaterial = 100;
                break;
            case ResourceType.Wasser:
                DrillController.dr.Wasser -= (100 - currentObjectResource.Wasser);
                currentObjectResource.Wasser = 100;
                break;
        }
    }

    private void UpdateSprites()
    {
        int currentAmount = 0;

        switch (typeOfResourceForRepair)
        {
            case ResourceType.Antrieb:
                currentAmount = currentObjectResource.Antrieb;
                break;
            case ResourceType.Baumaterial:
                currentAmount = currentObjectResource.Baumaterial;
                break;
            case ResourceType.Wasser:
                currentAmount = currentObjectResource.Wasser;
                break;
        }

        if (currentAmount > 80)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (currentAmount > 60)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (currentAmount > 0)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else
        {
            spriteRenderer.sprite = sprites[3];
        }
    }

    private void GetDamaged()
    {
        int amountOfDamage = Random.Range(0, 30);

        switch (typeOfResourceForRepair)
        {
            case ResourceType.Antrieb:
                currentObjectResource.Antrieb -= amountOfDamage;
                break;
            case ResourceType.Baumaterial:
                currentObjectResource.Baumaterial -= amountOfDamage;
                break;
            case ResourceType.Wasser:
                currentObjectResource.Wasser -= amountOfDamage;
                break;
        }
        
        Debug.Log("damaged");
    }
}
