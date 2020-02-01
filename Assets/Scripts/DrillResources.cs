using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillResources
{
    private int caramel;
    private int kaese;
    private int kaugummi;
    private int salat;
    private int zucker;
    public int Caramel { get => caramel; set => caramel = value; }
    public int Kaese { get => kaese; set => kaese = value; }
    public int Kaugummi { get => kaugummi; set => kaugummi = value; }
    public int Salat { get => salat; set => salat = value; }
    public int Zucker { get => zucker; set => zucker = value; }

    public DrillResources()
    {
        Caramel = 0;
        Kaese = 0;
        Kaugummi = 0;
        Salat = 0;
        Zucker = 0;
    }

    public void AddResource(DrillResources resources)
    {
        this.Caramel += resources.Caramel;
        this.Kaese += resources.Kaese;
        this.Kaugummi += resources.Kaugummi;
        this.Salat += resources.Salat;
        this.Zucker += resources.Zucker;
    }
}
