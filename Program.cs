using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MSSA_Sorting2
{
    class Program
    {
        //bubble sort              <-- O(n^2), best case O(n)
        //selection sort           <-- O(n^2)
        //insertion sort           <-- O(n^2)
        //merge sort               <-- O(n log n)
        //quicksort                <-- O(n^2), the average: O(n*log n), no extra memory needed
        static void SelectionSort2(int[] arr)
        {
            for (int pos = 0; pos < arr.Length - 1; pos++)
            {
                //for position pos ... search for the smallest value
                //  search for smallest value (look at positions pos, pos+1, ... , end of the array)
                int pos_min = pos;//this pos_min variable will keep track of where the smallest value is
                for (int j = pos + 1; j < arr.Length; j++) //j takes me through the array
                {
                    if (arr[j] < arr[pos_min]) //if we discovered something smaller
                        pos_min = j;
                }
                //then swap it with the element in position pos
                int tmp = arr[pos_min];
                arr[pos_min] = arr[pos];
                arr[pos] = tmp;
            }
        }       //selection sort           <-- O(n^2)

        static void SelectionSort(int[] arr)            //selection sort           <-- O(n^2)
        {
            for (int pos = 0; pos < arr.Length - 1; pos++)
            {
                //for position pos ... search for the smallest value
                //  search for smallest value (look at positions pos, pos+1, ... , end of the array)
                int pos_min = pos;//this pos_min variable will keep track of where the smallest value is
                for (int j = pos + 1; j < arr.Length; j++) //j takes me through the array
                {
                    if (arr[j].CompareTo(arr[pos_min]) < 0) //if we discovered something smaller
                        pos_min = j;
                }
                //then swap it with the element in position pos
                int tmp = arr[pos_min];
                arr[pos_min] = arr[pos];
                arr[pos] = tmp;
            }
        }

        static void BubbleSort(int[] arr)       //O(n^2)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool sortedFlag = true;
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1]) // swap arr[j] and arr[j+1]
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                        sortedFlag = false;
                    }
                }
                if (sortedFlag == true) //the array got completely sorted
                    return;
            }
        }

        static void PrintArray(int[] arr)
        {
            foreach (int value in arr)
                Console.Write(value + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] values2 = { 15, 22, 11, 28, 25, 5, 11, 19 };


            Console.WriteLine("Reading the file");
            //StreamReader infile = new StreamReader("randoms.txt");
            string[] valuesStr = File.ReadAllLines("randoms.txt");
            int[] values = new int[valuesStr.Length];


            Console.WriteLine("converting into integers");
            for (int i = 0; i < valuesStr.Length; i++) //convert each str into int
            {
                values[i] = Convert.ToInt32(valuesStr[i]);
            }

            //make a new copy
            int[] valuesCopy2 = new int[values.Length];
            for (int i = 0; i < values.Length; i++) //convert each str into int
            {
                valuesCopy2[i] = values[i];
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Selection Sort");
            SelectionSort(values); //sort the array
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            Console.WriteLine("Bubble Sort");
            BubbleSort(valuesCopy2);
            sw2.Stop();
            Console.WriteLine(sw2.ElapsedMilliseconds);

            //PrintArray(values2); //display the array

            Console.WriteLine("Done sorting");
        }
    }
}
