using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory: MonoBehaviour
{

    public DrillResources dr;
    public int maxAmount = 100;

    private void Start()
    {
        dr = new DrillResources();
    }

    public void AddItem(ResourceType type)
    {

        Withdraw(dr, type);

        //Debug.Log(dr.Antrieb + " " + dr.Baumaterial + " " + dr.Wasser);
        //Debug.Log(DrillController.dr.Antrieb + " " + DrillController.dr.Baumaterial + " " + DrillController.dr.Wasser);
    }

    public void RemoveItem(GameObject other)
    {

        dr = other.GetComponent<ObjectRepairLogic>().Repair(dr);

        //Debug.Log(dr.Antrieb + " " + dr.Baumaterial + " " + dr.Wasser);
    }


    private DrillResources Withdraw (DrillResources playerResources, ResourceType type)
    {
        DrillResources controller = DrillController.dr;

        switch (type)
        {
            case ResourceType.Antrieb:
                int amountAntriebMissing = maxAmount - playerResources.Antrieb;

                
                if (controller.Antrieb >= amountAntriebMissing)
                {
                    // Ship has enough in Storage to fill up Player Inventory
                    controller.Antrieb -= amountAntriebMissing;
                    playerResources.Antrieb = maxAmount;
                } else
                {
                    playerResources.Antrieb += controller.Antrieb;
                    controller.Antrieb = 0;

                }          
                break;
            case ResourceType.Baumaterial:
                int amountBaumaterialMissing = maxAmount - playerResources.Baumaterial;

                if (controller.Baumaterial >= amountBaumaterialMissing)
                {
                    controller.Baumaterial -= amountBaumaterialMissing;
                    playerResources.Baumaterial = maxAmount;
                }
                else
                {
                    playerResources.Baumaterial += controller.Baumaterial;
                    controller.Baumaterial = 0;

                }
                break;
            case ResourceType.Wasser:
                int amountWasserMissing = maxAmount - playerResources.Wasser;

                if (controller.Wasser >= amountWasserMissing)
                {
                    controller.Wasser -= amountWasserMissing;
                    playerResources.Wasser = maxAmount;
                }
                else
                {
                    playerResources.Wasser += controller.Wasser;
                    controller.Wasser = 0;

                }
                break;
        }

        return playerResources;
    }
}
