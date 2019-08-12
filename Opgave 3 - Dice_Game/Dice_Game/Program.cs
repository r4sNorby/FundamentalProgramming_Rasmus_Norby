using System;

namespace Dice_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Her bliver der kastet en terning af gangen indtil at der bliver slået en sekser. 

            /* 
            Random dice = new Random();
            int res;
            int x = 0;
            int antal;
            int sum = 0;

            Console.Write("Indtast antal terningner der skal kastes: ");
            antal = int.Parse(Console.ReadLine());

            // Dette loop itererer gennem antallet af terninger
            for (int i = 0; i < antal; i++)
            {
            // Dette loop slår med terningen indtil at der bliver slået en sekser
                do
                {
                // Variablen 'x' holder styr på mængden af slag med terningerne
                    res = dice.Next(1, 7);
                    x++;

                } while (res != 6);

                sum += 6;
                x++;
            }

            Console.WriteLine("Det tog {0:D} kast, at slå {1:D} seksere, med en sum på {2:D}", x, antal, sum);

            Console.ReadLine();
             */


            // Her bliver alle terninger kastet på en gang, hvert kast
            Random dice = new Random();
            int resultat;
            int x;
            int i = 0;

            Console.Write("Indtast antal terningner der skal kastes: ");
            x = int.Parse(Console.ReadLine());
 
            do
            {
                // For loopet slår med hver terning x antal gange
                resultat = 0;
                for (int j = 0; j <= x; j++)
                {
                    resultat += dice.Next(1, 7);
                }

                i++;
                // hvorefter at do while loopet tjekker om resultatet er lig med antallet af terninger gange 6, ellers slår den med terningerne igen!
            } while (x * 6 != resultat);

            Console.WriteLine("Det tog {0:D} kast, at slå {1:D} seksere", i, x);
            Console.ReadLine();
        }
    }
}
