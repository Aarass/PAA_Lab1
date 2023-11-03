namespace PAA_Lab_1
{
    public class BucketSort : Algorithm
    {
        protected override void run(short[] arr, int n)
        {
            int k = n;
            Algorithm.TotalOperations = 5 * (ulong)n;

            List<short>[] buckets = new List<short>[k];

            for (int i = 0; i < k; i++)
            {
                buckets[i] = new List<short>();

                Algorithm.DoneOperations++;
            }

            for (int i = 0; i < n; i++)
            {
                buckets[(int)Math.Floor((decimal)k * arr[i] / 10001)].Add(arr[i]);
                Algorithm.DoneOperations++;
                Algorithm.DoneOperations++;
                Algorithm.DoneOperations++;
            }

            for (int j = -1, i = 0; i < k; i++)
            {
                foreach(short v in buckets[i])
                {
                    arr[++j] = v;
                    Algorithm.DoneOperations++;
                }
            }

            for (int i = 1; i < n; i++)
            {
                short key = arr[i];
                int j = i - 1;
                while((j >= 0) && (arr[j] > key))
                {
                    arr[j + 1] = arr[j--];
                    Algorithm.DoneOperations++;
                }
                arr[j + 1] = key;
            }
            Algorithm.IsDone = true;
        }
    }
}