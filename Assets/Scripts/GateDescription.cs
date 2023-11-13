using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateType
{
    Player,
    Food,
    Animal,
    Wall
}

public class GateDescription : MonoBehaviour
{
    public GateType gateType;
}
