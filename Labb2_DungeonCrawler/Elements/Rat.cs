class Rat : Enemy
{
    public Rat()
    {
        this.EnemyName = "Rat";
        this.Health = 10;
        this.Color = ConsoleColor.Yellow;
        this.displayChar = 'r';
        this.AttackDice = new Dice(3, 6, 2);
        this.DefenceDice = new Dice(1, 6, 1);
    }
    public override void Update()
    {
        throw new NotImplementedException();
    }
}
