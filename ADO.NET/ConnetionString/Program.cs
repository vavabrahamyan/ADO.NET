using System;
using System.Configuration;

namespace ConnetionString
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source= DESKTOP-BG4E31L; 
                                        Internal Catalog= usersdb;
                                        Integrate Security= True";

            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //Console.WriteLine(connectionString);

            Console.ReadLine();
        }
    }
}
