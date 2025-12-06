using CAProject.Database;
using CAProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAProject
{
    public partial class Form1 : Form
    {
        private List<Room> currentRooms = new List<Room>();

        public Form1()
        {
            InitializeComponent();

            // Initialize the database connection
            DatabaseHotel.Initialize();

            //Create Rooms table and insert initial data
            //using (var conn = new SQLiteConnection("Data Source=reservationsystem.db"))
            //{
            //    conn.Open();
            //    var cmd = conn.CreateCommand();

            //    cmd.CommandText = @"
            //        INSERT OR IGNORE INTO Rooms 
            //        (RoomNumber, RoomType, PricePerNight, Capacity) VALUES

            //        (101, 'Single Room', 100, 1),
            //        (104, 'Single Room', 100, 1),
            //        (203, 'Single Room', 100, 1),
            //        (207, 'Single Room', 100, 1),

            //        (102, 'Double Room', 150, 2),
            //        (105, 'Double Room', 150, 2),
            //        (204, 'Double Room', 150, 2),
            //        (205, 'Double Room', 150, 2),

            //        (103, 'Triple Room', 180, 3),
            //        (107, 'Triple Room', 180, 3),
            //        (201, 'Triple Room', 180, 3),
            //        (206, 'Triple Room', 180, 3),

            //        (106, 'Family Room', 250, 4),
            //        (202, 'Family Room', 250, 4);
            //    ";

            //    cmd.ExecuteNonQuery();
            //}

            roomType.SelectedItemChanged += roomType_SelectedItemChanged;

            selectRoomNo.SelectedIndexChanged += (s, e) => UpdateTotalPrice();
            checkin.ValueChanged += (s, e) => UpdateTotalPrice();
            checkout.ValueChanged += (s, e) => UpdateTotalPrice();

        }

        // Create Reservation
        private void createReservationButton_Click(object sender, EventArgs e)  
        {
            //Validate form inputs
            if (!ValidateForm())
                return;

            // Get number of guests
            int noOfGuests =
               one.Checked ? 1 :
               two.Checked ? 2 :
               three.Checked ? 3 : 4;

            // Get check-in and check-out dates
            DateTime checkIn = checkin.Value.Date;
            DateTime checkOut = checkout.Value.Date;

            // Get selected room type and number
            Room selectedRoom = (Room)selectRoomNo.SelectedItem;
            //string selectedRoomType = roomType.SelectedItem.ToString();
            //string selectedRoomNumber = selectRoomNo.SelectedItem.ToString();
            //int roomNumber = int.Parse(selectedRoomNumber);

            if (noOfGuests > selectedRoom.Capacity)
            {
                MessageBox.Show("Too many guests for this room type.");
                return;
            }

            // Get total rate
            int nights = (checkOut - checkIn).Days;
            decimal totalPrice = ((Room)selectRoomNo.SelectedItem).PricePerNight * nights;

            // Create Guest object
            string name = guestName.Text;
            string email = guestEmail.Text;
            string phone = phoneNumber.Text;
            string addr = address.Text;

            Guest newGuest = new Guest(name, email, phone, addr);

            // Add guest to database and get assigned GuestID
            int guestId = DatabaseHotel.AddGuest(newGuest);
            newGuest.GuestID = guestId;

            // Create Reservation object and add to database
            Reservation newReservation = new Reservation(newGuest, selectedRoom.RoomNumber, checkIn, checkOut, noOfGuests, totalPrice);
            DatabaseHotel.AddReservation(newReservation);

            //Show reservation details in ListBox
            listBox1.Items.Add($"Reservation created for {newGuest.Name} with {noOfGuests} guests in room number {selectedRoom.RoomNumber} from {checkIn.ToShortDateString()} to {checkOut.ToShortDateString()}. Total Rate: €{totalPrice}");

            MessageBox.Show("Reservation created successfully!");
        }

        // Update room numbers based on selected room type
        //private void UpdateRoomNumbers()
        //{
        //    if (roomType.SelectedItem == null)
        //        return;

        //    string selectedType = roomType.SelectedItem.ToString();

        //    selectRoomNo.Items.Clear();

        //    var rooms = DatabaseHotel.GetRoomsByType(selectedType);

        //    foreach (var room in rooms)
        //    {
        //        selectRoomNo.Items.Add(room.ToString());
        //    }
        //}
        //private List<Room> currentRooms = new List<Room>();

        private void UpdateRoomNumbers()
        {
            if (roomType.SelectedItem == null)
                return;

            string selectedType = roomType.SelectedItem.ToString();

            DateTime checkInDate = checkin.Value.Date;
            DateTime checkOutDate = checkout.Value.Date;

            if (checkOutDate <= checkInDate)
                return;

            selectRoomNo.Items.Clear();

            currentRooms = DatabaseHotel.GetAvailableRoomsByTypeAndDate(
                selectedType,
                checkInDate,
                checkOutDate
            );

            foreach (var room in currentRooms)
                selectRoomNo.Items.Add(room);

            if (selectRoomNo.Items.Count > 0)
                selectRoomNo.SelectedIndex = 0;
            else
                MessageBox.Show("No rooms available for these dates.");
        }

        private void UpdateTotalPrice()
        {
            // No room selected -> clear
            if (selectRoomNo.SelectedItem == null)
            {
                totalRate.Text = "";
                return;
            }

            // Cast to Room
            var selectedRoom = selectRoomNo.SelectedItem as Room;
            if (selectedRoom == null)
            {
                totalRate.Text = "";
                return;
            }

            // Use .Date to ignore time-of-day
            DateTime inDate = checkin.Value.Date;
            DateTime outDate = checkout.Value.Date;

            // Out must be after in
            if (outDate <= inDate)
            {
                totalRate.Text = "";
                return;
            }

            int nights = (outDate - inDate).Days;

            // Safety: ensure at least one night
            if (nights < 1)
            {
                totalRate.Text = "";
                return;
            }

            decimal totalPrice = selectedRoom.PricePerNight * nights;
            totalRate.Text = totalPrice.ToString("0.00");
        }

        // Search reservation by ID
        private void searchReservationButton_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(searchReservation.Text, out int searchid))
            {
                MessageBox.Show("Invalid reservation ID.");
                return;
            }

            List<Reservation> reservations = DatabaseHotel.GetAllReservations();

            SortReservationsById.InsertionSortByReservationID(reservations);

            BinarySearchById searcher = new BinarySearchById();
            var foundReservation = searcher.BinarySearch(reservations, searchid);

            listBox1.Items.Clear();
            selectRoomNo.Items.Clear();

            if (foundReservation != null)
            {
                if (foundReservation.Guest == null)
                {
                    MessageBox.Show("Guest object is NULL inside this reservation.");
                    return;
                }
                listBox1.Items.Add(foundReservation);
                guestName.Text = foundReservation.Guest.Name;
                guestEmail.Text = foundReservation.Guest.Email;
                phoneNumber.Text = foundReservation.Guest.PhoneNumber;
                address.Text = foundReservation.Guest.Address;
                if (foundReservation.TotalNoOfGuests == 1)
                {
                    one.Checked = true;
                }
                else if (foundReservation.TotalNoOfGuests == 2)
                {
                    two.Checked = true;
                }
                else if (foundReservation.TotalNoOfGuests == 3)
                {
                    three.Checked = true;
                }
                else
                {
                    four.Checked = true;
                }
                checkin.Value = foundReservation.CheckInDate;
                checkout.Value = foundReservation.CheckOutDate;
                selectRoomNo.Items.Add(foundReservation.RoomNumber.ToString());
                totalRate.Text = foundReservation.TotalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Reservation not found!");
            }
        }

        // Delete reservation
        private void deleteReservationButton_Click(object sender, EventArgs e)
        {
            // Check if something is selected
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a reservation to delete.");
                return;
            }

            // Cast the selected item to Reservation
            var selectedReservation = (Reservation)listBox1.SelectedItem;

            // Optional: ask for confirmation
            var result = MessageBox.Show(
                $"Are you sure you want to delete Reservation ID {selectedReservation.ReservationID}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Call your delete method
                DatabaseHotel.DeleteReservation(selectedReservation.ReservationID);

                // Remove it from the ListBox
                listBox1.Items.Remove(selectedReservation);

                MessageBox.Show("Reservation deleted successfully.");
            }

        }

        // Update room numbers list box when room type changes
        private void roomType_SelectedItemChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

        // Update reservation
        private void updateReservationButton_Click(object sender, EventArgs e)
        {
            // Ensure something was searched and loaded
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please search and select a reservation to update.");
                return;
            }

            if (!ValidateForm())
                return;

            // Cast selected reservation
            var selectedReservation = (Reservation)listBox1.SelectedItem;

            // Update Guest object
            selectedReservation.Guest.Name = guestName.Text;
            selectedReservation.Guest.Email = guestEmail.Text;
            selectedReservation.Guest.PhoneNumber = phoneNumber.Text;
            selectedReservation.Guest.Address = address.Text;

            // Update guest in database
            DatabaseHotel.UpdateGuest(selectedReservation.Guest);

            // Update Reservation object

            // Guest count
            int noOfGuests = one.Checked ? 1 :
                             two.Checked ? 2 :
                             three.Checked ? 3 : 4;

            Room selectedRoom = (Room)selectRoomNo.SelectedItem;

            // Room number
            if (noOfGuests > selectedRoom.Capacity)
            {
                MessageBox.Show("Too many guests for this room.");
                return;
            }

            selectedReservation.RoomNumber = selectedRoom.RoomNumber;
            selectedReservation.TotalNoOfGuests = noOfGuests;
            selectedReservation.CheckInDate = checkin.Value;
            selectedReservation.CheckOutDate = checkout.Value;

            int nights = (checkout.Value - checkin.Value).Days;
            decimal newPrice = selectedRoom.PricePerNight * nights;

            selectedReservation.TotalPrice = newPrice;
            totalRate.Text = newPrice.ToString();

            DatabaseHotel.UpdateReservation(selectedReservation);

            MessageBox.Show("Reservation updated successfully.");

            // Refresh ListBox display
            listBox1.Items.Clear();
            listBox1.Items.Add(selectedReservation);
        }

        // Form validation method
        private bool ValidateForm()
        {
            string namePattern = @"^[A-Za-z]{3,}(?: [A-Za-z]{3,})+$";

            if (!Regex.IsMatch(guestName.Text.Trim(), namePattern))
            {
                errorProvider1.SetError(
                    guestName,
                    "Enter first and last name with at least 3 letters each (e.g. John Smith)."
                );
                return false; 
            }
            else
            {
                errorProvider1.SetError(guestName, "");
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$";

            if (!Regex.IsMatch(guestEmail.Text.Trim(), emailPattern))
            {
                errorProvider1.SetError(
                    guestEmail,
                    "Please enter a valid email address (e.g. name@email.com)."
                );
                return false;
            }
            else
            {
                errorProvider1.SetError(guestEmail, "");
            }

            string phoneNumberPattern = @"^\+\d{1,3} \d{8,15}$";

            if (!Regex.IsMatch(phoneNumber.Text.Trim(), phoneNumberPattern))
            {
                errorProvider1.SetError(
                    phoneNumber,
                    "Phone format must be: +CCC NNNNNNNN (e.g. +353 875570000)"
                );
                return false;
            }
            else
            {
                errorProvider1.SetError(phoneNumber, "");
            }

            string addressPattern = @"^[A-Za-z0-9 ,\-]+$";

            if (string.IsNullOrWhiteSpace(address.Text) ||
                !Regex.IsMatch(address.Text.Trim(), addressPattern))
            {
                errorProvider1.SetError(
                    address,
                    "Address is required and may only contain letters, numbers, spaces, commas, and hyphens."
                );
                return false;
            }
            else
            {
                errorProvider1.SetError(address, "");
            }

            if (!ValidateChildren())
                return false;

            if (roomType.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.");
                return false;
            }

            if (!(selectRoomNo.SelectedItem is Room selectedRoom))
            {
                MessageBox.Show("Please select a valid room.");
                return false;
            }

            int noOfGuests =
                one.Checked ? 1 :
                two.Checked ? 2 :
                three.Checked ? 3 : 4;

            if (noOfGuests > selectedRoom.Capacity)
            {
                MessageBox.Show(
                    $"This room supports up to {selectedRoom.Capacity} guests.",
                    "Capacity Exceeded",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            if (checkout.Value <= checkin.Value)
            {
                MessageBox.Show("Check-out must be after check-in.");
                return false;
            }

            // Prevent creating reservations in the past
            if (checkin.Value < DateTime.Today)
            {
                MessageBox.Show("Check-in date cannot be in the past.");
                return false;
            }

            if (checkout.Value < DateTime.Today)
            {
                MessageBox.Show("Check-out date cannot be in the past.");
                return false;
            }

            if (!decimal.TryParse(totalRate.Text, out _))
            {
                MessageBox.Show("Invalid total rate.");
                return false;
            }

            return true;
        }

        // Close application
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // List all reservations
        private void listAllReservationsButton_Click(object sender, EventArgs e)
        {
            List<Reservation> reservations = DatabaseHotel.GetAllReservations();

            listBox1.Items.Clear();

            if (reservations == null || reservations.Count == 0)
            {
                MessageBox.Show("No reservations found.");
                return;
            }

            listBox1.Items.Clear();

            foreach (var reservation in reservations)
            {
                listBox1.Items.Add(reservation);
            }

            MessageBox.Show("All reservations loaded successfully.");

        }

        // Sort reservations by check-in date
        private void sortByCheckInButton_Click(object sender, EventArgs e)
        {
            // Get all reservations
            List<Reservation> reservations = DatabaseHotel.GetAllReservations();

            // Safety check
            if (reservations == null || reservations.Count == 0)
            {
                MessageBox.Show("No reservations to sort.");
                return;
            }

            // ✅ APPLY INSERTION SORT BY CHECK-IN DATE
            SortReservationsByDate.InsertionSortByCheckInDate(reservations);

            // Refresh ListBox
            listBox1.Items.Clear();

            foreach (var reservation in reservations)
            {
                listBox1.Items.Add(reservation);
            }

            MessageBox.Show("Reservations sorted by check-in date.");
        }

        // Sort reservations by name
        private void sortByNameButton_Click(object sender, EventArgs e)
        {
            // Get all reservations
            List<Reservation> reservations = DatabaseHotel.GetAllReservations();

            // Safety check
            if (reservations == null || reservations.Count == 0)
            {
                MessageBox.Show("No reservations to sort.");
                return;
            }

            // ✅ Apply Bubble Sort
            SortReservationsByName.BubbleSortByGuestName(reservations);

            // Refresh ListBox
            listBox1.Items.Clear();
            foreach (var reservation in reservations)
            {
                listBox1.Items.Add(reservation);
            }

            MessageBox.Show("Reservations sorted by guest name (A–Z).");
        }

        // Clear form inputs
        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            guestName.Text = string.Empty;
            guestEmail.Text = string.Empty;
            phoneNumber.Text = string.Empty;
            address.Text = string.Empty;
            one.Checked = true;
            checkin.Value = DateTime.Today;
            checkout.Value = DateTime.Today;
            roomType.SelectedItem = null;
            totalRate.Text = string.Empty;
            listBox1.Items.Clear();
            selectRoomNo.Items.Clear();
        }

        private void clearForm_Click(object sender, EventArgs e)
        {
            guestName.Text = string.Empty;
            guestEmail.Text = string.Empty;
            phoneNumber.Text = string.Empty;
            address.Text = string.Empty;
            one.Checked = true;
            checkin.Value = DateTime.Today;
            checkout.Value = DateTime.Today;
            roomType.SelectedItem = null;
            totalRate.Text = string.Empty;
            listBox1.Items.Clear();
            selectRoomNo.Items.Clear();
        }
    }
}
