using Labb2_DungeonCrawler;

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

            Position.SetCursorAndWipe(0, 3);
            Console.Write($"{enemy.Name} deals {damageToP} dmg | {p.Name} HP: {p.Health}   ");
            Thread.Sleep(200);

            //    int attack = p.AttackDice.Roll();
            //    int defence = enemy.DefenceDice.Roll();

            //    Position.SetCursorAndWipe(0, 2);
            //    Console.WriteLine($"{p.Name} rolls their {p.AttackDice.ToString()} for a total of: {attack}.");
            //    Position.SetCursorAndWipe(0, 3);
            //    Console.WriteLine($"{enemy.Name} rolls their defence {enemy.DefenceDice.ToString()} for a total of {defence}.");

            //    if (attack >= defence)
            //    {
            //        Position.SetCursorAndWipe(0, 3);
            //        enemy.Health -= attack - defence;
            //        Console.Write($"{enemy.Name} takes {attack - defence} damage.");
            //    }
            //    else
            //    {
            //        Position.SetCursorAndWipe(0, 2);
            //        Console.WriteLine($"{enemy.Name} saves against {p.Name}'s attack.");
            //    }

            //    attack = enemy.AttackDice.Roll();
            //    defence = p.DefenceDice.Roll();
            //    Position.SetCursorAndWipe(0, 2);
            //    Console.WriteLine($"{enemy.Name} rolls their {enemy.AttackDice.ToString()} for a total of {attack}.");
            //    Position.SetCursorAndWipe(0, 3);
            //    Console.WriteLine($"{p.Name} rolls their {p.DefenceDice.ToString()} for a total of: {defence}.");

            //    if (attack >= defence)
            //    {
            //        Position.SetCursorAndWipe(0, 3);
            //        p.Health -= attack - defence;
            //        Console.Write($"{p.Name} takes {attack - defence} damage.");
            //    }
            //    else
            //    {
            //        Position.SetCursorAndWipe(0, 3);
            //        Console.WriteLine($"{p.Name} saves against {enemy.Name}'s attack.");
            //    }

            //    if (Console.KeyAvailable)
            //    {
            //        var key = Console.ReadKey(true);
            //        if (key.Key == ConsoleKey.Escape)
            //        {
            //            break;
            //        }
            //    }
            //}

            if (enemy.Health <= 0)
        {
            Position.SetCursorAndWipe(0, 4);
            Console.WriteLine($"{enemy.Name} collapses to the floor and perishes...");
        }
        else if (p.Health <= 0)
        {
            Position.SetCursorAndWipe(0, 4);
            Console.WriteLine($"GAME OVER");
        }

    }

}