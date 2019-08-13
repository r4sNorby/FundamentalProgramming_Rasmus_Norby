using System;

namespace Parring
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Sort array
             * { 9, 3, 9, 3, 9, 7, 9 }
             * { 9, 9, 3, 3, 9, 9, 7 }
             */

            Random ran = new Random();
            int n;
            int x = 0;

            int pair1;
            int pair2;
            int i = 0;

            // User decides array size
            Console.WriteLine("How big would you like the array to be?");
            n = int.Parse(Console.ReadLine());

            // Control input
            while (n % 2 == 0 || n == 1 || n < 0)
            {
                Console.Clear();
                Console.WriteLine("Please insert an uneven number bigger than 1!");
                n = int.Parse(Console.ReadLine());
            }

            int[] a = new int[n];

            //Generate array
            while (i <= n - 2)
            {
                pair1 = ran.Next(-10, 10);
                pair2 = ran.Next(-10, 10);

                while (pair1 != pair2)
                {
                    // Gen pairs next to each other
                    pair1 = ran.Next(-10, 10);
                    pair2 = ran.Next(-10, 10);
                }
                a[i] = pair1;
                a[i + 1] = pair2;
                i++;
                i++;
            }
            // Gen solo-value
            a[i] = ran.Next(-10, 10);

            // Shuffle array for display
            for (int j = 0; j < n; j++)
            {
                int ranIndex = ran.Next(1, n - 1);
                int temp = a[j];
                a[j] = a[ranIndex];
                a[ranIndex] = temp;
            }

            // Pair the array
            PairArray(a, n, x);

            SortArray(a, n);

            Console.ReadKey();
        }

        static void PairArray(int[] a, int n, int x)
        {

            bool pairFound;

            Console.Clear();
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
            Console.WriteLine("\nArray after pairing: [{0}] ", string.Join(", ", a));
            Console.WriteLine("\nThe value '{0}' can't be paired", x);
        }

        static void SortArray(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                // This loop runs through the rest of the numbers trying to find a pair
                for (int j = i + 1; j < n; j++)
                {
                    // In case 'j' finds an integer that matches 'i', it swaps 'j' with 
                    // the integer right of 'i', effectively creating a "pair" of integers next to each other
                    if (a[j] < a[i])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            Console.WriteLine("\nArray after sorting: [{0}] ", string.Join(", ", a));
        }
    }
}
