class Player : LevelElement //TODO: se över klassen
{
    public int Health { get; } = 100;
    public Dice AttackDice { get; } = new Dice(3, 6, 2);
    public Dice DefenceDice { get; } = new Dice(2, 6, 0);

    public Player(int x, int y)
    {
        this.displayChar = '@';
        this.Color = ConsoleColor.White;
        this.x = x; 
        this.y = y;
        this.AttackDice = AttackDice;
        this.DefenceDice = DefenceDice;
    }

}