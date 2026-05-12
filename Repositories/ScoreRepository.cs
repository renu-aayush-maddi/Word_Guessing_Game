using Npgsql;
using Word_Guessing_Game.Database;

namespace Word_Guessing_Game.Repositories
{
    internal class ScoreRepository
    {
        private NpgsqlConnection connection;
        public ScoreRepository()
        {
            connection = new DbConnection().Connect();
        }

        public void SaveScore(int userId, int score)
        {
            string insertCommand =$"insert into scores(user_id,score) values({userId},{score})";
            NpgsqlCommand command = new NpgsqlCommand(insertCommand,connection);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Score saved");
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
        }

        public void GetRecentTopScores()
        {
            string query ="select u.username, s.score, s.played_on from scores s "+
                            "join users u on s.user_id = u.id "+
                            "order by s.score desc, s.played_on desc "+
                            "limit 5";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            try
            {
                connection.Open();

                NpgsqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("\n=== TOP 5 SCORES ===");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - Score: {reader[1]} - {Convert.ToDateTime(reader[2])}");
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
        }
    }
}