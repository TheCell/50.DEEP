using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLogic : MonoBehaviour
{
    public ResourceType typeOfResource;
    public DrillResources drillResources;
    [SerializeField] private Sprite[] spritesForPower;
    [SerializeField] private Sprite[] spritesForBuildingMaterial;
    [SerializeField] private Sprite[] spritesForWater;
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
            case ResourceType.Antrieb:
                drillResources.Antrieb = 1;
                break;
            case ResourceType.Baumaterial:
                drillResources.Baumaterial = 1;
                break;
            case ResourceType.Wasser:
                drillResources.Wasser = 1;
                break;
            default:
                break;
        }
    }

    private void UpdateSprite()
    {
        switch(typeOfResource)
        {
            case ResourceType.Antrieb:
                // spriteRenderer.color = new Color(1f, 1f, 1f);
                spriteRenderer.sprite = spritesForPower[Random.Range(0, spritesForPower.Length)];
                break;
            case ResourceType.Baumaterial:
                // spriteRenderer.color = new Color(0.3f, .88f, 0.3f);
                spriteRenderer.sprite = spritesForBuildingMaterial[Random.Range(0, spritesForBuildingMaterial.Length)];
                break;
            case ResourceType.Wasser:
                // spriteRenderer.color = new Color(0.89f, 0.37f, 0.77f);
                spriteRenderer.sprite = spritesForWater[Random.Range(0, spritesForWater.Length)];
                break;
            default:
                break;
        }
    }
}
