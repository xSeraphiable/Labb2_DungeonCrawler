using Labb2_DungeonCrawler;

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
    public override void Update(IReadOnlyList<LevelElement> Elements, Player p)
    {
        Random random = new Random();
        LevelData levelElements = new LevelData();

        int nextStep = random.Next(4);

        if (nextStep == 0)
        {
            if (Position.CheckPlayerCollision(p, x, y + 1))
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Attack");
                //Attack
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
            if (Position.CheckPlayerCollision(p, x, y - 1))
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Attack");
                //Attack
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
            if (Position.CheckPlayerCollision(p, x +1, y))
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Attack");
                //Attack
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
            if (Position.CheckPlayerCollision(p, x - 1, y))
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Attack");
                //Attack
            }
            else if (Position.IsAvailable(Elements, this.x - 1, this.y))
            {

                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.x--;
            }

        }


    }
}
