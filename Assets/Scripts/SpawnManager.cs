using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    
    private float spawnRangeX = 15;
    private float spawnRangeMinZ = 3;
    private float spawnRangeMaxZ = 15;
    private float spawnPosTopZ = 20;
    private float spawnPosSideX = 20;
    private float rotationSide = 90;
    
    // Interval to spawn Animal
    private float startDelay = 1.5f;
    private float spawnInterval = 3.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Spawn Animal Top
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        
        Vector3 spawnPosTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosTopZ);
        Vector3 spawnPosLeft = new Vector3(-spawnPosSideX, 0, Random.Range(spawnRangeMinZ,spawnRangeMaxZ));
        Vector3 spawnPosRight = new Vector3(spawnPosSideX, 0, Random.Range(spawnRangeMinZ,spawnRangeMaxZ));
        Quaternion rotationLeftSide = Quaternion.Euler(0, rotationSide, 0);
        Quaternion rotationRightSide = Quaternion.Euler(0, -rotationSide, 0);
        
        Instantiate(animalPrefabs[animalIndex], spawnPosTop, animalPrefabs[animalIndex].transform.rotation);
        animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPosLeft, rotationLeftSide);
        animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPosRight, rotationRightSide);
    }

}
