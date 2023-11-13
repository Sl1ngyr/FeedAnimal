using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Pool;

public class Animal : MonoBehaviour
{
    public static int count = 0;
    public static bool isDestroyOutOfBounds = false;
    
    [SerializeField] private int maxHealth;
    private int currentHealth = 0;
    public HealthBarAnimals healthbar;

    [SerializeField] private float speed;

    private ObjectPool<Animal> _pool;
    private void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth); 
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider collider)
    {
        GateDescription nameTriggerCollider = collider.GetComponent<GateDescription>();

        if (nameTriggerCollider != null)
        {
            switch (nameTriggerCollider.gateType)
            {
                case GateType.Food:
                    currentHealth++;
                    healthbar.SetHealth(currentHealth);
                    if (currentHealth == maxHealth)
                    {
                        StartCoroutine("WaitForDeactivateAnimalAfterTime");
                    }
                    break;
                case GateType.Player:
                    _pool.Release(this);
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    break;
                case GateType.Wall:
                    isDestroyOutOfBounds = true;
                    _pool.Release(this);
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    break;
            }
        }
    }

    IEnumerator WaitForDeactivateAnimalAfterTime()
    {
        yield return new WaitForSeconds(.01f);
        _pool.Release(this);
        currentHealth = 0;
        healthbar.SetHealth(currentHealth);
        StopCoroutine("WaitForDeactivateAnimalAfterTime");
        count++;
    }

    public void SetPool(ObjectPool<Animal> pool)
    {
        _pool = pool;
    }
    
}
