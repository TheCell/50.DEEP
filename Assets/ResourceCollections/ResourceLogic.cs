using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLogic : MonoBehaviour
{
    public ResourceType typeOfResource;
    public DrillResources drillResources;
    [SerializeField] private Sprite[] spritesForTypes;
    private SpriteRenderer spriteRenderer;

    public void SetResourceType(ResourceType type)
    {
        typeOfResource = type;
        UpdateSprite();
        UpdateDrillResource();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        drillResources = new DrillResources();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void UpdateDrillResource()
    {
        switch (typeOfResource)
        {
            case ResourceType.Zucker:
                drillResources.Zucker = 1;
                break;
            case ResourceType.Salat:
                drillResources.Salat = 1;
                break;
            case ResourceType.Kaugummi:
                drillResources.Kaugummi = 1;
                break;
            case ResourceType.Kaese:
                drillResources.Kaese = 1;
                break;
            case ResourceType.Caramel:
                drillResources.Caramel = 1;
                break;
            default:
                break;
        }
    }

    private void UpdateSprite()
    {
        switch(typeOfResource)
        {
            case ResourceType.Zucker:
                // spriteRenderer.color = new Color(1f, 1f, 1f);
                spriteRenderer.sprite = spritesForTypes[0];
                break;
            case ResourceType.Salat:
                // spriteRenderer.color = new Color(0.3f, .88f, 0.3f);
                spriteRenderer.sprite = spritesForTypes[1];
                break;
            case ResourceType.Kaugummi:
                // spriteRenderer.color = new Color(0.89f, 0.37f, 0.77f);
                spriteRenderer.sprite = spritesForTypes[2];
                break;
            case ResourceType.Kaese:
                // spriteRenderer.color = new Color(0.87f, 0.87f, 0.12f);
                spriteRenderer.sprite = spritesForTypes[3];
                break;
            case ResourceType.Caramel:
                // spriteRenderer.color = new Color(0.9716981f, 0.6696121f, 0.3529281f);
                spriteRenderer.sprite = spritesForTypes[4];
                break;
            default:
                break;
        }
    }
}
