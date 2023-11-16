using SpawnManagerAnimal;
using UnityEngine;

public class SpawnPosAnimal : MonoBehaviour
{
    public static int countOfAnimal  = 0;
    public static int countPosAnimal = 0;
    
    private float spawnRangeX = 15;
    private float spawnRangeMinZ = 3;
    private float spawnRangeMaxZ = 15;
    private float spawnPosTopZ = 20;
    private float spawnPosSideX = 20;
    private float rotationSide = 90;

    private Quaternion basicRotationAnimal = new Quaternion(0, 180, 0, 0);
    private Vector3 spawnPosTop;
    private Vector3 spawnPosLeft;
    private Vector3 spawnPosRight;
    private Quaternion rotationLeftSide;
    private Quaternion rotationRightSide;
    
    public Vector3 SpawnPosTop => spawnPosTop;
    public Vector3 SpawnPosLeft => spawnPosLeft;
    public Vector3 SpawnPosRight => spawnPosRight;
    public Quaternion RotationLeftSide => rotationLeftSide;
    public Quaternion RotationRightSide => rotationRightSide;
    
    public void CreateAnimalSpawn(ref Animal animal, ref SpawnManager spawnManager)
    {
        if (countOfAnimal > spawnManager.GetLengthAnimalPrefabs())
        {
            countOfAnimal = 0;
        }
        animal = Instantiate(spawnManager.GetAnimalPrefab(countOfAnimal), spawnManager.GetTransformPosAnimalPrefab(countOfAnimal), 
            basicRotationAnimal);
        countOfAnimal++;
    }
    
    //Створення рандоної позиції об'єкта
    public void SetAnimalPos(ref Animals animal,ref SpawnManager spawnManager)
    {
        if (countPosAnimal >= 3)
        {
            countPosAnimal = 0;
        }
        
        SetAnimalPos();
        switch (countPosAnimal)
        {
            case 0:
                animal.gameObject.transform.position = SpawnPosTop;
                animal.gameObject.transform.rotation = basicRotationAnimal;
                countPosAnimal++;
                break;
            case 1:
                animal.gameObject.transform.position = SpawnPosRight;
                animal.gameObject.transform.rotation = RotationRightSide;
                countPosAnimal++;
                break;
            case 2:
                animal.gameObject.transform.position = SpawnPosLeft;
                animal.gameObject.transform.rotation = RotationLeftSide;
                countPosAnimal++;
                break;
        }
    }
    
    public void SetAnimalPos()
    {
        spawnPosTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosTopZ);
        spawnPosLeft = new Vector3(-spawnPosSideX, 0, Random.Range(spawnRangeMinZ,spawnRangeMaxZ));
        spawnPosRight = new Vector3(spawnPosSideX, 0, Random.Range(spawnRangeMinZ,spawnRangeMaxZ));
        rotationLeftSide = Quaternion.Euler(0, rotationSide, 0);
        rotationRightSide = Quaternion.Euler(0, -rotationSide, 0);
    }
    
}
