using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_09_06
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Give me two numbers to set the range for the game:");
                string given1 = Console.ReadLine();
                string given2 = Console.ReadLine();
                int g1 = int.Parse(given1);
                int g2 = int.Parse(given2);

                if (g1 >= g2 || g1 < 1)
                {
                    Console.WriteLine("Invalid range. The first number should be less than the second number and greater than or equal to 1.");
                    return;
                }

                int targetNumber = MakeGuessNumber(g1, g2);
                Console.WriteLine("Thank you! Try to guess the number between " + g1 + " and " + g2 + ":");

                int lives = targetNumber / 3;

                while (lives > 0)
                {
                    string guess = Console.ReadLine();
                    int guessedNumber;

                    if (int.TryParse(guess, out guessedNumber))
                    {
                        string result = GuessedNumber(targetNumber, guessedNumber);

                        if (result.StartsWith("You have tried it and you guessed the number"))
                        {
                            Console.WriteLine(result);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(result);
                            lives--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

                if (lives == 0)
                {
                    Console.WriteLine("You ran out of lives. The number was: " + targetNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static int MakeGuessNumber(int x, int y)
        {
            Random random = new Random();
            return random.Next(x, y + 1);
        }

        static string GuessedNumber(int target, int guessed)
        {
            if (guessed == target)
            {
                return "You have tried it and you guessed the number it was: " + target;
            }
            else if (guessed < target)
            {
                return "Too low. Try again!";
            }
            else
            {
                return "Too high. Try again!";
            }
        }

    }
}
