using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTests
{
    /// <summary>
    /// http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            var dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;");
            dbConnection.Open();

            Console.WriteLine("Sqlite database created");

            string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            Console.WriteLine("Test table created");

            sql = "insert into highscores (name, score) values ('Me', 3000)";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            Console.WriteLine("Table records added");

            Console.WriteLine("Fetching table records");

            sql = "select * from highscores order by score desc";
            command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
        }
    }
}
