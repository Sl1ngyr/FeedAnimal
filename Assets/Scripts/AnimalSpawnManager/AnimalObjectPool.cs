using SpawnManagerAnimal;
using UnityEngine;
using UnityEngine.Pool;

public class AnimalObjectPool : MonoBehaviour
{
    public ObjectPool<Animal> _pool;
    public SpawnPosAnimal spawnPosAnimal;
    
    private AnimalSpawnManager _animalSpawnManager;
   
    void Start()
    {
        _animalSpawnManager = GetComponent<AnimalSpawnManager>();
        _pool = new ObjectPool<Animal>(CreateAnimal, OnTakeAnimalFromPool, OnReturnAnimalToPool, OnDestroyAnimal, false,
            12, 30);
    }

    //Створення об'єкта
    private Animal CreateAnimal()
    {
        Animal animal = null;
        spawnPosAnimal.CreateAnimalSpawn(ref animal, ref _animalSpawnManager);
        animal.SetPool(_pool);
        return animal;
    }

    // Коли ми витягаємо об'єкт з пула
    private void OnTakeAnimalFromPool(BaseAnimal baseAnimal)
    {
        //Створення нової позиції об'єкта 
        spawnPosAnimal.SetAnimalPos(ref baseAnimal,ref _animalSpawnManager);
        
        //Активовуємо об'єкт
        baseAnimal.gameObject.SetActive(true);
    }

    // Коли ми повертаємо об'єкт в пул
    private void OnReturnAnimalToPool(Animal animal)
    {
        animal.gameObject.SetActive(false);
    }

    private void OnDestroyAnimal(Animal animal)
    {
        Destroy(animal.gameObject);
    }

}
