using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Services
{
    public class BinarySearchById
    {
        public Reservation BinarySearch(List<Reservation> sortedList, int id)
        {
            int left = 0, right = sortedList.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (sortedList[mid].ReservationID == id)
                    return sortedList[mid];
                if (sortedList[mid].ReservationID < id)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

    }
}
