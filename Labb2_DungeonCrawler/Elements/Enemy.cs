abstract class Enemy : Character
{
    protected readonly int _healthDefault;

    public Enemy(int startingHealth)
    {
        this.Health = startingHealth;
        this._healthDefault = startingHealth;
    }

    public abstract void Update(List<LevelElement> Elements, Player p);

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
        GameLoop.PrintTextCharByChar(name + deathMessage[random.Next(deathMessage.Length)]);
        Console.ResetColor();
    }

}
