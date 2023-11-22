using SpawnManagerAnimal;
using UnityEngine;

public class ScoreLivesPlayer : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;

    public int CurrentHealth => currentHealth;
    
    private AudioSource playerSound;

    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private HealthBarPlayer healthbar;

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
        if (Animals.isDestroyOutOfBounds)
        {
            --currentHealth;
            healthbar.SetHealth(currentHealth);
            Animals.isDestroyOutOfBounds = false;
            if (currentHealth == 0)
            {
                isGameOver = true;
            }
        }

        if (isGameOver)
        {
            gameOverScreen.Setup(Animals.scorePlayerFeedAnimal);
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
