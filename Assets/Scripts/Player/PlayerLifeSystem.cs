using System;
using SpawnManagerAnimal;
using UnityEngine;

public class PlayerLifeSystem : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;

    private AudioSource playerSound;

    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private PlayerHealthBar healthbar;

    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        playerSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (BaseAnimal.isDestroyOutOfBounds)
        {
            --currentHealth;
            healthbar.SetHealth(currentHealth);
            BaseAnimal.isDestroyOutOfBounds = false;
            if (currentHealth == 0)
            {
                isGameOver = true;
            }
        }

        if (isGameOver)
        {
            gameOverScreen.Setup(BaseAnimal.playerScoreFeedAnimal);
            isGameOver = false;
        }
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.CompareTag("Player") && collider.CompareTag("Animal"))
        {
            currentHealth--;
            healthbar.SetHealth(currentHealth);
            playerSound.PlayOneShot(hitSound, 1.0f);
            if (currentHealth == 0)
            {
                isGameOver = true;
            }
        }
    }
    
}
