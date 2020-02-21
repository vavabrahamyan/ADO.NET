using System;
using System.Data;
using System.Data.SqlClient;

namespace Parametrizer
{
    class Program
    {
        private static  void Foo(params int[] numbers)
        {
            Console.WriteLine(numbers[3]);
        }
        static void Main(string[] args)
        {
            Foo(3, 4, 5, 65, 76);






            string connectionString = @"Data Source=DESKTOP-BG4E31L;Initial Catalog=usersdb;Integrated Security=True";
            int age = 23;
            string name = "Kenny";
            string sqlExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age);SET @id=SCOPE_IDENTITY()";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                SqlParameter ageParam = new SqlParameter("@age", age);
                command.Parameters.Add(ageParam);
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output 
                };
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();

                Console.WriteLine("New object Id: {0}", idParam.Value);
            }
        }
    }
}
