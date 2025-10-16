
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
        this.AttackDice = new Dice(3, 6, 2);
        this.DefenceDice = new Dice(2, 6, 0);
        this.Health = 100;
        this.Name = name;
    }

    public override void Die()
    {
        IsAlive = false;
    }

}