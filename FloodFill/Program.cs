using System;

namespace FloodFill
{
    class Program
    {
        static void Main(string[] args)
        {
            const string data = "111111";

            Console.WriteLine($"Number of ways: {numberOfWays(data)}");
        }

        static int numberOfWays(string data)
        {
            Console.WriteLine(data);
            if (data.Length == 1)
                return 1;

            int newPossibilities = 0;

            if (data.Length > 2)
            {
                int firstPair = Int32.Parse($"{data[0]}{data[1]}");
                Console.WriteLine($"first pair: {firstPair}");
                if (firstPair > 0 && firstPair <= 26)
                    newPossibilities++;

                if (data.Length > 4)
                {
                    int secondPair = Int32.Parse($"{data[2]}{data[3]}");
                    Console.WriteLine($"first pair: {secondPair}");
                    if (secondPair > 0 && secondPair <= 26)
                        newPossibilities++;
                }

                int lastPair = Int32.Parse($"{data[data.Length - 2]}{data[data.Length - 1]}");
                Console.WriteLine($"last pair: {lastPair}");
                if (lastPair > 0 && lastPair <= 26)
                    newPossibilities++;
            }

            Console.WriteLine($"new possibilities: {newPossibilities}");
            return newPossibilities + numberOfWays(data.Substring(1));
        }
    }
}
