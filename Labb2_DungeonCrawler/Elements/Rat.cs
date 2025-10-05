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
    public override void Update(IReadOnlyList<LevelElement> Elements)
    {
        Random random = new Random();
        LevelData levelElements = new LevelData();

        int rnd = random.Next(4);

        if (rnd == 0)
        {
            if (levelElements.IsFree(Elements, this.x, this.y + 1))
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.y++;
            }
        }
        else if (rnd == 1)
        {
            if (levelElements.IsFree(Elements,this.x, this.y - 1))
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.y--;
            }
        }
        else if (rnd == 2)
        {
            if (levelElements.IsFree(Elements,this.x + 1, this.y))
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                this.x++;
            }
        }
        else if (rnd == 3)
        {
            if (levelElements.IsFree(Elements, this.x - 1, this.y))
            {
                Console.SetCursorPosition(x, y);
            Console.Write(' ');
            this.x--;
            }
        }
    }
}
