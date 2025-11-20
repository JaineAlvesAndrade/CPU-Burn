using ILGPU;
using ILGPU.Runtime;
using System;
using System.Diagnostics;
using System.Threading;
using ILGPU.Algorithms;

namespace CpuBurn
{
    public class GpuBurn
    {
        private static void BurnKernel(Index1D index, ArrayView<float> data)
        {
            float value = index;

            for (int i = 0; i < 50_000; i++)
            {
                value = XMath.Sqrt(value + 1.2345f);
            }

            data[index] = value;
        }

        public static Task BurnFullAsync(CancellationToken cancellationToken, int percentual)
        {
            if (percentual < 0 || percentual > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentual));
            }

            const int periodMs = 100;
            int busyMs = (int)Math.Round(periodMs * (percentual / 100.0));
            int sleepMs = periodMs - busyMs;

            return Task.Run(async () =>
            {
                using var context = Context.CreateDefault();

                var device = context.Devices
                    .Where(d => d.AcceleratorType == AcceleratorType.Cuda || d.AcceleratorType == AcceleratorType.OpenCL)
                    .OrderByDescending(d => d.AcceleratorType == AcceleratorType.Cuda) 
                    .FirstOrDefault();

                if (device == null)
                    throw new NotSupportedException("Nenhuma GPU CUDA/OpenCL foi encontrada.");

                using var accelerator = device.CreateAccelerator(context);

                // Escolhe um tamanho de grid razoável
                int length = accelerator.MaxNumThreadsPerGroup * accelerator.NumMultiprocessors;
                if (length <= 0)
                    length = 1024; // fallback

                // Compila kernel
                var burnKernel = accelerator
                    .LoadAutoGroupedStreamKernel<Index1D, ArrayView<float>>(BurnKernel);

                // Aloca buffer na GPU
                using var buffer = accelerator.Allocate1D<float>(length);

                var sw = new Stopwatch();

                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        // Parte "ocupada": lança kernel repetidamente por busyMs
                        sw.Restart();
                        while (sw.ElapsedMilliseconds < busyMs &&
                               !cancellationToken.IsCancellationRequested)
                        {
                            burnKernel(length, buffer.View);
                            accelerator.Synchronize(); // garante que terminou
                        }

                        // Parte "descanso": tenta se aproximar do percentual
                        if (sleepMs > 0)
                        {
                            try
                            {
                                await Task.Delay(sleepMs, cancellationToken)
                                          .ConfigureAwait(false);
                            }
                            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                            {
                                // cancelado durante o delay, só sair
                                break;
                            }
                        }
                    }
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    // cancel normal
                }
            }, cancellationToken);
        }

    }
}
