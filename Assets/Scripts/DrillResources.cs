using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillResources
{
    private int antrieb;
    private int baumaterial;
    private int wasser;
    public DrillResources()
    {
        Antrieb = 0;
        Baumaterial = 0;
        Wasser = 0;
    }

    public int Antrieb { get => antrieb; set => antrieb = value; }
    public int Baumaterial { get => baumaterial; set => baumaterial = value; }
    public int Wasser { get => wasser; set => wasser = value; }

    public void AddResource(DrillResources resources)
    {
        this.Antrieb += resources.Antrieb;
        this.Baumaterial += resources.Baumaterial;
        this.Wasser += resources.Wasser;
    }
}
