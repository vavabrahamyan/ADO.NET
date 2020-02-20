using System;
using System.Data.SqlClient;

namespace SDReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-BG4E31L;Initial Catalog=usersdb;Integrated Security=True";
            string sqlExtention = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExtention, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}");

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object age = reader.GetValue(2);

                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                }
                reader.Close();
            }
            Console.Read();
        }
    }
}
