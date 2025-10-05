using System.Security.Cryptography;

class Snake : Enemy
{
    public Snake()
    {
        this.EnemyName = "Snake";
        this.Health = 25;
        this.Color = ConsoleColor.Cyan;
        this.displayChar = 's';
        this.AttackDice = new Dice(3, 4, 2);
        this.DefenceDice = new Dice(1, 8, 5);
    }

    public override void Update()
    {
        
    }
}