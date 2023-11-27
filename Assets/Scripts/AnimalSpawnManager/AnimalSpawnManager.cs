using SpawnManagerAnimal;
using UnityEngine;
using DefaultNamespace;
public class AnimalSpawnManager : MonoBehaviour
{
    [SerializeField] private Animal[] animalPrefabs;
    [SerializeField] private BaseAnimal speedBaseAnimalPrefabSpeed;
    [SerializeField] private SpawnPosAnimal spawnPosAnimal;
    [SerializeField] public AudioManager _audioManager;
    private AnimalObjectPool _animalObjectPool;

    // Interval to spawn Animal
    private float startDelay = 1.5f;
    private float spawnInterval = 4;

    // Interval to spawn Fast Animal
    private float startDelayFastAnimal = 5;
    private float spawnIntervalFastAnimal = 20;
    
    
    void Start()
    {
        _animalObjectPool = GetComponent<AnimalObjectPool>();
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnFastAnimal", startDelayFastAnimal,spawnIntervalFastAnimal);
    }

    void SpawnRandomAnimal()
    {
        _animalObjectPool._pool.Get();
        _animalObjectPool._pool.Get();
        _animalObjectPool._pool.Get();
    }

    private void SpawnFastAnimal()
    {
        spawnPosAnimal.SetAnimalPos(speedBaseAnimalPrefabSpeed, this);
        var fastAnimal = Instantiate(speedBaseAnimalPrefabSpeed, speedBaseAnimalPrefabSpeed.transform.position,
            speedBaseAnimalPrefabSpeed.transform.rotation).GetComponent<FastAnimal>();
        fastAnimal.Init(_audioManager);
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
