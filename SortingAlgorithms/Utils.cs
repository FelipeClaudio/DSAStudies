        using System;
        
        namespace SortingAlgorithms
        {
            public static class Utils
            {
                public static void Swap(this int[] array, int oldIndex, int newIndex)
                {
                    if (oldIndex != newIndex)
                    {
                        int temp = array[oldIndex];
                        array[oldIndex] = array[newIndex];
                        array[newIndex] = temp;
                    }
                }

                public static void Print(this int[] array, string algorithm)
                {
                    Console.WriteLine(algorithm);
                    Console.Write("[");
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write($"{array[i]}");
                        if (i < array.Length - 1)
                            Console.Write(", ");
                    }

                    Console.WriteLine("]");
                }
            }
        }
        
