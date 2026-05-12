using Npgsql;
using Word_Guessing_Game.Database;
using Word_Guessing_Game.Models;

namespace Word_Guessing_Game.Repositories
{
    internal class UserRepository
    {
        private NpgsqlConnection connection;
        public UserRepository()
        {
            connection = new DbConnection().Connect();
        }

        public bool Register(User user)
        {
            string insertCommand =$"insert into users(username,password) values('{user.Username}','{user.Password}')";
            NpgsqlCommand command = new NpgsqlCommand(insertCommand,connection);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Registration successful");
                    return true;
                }
            }
            catch (PostgresException ex)
            {
                if(ex.SqlState == "23505") { Console.WriteLine("Username already exists"); }
                else
                {
                Console.WriteLine(ex.Message);
                }
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public User? Login(string username, string password)
        {
            string selectCommand = $"select * from users where username='{username}' and password='{password}'";
            NpgsqlCommand command = new NpgsqlCommand(selectCommand,connection);

            try
            {
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Username = reader[1].ToString()!,
                        Password = reader[2].ToString()!
                    };
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

            return null;
        }
    }

}
