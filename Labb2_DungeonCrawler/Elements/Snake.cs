
using System.Numerics;
using System.Security.Cryptography;

class Snake : Enemy
{
    public Snake() : base(25)
    {
        this.Name = "Snake";
        this.Color = ConsoleColor.Cyan;
        this.elementChar = 'S';
        this.AttackDice = new Dice(3, 4, 2);
        this.DefenceDice = new Dice(1, 8, 3);
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

    public override void Update(List<LevelElement> Elements, Player player)
    {        
        if (Health <= _healthDefault / 2) { elementChar = Char.ToLower(elementChar); }

        Console.SetCursorPosition(x, y);
        Console.Write(" ");

        if ((Position.CalculateDistance(x, y, player.x, player.y)) <= 2)
        {

            int dx = player.x - x;
            int dy = player.y - y;

            int moveX = 0;
            int moveY = 0;


            bool prioritizeX = Math.Abs(dx) >= Math.Abs(dy);

            if (prioritizeX)
            {
                if (dx > 0)
                    moveX = -1;
                else if (dx < 0)
                    moveX = 1;

                if (dy > 0)
                    moveY = -1;
                else if (dy < 0)
                    moveY = 1;
            }

            else
            {
                if (dy > 0)
                    moveY = -1;
                else if (dy < 0)
                    moveY = 1;

                if (dx > 0)
                    moveX = -1;
                else if (dx < 0)
                    moveX = 1;
            }


            if (prioritizeX)
            {
                if (moveX != 0 && Position.IsAvailable(Elements, x + moveX, y))
                {
                    x += moveX;
                    return;
                }

                if (moveY != 0 && Position.IsAvailable(Elements, x, y + moveY))
                {
                    y += moveY;
                    return;
                }

                if (moveY == 0)
                {
                    if (Position.IsAvailable(Elements, x, y + 1))
                    {
                        y += 1;
                        return;
                    }
                    if (Position.IsAvailable(Elements, x, y - 1))
                    {
                        y -= 1;
                        return;
                    }

                }

            }
            else
            {
                if (moveY != 0 && Position.IsAvailable(Elements, x, y + moveY))
                {
                    y += moveY;
                    return;
                }

                if (moveX != 0 && Position.IsAvailable(Elements, x + moveX, y))
                {
                    x += moveX;
                    return;
                }

                if (moveX == 0)
                {
                    if (Position.IsAvailable(Elements, x + 1, y))
                    {
                        x += 1;
                        return;
                    }
                    if (Position.IsAvailable(Elements, x - 1, y))
                    {
                        x -= 1;
                        return;
                    }

                }


            }

        }
    }
}

