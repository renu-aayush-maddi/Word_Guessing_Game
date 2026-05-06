namespace Word_Guessing_Game.Services
{
   internal class FeedbackGenerator
    {
        public char[] GenerateFeedback(string hiddenWord,string guess)
        {
            char[] feedback = new char[5];
            char[] hiddenChars = hiddenWord.ToCharArray();

            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == hiddenChars[i])
                {
                    feedback[i] = 'G';
                    hiddenChars[i] = '*';
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (feedback[i] == 'G')
                {
                    continue;
                }

                int index = Array.IndexOf(hiddenChars, guess[i]);

                if (index != -1)
                {
                    feedback[i] = 'Y';
                    hiddenChars[index] = '*';
                }
                else
                {
                    feedback[i] = 'X';
                }
            }

            return feedback;
        }
    }   
}
