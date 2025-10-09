using Labb2_DungeonCrawler;
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
            p.Health -= damageToP;


            Position.SetCursorAndWipe(0, 2);
            Console.Write($"{p.Name} deals {damageToE} dmg | {enemy.Name} HP: {enemy.Health}   ");
            Thread.Sleep(200);

            if (enemy.Health > 0)
            {
                Position.SetCursorAndWipe(0, 3);
                Console.Write($"{enemy.Name} deals {damageToP} dmg | {p.Name} HP: {p.Health}   ");
                Thread.Sleep(200);
            }
            

            if (enemy.Health <= 0)
            {
                Position.SetCursorAndWipe(0, 3);
                PrintDeathMessage(enemy.Name);
            }
            else if (p.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Position.SetCursorAndWipe(0, 3);
                Console.WriteLine($"GAME OVER");
            }
        }

        Thread.Sleep(2000);
        Position.SetCursorAndWipe(0, 2);
        Position.SetCursorAndWipe(0, 3);
        Position.SetCursorAndWipe(0, 4);
    }

    public static void PrintDeathMessage(string name)
    {
        string[] deathMessage = new string[]
        {
            " bites the dust... literally.",
            " has been sent back to the respawn queue.",
            " thought they could survive... they were wrong.",
            " goes down screaming... then quietly dies.",
            " is no more. Say hello to the grave."
        };

        Random random = new Random();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(name + deathMessage[random.Next(deathMessage.Length)]);
        Console.ResetColor();

    }


}