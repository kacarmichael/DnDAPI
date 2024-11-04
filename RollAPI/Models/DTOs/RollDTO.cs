using DnDConsole;

namespace RollAPI.DTOs;

public class RollDTO
{
    public int Id { get; set; }
    public Dictionary<int, int> diceSet { get; set; }
    public int RollSum { get; set; }
    
    public RollDTO(int id, Dictionary<int, int> set)
    {
        Id = id;
        diceSet = set;
        RollSum = getRoll(diceSet);
    }

    public RollDTO(Roll roll)
    {
        Id = roll.Id;
        diceSet = roll.diceSet;
        RollSum = getRoll(roll.diceSet);
    }
    
    public static int getRoll(Dictionary<int, int> diceSet)
    {
        int sum = 0;
        
        foreach (KeyValuePair<int, int> dice in diceSet)
        {
            sum += Random.Shared.Next(minValue: 1, maxValue: dice.Key) * dice.Value;
        }

        return sum;
    }
}