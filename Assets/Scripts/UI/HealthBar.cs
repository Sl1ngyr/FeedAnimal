using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class HealthBar : MonoBehaviour
    {
        [SerializeField] protected Slider slider;
        [SerializeField] protected Gradient gradient;
        [SerializeField] protected Image fill;

        public abstract void SetMaxHealth(int maxHealth);
        public abstract void SetHealth(int health);
    }
}