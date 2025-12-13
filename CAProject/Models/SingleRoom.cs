using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    public class SingleRoom : Room
    {
        public SingleRoom(int number, decimal price, bool available, int capacity)
            : base(number, price, available, capacity)
        {
        }
        public override string GetRoomType()
        {
            return "Single Room";
        }
    }
}
