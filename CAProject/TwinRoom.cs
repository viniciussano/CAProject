using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    internal class TwinRoom : Room
    {
        public TwinRoom(int roomNumber, decimal pricePerNight, bool isAvailable)
            : base(roomNumber, pricePerNight, isAvailable, 2)
        {
        }
        public override string GetRoomType()
        {
            return "Twin Room";
        }
    }
}
