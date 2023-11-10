using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public static int count = 0;
    
    private int maxHealth = 3;
    private int currentHealth = 0;
    public HealthBarAnimals healthbar;

    private void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            currentHealth++;
            healthbar.SetHealth(currentHealth);
            if (currentHealth == maxHealth)
            {
                StartCoroutine("WaitForDie");
            }
            Destroy(other.gameObject);
        }
        else if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(.09f);
        Destroy(gameObject);
        StopCoroutine("WaitForDie");
        count++;
    }
}
