abstract class Character : LevelElement
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public bool IsAlive { get; set; } = true;

    public abstract void Die();

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0 && IsAlive)
        {
            Die();
        }
    }

}