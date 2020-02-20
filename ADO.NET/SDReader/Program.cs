using System;
using System.Data.SqlClient;

namespace SDReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-BG4E31L;Initial Catalog=usersdb;Integrated Security=True";
            string sqlExtention = "SELECT SUM(*) FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExtention, connection);

                command.CommandText = "SELECT SUM(--columeName--) FROM --table--";
                object num = command.ExecuteScalar();


                Console.WriteLine(num);
            }
            Console.Read();
        }
    }
}
