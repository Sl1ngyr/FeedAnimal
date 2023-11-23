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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        playerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
            gameOverScreen.Setup(BaseAnimal.scorePlayerFeedAnimal);
            isGameOver = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player" && other.tag == "Animal")
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
