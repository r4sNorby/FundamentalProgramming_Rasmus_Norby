using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            int calculationNum = 0;
            bool negativeNumbers = false;
            MainMenu(points, calculationNum, negativeNumbers);
        }

        // Main Menu
        static int MainMenu(int points, int calculationNum, bool negativeNumbers)
        {
            string op;
            int diff;
            int diffPoints;

            Console.Clear();
            Console.WriteLine("* * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("*      Welcome to the MathGame!     *");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("Press A to test your addition");
            Console.WriteLine("Press S to test your subtraction");
            Console.WriteLine("Press M to test your multiplication");
            Console.WriteLine("Press D to test your division");
            Console.WriteLine("Press N to toggle negative numbers");
            Console.WriteLine("Negative numbers are currently {0}", negativeNumbers);
            Console.WriteLine("Press L to see list of HighScores");
            Console.WriteLine("Press X to exit");

            if (points > 0)
            {
                Console.WriteLine("\nYou have done {0} out of 10 calculations", calculationNum);
                Console.WriteLine("and you currently have {0} points", points);
            }

            ConsoleKeyInfo button = Console.ReadKey();


            switch (button.Key)
            {
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    op = "+";
                    diff = Difficulty(points, calculationNum, negativeNumbers);
                    diffPoints = DiffPoints(diff);
                    points = Calculate(diff, op, points, diffPoints, calculationNum, negativeNumbers);
                    break;
                case ConsoleKey.S:
                    Console.Clear();
                    op = "-";
                    diff = Difficulty(points, calculationNum, negativeNumbers);
                    diffPoints = DiffPoints(diff);
                    points = Calculate(diff, op, points, diffPoints, calculationNum, negativeNumbers);
                    break;
                case ConsoleKey.M:
                    Console.Clear();
                    op = "*";
                    diff = Difficulty(points, calculationNum, negativeNumbers);
                    diffPoints = DiffPoints(diff);
                    points = Calculate(diff, op, points, diffPoints, calculationNum, negativeNumbers);
                    break;
                case ConsoleKey.D:
                    Console.Clear();
                    op = "/";
                    diff = Difficulty(points, calculationNum, negativeNumbers);
                    diffPoints = DiffPoints(diff);
                    points = Calculate(diff, op, points, diffPoints, calculationNum, negativeNumbers);
                    break;
                case ConsoleKey.N:
                    negativeNumbers = !negativeNumbers;
                    MainMenu(points, calculationNum, negativeNumbers);
                    break;
                case ConsoleKey.L:
                    ScoreList(points, calculationNum, negativeNumbers);
                    break;
                default:
                    points = MainMenu(points, calculationNum, negativeNumbers);
                    break;
            }
            return points;
        }

        // Chose difficulty
        static int Difficulty(int points, int calculationNum, bool negativeNumbers)
        {
            Console.Clear();
            Console.WriteLine("Choose difficulty from 1 - 4");

            int diff = 0;
            ConsoleKeyInfo button = Console.ReadKey();

            switch (button.Key)
            {
                case ConsoleKey.D1:
                    diff = 1;
                    break;
                case ConsoleKey.D2:
                    diff = 2;
                    break;
                case ConsoleKey.D3:
                    diff = 3;
                    break;
                case ConsoleKey.D4:
                    diff = 4;
                    break;
                case ConsoleKey.X:
                    MainMenu(points, calculationNum, negativeNumbers);
                    break;
                default:
                    diff = Difficulty(points, calculationNum, negativeNumbers);
                    break;
            }
            return diff;
        }

        // Points based on on difficulty for display in the TestAnswer method
        static int DiffPoints(int diff)
        {
            int diffPoints = 0;

            switch (diff)
            {
                case 1:
                    diffPoints = 100;
                    break;
                case 2:
                    diffPoints = 200;
                    break;
                case 3:
                    diffPoints = 300;
                    break;
                case 4:
                    diffPoints = 500;
                    break;
            }
            return diffPoints;
        }

        // The main calculation method. Keeps everything together
        static int Calculate(int diff, string op, int points, int diffPoints, int calculationNum, bool negativeNumbers)
        {
            double num1;
            double num2;
            double result = 0;
            double answer;
            int attempts = 0;

            while (calculationNum <= 1)
            {
                InnerMenu(points, calculationNum, negativeNumbers);
                calculationNum++;

                num1 = GenNumbers(diff);
                num2 = GenNumbers(diff);

                if(negativeNumbers == false)
                {
                    switch (op)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            while (num1 < num2 && num1 == num2)
                            {
                                num1 = GenNumbers(diff);
                                num2 = GenNumbers(diff);
                            }
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            while(num1 == num2 || num1 % num2 != 0)

                            {
                                num1 = GenNumbers(diff);
                                num2 = GenNumbers(diff);
                            }
                            result = num1 / num2;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (op)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            result = num1 / num2;
                            break;
                        default:
                            break;
                    }
                }

                answer = Answer(num1, op, num2);
                points = TestAnswer(answer, result, attempts, num1, op, num2, diff, points, diffPoints, negativeNumbers);
            }
            HighScore(points, calculationNum, negativeNumbers);

            return points;
        }

        // Generate numbers
        static double GenNumbers(int diff)
        {
            Random ran = new Random();
            double tal = 0;

            switch (diff)
            {
                case 1:
                    tal = ran.Next(1, 10);
                    break;
                case 2:
                    tal = ran.Next(5, 100);
                    break;
                case 3:
                    tal = ran.Next(20, 250);
                    break;
                case 4:
                    tal = ran.Next(100, 1000);
                    break;
                default:
                    break;
            }
            return tal;
        }

        // Control that the users input is actually a number
        static double Control(string input, double num1, string op, double num2)
        {
            if (double.TryParse(input, out double answer)) { }
            else
            {
                Console.Clear();
                Console.WriteLine("Please use a number:");
                Console.Write("{0} {1} {2} = ", num1, op, num2);
                answer = Control(Console.ReadLine(), num1, op, num2);
            }
            return answer;
        }

        // Inner menu to go back to the main menu or continue
        static double InnerMenu(int points, int calculationNum, bool negativeNumbers)
        {
            Console.Clear();
            Console.WriteLine("Your have {0} points", points);
            Console.WriteLine("Press any key to continue or press 'X' to exit to main menu");
            ConsoleKeyInfo button = Console.ReadKey();

            switch (button.Key)
            {
                case ConsoleKey.X:
                    MainMenu(points, calculationNum, negativeNumbers);
                    break;
                default:
                    Console.Clear();
                    break;
            }
            return calculationNum;
        }

        // Compare the users answer to the result
        static int TestAnswer(double answer, double result, int attempts, double num1, string op, double num2, int diff, int points, int diffPoints, bool negativeNumbers)
        {
            attempts++;
            int win;
            if (answer == result)
            {
                Console.Clear();
                attempts = 0;
                win = 1;
                if (points > 0)
                {
                    Console.WriteLine("You now have {0} +{1} points!", points, diffPoints);
                }
                else
                {
                    Console.WriteLine("You gain +{0} points!", diffPoints);
                }
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
            else if (attempts >= 3)
            {
                Console.Clear();
                attempts = 0;
                win = 2;
                Console.WriteLine("Wrong! You lose {0} points! The result was: {1}", diffPoints, result);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                win = 3;
                Console.WriteLine("You lose 50 points");
                points -= 50;
                Console.WriteLine("Try again:");
                answer = Answer(num1, op, num2);
                points = TestAnswer(answer, result, attempts, num1, op, num2, diff, points, diffPoints, negativeNumbers);
            }
            points = CalcPoints(points, win, diff, negativeNumbers);
            return points;
        }

        // Grab the users input
        static double Answer(double num1, string op, double num2)
        {
            Console.Write("{0} {1} {2} = ", num1, op, num2);
            double answer = Control(Console.ReadLine(), num1, op, num2);
            return answer;
        }

        // Calculate the users score
        static int CalcPoints(int points, int win, int diff, bool negativeNumbers)
        {
            switch(negativeNumbers)
            {
                // In case of negative numbers
                case true:
                    switch (diff)
                    {
                        case 1:
                            switch (win)
                            {
                                case 1:
                                    points += 200;
                                    break;
                                case 2:
                                    points -= 75;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            switch (win)
                            {
                                case 1:
                                    points += 400;
                                    break;
                                case 2:
                                    points -= 225;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 3:
                            switch (win)
                            {
                                case 1:
                                    points += 600;
                                    break;
                                case 2:
                                    points -= 275;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 4:
                            switch (win)
                            {
                                case 1:
                                    points += 1000;
                                    break;
                                case 2:
                                    points -= 525;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                // In case of non-negative numbers
                case false:
                    switch (diff)
                    {
                        case 1:
                            switch (win)
                            {
                                case 1:
                                    points += 100;
                                    break;
                                case 2:
                                    points -= 50;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            switch (win)
                            {
                                case 1:
                                    points += 200;
                                    break;
                                case 2:
                                    points -= 100;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 3:
                            switch (win)
                            {
                                case 1:
                                    points += 300;
                                    break;
                                case 2:
                                    points -= 150;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 4:
                            switch (win)
                            {
                                case 1:
                                    points += 500;
                                    break;
                                case 2:
                                    points -= 250;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return points;
        }

        static void HighScore(int points, int calculationNum, bool negativeNumbers)
        {
            int[] pointsArray = new int[10];
            string[] namesArray = new string[10];
            string score;
            string name;

            // Insert username
            Console.WriteLine("Insert your name:");
            name = Console.ReadLine();

            using (StreamReader sr = new StreamReader("HighScore.txt"))
            {
                int i = 0;
                while ((score = sr.ReadLine()) != null)
                {
                    namesArray[i] = sr.ReadLine().ToString();
                    pointsArray[i] = int.Parse(sr.ReadLine());
                    i++;
                }
            }

            // If the last score in pointsArray is less than the new score, replace that score
            if (pointsArray[pointsArray.Length - 1] < points)
            {
                namesArray[namesArray.Length - 1] = name;
                pointsArray[pointsArray.Length - 1] = points;
            }
            else
            {
                Console.WriteLine("You did not get enough points for a high score");
                Console.ReadKey();
                MainMenu(points, calculationNum, negativeNumbers);
            }

            // Sort high scores
            int tempPoints;
            string tempName;
            int smallest;
            for (int i = 0; i < 10 - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < 10; j++)
                {
                    if (pointsArray[j] > pointsArray[smallest])
                    {
                        smallest = j;
                    }
                }
                tempPoints = pointsArray[smallest];
                pointsArray[smallest] = pointsArray[i];
                pointsArray[i] = tempPoints;

                tempName = namesArray[smallest];
                namesArray[smallest] = namesArray[i];
                namesArray[i] = tempName;
            }

            // Remove 11th element
            if (pointsArray.Length > 10)
            {
                int numToRemove = 11;
                pointsArray = pointsArray.Where(val => val != numToRemove).ToArray();
            }

            // Put points and names into Players
            Player[] players = new Player[20];

            for (int k = 0; k < 10; k++)
            {
                namesArray[k] = name;
                pointsArray[k] = points;
                players[k] = new Player(name, points);
            }


            // Write high scores to txt
            using (StreamWriter sw = new StreamWriter("HighScore.txt"))
            {
                foreach(int i in pointsArray)
                {
                    sw.WriteLine(i);
                    sw.WriteLine(i);
                }
            }
            MainMenu(points, calculationNum, negativeNumbers);
            
        }

        static int ScoreList(int points, int calculationNum, bool negativeNumbers)
        {
            // Read and show each line from the file.
            Console.Clear();
            string line;
            using (StreamReader sr = new StreamReader("HighScore.txt"))
            {
                /*while ((line = sr.ReadLine()) != null)
                {
                    int score = ReadLine(line);
                    string name = ReadLine(line);
                    Console.WriteLine("{0} - {1}", score, name);
                }*/
            }

            Console.WriteLine("\nPress any button to return");
            ConsoleKeyInfo button = Console.ReadKey();
            switch (button.Key)
            {
                default:
                    MainMenu(points, calculationNum, negativeNumbers);
                    break;
            }
            return calculationNum;
        }
    }
    public class Player
    {
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }
}
