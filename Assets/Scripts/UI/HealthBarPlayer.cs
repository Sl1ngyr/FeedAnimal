using UnityEngine.UI;
using UnityEngine;
using UI;

public class HealthBarPlayer : HealthBar
{
    [SerializeField] private Text text;
    public override void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        
        fill.color = gradient.Evaluate(1f);
        text.text = $"Lives: {maxHealth.ToString()}";
    }

    public override void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        text.text = $"Lives: {slider.value.ToString()}";
    }
}
