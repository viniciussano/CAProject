using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAProject.Database;
using CAProject.Services;
using System.Text.RegularExpressions;

namespace CAProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseHotel.Initialize();

            roomType.SelectedItemChanged += roomType_SelectedItemChanged;

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void createReservationButton_Click(object sender, EventArgs e)  
        {

            if (!ValidateForm())
                return;

            string name = guestName.Text;
            string email = guestEmail.Text;
            string phone = phoneNumber.Text;
            string addr = address.Text;

            Guest newGuest = new Guest(name, email, phone, addr);

            int guestId = DatabaseHotel.AddGuest(newGuest);
            newGuest.GuestID = guestId;
            DatabaseHotel.PrintAllGuests();

            int noOfGuests;

            if (one.Checked)
            {
                noOfGuests = 1;
            }
            else if (two.Checked)
            {
                noOfGuests = 2;
            }
            else if (three.Checked)
            {
                noOfGuests = 3;
            }
            else
            {
                noOfGuests = 4;
            }

            DateTime checkIn = checkin.Value;
            DateTime checkOut = checkout.Value;


            string selectedRoomType = roomType.SelectedItem.ToString();

            string selectedRoomNumber = selectRoomNo.SelectedItem.ToString();
            int roomNumber = int.Parse(selectedRoomNumber);

            DoubleRoom newRoom = new DoubleRoom(roomNumber, 150.00m, true);

            string total = totalRate.Text;
            double finalRate = double.Parse(total);

            Reservation newReservation = new Reservation(newGuest, roomNumber, checkIn, checkOut, noOfGuests, (decimal)finalRate);
            DatabaseHotel.AddReservation(newReservation);

            listBox1.Items.Add($"Reservation created for {newGuest.Name} with {noOfGuests} guests in a {selectedRoomNumber} from {checkIn.ToShortDateString()} to {checkOut.ToShortDateString()}. Total Rate: ${finalRate}");
        }

        private void UpdateRoomNumbers()
        {
            if (roomType.SelectedItem == null)
                return;

            string selectedType = roomType.SelectedItem.ToString();

            selectRoomNo.Items.Clear();

            if (selectedType == "Single Room")
            {
                selectRoomNo.Items.Add("101");
                selectRoomNo.Items.Add("104");
                selectRoomNo.Items.Add("203");
                selectRoomNo.Items.Add("207");
            }
            else if (selectedType == "Double Room")
            {
                selectRoomNo.Items.Add("102");
                selectRoomNo.Items.Add("105");
                selectRoomNo.Items.Add("204");
                selectRoomNo.Items.Add("205");
            }
            else if (selectedType == "Triple Room")
            {
                selectRoomNo.Items.Add("103");
                selectRoomNo.Items.Add("107");
                selectRoomNo.Items.Add("201");
                selectRoomNo.Items.Add("206");
            }
            else if (selectedType == "Family Room")
            {
                selectRoomNo.Items.Add("106");
                selectRoomNo.Items.Add("202");
            }
        }

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

        private void roomType_SelectedItemChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

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

            // -------------------------------
            // UPDATE GUEST OBJECT
            // -------------------------------
            selectedReservation.Guest.Name = guestName.Text;
            selectedReservation.Guest.Email = guestEmail.Text;
            selectedReservation.Guest.PhoneNumber = phoneNumber.Text;
            selectedReservation.Guest.Address = address.Text;

            // Update guest in DB
            DatabaseHotel.UpdateGuest(selectedReservation.Guest);

            // -------------------------------
            // UPDATE RESERVATION OBJECT
            // -------------------------------

            // Guest count
            int noOfGuests = one.Checked ? 1 :
                             two.Checked ? 2 :
                             three.Checked ? 3 : 4;

            selectedReservation.TotalNoOfGuests = noOfGuests;

            // Room number
            if (selectRoomNo.SelectedItem == null)
            {
                MessageBox.Show("Please select a room number.");
                return;
            }

            selectedReservation.RoomNumber = int.Parse(selectRoomNo.SelectedItem.ToString());

            // Dates
            selectedReservation.CheckInDate = checkin.Value;
            selectedReservation.CheckOutDate = checkout.Value;

            // Price
            if (!decimal.TryParse(totalRate.Text, out decimal newPrice))
            {
                MessageBox.Show("Invalid price value.");
                return;
            }

            selectedReservation.TotalPrice = newPrice;

            // Update reservation in DB
            DatabaseHotel.UpdateReservation(selectedReservation);

            // -------------------------------
            // VISUAL FEEDBACK
            // -------------------------------
            MessageBox.Show("Reservation updated successfully!");

            // Refresh ListBox display
            listBox1.Items.Clear();
            listBox1.Items.Add(selectedReservation);
        }

        private bool ValidateForm()
        {
            string namePattern = @"^[A-Za-z]{3,}(?: [A-Za-z]{3,})+$";

            if (!Regex.IsMatch(guestName.Text.Trim(), namePattern))
            {
                errorProvider1.SetError(
                    guestName,
                    "Enter first and last name with at least 3 letters each (e.g. John Smith)."
                );
                return false;   // ✅ STOP saving
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

            string addressPattern = @"^[A-Za-z0-9 ]+$";

            if (string.IsNullOrWhiteSpace(address.Text) ||
                !Regex.IsMatch(address.Text.Trim(), addressPattern))
            {
                errorProvider1.SetError(
                    address,
                    "Address is required and may only contain letters, numbers, and spaces."
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

            if (selectRoomNo.SelectedItem == null)
            {
                MessageBox.Show("Please select a room number.");
                return false;
            }

            if (checkout.Value <= checkin.Value)
            {
                MessageBox.Show("Check-out must be after check-in.");
                return false;
            }

            // ✅ Prevent creating reservations in the past
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
