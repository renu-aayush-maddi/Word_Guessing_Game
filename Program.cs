using Word_Guessing_Game.Models;

namespace Word_Guessing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Game game = new Game();

                game.Start();

                Console.WriteLine("\nPlay Again? (yes/no)");

                string choice = Console.ReadLine()?.Trim().ToLower() ?? "";

                playAgain = choice.StartsWith("y");
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}