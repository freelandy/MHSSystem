using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ConsoleApp1
{
    class Program
    {
        public static readonly string dbFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, "db.db");
        static void Main(string[] args)
        {
            SqliteConnection conn = new SqliteConnection("Data Source=" + dbFilePath);
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Teacher";

            conn.Open();
            SqliteDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine(reader["TeacherName"].ToString());
            }

            conn.Close();
            Console.ReadKey();

        }
    }
}
