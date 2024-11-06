using DnDConsole;

namespace RollAPI.DTOs;

public class RollResponseDTO
{
    public int Id { get; set; }
    public Dictionary<int, int> diceSet { get; set; }
    public int RollSum { get; set; }
    
    public RollResponseDTO() {}
    
    public RollResponseDTO(int id, Dictionary<int, int> set)
    {
        Id = id;
        diceSet = set;
        RollSum = getRoll(diceSet);
    }

    public RollResponseDTO(Roll roll)
    {
        Id = roll.Id;
        diceSet = roll.diceSet;
        RollSum = getRoll(roll.diceSet);
    }

    public RollResponseDTO(RollRequestDTO req)
    {
        Id = 0;
        diceSet = req.diceSet;
        RollSum = getRoll(req.diceSet);
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

public class RollRequestDTO
{
    public Dictionary<int, int> diceSet { get; set; }
    
    public RollRequestDTO() {}
    
    public RollRequestDTO(Dictionary<int, int> set)
    {
        diceSet = set;
    }

    public RollRequestDTO(Roll roll)
    {
        diceSet = roll.diceSet;
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