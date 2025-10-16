
using System.Numerics;
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
        Console.SetCursorPosition(this.x, this.y);
        Console.Write(" ");

        if ((Position.CalculateDistance(this.x, this.y, player.x, player.y)) <= 2)
        {

            int dx = player.x - this.x;
            int dy = player.y - this.y;

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
                if (moveX != 0 && Position.IsAvailable(Elements, this.x + moveX, this.y))
                {
                    this.x += moveX;
                    return;
                }

                if (moveY != 0 && Position.IsAvailable(Elements, this.x, this.y + moveY))
                {
                    this.y += moveY;
                    return;
                }
            }
            else
            {
                if (moveY != 0 && Position.IsAvailable(Elements, this.x, this.y + moveY))
                {
                    this.y += moveY;
                    return;
                }

                if (moveX != 0 && Position.IsAvailable(Elements, this.x + moveX, this.y))
                {
                    this.x += moveX;
                    return;
                }
            }

        }
    }

    //if ((Position.CalculateDistance(this.x, this.y, p.x, p.y)) <= 2)
    //{
    //    Console.SetCursorPosition(this.x, this.y);
    //    Console.Write(" ");

    //    int dx = p.x - this.x;
    //    int dy = p.y - this.y;

    //    if (dx > dy)
    //    {
    //        if (dx > 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x - 1, this.y))
    //            {
    //                this.x -= 1;
    //            }
    //        }
    //        else if (dx < 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x + 1, this.y))
    //            {
    //                this.x += 1;
    //            }
    //        }
    //        else if (dy > 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x, this.y - 1))
    //            {
    //                this.y -= 1;
    //            }
    //        }
    //        else if (Position.IsAvailable(Elements, this.x, this.y + 1))
    //        {
    //            this.y += 1;
    //        }
    //    }
    //    else
    //    {
    //        if (dy > 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x, this.y - 1))
    //            {
    //                this.y -= 1;
    //            }
    //        }
    //        else if (dy < 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x, this.y + 1))
    //            {
    //                this.y += 1;
    //            }
    //        }
    //        else if (dx > 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x - 1, this.y))
    //            {
    //                this.x -= 1;
    //            }
    //        }
    //        else
    //        {
    //            if (Position.IsAvailable(Elements, this.x + 1, this.y))
    //            {
    //                this.x += 1;
    //            }
    //        }
    //    }

    //if (dx > dy)
    //{
    //    if (dx < 0)
    //    {
    //        if (Position.IsAvailable(Elements, this.x + 1, this.y))
    //        {
    //            this.x += 1;
    //        }
    //        else if (Position.IsAvailable(Elements, this.x, this.y - 1))
    //        {
    //            this.y -= 1;
    //        }
    //        else if (Position.IsAvailable(Elements, this.x, this.y - 1))
    //        {
    //            this.y -= 1;
    //        }
    //    }
    //    else
    //    {
    //        if (Position.IsAvailable(Elements, this.x - 1, this.y))
    //        {
    //            this.x -= 1;
    //        }
    //        else if (Position.IsAvailable(Elements, this.x, this.y + 1))
    //        {
    //            this.y += 1;
    //        }
    //        else if (Position.IsAvailable(Elements, this.x, this.y - 1))
    //        {
    //            this.y -= 1;
    //        }
    //    }

    //}
    //if (dx < dy)
    //{
    //    if (dy < 0)
    //    {
    //        if (Position.IsAvailable(Elements, this.x, this.y + 1))
    //        {
    //            this.y += 1;
    //        }
    //        else if (dx > 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x + 1, this.y))
    //            {
    //                this.x += 1;
    //            }
    //        }
    //        else
    //        {
    //            if (Position.IsAvailable(Elements, this.x - 1, this.y))
    //            {
    //                this.x -= 1;
    //            }
    //        }
    //    }
    //    else if (dy > 0)
    //    {
    //        if (Position.IsAvailable(Elements, this.x, this.y - 1))
    //        {
    //            this.y -= 1;
    //        }
    //        else if (dx > 0)
    //        {
    //            if (Position.IsAvailable(Elements, this.x + 1, this.y))
    //            {
    //                this.x += 1;
    //            }
    //        }
    //        else
    //        {
    //            if (Position.IsAvailable(Elements, this.x - 1, this.y))
    //            {
    //                this.x -= 1;
    //            }
    //        }
    //    }
    //}
}

