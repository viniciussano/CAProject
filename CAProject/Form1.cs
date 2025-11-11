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

namespace CAProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseHotel.Initialize();
        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void createReservation_Click(object sender, EventArgs e)
        {
            string name = guestName.Text;
            string email = guestEmail.Text;
            string phone = phoneNumber.Text;
            string addr = address.Text;

            Guest newGuest = new Guest(name, email, phone, addr);

            DatabaseHotel.AddGuest(newGuest);
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

            if(roomType.Items == null)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }
            string selectedRoomType = roomType.SelectedItem.ToString();

            string roomsSelected = roomSelector.SelectedNode?.Text;
            int roomNumber = int.Parse(roomsSelected);

            DoubleRoom newRoom = new DoubleRoom(roomNumber, 150.00m, true);

            string total = totalRate.Text;
            double finalRate = double.Parse(total);

            Reservation newReservation = new Reservation(1, newRoom, checkIn, checkOut, newGuest, noOfGuests, (decimal)finalRate);

            //MessageBox.Show($"Reservation created for {newGuest.Name} with {noOfGuests} guests in a {selectedRoomType} from {checkIn.ToShortDateString()} to {checkOut.ToShortDateString()}. Total Rate: ${finalRate}");

            listBox1.Items.Add($"Reservation created for {newGuest.Name} with {noOfGuests} guests in a {roomsSelected} from {checkIn.ToShortDateString()} to {checkOut.ToShortDateString()}. Total Rate: ${finalRate}");
        }
    }
}
