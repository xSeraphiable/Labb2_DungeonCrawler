
using System;
using System.Diagnostics;

class Player : Character
{
   
    public int OldX { get; set; }
    public int OldY { get; set; }


    public Player(int x, int y)
    {
        this.elementChar = '@';
        this.Color = ConsoleColor.White;
        this.x = x;
        this.y = y;
        this.AttackDice = new Dice(3, 6, 2);
        this.DefenceDice = new Dice(2, 6, 0);
        this.Health = 100;
        this.Name = "Ame";
    }

    public override void Die()
    {
        IsAlive = false;
    }





    //public static void Attack(Player p, Enemy enemy)
    //{
    //    Console.SetCursorPosition(0, 2);
    //    Console.ForegroundColor = ConsoleColor.DarkRed;
    //    Console.WriteLine("***IN COMBAT***");
    //    Console.ResetColor();


    //    while (enemy.Health > 0 && p.Health > 0)
    //    {

    //        int damageToE = Math.Max(p.AttackDice.Roll() - enemy.DefenceDice.Roll(), 0);
    //        int damageToP = Math.Max(enemy.AttackDice.Roll() - p.DefenceDice.Roll(), 0);

    //        enemy.Health -= damageToE;

    //        if (enemy.Health > 0)
    //        {
    //            p.Health -= damageToP;
    //        }

    //        Position.SetCursorAndWipeEntireRow(0, 3);

    //        if (enemy.Health >= 0)
    //        {
    //            Console.Write($"{p.Name} deals {damageToE} dmg | {enemy.Name} HP: {enemy.Health}   ");
    //        }
    //        else
    //        {
    //            Console.Write($"{p.Name} deals {damageToE} dmg | {enemy.Name} HP: 0   ");
    //        }

    //        Thread.Sleep(200);

    //        if (enemy.Health > 0)
    //        {
    //            Position.SetCursorAndWipeEntireRow(0, 4);
    //            Console.Write($"{enemy.Name} deals {damageToP} dmg | {p.Name} HP: {p.Health}   ");
    //            Thread.Sleep(200);
    //        }


    //        if (enemy.Health <= 0)
    //        {
    //            Position.SetCursorAndWipeEntireRow(0, 4);
    //            Enemy.PrintDeathMessage(enemy.Name);
    //        }
    //        else if (p.Health <= 0)
    //        {
    //            Console.Clear();
    //            break;
    //            //Console.ForegroundColor = ConsoleColor.DarkRed;
    //            //Position.SetCursorAndWipeEntireRow(0, 4);
    //            //Console.WriteLine($"GAME OVER");
    //        }
    //    }

    //    if (p.Health > 0)
    //    {
    //        Position.SetCursorAndWipeEntireRow(0, 3);
    //        Thread.Sleep(1500);
    //        Position.SetCursorAndWipeEntireRow(0, 2);
    //        Position.SetCursorAndWipeEntireRow(0, 4);
    //    }


    //}

}