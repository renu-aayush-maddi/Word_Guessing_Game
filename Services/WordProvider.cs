namespace Word_Guessing_Game.Services
{
    internal class WordProvider
    {
        private List<string> words = new List<string>
            {
                "LUCAS",
                "DUSTY",
                "ROBIN",
                "BILLY",
                "STEVE",
                "NANCY"
            };

        public string GetWord()
        {
            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index];
        }
        
    }
}