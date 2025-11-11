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
        public Room ReservedRoom { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Guest GuestName { get; set; }
        public int TotalNoOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public Reservation(int reservationID, Room reservedRoom, DateTime checkInDate, DateTime checkOutDate, Guest guestName, int totalNoOfGuests, decimal totalPrice)
        {
            ReservationID = reservationID;
            ReservedRoom = reservedRoom;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            GuestName = guestName;
            TotalNoOfGuests = totalNoOfGuests;
            TotalPrice = totalPrice;
        }
        public override string ToString()
        {
            return $"Reservation ID: {ReservationID}, Guest: {GuestName}, Room: {ReservedRoom.GetRoomType()} (#{ReservedRoom.RoomNumber}), Check-In: {CheckInDate.ToShortDateString()}, Check-Out: {CheckOutDate.ToShortDateString()}";
        }
    }
}
