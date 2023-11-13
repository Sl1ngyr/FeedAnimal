using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
 
public class FoodSpawner : MonoBehaviour
{
    public ObjectPool<Food> _foodPool;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        _foodPool = new ObjectPool<Food>(CreateFood, OnTakeFoodFromPool, OnReturnFoodToPool, OnDestroyFood, true, 30,
            150);
    }

    private Food CreateFood()
    {
        Food food = Instantiate(playerController.foodPrefab, playerController.gameObject.transform.position,
            playerController.foodPrefab.transform.rotation);
        food.SetPool(_foodPool);
        return food;
    }

    private void OnTakeFoodFromPool(Food food)
    {
        food.gameObject.transform.position = playerController.gameObject.transform.position;
        
        food.gameObject.SetActive(true);
    }

    private void OnReturnFoodToPool(Food food)
    {
        food.gameObject.SetActive(false);
    }

    private void OnDestroyFood(Food food)
    {
        Destroy(food.gameObject);
    }
}
