abstract class Enemy : LevelElement
{
    public string Name { get; set; }

    public int Health { get; set; }

    public Dice AttackDice { get; set; }

    public Dice DefenceDice { get; set; }

    public abstract void Update(IReadOnlyList<LevelElement> Elements, Player p);

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
