using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    public abstract class Room
    {
        public int RoomNumber { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }

        protected Room(int roomNumber, decimal pricePerNight, bool isAvailable, int capacity)
        {
            RoomNumber = roomNumber;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
            Capacity = capacity;
        }

        public abstract string GetRoomType();

        public override string ToString()
        {
            return $"{RoomNumber} ({GetRoomType()}) - €{PricePerNight}/night";
        }
    }
}
