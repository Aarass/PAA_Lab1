using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace PAA_Lab_1
{
    internal class Program
    {
        static int[] lengths = {100, 1000, 10000 , 100000, 1000000, 10000000 };//  };
        static void Main(string[] args)
        {
            short[] startingArray = new short[10000000];
            randomizeArray(startingArray);

            //printArray(startingArray);
            //Console.WriteLine();


            Stopwatch stopwatch = new Stopwatch();
            Algorithm[] sortingAlgorithms = {new BucketSort(), new HeapSort(), new BubbleSort() };
            foreach (Algorithm currentAlgorithm in sortingAlgorithms)
            {

                Console.WriteLine(currentAlgorithm.GetType().Name);
                Console.WriteLine("---------------------------");
                foreach (int length in lengths)
                {
                    short[] activeArray = new short[length];
                    Array.Copy(startingArray, activeArray, length);

                    Console.WriteLine(length);
                    currentAlgorithm.Run(activeArray, stopwatch);

                    Console.SetCursorPosition(10, Console.CursorTop - 1);
                    Console.WriteLine(" | ");

                    Console.SetCursorPosition(15, Console.CursorTop - 1);
                    printTime(stopwatch.Elapsed);

                    //printArray(activeArray);

                    Console.SetCursorPosition(30, Console.CursorTop);
                    if (arrayIsSorted(activeArray))
                        Console.Write(" ✓");
                    else
                        Console.Write(" ☓");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        static void randomizeArray(short[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = (short) random.Next(10000);
        }
        static bool arrayIsSorted(short[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    return false;
            return true;
        }
        static void printArray(short[] arr)
        {
            string s = "";
            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[i];
                s += " ";
            }
            Console.WriteLine(s);
        }
        static void printTime(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.Write(elapsedTime);
        }
    }
}