using System;
using SpawnManagerAnimal;
using UnityEngine;
using DefaultNamespace;
using UnityEngine.Serialization;

public class PlayerLifeSystem : MonoBehaviour
{
    //Hp bar
    private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private PlayerHealthBar healthbar;
    //Sound
    [SerializeField] private AudioManager audio;

    [SerializeField] private GameOverScreen gameOverScreen;
    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (BaseAnimal.isDestroyOutOfBounds)
        {
            --currentHealth;
            healthbar.SetHealth(currentHealth);
            BaseAnimal.isDestroyOutOfBounds = false;
            audio.PlaySFX(SoundType.Hit);
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
            audio.PlaySFX(SoundType.Hit);
            if (currentHealth == 0)
            {
                isGameOver = true;
            }
        }
    }
    
}
