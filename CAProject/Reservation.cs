using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int GuestId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalNoOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public Guest Guest { get; set; }

        public Reservation(Guest guest, int roomNumber, DateTime checkInDate, DateTime checkOutDate, int totalNoOfGuests, decimal totalPrice)
        {
            Guest = guest;
            GuestId = guest.Id;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalNoOfGuests = totalNoOfGuests;
            TotalPrice = totalPrice;
        }
        public override string ToString()
        {
            return $"Reservation ID: {ReservationID}, GuestID: {GuestId}, Guest Name: {Guest.Name} Room: {RoomNumber}, Check-In: {CheckInDate.ToShortDateString()}, Check-Out: {CheckOutDate.ToShortDateString()}, Total Number of Guests: {TotalNoOfGuests}, Total Price: {TotalPrice}";
        }
    }
}
