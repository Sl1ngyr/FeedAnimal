using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public Animal[] animalPrefabs;
    
    private float spawnRangeX = 15;
    private float spawnRangeMinZ = 3;
    private float spawnRangeMaxZ = 15;
    private float spawnPosTopZ = 20;
    private float spawnPosSideX = 20;
    private float rotationSide = 90;
    
    private Vector3 spawnPosTop;
    private Vector3 spawnPosLeft;
    private Vector3 spawnPosRight;
    private Quaternion rotationLeftSide;
    private Quaternion rotationRightSide;
    
    // Interval to spawn Animal
    private float startDelay = 1.5f;
    private float spawnInterval = 4f;
    
    public Vector3 SpawnPosTop => spawnPosTop;
    public Vector3 SpawnPosLeft => spawnPosLeft;
    public Vector3 SpawnPosRight => spawnPosRight;
    public Quaternion RotationLeftSide => rotationLeftSide;
    public Quaternion RotationRightSide => rotationRightSide;

    private ObjectPoolAnimal objectPoolAnimal;
    
    // Start is called before the first frame update
    void Start()
    {
        objectPoolAnimal = GetComponent<ObjectPoolAnimal>();
        //Spawn Animal Top
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        objectPoolAnimal._pool.Get();
        objectPoolAnimal._pool.Get();
        objectPoolAnimal._pool.Get();
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
