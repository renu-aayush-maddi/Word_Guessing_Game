using Word_Guessing_Game.Exceptions;
using Word_Guessing_Game.Services;

namespace Word_Guessing_Game.Models
{
    internal class Game
    {
        private string hiddenWord;
        private int maxAttempts = 6;
        private List<string> guessedWords = new List<string>();
        private WordProvider provider = new WordProvider();
        private FeedbackGenerator feedbackGenerator = new FeedbackGenerator();
        private ConsoleRenderer renderer = new ConsoleRenderer();
        private CommentGenerator commentGenerator = new CommentGenerator();
        private ScoreCalculator scoreCalculator = new ScoreCalculator();

        public Game()
        {
            hiddenWord = provider.GetWord();
        }

        public void Start()
        {
            Console.WriteLine("-----WORD GUESS GAME----");

            for (int attempt =1; attempt<=maxAttempts; attempt++)
            {
                try
                {
                    Console.WriteLine($"\nAttempt {attempt}/{maxAttempts}");

                    Console.Write("Enter a 5-letter word: ");

                    string guess = Console.ReadLine()!.ToUpper();

                    GuessValidator.Validate(guess);

                    if (guessedWords.Contains(guess))
                    {
                        renderer.ShowError("Duplicate guess not allowed.Try a different word!");
                        attempt--;
                        continue;
                    }

                    guessedWords.Add(guess);

                    char[] feedback = feedbackGenerator.GenerateFeedback(hiddenWord,guess);

                    renderer.DisplayFeedback(guess,feedback);

                    if (guess == hiddenWord)
                    {
                        renderer.ShowSuccess("You guessed the word!");
                        Console.WriteLine(commentGenerator.GetComment(attempt));
                        int score =scoreCalculator.CalculateScore(attempt);
                        Console.WriteLine($"Score:{score}");
                        return;
                    }
                }
                catch (InvalidGuessException ex)
                {
                    renderer.ShowError(ex.Message);
                    attempt--;
                }
            }

            renderer.ShowWarning($"Game Over! Hidden word was : {hiddenWord}");
        }
    }
}