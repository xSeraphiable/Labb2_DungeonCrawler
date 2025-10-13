

class Rat : Enemy
{
    public Rat()
    {
        this.Name = "Rat";
        this.Health = 10;
        this.Color = ConsoleColor.Yellow;
        this.elementChar = 'r';
        this.AttackDice = new Dice(3, 6, 2);
        this.DefenceDice = new Dice(1, 6, 1);
    }
    public override void Update(IReadOnlyList<LevelElement> Elements, Player p)
    {

        Console.SetCursorPosition(x, y);
        Console.Write(' ');

        Random random = new Random();
        LevelData levelElements = new LevelData();

        int nextStep = random.Next(4);

        if (nextStep == 0)
        {
            if (Position.IsPlayerAtPosition(p, x, y + 1))
            {

                //Attack
            }
            else if (Position.IsAvailable(Elements, this.x, this.y + 1))
            {
                
                this.y++;
            }
        }
        else if (nextStep == 1)
        {
            if (Position.IsPlayerAtPosition(p, x, y - 1))
            {

                //Attack
            }
            else if (Position.IsAvailable(Elements, this.x, this.y - 1))
            {
                //Console.SetCursorPosition(x, y);
                //Console.Write(' ');
                this.y--;
            }
        }
        else if (nextStep == 2)
        {
            if (Position.IsPlayerAtPosition(p, x + 1, y))
            {

                //Attack
            }
            else if (Position.IsAvailable(Elements, this.x + 1, this.y))
            {
                //Console.SetCursorPosition(x, y);
                //Console.Write(' ');
                this.x++;
            }
        }
        else if (nextStep == 3)
        {
            if (Position.IsPlayerAtPosition(p, x - 1, y))
            {

                //Attack
            }
            else if (Position.IsAvailable(Elements, this.x - 1, this.y))
            {

                //Console.SetCursorPosition(x, y);
                //Console.Write(' ');
                this.x--;
            }
        }
    }

    //TODO: ersätt med attack och defend. Skapa en klass för att hantera dueller.
    public void Attack(Player p)
    {


        while (Health > 0 && p.Health > 0)
        {

            int damageToE = Math.Max(p.AttackDice.Roll() - DefenceDice.Roll(), 0);
            int damageToP = Math.Max(AttackDice.Roll() - DefenceDice.Roll(), 0);

            Health -= damageToE;
            if (Health > 0)
            { p.Health -= damageToP; }

            Position.SetCursorAndWipeEntireRow(0, 2);
            if (Health >= 0)
            {
                Console.Write($"{p.Name} deals {damageToE} dmg | {Name} HP: {Health}   ");
            }
            else { Console.Write($"{p.Name} deals {damageToE} dmg | {Name} HP: 0   "); }
            Thread.Sleep(200);

            if (Health > 0)
            {
                Position.SetCursorAndWipeEntireRow(0, 3);
                Console.Write($"{Name} deals {damageToP} dmg | {p.Name} HP: {p.Health}   ");
                Thread.Sleep(200);
            }


            if (Health <= 0)
            {
                Position.SetCursorAndWipeEntireRow(0, 3);
                PrintDeathMessage(Name);
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
