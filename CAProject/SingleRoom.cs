using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    public class SingleRoom : Room
    {
        public SingleRoom(int roomNumber, decimal pricePerNight, bool isAvailable)
            : base(roomNumber, pricePerNight, isAvailable, 1)
        {
        }
        public override string GetRoomType()
        {
            return "Single Room";
        }
    }
}
