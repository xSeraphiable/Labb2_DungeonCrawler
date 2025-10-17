
using System;
using System.Diagnostics;

class Player : Character
{

    public int OldX { get; set; }
    public int OldY { get; set; }

    public Player(int x, int y, string name)
    {
        this.elementChar = '@';
        this.Color = ConsoleColor.White;
        this.x = x;
        this.y = y;
        this.AttackDice = new Dice(2, 6, 2);
        this.DefenceDice = new Dice(2, 6, 0);
        this.Health = 100;
        this.Name = name;
    }

    public void PrintStats(int rounds)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"|||   Player: {Name}  |  Current health: {Health}  |  Rounds: {rounds}  |||");
    }

    public void HandleInput(ConsoleKey key)
    {
        OldX = x;
        OldY = y;


        if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
        {
            y--;
        }
        else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
        {
            y++;
        }
        else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
        {
            x++;
        }
        else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
        {
            x--;
        }

    }

    public override void Die()
    {
        IsAlive = false;
    }

}