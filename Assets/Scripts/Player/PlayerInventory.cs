using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory: MonoBehaviour
{

    public DrillResources dr;

    private void Start()
    {
        dr = new DrillResources();
    }

    public void AddItem(ResourceType type)
    {
        
        switch (type)
        {
            case ResourceType.Antrieb:
                dr.Antrieb += 1;
                break;
            case ResourceType.Baumaterial:
                dr.Baumaterial += 1;
                break;
            case ResourceType.Wasser:
                dr.Wasser += 1;
                break;
        }

        DrillController.dr.Antrieb = -dr.Antrieb;
        DrillController.dr.Baumaterial = -dr.Baumaterial;
        DrillController.dr.Wasser = -dr.Wasser;

        Debug.Log(dr.Antrieb + " " + dr.Baumaterial + " " + dr.Wasser);
        Debug.Log(DrillController.dr.Antrieb + " " + DrillController.dr.Baumaterial + " " + DrillController.dr.Wasser);
    }

    public void RemoveItem(GameObject other)
    {

        dr = other.GetComponent<ObjectRepairLogic>().Repair(dr);

        Debug.Log(dr.Antrieb + " " + dr.Baumaterial + " " + dr.Wasser);
    }
}
