public class Health
{
    int current, minHealth, maxHealth;

    // Remove health points
    public void Damage(int amount)
    {
        current -= amount;
        if (current < minHealth)
        {
            current = minHealth;
        }
    }

    // Add health points
    public void Heal(int amount)
    {
        current += amount;
        if (current > maxHealth)
        {
            current = maxHealth;
        }
    }

    public Health(int startHealth = 10, int maxH = 10, int minH = 0)
    {
        current = startHealth;
        minHealth = minH;
        maxHealth = maxH;
    }
}