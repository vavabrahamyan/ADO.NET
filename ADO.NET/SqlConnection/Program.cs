using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET.Connection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source= DESKTOP-BG4E31L; Initial Catalog=usersdb; Integrated Security=True";
            //ConnectionMethod(connectionString);
            //ConnectWithDB(connectionString);

            Console.ReadLine();
        }
        private static async Task ConnectWithDB(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Async Connection is open");
            }
            Console.WriteLine("Async Connection is closed");
        }

        private static void ConnectionMethod(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connection is open");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error 4004 {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine($"Server Name:={connection.DataSource}");
                connection.Close();
                Console.WriteLine("Connection is closed");
            }

            Console.Read();
        }
    }
}
