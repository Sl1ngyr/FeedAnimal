using SpawnManagerAnimal;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolAnimal : MonoBehaviour
{
    public ObjectPool<Animal> _pool;
    public SpawnPosAnimal spawnPosAnimal;
    
    private SpawnManager spawnManager;
   
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        _pool = new ObjectPool<Animal>(CreateAnimal, OnTakeAnimalFromPool, OnReturnAnimalToPool, OnDestroyAnimal, false,
            12, 30);
    }

    //Створення об'єкта
    private Animal CreateAnimal()
    {
        Animal animal = null;
        spawnPosAnimal.CreateAnimalSpawn(ref animal, ref spawnManager);
        animal.SetPool(_pool);
        return animal;
    }

    // Коли ми витягаємо об'єкт з пула
    private void OnTakeAnimalFromPool(Animals animal)
    {
        //Створення нової позиції об'єкта 
        spawnPosAnimal.SetAnimalPos(ref animal,ref spawnManager);
        
        //Активовуємо об'єкт
        animal.gameObject.SetActive(true);
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
