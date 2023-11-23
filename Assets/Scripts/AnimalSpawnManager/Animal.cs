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
        GateDescription nameTriggerCollider = collider.GetComponent<GateDescription>();

        if (nameTriggerCollider != null)
        {
            switch (nameTriggerCollider.gateType)
            {
                case GateType.Food:
                    currentHealth++;
                    healthbar.SetHealth(currentHealth);
                    ActionSoundManager.onAnimalSoundPlayed?.Invoke();
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
        Debug.Log(scorePlayerFeedAnimal.ToString());
        scorePlayerFeedAnimal++;
        Debug.Log(scorePlayerFeedAnimal.ToString());
        onScoreTextSet?.Invoke();
        StopCoroutine("WaitForDeactivateAnimalAfterTime");
    }

    public void SetPool(ObjectPool<Animal> pool)
    {
        _pool = pool;
    }
}