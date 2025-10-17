

class Rat : Enemy
{

    public Rat() : base (10)
    {
        this.Name = "Rat";
        this.Color = ConsoleColor.Yellow;
        this.elementChar = 'R';
        this.AttackDice = new Dice(1, 6, 3);
        this.DefenceDice = new Dice(1, 6, 1);
    }

    public override void Die()
    {
        IsAlive = false;
        Thread.Sleep(800);
        Console.SetCursorPosition(0, 4);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Enemy.PrintDeathMessage(Name);
        Console.ResetColor();
        Console.SetCursorPosition(x, y);
        Console.Write(' ');
    }

    public override void Update(List<LevelElement> Elements, Player p)
    {
        if (Health <= _healthDefault / 2) { elementChar = char.ToLower(elementChar); }

        if (IsAlive)
        {
            Random random = new Random();
            LevelData levelElements = new LevelData();

            int nextStep = random.Next(4);

            if (nextStep == 0)
            {
                if (Position.IsPlayerAtPosition(p, x, y + 1))
                {
                    GameLoop.Attack(this, p);
                }
                else if (Position.IsAvailable(Elements, this.x, this.y + 1))
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                    this.y++;
                }
            }
            else if (nextStep == 1)
            {
                if (Position.IsPlayerAtPosition(p, x, y - 1))
                {
                    GameLoop.Attack(this, p);
                }
                else if (Position.IsAvailable(Elements, this.x, this.y - 1))
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                    this.y--;
                }
            }
            else if (nextStep == 2)
            {
                if (Position.IsPlayerAtPosition(p, x + 1, y))
                {
                    GameLoop.Attack(this, p);
                }
                else if (Position.IsAvailable(Elements, this.x + 1, this.y))
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                    this.x++;
                }
            }
            else if (nextStep == 3)
            {
                if (Position.IsPlayerAtPosition(p, x - 1, y))
                {
                    GameLoop.Attack(this, p);
                }
                else if (Position.IsAvailable(Elements, this.x - 1, this.y))
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                    this.x--;
                }
            }


            if (Position.CalculateDistance(x, y, p.x, p.y) > 5)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
            }
        }
    }


}
