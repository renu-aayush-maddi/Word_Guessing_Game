using Npgsql;
using Word_Guessing_Game.Database;

namespace Word_Guessing_Game.Repositories
{
    internal class WordRepository
    {
        private NpgsqlConnection connection;
        public WordRepository()
        {
            connection = new DbConnection().Connect();
        }

        public string GetWord()
        {
            List<string> words = new List<string>();

            string query ="select word from words";

            NpgsqlCommand command = new NpgsqlCommand(query,connection);

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    words.Add(reader[0].ToString()!);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Random random = new Random();
            int index = random.Next(words.Count);
            
            return words[index];
        }
    }
}