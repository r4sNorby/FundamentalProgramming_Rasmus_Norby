using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int minVar = 500;
            int wn;

            Console.WriteLine("Indtast et tal");
            minVar = int.Parse(Console.ReadLine());
            for(int n = 0; n <= minVar; n++)
            {
                Console.Write("*");
            }
            Console.ReadLine();

            wn = 0;
            while (wn < minVar)
            {
                Console.Write("+");
                wn++;
            }
            Console.ReadLine();
        }
    }
}
