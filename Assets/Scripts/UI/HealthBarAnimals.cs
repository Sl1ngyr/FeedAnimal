using UI;

public class HealthBarAnimals : HealthBar
{
    public override void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public override void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
