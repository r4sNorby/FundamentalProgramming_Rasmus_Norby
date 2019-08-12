using System;

namespace Parring
{
    class Program
    {
        static void Main(string[] args)
        {
             // Future update: Make the array random

            /*
             * { 9, 3, 9, 3, 9, 7, 9 }
             * { 9, 9, 3, 3, 9, 9, 7 }
             */

            int[] a = { 8, 9, 3, 9, 5, 3, 9, 7, 9, 5, 8 };
            //int[] a = { 9, 7, 9, 3, 9, 3, 9 };
            // Remember to change n accordingly
            int n = 11;
            int x = 0;

            PairArray(a, n, x);
        }

        static void PairArray(int[] a, int n, int x)
        {
            
            bool pairFound;

            // Write the array once for comparison
            Console.WriteLine("Array before pairing: [{0}]", string.Join(", ", a));

            // This loop iterates through each integer in the array
            for (int i = 0; i < n; i++)
            {
                pairFound = false;
                // This loop runs through the rest of the numbers trying to find a pair
                for (int j = i + 1; j < n; j++)
                {
                    // In case 'j' finds an integer that matches 'i', it swaps 'j' with 
                    // the integer right of 'i', effectively creating a "pair" of integers next to each other
                    if (a[j] == a[i])
                    {
                        int temp = a[i + 1];
                        a[i + 1] = a[j];
                        a[j] = temp;
                        pairFound = true;
                        break;
                    }

                }

                // If we can't find a pair, then this must be the integer we are looking for!
                // 'x' is set to that value...
                if (!pairFound)
                {
                    x = a[i];
                }
                // if a pair was found, we "skip" a number (the second number of the pair)
                // and try the next 'i' value
                else
                {
                    i++;
                }
            }

            // ...and then printed
            Console.WriteLine("Array after pairing: [{0}] ", string.Join(", ", a));
            Console.WriteLine("The value '{0}' can't be paired", x);
            Console.ReadKey();
        }
    }
}
