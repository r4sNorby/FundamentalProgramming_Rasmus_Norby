using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        // Main Menu
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("* * * * * * * * * * * *");
            Console.WriteLine("*      Calculator     *");
            Console.WriteLine("* * * * * * * * * * * *");
            Console.WriteLine("Welcome to my Calculator!");
            Console.WriteLine("Press 'C' to calculate");

            var button = Console.ReadKey();
            switch(button.Key)
            {
                case ConsoleKey.C:
                    Input();
                    break;
                default:
                    Input();
                    break;
            }
        }

        // User input
        static void Input()
        {
            double tal1;
            double result = 0;
            bool exit = false;

            Console.Clear();
            Console.WriteLine("Choose a starting number and press Enter to continue: ");
            tal1 = Control(Console.ReadLine());

            do
            {
                Console.Clear();
                string op = "";
                double tal2 = 0;

                Console.WriteLine("Choose an operator and press Enter: ");
                Console.Write("{0} ", tal1);

                // Operator Control
                op = OpControl(Console.ReadLine());

                Console.Clear();
                Console.WriteLine("Chose the next number and press Enter: ");
                Console.Write("{0} {1} ", tal1, op);
                tal2 = Control(Console.ReadLine());

                // Default statement not necessary
                switch (op)
                {
                    case "+":
                        result = Add(tal1, tal2);
                        break;
                    case "-":
                        result = Subtract(tal1, tal2);
                        break;
                    case "*":
                        result = Multiply(tal1, tal2);
                        break;
                    case "/":
                        result = Divide(tal1, tal2);
                        break;
                    default:
                        op = OpControl(Console.ReadLine());
                        break;
                }
                tal1 = InnerMenu(tal1, op, tal2, result);

            } while (!exit);

            Console.ReadLine();
        }

        // Add
        static double Add(double tal1, double tal2)
        {
            double result = tal1 + tal2;
            return result;
        }

        // Subtract
        static double Subtract(double tal1, double tal2)
        {
            double result = tal1 - tal2;
            return result;
        }

        // Multiply
        static double Multiply(double tal1, double tal2)
        {
            double result = tal1 * tal2;
            return result;
        }

        // Divide
        static double Divide(double tal1, double tal2)
        {
            double result = tal1 / tal2;
            return result;
        }

        // Control of user input
        static double Control(string input)
        {
            if (double.TryParse(input, out double answer)){}
            else
            {
                Console.Clear();
                Console.WriteLine("Please use a number:");
                answer = Control(Console.ReadLine());
            }
            return answer;
        }

        // Control of the operator
        static string OpControl(string op)
        {
            switch (op)
            {
                case "+":
                    op = "+";
                    break;
                case "-":
                    op = "-";
                    break;
                case "*":
                    op = "*";
                    break;
                case "/":
                    op = "/";
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please use a proper operator");
                    op = OpControl(Console.ReadLine());
                    break;
            }
            return op;
        }

        // Menu to go back to the Main Menu or continue calculating
        static double InnerMenu(double tal1, string op, double tal2, double result)
        {
            // Add advanced calculator
            Console.Clear();
            Console.WriteLine("{0} {1} {2} = {3}", tal1, op, tal2, result);
            Console.WriteLine("Press 'X' to exit or press Enter to continue");
            var button = Console.ReadKey();

            switch (button.Key)
            {
                case ConsoleKey.X:
                    MainMenu();
                    break;
                case ConsoleKey.Enter:
                    tal1 = result;
                    break;
                default:
                    tal1 = InnerMenu(tal1, op, tal2, result);
                    break;
            }
            return tal1;
        }
    }
}
