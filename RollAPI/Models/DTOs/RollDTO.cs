using DnDConsole;

namespace RollAPI.Models.DTOs;

public class RollResponseDto
{
    public int Id { get; set; }
    public Dictionary<int, int> DiceSet { get; set; }
    public int RollSum { get; set; }
    
    public RollResponseDto() {}
    
    public RollResponseDto(int id, Dictionary<int, int> set)
    {
        Id = id;
        DiceSet = set;
        RollSum = GetRoll(DiceSet);
    }

    public RollResponseDto(Roll roll)
    {
        Id = roll.Id;
        DiceSet = roll.DiceSet;
        RollSum = GetRoll(roll.DiceSet);
    }

    public RollResponseDto(RollRequestDto req)
    {
        Id = 0;
        DiceSet = req.DiceSet;
        RollSum = GetRoll(req.DiceSet);
    }

    private static int GetRoll(Dictionary<int, int> diceSet)
    {
        int sum = 0;
        
        foreach (KeyValuePair<int, int> dice in diceSet)
        {
			foreach (int i in Enumerable.Range(0, dice.Value)) 
			{
                sum += Random.Shared.Next(minValue: 1, maxValue: dice.Key);
            }
        }

        return sum;
    }
}

public class RollRequestDto
{
    public Dictionary<int, int> DiceSet { get; set; }
    
    public RollRequestDto() {}
    
    public RollRequestDto(Dictionary<int, int> set)
    {
        DiceSet = set;
    }

    public RollRequestDto(Roll roll)
    {
        DiceSet = roll.DiceSet;
    }
    
    
    public static int GetRoll(Dictionary<int, int> diceSet)
    {
        int sum = 0;
        
        foreach (KeyValuePair<int, int> dice in diceSet)
        {
			foreach (int i in Enumerable.Range(0, dice.Value)) 
			{
                sum += Random.Shared.Next(minValue: 1, maxValue: dice.Key);
            }
        }

        return sum;
    }
}