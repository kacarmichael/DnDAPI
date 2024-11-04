// See https://aka.ms/new-console-template for more information

namespace DnDConsole;

internal class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, int> diceSet = new Dictionary<int, int>
        {
            { 4, 0 },
            { 8, 0 },
            { 10, 0 },
            { 12, 0 },
            { 20, 0 },
            { 100, 0 }
        };

        foreach (KeyValuePair<int, int> dice in diceSet)
        {
            Console.WriteLine("Enter total # of D" + dice.Key);
            int num;
            bool exitFlag = false;
            while (!exitFlag)
            {
                try
                {
                    int.TryParse(Console.ReadLine(), out num);
                    diceSet[dice.Key] = num;
                    exitFlag = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }
            }
        }
        
        Roll roll = new Roll(set: diceSet);
        Console.WriteLine("Result of roll: " + roll.getRoll());
    }
}