using SpawnManagerAnimal;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] private Animal[] animalPrefabs;
    [SerializeField] private Animals speedAnimalPrefabSpeed;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private SpawnPosAnimal spawnPosAnimal;
    private ObjectPoolAnimal objectPoolAnimal;
    
    // Interval to spawn Animal
    private float startDelay = 1.5f;
    private float spawnInterval = 4;

    // Interval to spawn Fast Animal
    private float startDelayFastAnimal = 5;
    private float spawnIntervalFastAnimal = 20;
    
    
    void Start()
    {
        objectPoolAnimal = GetComponent<ObjectPoolAnimal>();
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnFastAnimal", startDelay,spawnIntervalFastAnimal);
    }

    void SpawnRandomAnimal()
    {
        objectPoolAnimal._pool.Get();
        objectPoolAnimal._pool.Get();
        objectPoolAnimal._pool.Get();
    }

    private void SpawnFastAnimal()
    {
        spawnPosAnimal.SetAnimalPos(ref speedAnimalPrefabSpeed, ref _spawnManager);
        Instantiate(speedAnimalPrefabSpeed, speedAnimalPrefabSpeed.transform.position,
            speedAnimalPrefabSpeed.transform.rotation);
    }

    public Animal GetAnimalPrefab(int i)
    {
        return animalPrefabs[i];
    }

    public Vector3 GetTransformPosAnimalPrefab(int i)
    {
        return animalPrefabs[i].transform.position;
    }

    public int GetLengthAnimalPrefabs()
    {
        return animalPrefabs.Length;
    }
    
}
