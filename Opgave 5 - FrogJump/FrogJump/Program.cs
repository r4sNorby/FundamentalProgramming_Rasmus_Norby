using System;

namespace FrogJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = CalcJumps(10, 85, 30);

            Console.WriteLine("Frøen skal hoppe minimum {0:D} gange", result);

            Console.ReadLine();
        }

        // CalcJumps metode til at regne antallet af hop ud
        private static int CalcJumps(int X, int Y, int D)
        {
            // X er startposition
            // Y er slutposition
            // D er distancen som frøen hopper
            int i;

            // Antallet af hop regnes ud
            for (i = 0; X < Y; i++)
            {
                X += D;
            }

            return i;
        }
    }
}
