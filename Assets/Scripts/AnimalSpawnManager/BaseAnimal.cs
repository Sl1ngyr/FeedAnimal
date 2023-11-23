using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace SpawnManagerAnimal
{
    public abstract class BaseAnimal : MonoBehaviour
    {
        public static int scorePlayerFeedAnimal = 0;
        public static bool isDestroyOutOfBounds = false;
        public static Action onScoreTextSet;
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maxHealth;
        [SerializeField] protected AnimalHealthBar healthbar;
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

        private void OnEnable()
        {
            ActionSoundManager.onAnimalSoundPlayed += AnimalSoundHit;
        }

        private void OnDisable()
        {
            ActionSoundManager.onAnimalSoundPlayed -= AnimalSoundHit;
        }
        
        private void AnimalSoundHit()
        {
            animalSound.PlayOneShot(eatSound, 0.5f);
        }
        
        protected virtual IEnumerator WaitForDeactivateAnimalAfterTime()
        {
            yield return new WaitForSeconds(.01f);
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);
            scorePlayerFeedAnimal++;
            onScoreTextSet?.Invoke();
            StopCoroutine("WaitForDeactivateAnimalAfterTime");
            Destroy(gameObject);
        }
    }
}