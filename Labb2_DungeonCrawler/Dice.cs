
/// <summary>
/// Will give you a set of very shiny dice.
/// </summary>
class Dice
{
    public int numberOfDice { get; set; }
    public int sidesPerDice { get; set; }
    public int modifier { get; set; }
    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        this.numberOfDice = numberOfDice;
        this.sidesPerDice = sidesPerDice;
        this.modifier = modifier;
    }

 
    public int Roll(Dice dice)
    {
        int sum = 0;

        Random rnd = new Random();

        for (int i = 0; i < dice.numberOfDice; i++)
        {
            sum += rnd.Next(dice.sidesPerDice);
        }

        return sum + dice.modifier;
    }

    public override string ToString()
    {
        return this.numberOfDice + "d" + this.sidesPerDice + "+" + this.modifier;
    }
}