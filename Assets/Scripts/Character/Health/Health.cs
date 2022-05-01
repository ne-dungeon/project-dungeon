public class Health
{
  int health, minHealth, maxHealth;

  // Remove health points
  public void Damage(int amount)
  {
    health -= amount;
    if (health < minHealth)
    {
      health = minHealth;
    }
  }

// Add health points
  public void Heal(int amount)
  {
    health += amount;
    if (health > maxHealth)
    {
      health = maxHealth;
    }
  }

  public Health(int startHealth = 10, int maxH = 10, int minH = 0)
  {
    health = startHealth;
    minHealth = minH;
    maxHealth = maxH;
  }
}