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
            GuestId = guest.GuestID;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            TotalNoOfGuests = totalNoOfGuests;
            TotalPrice = totalPrice;
        }
        public override string ToString()
        {
            return $"ID: {ReservationID} // Guest: {Guest.Name} // GuestID: {GuestId} // Room: {RoomNumber} // " +
                   $"Check-In: {CheckInDate:d} // Check-Out: {CheckOutDate:d} // No of Guests: {TotalNoOfGuests} // Price: {TotalPrice:C}";
        }
    }
}
