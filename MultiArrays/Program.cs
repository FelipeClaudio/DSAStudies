using System;

namespace MultiArrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int [,] multiArray = new int [,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            for (int row = 0; row < multiArray.GetLength(0); row++)
            {
                for (int column = 0; column < multiArray.GetLength(1); column++)
                {
                    int oldValue = multiArray[row, column];
                    int newValue = oldValue * 3;
                    Console.WriteLine($"OldValue: {oldValue} | NewValue: {newValue}");
                }
            }

            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[] {1, 2, 3};
            jaggedArray[1] = new int[] {4, 5, 6};
            jaggedArray[3] = new int[] {7, 8, 9};

            Console.WriteLine(jaggedArray[0][2]);
            Console.WriteLine(jaggedArray[1][0]);
            Console.WriteLine(jaggedArray[2]);
            Console.WriteLine(jaggedArray[3]);
            Console.WriteLine("Funciona!");
        }
    }
}