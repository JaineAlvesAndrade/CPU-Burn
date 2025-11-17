using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuBurn
{
    public static class DiskBurn
    {
        public static Task BurnFullAsync(
            CancellationToken cancellationToken,
            string folder,
            int percentual)
        {
            if (percentual < 0 || percentual > 100)
                throw new ArgumentOutOfRangeException(nameof(percentual));

            if (string.IsNullOrWhiteSpace(folder))
                throw new ArgumentNullException(nameof(folder));

            Directory.CreateDirectory(folder);

            const int periodMs = 100;
            int busyMs = (int)Math.Round(periodMs * (percentual / 100.0));
            int sleepMs = periodMs - busyMs;

            string filePath = Path.Combine(folder, "diskburn.bin");

            const long fileSizeBytes = 512L * 1024 * 1024;

            return Task.Run(() =>
            {
                byte[] buffer = new byte[8 * 1024 * 1024];
                var rng = new Random();
                rng.NextBytes(buffer);

                using var fs = new FileStream(
                    filePath,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.Read,
                    bufferSize: buffer.Length,
                    options: FileOptions.WriteThrough); 

                if (fs.Length < fileSizeBytes)
                    fs.SetLength(fileSizeBytes);

                long position = 0;
                var periodo = new Stopwatch();
                var flushTimer = new Stopwatch();
                flushTimer.Start();

                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        periodo.Restart();
                        while (periodo.ElapsedMilliseconds < busyMs &&
                               !cancellationToken.IsCancellationRequested)
                        {
                            fs.Position = position;
                            fs.Write(buffer, 0, buffer.Length);
                            position += buffer.Length;

                            if (position >= fileSizeBytes)
                                position = 0; 

                            if (flushTimer.ElapsedMilliseconds >= 500)
                            {
                                fs.Flush(true);
                                flushTimer.Restart();
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
                    // cancel normal
                }
            }, cancellationToken);
        }
    }
}
