using System;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace _TransactionScope
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString1 = "Data Source=DESKTOP-BG4E31L;Initial Catalog=usersdb;Integrated Security=True";
            string connectionString2 = "Data Source=DESKTOP-BG4E31L;Initial Catalog=MyDB;Integrated Security=True";

            string commandText1 = "SELECT * FROM Users";
            string commandText2 = "SELECT * FROM User";
            CreateTransactionScope(connectionString1, connectionString2, commandText1, commandText2);

        }
        public static int CreateTransactionScope(string connectionString1, string connectionString2, string commandText1, string commandText2)
        {
            int returnValue = 0;
            StringWriter writer = new StringWriter();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection1 = new SqlConnection(connectionString1))
                    {
                        connection1.Open();

                        SqlCommand command1 = new SqlCommand(commandText1, connection1);
                        returnValue = command1.ExecuteNonQuery();
                        writer.WriteLine($"Rows to be affected by command1: {returnValue}");


                        using (SqlConnection connection2 = new SqlConnection(connectionString2))
                        {
                            connection2.Open();

                            returnValue = 0;
                            SqlCommand command2 = new SqlCommand(commandText2, connection2);
                            returnValue = command2.ExecuteNonQuery();
                            writer.WriteLine($"Rows to be affected by command2: {returnValue}");
                        }
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                writer.WriteLine($"TransactionAbortedException Message: {ex.Message}");
            }
            Console.WriteLine(writer.ToString());

            return returnValue;
        }

    }
}
