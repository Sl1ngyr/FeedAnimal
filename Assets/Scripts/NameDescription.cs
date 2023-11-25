using UnityEngine;

public enum NameType // теги для визначення об'єкта
{
    Player,
    Food,
    Animal,
    Wall,
}

public class NameDescription : MonoBehaviour
{
    public NameType nameType;
}
