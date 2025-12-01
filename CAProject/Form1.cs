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
           
            guestName.Validating += guestName_Validating;
            guestEmail.Validating += guestEmail_Validating;
            phoneNumber.Validating += phoneNumber_Validating;
            address.Validating += address_Validating;

        }
        private void guestName_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[A-Za-z]{3,}(?: [A-Za-z]{3,})+$";

            if (!Regex.IsMatch(guestName.Text.Trim(), pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(
                    guestName,
                    "Enter first and last name (e.g. John Smith)."
                );
            }
            else
            {
                errorProvider1.SetError(guestName, "");
            }
        }
        private void guestEmail_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$";

            if (!Regex.IsMatch(guestEmail.Text, pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(guestEmail, "Please enter a valid email address.");
            }
            else
            {
                errorProvider1.SetError(guestEmail, "");
            }
        }
        private void phoneNumber_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^\+\d{1,3} \d{8,15}$";

            if (!Regex.IsMatch(phoneNumber.Text.Trim(), pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(
                    phoneNumber,
                    "Phone format must contain: + country code and number (e.g. +353 875570000)"
                );
            }
            else
            {
                errorProvider1.SetError(phoneNumber, "");
            }
        }
        private void address_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"^[A-Za-z0-9 ]+$";

            if (string.IsNullOrWhiteSpace(address.Text) ||
                !Regex.IsMatch(address.Text.Trim(), pattern))
            {
                e.Cancel = true;
                errorProvider1.SetError(
                    address,
                    "Address is required and may only contain letters, numbers, and spaces."
                );
            }
            else
            {
                errorProvider1.SetError(address, "");
            }
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
            newGuest.Id = guestId;
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

            if (roomType.SelectedItem == null)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }
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

            if (!decimal.TryParse(totalRate.Text, out _))
            {
                MessageBox.Show("Invalid total rate.");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
