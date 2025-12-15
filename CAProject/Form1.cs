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
            // Initialize form components
            InitializeComponent();

            // Initialize the database connection
            DatabaseHotel.Initialize();

        }

        //--------------------------------------------------------------------------
        // Form validation method
        //--------------------------------------------------------------------------
        private bool ValidateForm()
        {
            // Name validation: at least first and last name with min 3 letters each
            string namePattern = @"^[A-Za-z]{3,}(?: [A-Za-z]{3,})+$";

            // Trim whitespace and validate
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

            // Email validation: characters before and after @, valid domain, 2 characters after dot
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$";

            // Trim whitespace and validate
            if (!Regex.IsMatch(guestEmail.Text.Trim(), emailPattern))
            {
                errorProvider1.SetError(
                    guestEmail,
                    "Enter a valid email address (e.g. name@email.com)."
                );
                return false;
            }
            else
            {
                errorProvider1.SetError(guestEmail, "");
            }

            // Phone number validation: + country code (1-3 digits) space number (8-15 digits)
            string phoneNumberPattern = @"^\+\d{1,3} \d{8,15}$";

            if (!Regex.IsMatch(phoneNumber.Text.Trim(), phoneNumberPattern))
            {
                errorProvider1.SetError(
                    phoneNumber,
                    "Phone format must be: '+' country code (1-3 digits) 'space' number (8-15 digits) (e.g. +353 875570000)."
                );
                return false;
            }
            else
            {
                errorProvider1.SetError(phoneNumber, "");
            }

            // Address validation: letters, numbers, spaces, commas, hyphens
            string addressPattern = @"^[A-Za-z0-9 ,\-]+$";

            if (string.IsNullOrWhiteSpace(address.Text) ||
                !Regex.IsMatch(address.Text.Trim(), addressPattern))
            {
                errorProvider1.SetError(
                    address,
                    "Address is required and may only contain letters, numbers, spaces, commas, and hyphens (e.g. 30 Fonthill Avenue, Dublin, Ireland)."
                );
                return false;
            }
            else
            {
                errorProvider1.SetError(address, "");
            }

            // Room type selected
            if (roomType.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.");
                return false;
            }

            // Room number selected
            if (!(selectRoomNo.SelectedItem is Room selectedRoom))
            {
                MessageBox.Show("Please select a valid room.");
                return false;
            }

            int noOfGuests =
                one.Checked ? 1 :
                two.Checked ? 2 :
                three.Checked ? 3 : 4;

            // Check room capacity vs number of guests
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

            // Ensure check-out is after check-in
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

            // Prevent creating reservations with check-out in the past
            if (checkout.Value < DateTime.Today)
            {
                MessageBox.Show("Check-out date cannot be in the past.");
                return false;
            }

            // Ensure total rate is valid positive decimal
            if (!decimal.TryParse(totalRate.Text, out decimal rate) || rate <= 0)
            {
                MessageBox.Show("Invalid total rate.");
                return false;
            }

            return true;
        }

        // Flag to prevent room updates while loading reservation in the form
        private bool isLoadingReservation = false;

        //--------------------------------------------------------------------------
        // Update available room numbers based on selected type and dates
        //--------------------------------------------------------------------------
        private void UpdateRoomNumbers()
        {
            // Prevent updates rooms while loading reservation in the form
            if (isLoadingReservation)
                return;

            // No room type selected -> clear
            if (roomType.SelectedItem == null)
                return;

            // Get selected type and dates
            string selectedType = roomType.SelectedItem.ToString();

            DateTime checkInDate = checkin.Value.Date;
            DateTime checkOutDate = checkout.Value.Date;

            // Clear current room numbers
            selectRoomNo.Items.Clear();

            // Get available rooms from database
            currentRooms = DatabaseHotel.GetAvailableRoomsByTypeAndDate(
                selectedType,
                checkInDate,
                checkOutDate
            );

            // Populate room numbers list box
            foreach (var room in currentRooms)
                selectRoomNo.Items.Add(room);

            // Select first room by default if any available otherwise show message
            if (selectRoomNo.Items.Count > 0)
                selectRoomNo.SelectedIndex = 0;
            else
                MessageBox.Show("No rooms available for these dates.");
        }

        //--------------------------------------------------------------------------
        // Update room numbers list box when room type changes
        //--------------------------------------------------------------------------
        private void roomType_SelectedItemChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

        //--------------------------------------------------------------------------
        // Update room numbers list box and total price when check-in date changes
        //--------------------------------------------------------------------------
        private void checkin_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
            UpdateTotalPrice();
        }

        //--------------------------------------------------------------------------
        // Update room numbers list box and total price when check-out date changes
        //--------------------------------------------------------------------------
        private void checkout_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
            UpdateTotalPrice();
        }

        //--------------------------------------------------------------------------
        // Update total price when room or dates change
        //--------------------------------------------------------------------------
        private void UpdateTotalPrice()
        {
            // No room selected -> clear
            if (selectRoomNo.SelectedItem == null)
            {
                totalRate.Text = "";
                return;
            }

            // Get selected room
            var selectedRoom = selectRoomNo.SelectedItem as Room;
            if (selectedRoom == null)
            {
                totalRate.Text = "";
                return;
            }

            // Get dates
            DateTime inDate = checkin.Value.Date;
            DateTime outDate = checkout.Value.Date;

            // Check-out must be after in
            if (outDate <= inDate)
            {
                totalRate.Text = "";
                return;
            }

            // Calculate number of nights
            int nights = (outDate - inDate).Days;

            // Calculate total price
            decimal totalPrice = selectedRoom.PricePerNight * nights;
            totalRate.Text = totalPrice.ToString("0.00");
        }

        //--------------------------------------------------------------------------
        // Update total price when change room selection
        //--------------------------------------------------------------------------
        private void SelectRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        //--------------------------------------------------------------------------
        // Create Reservation
        //--------------------------------------------------------------------------
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

            // Check room capacity vs number of guests and show error if exceeded
            if (noOfGuests > selectedRoom.Capacity)
            {
                MessageBox.Show("Too many guests for this room type.");
                return;
            }

            // Get total rate based on room price and number of nights
            int nights = (checkOut - checkIn).Days;
            decimal totalPrice = ((Room)selectRoomNo.SelectedItem).PricePerNight * nights;

            // Get guest details from form
            string name = guestName.Text;
            string email = guestEmail.Text;
            string phone = phoneNumber.Text;
            string addr = address.Text;

            // Create Guest object
            Guest newGuest = new Guest(name, email, phone, addr);

            // Add guest to database and get assigned GuestID
            int guestId = DatabaseHotel.AddGuest(newGuest);
            newGuest.GuestID = guestId;

            // Create Reservation object and add to database
            Reservation newReservation = new Reservation(newGuest, selectedRoom.RoomNumber, checkIn, checkOut, noOfGuests, totalPrice);
            DatabaseHotel.AddReservation(newReservation);

            // Show success message
            MessageBox.Show("Reservation created successfully!");

            //Show reservation details in ListBox
            listBox1.Items.Clear();
            listBox1.Items.Add($"Reservation created for {newGuest.Name} with {noOfGuests} guest(s) in room number {selectedRoom.RoomNumber} from {checkIn.ToShortDateString()} to {checkOut.ToShortDateString()}. Total Rate: €{totalPrice}");
            
        }

        //--------------------------------------------------------------------------
        // Update reservation
        //--------------------------------------------------------------------------
        private void updateReservationButton_Click(object sender, EventArgs e)
        {
            // Check if something is selected
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please search and select a reservation to update.");
                return;
            }

            // Validate form inputs
            if (!ValidateForm())
                return;

            // Cast selected reservation
            var selectedReservation = (Reservation)listBox1.SelectedItem;

            // Update guest object details
            selectedReservation.Guest.Name = guestName.Text;
            selectedReservation.Guest.Email = guestEmail.Text;
            selectedReservation.Guest.PhoneNumber = phoneNumber.Text;
            selectedReservation.Guest.Address = address.Text;

            // Update guest in database
            DatabaseHotel.UpdateGuest(selectedReservation.Guest);

            // Get number of guests
            int noOfGuests = one.Checked ? 1 :
                             two.Checked ? 2 :
                             three.Checked ? 3 : 4;

            // Get selected room
            Room selectedRoom = (Room)selectRoomNo.SelectedItem;

            // Check room capacity vs number of guests
            if (noOfGuests > selectedRoom.Capacity)
            {
                MessageBox.Show("Too many guests for this room.");
                return;
            }

            // Update reservation details
            selectedReservation.RoomNumber = selectedRoom.RoomNumber;
            selectedReservation.TotalNoOfGuests = noOfGuests;
            selectedReservation.CheckInDate = checkin.Value;
            selectedReservation.CheckOutDate = checkout.Value;

            int nights = (checkout.Value - checkin.Value).Days;
            decimal newPrice = selectedRoom.PricePerNight * nights;

            selectedReservation.TotalPrice = newPrice;
            totalRate.Text = newPrice.ToString();

            // Update reservation in database
            DatabaseHotel.UpdateReservation(selectedReservation);

            // Show success message
            MessageBox.Show("Reservation updated successfully.");

            // Refresh ListBox display
            listBox1.Items.Clear();
            listBox1.Items.Add(selectedReservation);
        }

        //--------------------------------------------------------------------------
        // Delete reservation
        //--------------------------------------------------------------------------
        private void deleteReservationButton_Click(object sender, EventArgs e)
        {
            // Check if something is selected
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a reservation to delete.");
                return;
            }

            // Cast selected reservation
            var selectedReservation = (Reservation)listBox1.SelectedItem;

            // Ask for confirmation
            var result = MessageBox.Show(
                $"Are you sure you want to delete Reservation ID {selectedReservation.ReservationID}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // If confirmed, delete
            if (result == DialogResult.Yes)
            {
                // Call delete method
                DatabaseHotel.DeleteReservation(selectedReservation.ReservationID);

                // Remove it from the ListBox
                listBox1.Items.Remove(selectedReservation);

                // Show success message
                MessageBox.Show("Reservation deleted successfully.");
            }

        }

        //--------------------------------------------------------------------------
        // Search reservation by ID
        //--------------------------------------------------------------------------
        private void searchReservationButton_Click(object sender, EventArgs e)
        {

            // Validate input
            if (!int.TryParse(searchReservation.Text, out int searchId) || searchId <= 0)
            {
                MessageBox.Show("Invalid reservation ID.");
                return;
            }

            // Get all reservations
            List<Reservation> reservations = DatabaseHotel.GetAllReservations();

            // Sort reservations by ID using Insertion Sort
            SortReservationsById.InsertionSortByReservationID(reservations);

            // Perform binary search and get result
            var foundReservation = BinarySearchById.BinarySearch(reservations, searchId);

            // Clear previous results
            listBox1.Items.Clear();
            selectRoomNo.Items.Clear();

            // Display found reservation or show not found message
            if (foundReservation != null)
            {
                // Add to ListBox and select
                listBox1.Items.Add(foundReservation);
                listBox1.SelectedIndex = 0;

                // Load details into form
                LoadReservationIntoForm(foundReservation);
            }
            else
            {
                MessageBox.Show("Reservation not found!");
            }
        }

        //--------------------------------------------------------------------------
        // List all reservations
        //--------------------------------------------------------------------------
        private void listAllReservationsButton_Click(object sender, EventArgs e)
        {
            // Get all reservations
            List<Reservation> reservations = DatabaseHotel.GetAllReservations();

            // Safety check
            if (reservations == null || reservations.Count == 0)
            {
                MessageBox.Show("No reservations found.");
                return;
            }

            listBox1.Items.Clear();

            // Display all reservations
            foreach (var reservation in reservations)
            {
                listBox1.Items.Add(reservation);
            }

            // Show success message
            MessageBox.Show("All reservations loaded successfully.");

        }

        //--------------------------------------------------------------------------
        // Sort reservations by name
        //--------------------------------------------------------------------------
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

            // Apply Bubble Sort
            SortReservationsByName.BubbleSortByGuestName(reservations);

            // Refresh ListBox
            listBox1.Items.Clear();

            // Display sorted reservations
            foreach (var reservation in reservations)
            {
                listBox1.Items.Add(reservation);
            }

            // Show success message
            MessageBox.Show("Reservations sorted by guest name (A–Z).");
        }

        //--------------------------------------------------------------------------
        // Sort reservations by check-in date
        //--------------------------------------------------------------------------
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

            // Apply Insertion Sort
            SortReservationsByDate.MergeSortByCheckInDate(reservations);

            // Refresh ListBox
            listBox1.Items.Clear();

            // Display sorted reservations
            foreach (var reservation in reservations)
            {
                listBox1.Items.Add(reservation);
            }

            // Show success message
            MessageBox.Show("Reservations sorted by check-in date.");
        }

        //--------------------------------------------------------------------------
        // Load reservation details into form
        //--------------------------------------------------------------------------
        private void LoadReservationIntoForm(Reservation foundReservation)
        {
            // Safety check
            if (foundReservation == null || foundReservation.Guest == null)
                return;

            // Set loading flag
            isLoadingReservation = true;

            // Fill guest info
            guestName.Text = foundReservation.Guest.Name;
            guestEmail.Text = foundReservation.Guest.Email;
            phoneNumber.Text = foundReservation.Guest.PhoneNumber;
            address.Text = foundReservation.Guest.Address;

            // Guests radio buttons
            one.Checked = foundReservation.TotalNoOfGuests == 1;
            two.Checked = foundReservation.TotalNoOfGuests == 2;
            three.Checked = foundReservation.TotalNoOfGuests == 3;
            four.Checked = foundReservation.TotalNoOfGuests == 4;

            // Dates
            checkin.Value = foundReservation.CheckInDate;
            checkout.Value = foundReservation.CheckOutDate;

            // Room
            selectRoomNo.Items.Clear();
            selectRoomNo.Items.Add(foundReservation.RoomNumber.ToString());
            selectRoomNo.SelectedIndex = 0;

            // Price
            totalRate.Text = foundReservation.TotalPrice.ToString("0.00");

            // Unset loading flag
            isLoadingReservation = false;
        }

        //--------------------------------------------------------------------------
        // Load reservation details when selected in ListBox
        //--------------------------------------------------------------------------
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            if (listBox1.SelectedItem is Reservation selectedReservation)
            {
                LoadReservationIntoForm(selectedReservation);
            }
        }

        //--------------------------------------------------------------------------
        // Clear form inputs
        //--------------------------------------------------------------------------
        private void ClearAllInputForm()
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
            ClearAllInputForm();
        }

        //--------------------------------------------------------------------------
        // Clear form inputs and search textbox
        //--------------------------------------------------------------------------
        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            ClearAllInputForm();
            searchReservation.Text = string.Empty;
        }

        //--------------------------------------------------------------------------
        // Exit application on form close
        //--------------------------------------------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //--------------------------------------------------------------------------
        // Close application when close button clicked
        //--------------------------------------------------------------------------
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
