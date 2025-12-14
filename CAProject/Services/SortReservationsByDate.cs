using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Services
{
    public class SortReservationsByDate
    {
        // Merge Sort implementation to sort reservations by CheckInDate
        public static void MergeSortByCheckInDate(List<Reservation> list)
        {
            if (list == null || list.Count <= 1)
                return;

            MergeSort(list, 0, list.Count - 1);
        }

        // Recursive Merge Sort
        private static void MergeSort(List<Reservation> list, int left, int right)
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            // Sort left half
            MergeSort(list, left, mid);

            // Sort right half
            MergeSort(list, mid + 1, right);

            // Merge the two halves
            Merge(list, left, mid, right);
        }

        // Merge two sorted halves
        private static void Merge(List<Reservation> list, int left, int mid, int right)
        {
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            var leftList = new List<Reservation>(leftSize);
            var rightList = new List<Reservation>(rightSize);

            for (int i = 0; i < leftSize; i++)
                leftList.Add(list[left + i]);

            for (int j = 0; j < rightSize; j++)
                rightList.Add(list[mid + 1 + j]);

            int a = 0, b = 0, k = left;

            // Merge two sorted lists by CheckInDate
            while (a < leftSize && b < rightSize)
            {
                if (leftList[a].CheckInDate <= rightList[b].CheckInDate)
                {
                    list[k] = leftList[a];
                    a++;
                }
                else
                {
                    list[k] = rightList[b];
                    b++;
                }
                k++;
            }

            // Copy remaining elements (only one of these will run)
            while (a < leftSize)
            {
                list[k] = leftList[a];
                a++;
                k++;
            }

            while (b < rightSize)
            {
                list[k] = rightList[b];
                b++;
                k++;
            }
        }

    }

}
