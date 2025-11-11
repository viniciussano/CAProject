using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Database
{
    public static class DatabaseHotel
    {

        private static readonly string DbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reservationsystem.db");

        public static void Initialize()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DbFile));

            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
               
                connection.Open();

                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Guests (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Email TEXT NOT NULL,
                            PhoneNumber TEXT NOT NULL,
                            Address TEXT NOT NULL
                )";
                    tableCmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Guest> GetAllGuests()
        {
            var guests = new List<Guest>();

            var connection = new SQLiteConnection($"Data Source={DbFile}");
            connection.Open();

            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = "SELECT Name, Email, PhoneNumber, Address FROM Guests";

            var reader = selectCmd.ExecuteReader();
            while (reader.Read())
            {
                guests.Add(new Guest(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }

            return guests;
        }

        public static void AddGuest(Guest guest)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile}"))
            {   
                connection.Open();

                using (var insertCmd = connection.CreateCommand())
                {
                    insertCmd.CommandText = "INSERT INTO Guests (Name, Email, PhoneNumber, Address) VALUES ($name, $email, $phone, $address)";
                    insertCmd.Parameters.AddWithValue("$name", guest.Name);
                    insertCmd.Parameters.AddWithValue("$email", guest.Email);
                    insertCmd.Parameters.AddWithValue("$phone", guest.PhoneNumber);
                    insertCmd.Parameters.AddWithValue("$address", guest.Address);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }
        public static void PrintAllGuests()
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile}"))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Guests";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Email: {reader["Email"]}");
                        }
                    }
                }
            }
        }
    }
}
