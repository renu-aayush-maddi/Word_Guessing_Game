using Word_Guessing_Game.Exceptions;

namespace Word_Guessing_Game.Services
{
    internal class GuessValidator
    {
        public static void Validate(string guess)
        {
            if(string.IsNullOrWhiteSpace(guess))
            {
                throw new InvalidGuessException("Input cannot be empty!");
            }
            if (guess.Any(char.IsDigit))
            {
                throw new InvalidGuessException("Numbers are not allowed");
            }
            if (!guess.All(char.IsLetter))
            {
                throw new InvalidGuessException("Special characters are not allowed");
            }

            if(guess.Length < 5)
            {
                throw new InvalidGuessException("Input contains less than 5 letters.It must be exactly 5 letters");
            }

            if (guess.Length > 5)
            {
                throw new InvalidGuessException("Input cannot exceed 5 letters");
            }

        }
    }
}