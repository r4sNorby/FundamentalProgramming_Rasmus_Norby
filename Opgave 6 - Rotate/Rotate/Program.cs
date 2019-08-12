using System;

namespace Rotate
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Rotates an Array right
             * { 1, 2, 8, 9, 5} 
             * { 5, 1, 2, 8, 9}
             * { 9, 5, 1, 2, 8}
             */
            int k;
            int n;
            Random ran = new Random();


            // Enter the size of the array
            Console.Write("Enter the amount of numbers in the array: ");
            n = int.Parse(Console.ReadLine());


            // Generate an array with 'n' random integers
            int[] a = new int[n];

            for (int j = 0; j < n; j++)
            {
                a[j] = ran.Next(1, 11);
            }

            // Enter rotations
            Console.Write("Enter rotations: ");
            k = int.Parse(Console.ReadLine());

            Rotate(k, n, a);
        }

        static void Rotate(int k, int n, int[] a)
        {
            // Print the current array once
            Console.WriteLine("\nArray: [{0}]", string.Join(", ", a));

            // This loop controls the amount of rotations
            for (int i = 0; i < k; i++)
            {
                // Temporarily saves the last value in the array
                int temp = a[n - 1];

                // This loop moves each int in the array right by 1
                for (int x = n; x - 1 > 0; x--)
                {
                    a[x - 1] = a[x - 2];
                }
                // Place the 'temp' value in the first position in the array
                a[0] = temp;
            }

            Console.WriteLine("\nAfter rotating, the array becomes: [{0}]", string.Join(", ", a));
            Console.ReadKey();
        }
    }
}
