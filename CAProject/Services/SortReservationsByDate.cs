using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Services
{
    public class SortReservationsByDate
    {
        public static void InsertionSortByCheckInDate(List<Reservation> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                var key = list[i];
                int j = i - 1;

                while (j >= 0 && list[j].CheckInDate > key.CheckInDate)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = key;
            }
        }
    }

}
