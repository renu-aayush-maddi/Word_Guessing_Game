namespace Word_Guessing_Game.Services
{
    internal class ConsoleRenderer
    {
        public void DisplayFeedback(string guess,char[] feedback)
        {
            Console.WriteLine();

            for (int i = 0; i < guess.Length; i++)
            {
                Console.Write(guess[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < feedback.Length; i++)
            {
                if (feedback[i] == 'G')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (feedback[i] == 'Y')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(feedback[i] + " ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}




