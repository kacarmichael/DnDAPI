namespace DnDConsole;

public class Roll
{
    public Dictionary<int, int> diceSet;
    private Random rnd = new Random();

    public Roll(Dictionary<int, int> set)
    {
        // sides: numDice
        this.diceSet = set;
    }

    public int getRoll()
    {
        int sum = 0;
        
        foreach (KeyValuePair<int, int> dice in diceSet)
        {
            sum += rnd.Next(minValue: 1, maxValue: dice.Key) * dice.Value;
        }

        return sum;
    }
}