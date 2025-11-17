using System.Diagnostics;

namespace CpuBurn
{
    public static class MemoryBurn
    {
        public static Task BurnFullAsync(
            CancellationToken cancellationToken,
            int percentual,
            int memoryMb)
        {
            if (percentual < 0 || percentual > 100)
                throw new ArgumentOutOfRangeException(nameof(percentual));

            if (memoryMb <= 0)
                throw new ArgumentOutOfRangeException(nameof(memoryMb));

            if (memoryMb > 2048)
                throw new ArgumentOutOfRangeException(nameof(memoryMb), "Use no máximo 2048 MB (2 GB) por instância.");

            const int periodMs = 100;
            int busyMs = (int)Math.Round(periodMs * (percentual / 100.0));
            int sleepMs = periodMs - busyMs;

            return Task.Run(() =>
            {
                long totalBytes = (long)memoryMb * 1024 * 1024;
                if (totalBytes > int.MaxValue)
                    throw new InvalidOperationException("Buffer maior que o limite de array de byte em .NET.");

                byte[] buffer = new byte[(int)totalBytes];

                for (int i = 0; i < buffer.Length; i += 4096)
                {
                    buffer[i] = 1;
                }

                var sw = new Stopwatch();

                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        sw.Restart();

                        while (sw.ElapsedMilliseconds < busyMs &&
                               !cancellationToken.IsCancellationRequested)
                        {
                            for (int i = 0; i < buffer.Length; i += 4096)
                            {
                                buffer[i]++; 
                            }
                        }

                        if (sleepMs > 0)
                        {
                            Thread.Sleep(sleepMs);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    
                }
            }, cancellationToken);
        }
    }
}
