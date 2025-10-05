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
    public override void Update()
    {
        Random random = new Random();
       // LevelData levelElements = new LevelData();

        if (random.Next(4) == 0)
        {
            //if (levelElements.IsPositionEmpty(this.x, this.y + 1))
            //{
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.y++;
            //}
        }
        else if (random.Next(4) == 1)
        {
            //if (levelElements.IsPositionEmpty(this.x, this.y - 1))
            //{
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.y--;
            //}
        }
        else if (random.Next(4) == 2)
        {
            //if (levelElements.IsPositionEmpty(this.x+1, this.y))
            //{
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.x++;
            //}
        }
        else if (random.Next(4) == 3)
        {
            //if (levelElements.IsPositionEmpty(this.x -1, this.y))
            //{
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.x--;
            //}
        }
    }
}
