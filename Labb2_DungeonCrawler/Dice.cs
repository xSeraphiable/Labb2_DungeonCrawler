
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


    public int Roll()
    {
        int sum = 0;

        Random rnd = new Random();

        for (int i = 0; i < numberOfDice; i++)
        {
            sum += rnd.Next(sidesPerDice);
        }

        return sum + modifier;
    }

    public override string ToString()
    {
        return this.numberOfDice + "d" + this.sidesPerDice + "+" + this.modifier;
    }
}