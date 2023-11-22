using System.Collections;
using SpawnManagerAnimal;
using UnityEngine;
using UnityEngine.Pool;

public class Animal : Animals
{
    private ObjectPool<Animal> _pool;
    
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
                    animalSound.PlayOneShot(eatSound, 1.0f);
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

    protected override IEnumerator WaitForDeactivateAnimalAfterTime()
    {
        yield return new WaitForSeconds(.01f);
        _pool.Release(this);
        currentHealth = 0;
        healthbar.SetHealth(currentHealth);
        StopCoroutine("WaitForDeactivateAnimalAfterTime");
        scorePlayerFeedAnimal++;
    }

    public void SetPool(ObjectPool<Animal> pool)
    {
        _pool = pool;
    }
}