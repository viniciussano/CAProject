using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Services
{
    public class SortReservationsByName
    {
        public static void BubbleSortByGuestName(List<Reservation> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Compare guest names alphabetically
                    if (string.Compare(list[j].Guest.Name, list[j + 1].Guest.Name) > 0)
                    {
                        // Swap
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }
}
