﻿using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRepairLogic : MonoBehaviour
{
    [SerializeField] private ResourceType typeOfResourceForRepair;
    [SerializeField] private float minimumTimeBetweenDamage = 5f;
    [SerializeField] private float maximumTimeBetweenDamage = 15f;
    private DrillResources currentObjectResource;
    private float nextDamageTime;

    public bool DoesDamage()
    {
        bool isDamaging = false;
        int currentHealth = 100;

        switch (typeOfResourceForRepair)
        {
            case ResourceType.Antrieb:
                currentHealth = currentObjectResource.Antrieb;
                break;
            case ResourceType.Baumaterial:
                currentHealth = currentObjectResource.Baumaterial;
                break;
            case ResourceType.Wasser:
                currentHealth = currentObjectResource.Wasser;
                break;
        }

        if (currentHealth < 1)
        {
            isDamaging = true;
        }

        return isDamaging;
    }

    private void Start()
    {
        currentObjectResource = new DrillResources();

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

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            DrillResources playerResources = new DrillResources(50, 50, 50);
            DrillResources playerResAfter = Repair(playerResources);

            Debug.Log(
                "playerResources before"
                + "Antrieb " + playerResources.Antrieb
                + " baumat " + playerResources.Baumaterial
                + " wasser " + playerResources.Wasser);
            Debug.Log(
                "playerResources after"
                + "Antrieb " + playerResAfter.Antrieb
                + " baumat " + playerResAfter.Baumaterial
                + " wasser " + playerResAfter.Wasser);
        }
    }

    private void UpdateNextDamageTime()
    {
        float randomSeconds = Random.Range(minimumTimeBetweenDamage, maximumTimeBetweenDamage);
        this.nextDamageTime = Time.time + randomSeconds;
    }

    public DrillResources Repair(DrillResources playerResources)
    {

        DrillResources resourceReduction = new DrillResources();

        switch (typeOfResourceForRepair)
        {
            case ResourceType.Antrieb:
                int amountAntriebMissing = 100 - currentObjectResource.Antrieb;
                GetComponent<AudioSource>().Play();
                if (playerResources.Antrieb >= amountAntriebMissing)
                {
                    // player has the amount or more in inventory. Reduce inventory
                    currentObjectResource.Antrieb = 100;
                    resourceReduction.Antrieb = -amountAntriebMissing;
                }
                else
                {
                    // player has less resource then needed. Only repairing the amount hold
                    int stillAmountMissing = amountAntriebMissing - playerResources.Antrieb;
                    resourceReduction.Antrieb = - playerResources.Antrieb;
                    currentObjectResource.Antrieb = 100 - stillAmountMissing;
                }
                break;
            case ResourceType.Baumaterial:
                //int amountBaumaterialMissing = 100 - currentObjectResource.Baumaterial;
                currentObjectResource.Baumaterial = 100;
                GetComponent<AudioSource>().Play();

                //if (playerResources.Antrieb >= amountBaumaterialMissing)
                //{
                //    // player has the amount or more in inventory. Reduce inventory
                //    currentObjectResource.Baumaterial = 100;
                //    resourceReduction.Baumaterial = -amountBaumaterialMissing;
                //}
                //else
                //{
                //    // player has less resource then needed. Only repairing the amount hold
                //    int stillAmountMissing = amountBaumaterialMissing - playerResources.Baumaterial;
                //    resourceReduction.Baumaterial = -playerResources.Baumaterial;
                //}
                break;
            case ResourceType.Wasser:
                int amountWasserMissing = 100 - currentObjectResource.Wasser;
                GetComponent<AudioSource>().Play();

                if (playerResources.Wasser >= amountWasserMissing)
                {
                    // player has the amount or more in inventory. Reduce inventory
                    currentObjectResource.Wasser = 100;
                    resourceReduction.Wasser = -amountWasserMissing;
                }
                else
                {
                    // player has less resource then needed. Only repairing the amount hold
                    int stillAmountMissing = amountWasserMissing - playerResources.Wasser;
                    resourceReduction.Wasser = -playerResources.Wasser;
                    currentObjectResource.Wasser = 100 - stillAmountMissing;
                }
                break;
        }
        
        UpdateSprites();
        playerResources.AddResource(resourceReduction);
        Debug.Log(
    "Object ressources after"
    + "Antrieb " + currentObjectResource.Antrieb
    + " baumat " + currentObjectResource.Baumaterial
    + " wasser " + currentObjectResource.Wasser);
        return playerResources;
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

        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetInteger("Health", currentAmount);
        }
        else
        {
            Debug.LogError("no Animator");
        }
    }

    private void GetDamaged()
    {
        int amountOfDamage = Random.Range(0, 20);

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
    }
}
