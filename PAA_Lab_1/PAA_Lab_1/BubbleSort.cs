using System.Globalization;
using System.Numerics;

namespace PAA_Lab_1
{
    public class BubbleSort : Algorithm
    {
        protected override void run(short[] arr, int n)
        {
            Algorithm.TotalOperations = ((ulong)n * (ulong)n - (ulong)n)/ 2;

            for (int i = 0; i < n - 1; i++)
            {
                bool swaped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        short pom = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = pom;

                        swaped = true;
                    }
                    Algorithm.DoneOperations++;
                }
                if (!swaped)
                {
                    break;
                }
            }
            Algorithm.IsDone = true;
        }
    }
}
