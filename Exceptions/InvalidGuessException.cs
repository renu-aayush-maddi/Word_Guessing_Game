namespace Word_Guessing_Game.Exceptions
{
    internal class InvalidGuessException : Exception
    {
        public InvalidGuessException(string message): base(message)
        {

        }
    }
}