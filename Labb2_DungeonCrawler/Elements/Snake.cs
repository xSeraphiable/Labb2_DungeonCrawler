using Labb2_DungeonCrawler;
using System.Security.Cryptography;

class Snake : Enemy
{
    public Snake()
    {
        this.Name = "Snake";
        this.Health = 25;
        this.Color = ConsoleColor.Cyan;
        this.elementChar = 's';
        this.AttackDice = new Dice(3, 4, 2);
        this.DefenceDice = new Dice(1, 8, 5);
    }

    public override void Update(IReadOnlyList<LevelElement> Elements, Player p)
    {
       //TODO: Förbättring krävs.. Just nu rör dom sig bara om spelaren gör det.
        if ((Position.CalculateDistance(this.x, this.y, p.x, p.y)) < 3)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(" ");

            if (p.x - p.OldX == 0)
            {
                // TODO: kanske att jag ska använda en while-loop här på något sätt istället.
               

                if (p.y > p.OldY)
                {
                    if ((Position.IsAvailable(Elements, this.x, this.y + p.y - p.OldY)))
                    {
                        this.y += p.y - p.OldY;
                    }
                }
                else
                {
                    if ((Position.IsAvailable(Elements, this.x, this.y + p.OldY - p.y)))
                    {
                        this.y += p.OldY - p.y;
                    }
                }
            }
            else
            {
                if (p.x > p.OldX)
                {
                    if (Position.IsAvailable(Elements, this.x + p.OldX - p.x, this.y))
                    {
                        this.x += p.OldX - p.x;
                    }
                    else
                    {

                        if (Position.IsAvailable(Elements, this.x + p.x - p.OldX, this.y))
                        {
                            this.x += p.x - p.OldX;
                        }
                    }
                }

            }
        }
    }
}