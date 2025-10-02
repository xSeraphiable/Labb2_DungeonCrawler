abstract class Enemy : LevelElement
{
    public string EnemyName { get; set; }

    public int Health { get; set; }

    public Dice AttackDice { get; set; }

    public Dice DefenceDice { get; set; }

    public abstract void Update();

}
