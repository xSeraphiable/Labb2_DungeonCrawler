abstract class Enemy : LevelElement
{
    public string Name { get; set; }

    public int Health { get; set; }

    public Dice AttackDice { get; set; }

    public Dice DefenceDice { get; set; }

    //TODO: behöver antagligen också ta inparametrar med spelarens koordinater.
    public abstract void Update(IReadOnlyList<LevelElement> Elements, Player p);

}
