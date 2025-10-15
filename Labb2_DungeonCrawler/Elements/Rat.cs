

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
    public void Attack()
    {
        AttackDice.Roll();
    }

    public void Defend()
    {

    }
}
