using System.Diagnostics;

namespace CpuBurn
{
    public class CpuBurn
    {
        public static Task BurnFullAsync(CancellationToken cancellationToken, int percentual)
        {
            if (percentual < 0 || percentual > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentual));
            }

            int cores = Environment.ProcessorCount;
            Task[] tasks = new Task[cores];

            for (int i = 0; i < cores; i++)
            {
                tasks[i] = Task.Run(() =>
                {
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
                }, cancellationToken);
            }

            return Task.WhenAll(tasks);
        }
    }
}
