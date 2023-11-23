using SpawnManagerAnimal;
using UnityEngine;
using DefaultNamespace;

public class FastAnimal : BaseAnimal
{
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
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    Destroy(gameObject);
                    break;
                case GateType.Wall:
                    isDestroyOutOfBounds = true;
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
