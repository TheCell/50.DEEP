using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillResources
{

    private int caramel { get; set; }
    private int kaese { get; set; }
    private int kaugummi { get; set; }
    private int salat { get; set; }
    private int zucker { get; set; }

    public DrillResources()
    {
        caramel = 0;
        kaese = 0;
        kaugummi = 0;
        salat = 0;
        zucker = 0;
    }

    public void AddRessource(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Caramel:
                caramel += 1;
                break;
            case ResourceType.Kaese:
                kaese += 1;
                break;
            case ResourceType.Kaugummi:
                kaugummi += 1;
                break;
            case ResourceType.Salat:
                salat += 1;
                break;
            case ResourceType.Zucker:
                zucker += 1;
                break;
            default:
                break;
        }
    }
}
