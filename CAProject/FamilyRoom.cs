using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    public class FamilyRoom : Room
    {
        public bool AreInterconnectedRooms { get; set; }
        public FamilyRoom(int roomNumber, decimal pricePerNight, bool isAvailable, bool areInterconnectedRooms)
            : base(roomNumber, pricePerNight, isAvailable, 4)
        {
            AreInterconnectedRooms = areInterconnectedRooms;
        }
        public override string GetRoomType()
        {
            return "Single Room";
        }
    }
}
