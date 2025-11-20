using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CpuBurn
{
    public class CpuBurn
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentThread();

        [DllImport("kernel32.dll")]
        static extern UIntPtr SetThreadAffinityMask(IntPtr hThread, UIntPtr dwThreadAffinityMask);

        public static Task BurnFullAsync(CancellationToken cancellationToken, int percentual, int[]? selectedCores = null)
        {
            if (percentual < 0 || percentual > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentual));
            }

            int totalCores = Environment.ProcessorCount;

            if (selectedCores == null || selectedCores.Length == 0)
            {
                selectedCores = Enumerable.Range(0, totalCores).ToArray();
            }

            foreach (int core in selectedCores)
            {
                if (core < 0 || core >= totalCores)
                {
                    throw new ArgumentOutOfRangeException(nameof(selectedCores), $"Core {core} is invalid. Must be between 0 and {totalCores - 1}.");
                }
            }

            TaskCompletionSource<bool>[] tasks = new TaskCompletionSource<bool>[selectedCores.Length];

            for (int i = 0; i < selectedCores.Length; i++)
            {
                int currentCore = selectedCores[i];

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                tasks[i] = tcs;

                Thread th = new Thread(() =>
                {
                    SetAffinity(currentCore);

                    Stopwatch sw = new();

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        int busyMs = (int)Math.Round(100 * (percentual / 100.0));
                        int sleepMs = 100 - busyMs;

                        sw.Restart();
                        while (sw.ElapsedMilliseconds < busyMs && !cancellationToken.IsCancellationRequested)
                        {
                            Math.Sqrt(12345.6789);
                        }

                        if (sleepMs > 0)
                        {
                            Thread.Sleep(sleepMs);
                        }
                    }

                    tcs.TrySetResult(true);
                });

                th.IsBackground = true;
                th.Start();
            }

            return Task.WhenAll(tasks.Select(t => t.Task));
        }

        static void SetAffinity(int cpuIndex)
        {
            IntPtr handle = GetCurrentThread();

            UIntPtr mask = (UIntPtr)(1 << cpuIndex);

            UIntPtr result = SetThreadAffinityMask(handle, mask);
        }
    }
}
