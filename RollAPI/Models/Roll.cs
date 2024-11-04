namespace DnDConsole;

public class Roll
{
    // sides: numDice
    public Dictionary<int, int> diceSet { get; set; }
    public int Id { get; set; }

    public Roll(int id, Dictionary<int, int> set)
    {
        Id = id;
        diceSet = set;
    }
}