using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipMaxValues", order = 1)]
public class ShipMaxValues : ScriptableObject
{
    public string shipName = "no name :(";
    public int maxShipHP = 100;
    public int maxAntriebContainer = 200;
    public int maxBaumaterialContainer = 200;
    public int maxWasserContainer = 200;
}
