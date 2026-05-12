using Npgsql;

namespace Word_Guessing_Game.Database
{
    internal class DbConnection
    {
        string connectionString ="Host=localhost;Port=5469;Database=Game;Username=postgres;Password=aayush05";
        public NpgsqlConnection Connect()
        {
            return new NpgsqlConnection(connectionString);
        }
        
    }
}