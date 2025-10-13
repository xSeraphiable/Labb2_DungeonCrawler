
using System;
using System.Diagnostics;

class Player : LevelElement //TODO: se över klassen
{
    public string Name { get; set; } = "Ame";
    public int Health { get; set; } = 100;
    public Dice AttackDice { get; } = new Dice(3, 6, 2);
    public Dice DefenceDice { get; } = new Dice(2, 6, 0);

    public int OldX { get; set; }
    public int OldY { get; set; }


    public Player(int x, int y)
    {
        this.elementChar = '@';
        this.Color = ConsoleColor.White;
        this.x = x;
        this.y = y;
        this.AttackDice = AttackDice;
        this.DefenceDice = DefenceDice;
    }

    public static void Attack(Player p, Enemy enemy)
    {


        while (enemy.Health > 0 && p.Health > 0)
        {

            int damageToE = Math.Max(p.AttackDice.Roll() - enemy.DefenceDice.Roll(), 0);
            int damageToP = Math.Max(enemy.AttackDice.Roll() - p.DefenceDice.Roll(), 0);

            enemy.Health -= damageToE;
            if (enemy.Health > 0)
            { p.Health -= damageToP; }

            Position.SetCursorAndWipeEntireRow(0, 2);
            if (enemy.Health >= 0)
            {
            Console.Write($"{p.Name} deals {damageToE} dmg | {enemy.Name} HP: {enemy.Health}   ");
            }
            else { Console.Write($"{p.Name} deals {damageToE} dmg | {enemy.Name} HP: 0   "); }
                Thread.Sleep(200);

            if (enemy.Health > 0)
            {
                Position.SetCursorAndWipeEntireRow(0, 3);
                Console.Write($"{enemy.Name} deals {damageToP} dmg | {p.Name} HP: {p.Health}   ");
                Thread.Sleep(200);
            }


            if (enemy.Health <= 0)
            {
                Position.SetCursorAndWipeEntireRow(0, 3);
                Enemy.PrintDeathMessage(enemy.Name);
            }
            else if (p.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Position.SetCursorAndWipeEntireRow(0, 3);
                Console.WriteLine($"GAME OVER");
            }
        }

        Thread.Sleep(2000);
        Position.SetCursorAndWipeEntireRow(0, 2);
        Position.SetCursorAndWipeEntireRow(0, 3);
        Position.SetCursorAndWipeEntireRow(0, 4);
    }




}