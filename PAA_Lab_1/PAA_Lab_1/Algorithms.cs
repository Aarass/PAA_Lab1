using System.Diagnostics;
using System.Globalization;
using System.Numerics;

namespace PAA_Lab_1
{
    public abstract class Algorithm
    {
        public static ulong TotalOperations;
        public static ulong DoneOperations;
        public static bool IsDone;
        public static void Setup()
        {
            DoneOperations = 0;
            IsDone = false;
        }
        public void Run(short[] arr, Stopwatch stopwatch)
        {
            Setup();

            Thread t = new Thread(DealWithProgressBar);
            t.Start();
                stopwatch.Restart();
                    run(arr, arr.Length);
                stopwatch.Stop();
            t.Join();

        }
        protected abstract void run(short[] arr, int n);

        static void DealWithProgressBar()
        {
            Progress progress = new Progress(100);
            while (Algorithm.IsDone == false)
            {
                decimal t = Algorithm.TotalOperations;
                decimal d = Algorithm.DoneOperations;
                decimal p = d / t;

                float percentage = (float)p;

                progress.ShowProgress(percentage);
            }
            progress.ShowProgress(1f);
            progress.HideProgress();
        }
    }
}
