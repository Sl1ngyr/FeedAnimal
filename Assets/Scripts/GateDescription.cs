using UnityEngine;

public enum GateType // теги для визначення об'єкта
{
    Player,
    Food,
    Animal,
    Wall,
    FastAnimal
}

public class GateDescription : MonoBehaviour
{
    public GateType gateType;
}
