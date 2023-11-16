using SpawnManagerAnimal;
using UnityEngine;

public class FastAnimal : Animals
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
                    if (currentHealth == maxHealth)
                    {
                        StartCoroutine("WaitForDeactivateAnimalAfterTime");
                    }
                    break;
                case GateType.Player:
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    break;
                case GateType.Wall:
                    isDestroyOutOfBounds = true;
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    break;
            }
        }
    }
}
