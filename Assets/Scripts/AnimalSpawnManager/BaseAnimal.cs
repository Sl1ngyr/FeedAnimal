using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace SpawnManagerAnimal
{
    public abstract class BaseAnimal : MonoBehaviour
    {
        public static int playerScoreFeedAnimal = 0;
        public static bool isDestroyOutOfBounds = false;
        public static Action onScoreTextSet;
        
        //Hp bar
        [SerializeField] protected AnimalHealthBar healthbar;
        [SerializeField] protected int currentHealth;
        [SerializeField] protected int maxHealth;
        //speed animal
        [SerializeField] protected float speed;

        protected AudioManager _audioManager;
        
        private void Start()
        {
            healthbar.SetMaxHealth(maxHealth);
            healthbar.SetHealth(currentHealth);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        public void Init(AudioManager audioManager)
        {
            _audioManager = audioManager;
        }
        
        protected virtual IEnumerator WaitForDeactivateAnimalAfterTime()
        {
            yield return new WaitForSeconds(.01f);
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);
            playerScoreFeedAnimal++;
            onScoreTextSet?.Invoke();
            StopCoroutine("WaitForDeactivateAnimalAfterTime");
            Destroy(gameObject);
        }
    }
}