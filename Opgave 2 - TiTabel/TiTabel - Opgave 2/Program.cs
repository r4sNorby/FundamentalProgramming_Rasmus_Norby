using System;

namespace TiTabel___Opgave_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum;

            // Første loop sætter en 'i' værdi
            for (int i = 1; i <= 10; i++)
            {
                // hvorefter at dette loop udskriver 'i' gange 'j'
                for (int j = 1; j <= 10; j++)
                {
                    sum = i * j;
                    Console.Write(sum.ToString().PadLeft(5));
                }
                // Når der er udskrevet 10 værdier skiftes der til næste linje 
                // og det hele starter forfra med en ny 'i' værdi
                Console.WriteLine();
            }
            Console.ReadLine();
          
        }
    }
}
