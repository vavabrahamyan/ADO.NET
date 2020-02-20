using System;
using System.Data.SqlClient;
using System.Text;

namespace Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source= DESKTOP-BG4E31L; Initial Catalog=usersdb; Integrated Security=True";


            //Delete(connectionString, "delete from Users where Name = 'Vahe'");

            //Insert(connectionString, "insert into Users (Name, Age) values ('Vahe', 25)");

            for (int i = 0; i < 20; i++)
            {

            }

        }

        private static void Delete(string connectionString, string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Set objects: {0}", number);
            }
        }
        private static void Update(string connectionString, string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Set objects: {0}", number);
            }
        }

        private static void Insert(string connectionString, string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Set objects: {0}", number);
            }
        }
    }
}
