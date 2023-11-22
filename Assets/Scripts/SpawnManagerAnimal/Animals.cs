using System.Collections;
using UnityEngine;

namespace SpawnManagerAnimal
{
    public abstract class Animals : MonoBehaviour
    {
        public static int scorePlayerFeedAnimal = 0;
        public static bool isDestroyOutOfBounds = false;
        
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maxHealth;
        [SerializeField] protected HealthBarAnimals healthbar;
        [SerializeField] protected float speed;
        [SerializeField] protected AudioClip eatSound;
        protected AudioSource animalSound;
        
        private void Start()
        {
            healthbar.SetMaxHealth(maxHealth);
            healthbar.SetHealth(currentHealth);
            animalSound = GetComponent<AudioSource>();
        }
        
        private void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        protected virtual IEnumerator WaitForDeactivateAnimalAfterTime()
        {
            yield return new WaitForSeconds(.01f);
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);
            scorePlayerFeedAnimal++;
            StopCoroutine("WaitForDeactivateAnimalAfterTime");
            Destroy(gameObject);
        }
    }
}