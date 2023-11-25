using System.Collections;
using SpawnManagerAnimal;
using UnityEngine;
using UnityEngine.Pool;
using DefaultNamespace;

public class Animal : BaseAnimal
{
    private ObjectPool<Animal> _pool;
    
    private void OnTriggerEnter(Collider collider)
    {
        NameDescription nameTriggerCollider = collider.GetComponent<NameDescription>();

        if (nameTriggerCollider != null)
        {
            switch (nameTriggerCollider.nameType)
            {
                case NameType.Food:
                    currentHealth++;
                    healthbar.SetHealth(currentHealth);
                    _audioManager.PlaySFX(SoundType.Eat);
                    if (currentHealth == maxHealth)
                    {
                        StartCoroutine("WaitForDeactivateAnimalAfterTime");
                    }
                    break;
                case NameType.Player:
                    _pool.Release(this);
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    break;
                case NameType.Wall:
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
        playerScoreFeedAnimal++;
        onScoreTextSet?.Invoke();
        StopCoroutine("WaitForDeactivateAnimalAfterTime");
    }

    public void SetPool(ObjectPool<Animal> pool)
    {
        _pool = pool;
    }
}