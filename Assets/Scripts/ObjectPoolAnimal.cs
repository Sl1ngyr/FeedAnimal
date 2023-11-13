using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum RandomSpawnSideAnimal // список позицій для рандома
{
    Top,
    Left,
    Right
}

public class ObjectPoolAnimal : MonoBehaviour
{
    public ObjectPool<Animal> _pool;

    private SpawnManager spawnManager;
    private RandomSpawnSideAnimal randomSide;
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        _pool = new ObjectPool<Animal>(CreateAnimal, OnTakeAnimalFromPool, OnReturnAnimalToPool, OnDestroyAnimal, true,
            10, 30);
    }

    //Створення об'єкта
    private Animal CreateAnimal()
    {
        Animal animal = null;
        CreateRandomAnimalSpawn(ref animal);
        animal.SetPool(_pool);
        return animal;
    }

    // Коли ми витягаємо об'єкт з пула
    private void OnTakeAnimalFromPool(Animal animal)
    {
        //Створення нової позиції об'єкта 
        SetAnimalRandomPos(ref animal);
        
        //Активовуємо об'єкт
        animal.gameObject.SetActive(true);
    }

    private void OnReturnAnimalToPool(Animal animal)
    {
        animal.gameObject.SetActive(false);
    }

    private void OnDestroyAnimal(Animal animal)
    {
        Destroy(animal.gameObject);
    }
    
    //Створення рандоної позиції об'єкта
    private void CreateRandomAnimalSpawn(ref Animal animal)
    {
        int animalIndexRandom = Random.Range(0, spawnManager.animalPrefabs.Length); // рандомний індекс
        randomSide = (RandomSpawnSideAnimal)Random.Range(0, System.Enum.GetValues(typeof(RandomSpawnSideAnimal)).Length); // рандомне значення з якого ми присвоїм позицію об'єкту
        spawnManager.SetAnimalPos();
        switch (randomSide)
        {
            case RandomSpawnSideAnimal.Top:
                animal = Instantiate(spawnManager.animalPrefabs[animalIndexRandom], spawnManager.SpawnPosTop, spawnManager.animalPrefabs[animalIndexRandom].transform.rotation);
                break;
            case RandomSpawnSideAnimal.Right:
                animal = Instantiate(spawnManager.animalPrefabs[animalIndexRandom], spawnManager.SpawnPosRight, spawnManager.RotationRightSide);
                break;
            case RandomSpawnSideAnimal.Left:
                animal = Instantiate(spawnManager.animalPrefabs[animalIndexRandom], spawnManager.SpawnPosLeft, spawnManager.RotationLeftSide);
                break;
        }
    }

    private void SetAnimalRandomPos(ref Animal animal)
    {
        randomSide = (RandomSpawnSideAnimal)Random.Range(0, System.Enum.GetValues(typeof(RandomSpawnSideAnimal)).Length); // рандомне значення з якого ми присвоїм позицію об'єкту
        spawnManager.SetAnimalPos();
        switch (randomSide)
        {
            case RandomSpawnSideAnimal.Top:
                animal.gameObject.transform.position = spawnManager.SpawnPosTop;
                animal.gameObject.transform.rotation = spawnManager.animalPrefabs[0].transform.rotation;
                break;
            case RandomSpawnSideAnimal.Right:
                animal.gameObject.transform.position = spawnManager.SpawnPosRight;
                animal.gameObject.transform.rotation = spawnManager.RotationRightSide;
                break;
            case RandomSpawnSideAnimal.Left:
                animal.gameObject.transform.position = spawnManager.SpawnPosLeft;
                animal.gameObject.transform.rotation = spawnManager.RotationLeftSide;
                break;
        }
    }
    
}
