using Labb2_DungeonCrawler;
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

    public override void Update(IReadOnlyList<LevelElement> Elements, Player p)
    {
        //TODO: Gör om villkoren. Just nu följer ormarna efter spelaren...
        if ((Position.CalculateDistance(this.x, this.y, p.x, p.y)) < 3)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(" ");

            if (p.x - p.OldX == 0)
            {
                if (Position.IsAvailable(Elements, this.x, this.y + p.y - p.OldY)) // TODO: kanske att jag ska använda en while-loop här på något sätt istället.
                {
                    this.y += p.y - p.OldY;
                }
            }
            else
            {
                if (Position.IsAvailable(Elements, this.x + p.x - p.OldX, this.y))
                this.x += p.x - p.OldX;
            }
        }
    }
}