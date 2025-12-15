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
        // Path to the SQLite database file  CAProject\bin\x64\Debug
        private static readonly string DbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reservationsystem.db");

        // Initialize the database and create tables if they do not exist
        public static void Initialize()
        {
            // Ensure the database directory exist
            Directory.CreateDirectory(Path.GetDirectoryName(DbFile));

            // Create SQLite database connection
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                // Create database file if it does not exist or open existing one
                connection.Open();

                // Create Guests table
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Guests (
                            GuestID INTEGER PRIMARY KEY AUTOINCREMENT,
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

                // Create Rooms table
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Rooms (
                            RoomNumber INTEGER PRIMARY KEY,
                            RoomType TEXT NOT NULL,
                            PricePerNight REAL NOT NULL,    
                            Capacity INTEGER NOT NULL
                    )";
                    tableCmd.ExecuteNonQuery();
                }
            }

            //Insert initial data into Rooms table
            using (var connection = new SQLiteConnection("Data Source=reservationsystem.db"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @"
                    INSERT OR IGNORE INTO Rooms 
                    (RoomNumber, RoomType, PricePerNight, Capacity) VALUES

                    (101, 'Single Room', 100, 1),
                    (104, 'Single Room', 100, 1),
                    (203, 'Single Room', 100, 1),
                    (207, 'Single Room', 100, 1),

                    (102, 'Double Room', 150, 2),
                    (105, 'Double Room', 150, 2),
                    (204, 'Double Room', 150, 2),
                    (205, 'Double Room', 150, 2),

                    (103, 'Triple Room', 180, 3),
                    (107, 'Triple Room', 180, 3),
                    (201, 'Triple Room', 180, 3),
                    (206, 'Triple Room', 180, 3),

                    (106, 'Family Room', 250, 4),
                    (202, 'Family Room', 250, 4);
                ";

                cmd.ExecuteNonQuery();
            }

            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
               
                connection.Open();

                // Create Reservations table
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
                            FOREIGN KEY(GuestID) REFERENCES Guests(GuestID),
                            CHECK (CheckOutDate > CheckInDate)
                    )";
                    tableCmd.ExecuteNonQuery();
                }
            }

            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                // Create Users table
                using (var tableCmd = connection.CreateCommand())
                {
                    tableCmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL
                )";
                    tableCmd.ExecuteNonQuery();
                }
            }

            // For demonstration purposes, add a default user if none exist
            using (var conn = new SQLiteConnection("Data Source=reservationsystem.db"))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT OR IGNORE INTO Users (Username, Password) VALUES ('admin', 'password')";
                cmd.ExecuteNonQuery();
            }
        }

        // Add a new guest and return the generated GuestID
        public static int AddGuest(Guest guest)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile}"))
            {   
                connection.Open();

                // Insert guest infomation
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

        // Get available rooms by type and date range between check-in and check-out
        public static List<Room> GetAvailableRoomsByTypeAndDate(string roomType, DateTime checkIn, DateTime checkOut)
        {
            var rooms = new List<Room>();

            using (var connection = new SQLiteConnection("Data Source=reservationsystem.db"))
            {
                connection.Open();

                // Query to find available rooms of the specified type
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT r.RoomNumber, r.RoomType, r.PricePerNight, r.Capacity
                    FROM Rooms r
                    WHERE r.RoomType = @type
                    AND r.RoomNumber NOT IN
                    (
                        SELECT RoomNumber
                        FROM Reservations
                        WHERE
                            CheckInDate < @checkOut
                            AND CheckOutDate > @checkIn
                    );
                ";

                // Add parameters
                cmd.Parameters.AddWithValue("@type", roomType);
                cmd.Parameters.AddWithValue("@checkIn", checkIn);
                cmd.Parameters.AddWithValue("@checkOut", checkOut);

                // Execute the query and read the results
                using (var reader = cmd.ExecuteReader())
                {

                    // Map database rows to Room objects
                    while (reader.Read())
                    {
                        int number = reader.GetInt32(0);
                        string type = reader.GetString(1);
                        decimal price = reader.GetDecimal(2);
                        int capacity = reader.GetInt32(3);

                        Room room = null;

                        if (type == "Single Room")
                        {
                            room = new SingleRoom(number, price, true, capacity);
                        }
                        else if (type == "Double Room")
                        {
                            room = new DoubleRoom(number, price, true, capacity);
                        }
                        else if (type == "Triple Room")
                        {
                            room = new TripleRoom(number, price, true, capacity);
                        }
                        else if (type == "Family Room")
                        {
                            room = new FamilyRoom(number, price, true, capacity);
                        }

                        // Add the room to the list if it was created successfully
                        if (room != null)
                            rooms.Add(room);
                    }
                }
            }

            // Return the list of available rooms
            return rooms;
        }

        // Add a new reservation
        public static void AddReservation(Reservation reservation)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile}"))
            {
                connection.Open();

                // Insert reservation information
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

        // Get all reservations with guest details
        public static List<Reservation> GetAllReservations()
        {
            var reservations = new List<Reservation>();

            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                // Query to get all reservations with guest details
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
                            JOIN Guests G ON R.GuestID = G.GuestID";

                    // Execute the query and read the results
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map guest details
                            var guest = new Guest
                            {
                                GuestID = Convert.ToInt32(reader["GuestID"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Address = reader["Address"].ToString()
                            };

                            // Map reservation details
                            var reservationId = Convert.ToInt32(reader["ReservationID"]);
                            var guestId = Convert.ToInt32(reader["GuestID"]);
                            var roomNumber = Convert.ToInt32(reader["RoomNumber"]);                           
                            var checkInDate = reader.GetDateTime(reader.GetOrdinal("CheckInDate"));
                            var checkOutDate = reader.GetDateTime(reader.GetOrdinal("CheckOutDate"));
                            var totalGuests = Convert.ToInt32(reader["TotalNoOfGuests"]);                      
                            var totalPrice = Convert.ToDecimal(reader["TotalPrice"]);

                            // Create Reservation object
                            var reservation = new Reservation(
                                guest: guest,
                                roomNumber: Convert.ToInt32(reader["RoomNumber"]),
                                checkInDate: DateTime.Parse(reader["CheckInDate"].ToString()),
                                checkOutDate: DateTime.Parse(reader["CheckOutDate"].ToString()),
                                totalNoOfGuests: Convert.ToInt32(reader["TotalNoOfGuests"]),
                                totalPrice: Convert.ToDecimal(reader["TotalPrice"])
                            )
                            {
                                // Set the ReservationID and GuestId
                                ReservationID = reservationId,
                                GuestId = guestId
                            };

                            // Add to the list
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            // Return the list of reservations
            return reservations;
        }

        // Update guest information
        public static void UpdateGuest(Guest guest)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                // Update guest information
                using (var updateCmd = connection.CreateCommand())
                {
                    updateCmd.CommandText = @"
                        UPDATE Guests
                        SET 
                            Name = @name,
                            Email = @email,
                            PhoneNumber = @phone,
                            Address = @address
                        WHERE GuestID = @id
                    ";

                    // Set parameters
                    updateCmd.Parameters.AddWithValue("@name", guest.Name);
                    updateCmd.Parameters.AddWithValue("@email", guest.Email);
                    updateCmd.Parameters.AddWithValue("@phone", guest.PhoneNumber);
                    updateCmd.Parameters.AddWithValue("@address", guest.Address);

                    updateCmd.Parameters.AddWithValue("@id", guest.GuestID);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any row was updated and return message
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

        // Update reservation information
        public static void UpdateReservation(Reservation reservation)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                // Update reservation information
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

                    // Set parameters
                    updateCmd.Parameters.AddWithValue("@guestId", reservation.GuestId);
                    updateCmd.Parameters.AddWithValue("@roomNumber", reservation.RoomNumber);
                    var checkInParam = updateCmd.Parameters.Add("@checkInDate", System.Data.DbType.Date);
                    checkInParam.Value = reservation.CheckInDate.Date;
                    var checkOutParam = updateCmd.Parameters.Add("@checkOutDate", System.Data.DbType.Date);
                    checkOutParam.Value = reservation.CheckOutDate.Date;
                    updateCmd.Parameters.AddWithValue("@totalGuests", reservation.TotalNoOfGuests);
                    updateCmd.Parameters.AddWithValue("@totalPrice", reservation.TotalPrice);

                    updateCmd.Parameters.AddWithValue("@reservationId", reservation.ReservationID);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any row was updated and return message
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

        // Delete a reservation by ID
        public static void DeleteReservation(int reservationId)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                // Delete reservation
                using (var deleteCmd = connection.CreateCommand())
                {
                    deleteCmd.CommandText = "DELETE FROM Reservations WHERE ReservationID = @id";
                    deleteCmd.Parameters.AddWithValue("@id", reservationId);

                    // Execute the delete command
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    // Check if any row was deleted and return message
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

        // Validate user credentials
        public static bool ValidateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFile};Version=3;"))
            {
                connection.Open();

                // Check if the username and password exist in the Users table
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT COUNT(*) 
                        FROM Users 
                        WHERE Username = @username 
                        AND Password = @password";

                    // Set parameters
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    // Return true if a matching user is found
                    return result > 0;
                }
            }
        }
    }
}
