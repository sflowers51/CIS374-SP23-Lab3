using System;
using System.Collections.Generic;
using Lab3.SortingAlgorithms;
using System.Diagnostics;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = GenerateNearlySortedIntList(1_000, 50_000);

            //intList.Sort();
            //intList.Reverse();

            double totalTime = 0.0;
            double averageTime = 0.0;


            //InsertionSort<int> insertionSort = new InsertionSort<int>();
            //Console.WriteLine("INSERTION SORT");

            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort<int>(insertionSort, intListCopy);
            //}

            //averageTime = totalTime / 11;

            //Console.WriteLine($"INSERTION Average: {averageTime.ToString("F8")}");
            //Console.WriteLine("");



            //BubbleSort<int> bubbleSort = new BubbleSort<int>();
            //Console.WriteLine("BUBBLE SORT");

            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort<int>(bubbleSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"BUBBLE Average: {averageTime.ToString("F8")}");
            //Console.WriteLine("");



            HeapSort<int> heapSort = new HeapSort<int>();
            Console.WriteLine("HEAP SORT");

            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort<int>(heapSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"HEAP Average: {averageTime.ToString("F8")}");
            Console.WriteLine("");





            QuickSort<int> quickSort = new QuickSort<int>();
            Console.WriteLine("QUICK SORT");

            totalTime = 0;

            for (int i = 0; i < 11; i++)
            {
                List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

                totalTime += TimeSort<int>(quickSort, intListCopy);
            }

            averageTime = totalTime / 11;
            Console.WriteLine($"QUICK Average: {averageTime.ToString("F8")}");
            Console.WriteLine("");




            //RadixSort radixSort = new RadixSort();
            //Console.WriteLine("RADIX SORT");

            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort(radixSort, intListCopy);
            //}

            //averageTime = totalTime / 11;
            //Console.WriteLine($"RADIX Average: {averageTime.ToString("F8")}");
            //Console.WriteLine("");





            //BucketSort bucketSort = new BucketSort();
            //Console.WriteLine("BUCKET SORT");

            //totalTime = 0;

            //for (int i = 0; i < 11; i++)
            //{
            //    List<int> intListCopy = new List<int>(intList);   // make a copy of the original unsorted array

            //    totalTime += TimeSort(bucketSort, intListCopy);
            //}

            //averageTime = totalTime / 11;



            Console.WriteLine($"BUCKET Average: {averageTime.ToString("F8")}");

            Console.WriteLine(intList.Count);
        }

        public static double TimeSort<T>(ISortable<T> sortable, List<T> items) where T : IComparable<T>
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(ref items);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);

            return ts.TotalSeconds;

        }

        public static double TimeSort(ISortableInt sortable, List<int> items)
        {
            int[] array = items.ToArray();

            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var sorted = sortable.Sort(array);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            Console.WriteLine(ts.TotalSeconds);


            return ts.TotalSeconds;
        }


        public static List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.Next(maxValue));
            }

            return list;
        }

        // do not need lol
        //public static List<double> GenerateRandomDoubleList(int length, double maxValue)
        //{
        //    List<double> list = new List<double>();

        //    Random random = new Random();

        //    for (int i = 0; i < length; i++)
        //    {
        //        list.Add(random.NextDouble() * maxValue);
        //    }

        //    return list;
        //}

        public static List<int> GenerateNearlySortedIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.Next(maxValue));
            }

            list.Sort();

            for(int i = 0; i < length * 0.025; i++)
            {
                int rand1 = random.Next(0, length);
                int rand2 = random.Next(0, length);

                var temp = list[rand1];

                list[rand1] = list[rand2];
                list[rand2] = temp;
            }

            return list;
        }
    }
}
