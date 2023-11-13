using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLivesPlayer : MonoBehaviour
{
    private int maxHealth = 3;

    private int currentHealth;

    public HealthBarPlayer healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Animal.isDestroyOutOfBounds)
        {
            --currentHealth;
            healthbar.SetHealth(currentHealth);
            Animal.isDestroyOutOfBounds = false;
        }
        if (currentHealth == 0)
        {
            FindObjectOfType<LoadGame>().LoadScene();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player" && other.tag == "Animal")
        {
            currentHealth -= 1;
            healthbar.SetHealth(currentHealth);
        }
    }
    
}
