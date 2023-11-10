using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text text;
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        
        fill.color = gradient.Evaluate(1f);
        text.text = $"Lives: {maxHealth.ToString()}";
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        text.text = $"Lives: {slider.value.ToString()}";
    }
}
