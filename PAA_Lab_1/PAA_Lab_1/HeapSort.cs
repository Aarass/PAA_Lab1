using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_1
{
    partial class HeapSort : Algorithm
    {
        int m_HeapSize;
        protected override void run(short[] arr, int n)
        {
            Algorithm.TotalOperations = (ulong)(n * Math.Log2(n));

            BuildHeap(arr);
            for(int i = n - 1; i >= 1; i--)
            {
                short pom = arr[0];
                arr[0] = arr[i];
                arr[i] = pom;
                m_HeapSize--;
                Heapify(arr, 0);
            }
            Algorithm.IsDone = true;
        }
        private void BuildHeap(short[] arr)
        {
            m_HeapSize = arr.Length;
            for(int i = m_HeapSize / 2 - 1; i >= 0; i--)
                Heapify(arr, i);
        }
        private void Heapify(short[] arr, int i)
        {
            Algorithm.DoneOperations++;

            int l = Left(i);
            int r = Right(i);

            int largest;
            if (l < m_HeapSize && arr[l] > arr[i])
                largest = l;
            else
                largest = i;
            if (r < m_HeapSize && arr[r] > arr[largest])
                largest = r;

            if(largest != i)
            {
                short pom = arr[largest];
                arr[largest] = arr[i];
                arr[i] = pom;
                Heapify(arr, largest);
            }

        }
        private int Left(int i) { return 2 * i + 1; }
        private int Right(int i) { return 2 * i + 2; }
    }
}