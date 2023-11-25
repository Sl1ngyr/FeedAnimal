using SpawnManagerAnimal;
using UnityEngine;

public class FastAnimal : BaseAnimal
{
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
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    Destroy(gameObject);
                    break;
                case NameType.Wall:
                    isDestroyOutOfBounds = true;
                    currentHealth = 0;
                    healthbar.SetHealth(currentHealth);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
