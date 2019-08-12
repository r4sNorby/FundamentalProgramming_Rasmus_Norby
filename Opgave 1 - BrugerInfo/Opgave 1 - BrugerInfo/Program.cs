using System;

namespace Opgave_1___BrugerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            int age;
            char gender;
            int old;
            int oldYear;
            // DateTime.Today finder dagens dato og år
            DateTime today = DateTime.Today;

            Console.WriteLine("Hvad er dit fornavn?");
            firstName = Console.ReadLine();
            Console.WriteLine("Hvad er dit efternavn?");
            lastName = Console.ReadLine();
            Console.WriteLine("Hvor gammel er du?");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Angiv dit køn som mand(m) eller kvinde(k)");
            gender = char.Parse(Console.ReadLine());
            Console.WriteLine("Hvor gammel mener du at man skal være før man er gammel?");
            old = int.Parse(Console.ReadLine());

            if (age < old)
            {
                // Det år brugeren bliver gammel, bliver regnet ud.
                old -= age;
                oldYear = today.Year + old;
                Console.WriteLine("Der er " + old + " år til at du er gammel hvilket bliver i år " + oldYear + "!");
            }
            else
            {
                Console.WriteLine("Du er allerede gammel!");
            }
            Console.ReadLine();
        }
    }
}
