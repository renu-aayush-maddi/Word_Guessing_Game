namespace Word_Guessing_Game.Services
{
    internal class ScoreCalculator
    {
        public int CalculateScore(int attempt)
        {
            return (7 - attempt) * 10;
        }
    }
}