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

            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
               
                connection.Open();
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Reservations (
                            ReservationID INTEGER PRIMARY KEY AUTOINCREMENT,
                            GuestID INTEGER NOT NULL,
                            RoomNumber INTEGER NOT NULL,
                            CheckInDate DATE NOT NULL,
                            CheckOutDate DATE NOT NULL,
                            TotalNoOfGuests INTEGER NOT NULL,
                            TotalPrice REAL NOT NULL,
                            FOREIGN KEY(GuestID) REFERENCES Guests(Id),
                            CHECK (CheckOutDate > CheckInDate)
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

        public static int AddGuest(Guest guest)
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

                    // Get the auto-generated ID
                    insertCmd.CommandText = "SELECT last_insert_rowid();";
                    int id = Convert.ToInt32(insertCmd.ExecuteScalar());

                    guest.GuestID = id; // Optionally store it in the object
                    return id;
                }
            }
        }

        public static void AddReservation(Reservation reservation)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile}"))
            {
                connection.Open();

                using (var insertCmd = connection.CreateCommand())
                {
                    insertCmd.CommandText = "INSERT INTO Reservations (GuestId, RoomNumber, CheckInDate, CheckOutDate, TotalNoOfGuests, TotalPrice) VALUES ($guestid, $roomnumber, $checkindate, $checkoutdate, $totalnoofguests, $totalprice)";
                    insertCmd.Parameters.AddWithValue("$guestid", reservation.GuestId);
                    insertCmd.Parameters.AddWithValue("$roomnumber", reservation.RoomNumber);
                    var checkInParam = insertCmd.Parameters.Add("$checkindate", System.Data.DbType.Date);
                    checkInParam.Value = reservation.CheckInDate.Date;
                    var checkOutParam = insertCmd.Parameters.Add("$checkoutdate", System.Data.DbType.Date);
                    checkOutParam.Value = reservation.CheckOutDate.Date;
                    insertCmd.Parameters.AddWithValue("$totalnoofguests", reservation.TotalNoOfGuests);
                    insertCmd.Parameters.AddWithValue("$totalprice", reservation.TotalPrice);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Reservation> GetAllReservations()
        {
            var reservations = new List<Reservation>();

            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                using (var selectCmd = connection.CreateCommand())
                {
                    selectCmd.CommandText = @"
                            SELECT 
                            R.ReservationID,
                            R.GuestID,
                            R.RoomNumber,
                            R.CheckInDate,
                            R.CheckOutDate,
                            R.TotalNoOfGuests,
                            R.TotalPrice,
                            G.Name,
                            G.Email,
                            G.PhoneNumber,
                            G.Address
                            FROM Reservations R
                            JOIN Guests G ON R.GuestID = G.Id";

                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var guest = new Guest
                            {
                                GuestID = Convert.ToInt32(reader["GuestID"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Address = reader["Address"].ToString()
                            };

                            var reservationId = Convert.ToInt32(reader["ReservationID"]);
                            var guestId = Convert.ToInt32(reader["GuestID"]);
                            var roomNumber = Convert.ToInt32(reader["RoomNumber"]);

                            // Dates stored as DATE — safely parse
                            var checkInDate = reader.GetDateTime(reader.GetOrdinal("CheckInDate"));
                            var checkOutDate = reader.GetDateTime(reader.GetOrdinal("CheckOutDate"));

                            var totalGuests = Convert.ToInt32(reader["TotalNoOfGuests"]);

                            // REAL → decimal or double (decimal is better for money)
                            var totalPrice = Convert.ToDecimal(reader["TotalPrice"]);

                            var reservation = new Reservation(
                                guest: guest,
                                roomNumber: Convert.ToInt32(reader["RoomNumber"]),
                                checkInDate: DateTime.Parse(reader["CheckInDate"].ToString()),
                                checkOutDate: DateTime.Parse(reader["CheckOutDate"].ToString()),
                                totalNoOfGuests: Convert.ToInt32(reader["TotalNoOfGuests"]),
                                totalPrice: Convert.ToDecimal(reader["TotalPrice"])
                            )
                            {
                                ReservationID = reservationId,
                                GuestId = guestId
                            };

                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
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

        public static void DeleteReservation(int reservationId)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                using (var deleteCmd = connection.CreateCommand())
                {
                    deleteCmd.CommandText = "DELETE FROM Reservations WHERE ReservationID = @id";
                    deleteCmd.Parameters.AddWithValue("@id", reservationId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Reservation {reservationId} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"No reservation found with ID {reservationId}.");
                    }
                }
            }
        }

        public static void UpdateGuest(Guest guest)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                using (var updateCmd = connection.CreateCommand())
                {
                    updateCmd.CommandText = @"
                        UPDATE Guests
                        SET 
                            Name = @name,
                            Email = @email,
                            PhoneNumber = @phone,
                            Address = @address
                        WHERE Id = @id
                    ";

                    updateCmd.Parameters.AddWithValue("@name", guest.Name);
                    updateCmd.Parameters.AddWithValue("@email", guest.Email);
                    updateCmd.Parameters.AddWithValue("@phone", guest.PhoneNumber);
                    updateCmd.Parameters.AddWithValue("@address", guest.Address);

                    updateCmd.Parameters.AddWithValue("@id", guest.GuestID);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Guest {guest.GuestID} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"No guest found with ID {guest.GuestID}.");
                    }
                }
            }
        }

        public static void UpdateReservation(Reservation reservation)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                using (var updateCmd = connection.CreateCommand())
                {
                    updateCmd.CommandText = @"
                        UPDATE Reservations
                        SET 
                            GuestID = @guestId,
                            RoomNumber = @roomNumber,
                            CheckInDate = @checkInDate,
                            CheckOutDate = @checkOutDate,
                            TotalNoOfGuests = @totalGuests,
                            TotalPrice = @totalPrice
                        WHERE ReservationID = @reservationId
                    ";

                    updateCmd.Parameters.AddWithValue("@guestId", reservation.GuestId);
                    updateCmd.Parameters.AddWithValue("@roomNumber", reservation.RoomNumber);
                    var checkInParam = updateCmd.Parameters.Add("@checkInDate", System.Data.DbType.Date);
                    checkInParam.Value = reservation.CheckInDate.Date;
                    var checkOutParam = updateCmd.Parameters.Add("@checkOutDate", System.Data.DbType.Date);
                    checkOutParam.Value = reservation.CheckOutDate.Date;
                    updateCmd.Parameters.AddWithValue("@totalGuests", reservation.TotalNoOfGuests);
                    updateCmd.Parameters.AddWithValue("@totalPrice", reservation.TotalPrice);

                    updateCmd.Parameters.AddWithValue("@reservationId", reservation.ReservationID);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Reservation {reservation.ReservationID} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"No reservation found with ID {reservation.ReservationID}.");
                    }
                }
            }
        }
    }
}
