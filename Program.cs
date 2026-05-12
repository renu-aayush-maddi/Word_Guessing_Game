using Word_Guessing_Game.Models;
using Word_Guessing_Game.Repositories;
using Word_Guessing_Game.Services;

namespace Word_Guessing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRepository repository = new UserRepository();

            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");

            string choice = Console.ReadLine() ?? "";

            if(choice == "2")
            {
                User newUser = new User();

                Console.Write("Username : ");
                newUser.Username = Console.ReadLine() ?? "";

                Console.Write("Password : ");
                newUser.Password = Console.ReadLine() ?? "";

                repository.Register(newUser);
            }

            User? loggedInUser = null;

            while(loggedInUser == null)
            {
                Console.WriteLine("\nLogin");

                Console.Write("Username : ");
                string username = Console.ReadLine() ?? "";

                Console.Write("Password : ");
                string password = Console.ReadLine() ?? "";

                loggedInUser = repository.Login(username,password);

                if(loggedInUser == null)
                {
                    Console.WriteLine("Invalid credentials.Try again!");
                }
            }

            bool playAgain = true;
            ScoreRepository scoreRepository = new ScoreRepository();

            while(playAgain)
            {
                Game game = new Game(loggedInUser);

                game.Start();

                Console.WriteLine("\nView Top 5 Scores? (yes/no)");
                string scoreOption = Console.ReadLine()!.Trim().ToLower();

                if(scoreOption.StartsWith("y"))
                {
                    scoreRepository.GetRecentTopScores();
                }

                Console.WriteLine("\nPlay Again? (yes/no)");
                string option = Console.ReadLine()!.Trim().ToLower();

                playAgain = option.StartsWith("y");
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}