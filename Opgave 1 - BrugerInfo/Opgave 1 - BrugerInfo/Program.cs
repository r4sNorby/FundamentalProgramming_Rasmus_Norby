using System;

namespace Opgave_1___BrugerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Velkommen til opgave 1!");
            Console.WriteLine("Tryk på en tast for at fortsætte");
            Console.ReadKey();
            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Tryk på I for at indtaste data");
            Console.WriteLine("Tryk på S for at se forrige data");

            ConsoleKeyInfo button = Console.ReadKey();

            switch(button.Key)
            {
                case ConsoleKey.I:
                    Input();
                    break;
                case ConsoleKey.S:
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        static void Input()
        {
            string firstName;
            string lastName;
            int age;
            string gender;
            int old;
            int oldYear;
            // DateTime.Today finder dagens dato og år
            DateTime today = DateTime.Today;

            Console.Clear();
            Console.WriteLine("Hvad er dit fornavn?");
            firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hvad er dit efternavn?");
            lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hvor gammel er du?");
            age = Control(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Angiv dit køn som mand(m) eller kvinde(k)");
            gender = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hvor gammel mener du at man skal være før man er gammel?");
            old = Control(Console.ReadLine());
            Console.Clear();

            if (gender == "m")
            {
                gender = "mand";
            }
            else
            {
                gender = "kvinde";
            }

            if (age < old)
            {
                // Det år brugeren bliver gammel, bliver regnet ud.
                old -= age;
                oldYear = today.Year + old;
                Console.WriteLine("Hej {0} {1}!", firstName, lastName);
                Console.WriteLine("Der er {0} år til at du bliver en gammel {1}, hvilket bliver i år {2}!", old, gender, oldYear);
            }
            else
            {
                Console.WriteLine("Hej {0} {1}!", firstName, lastName);
                Console.WriteLine("Du er allerede gammel!");
            }
            Console.WriteLine("Tryk på en tast for at gå tilbage til Menuen");
            Console.ReadKey();
            Input();
        }

        static int Control(string input)
        {
            if (int.TryParse(input, out int age)) { }
            else
            {
                Console.Clear();
                Console.WriteLine("Indtast venligst et tal:");
                age = Control(Console.ReadLine());
            }
            return age;
        }
    }
}
