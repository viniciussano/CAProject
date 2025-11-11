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
        public int capacity { get; set; }

        public Room(int roomNumber, decimal pricePerNight, bool isAvailable, int capacity)
        {
            RoomNumber = roomNumber;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
            this.capacity = capacity;
        }

        public abstract string GetRoomType();
    }
}
