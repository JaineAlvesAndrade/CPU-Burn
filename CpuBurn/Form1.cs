using System.Diagnostics;

namespace CpuBurn
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private bool _isBurning = false;
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _gpuCounter;
        private readonly List<PerformanceCounter> _gpuCounters = new();
        private readonly System.Windows.Forms.Timer _timer;

        public Form1()
        {
            InitializeComponent();
            InitializeCoresListBox();

            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _gpuCounter = new PerformanceCounter("GPU Engine", "Utilization Percentage");

            try
            {
                var category = new PerformanceCounterCategory("GPU Engine");
                var instances = category.GetInstanceNames();

                foreach (var name in instances)
                {
                    if (name.Contains("engtype_3D", StringComparison.OrdinalIgnoreCase))
                    {
                        _gpuCounters.Add(
                            new PerformanceCounter("GPU Engine", "Utilization Percentage", name)
                        );
                    }
                }
            }
            catch
            {
                // se não tiver categoria GPU Engine, deixa lista vazia
            }
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void InitializeCoresListBox()
        {
            int cores = Environment.ProcessorCount;
            for (int i = 0; i < cores; i++)
            {
                _coresSelection.Items.Add($"Núcleo {i + 1}", true);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_isBurning)
            {
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Cancel();
                }

                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            _isBurning = true;
            button1.Text = "Parar";

            int percentual = trackerUso.Value;

            try
            {
                IList<Task> tasks = new List<Task>();

                bool cpuSelecionado = false;
                bool gpuSelecionado = false;

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    bool marcado = checkedListBox1.GetItemChecked(i);
                    string? texto = checkedListBox1.Items[i]?.ToString();

                    if (!marcado || string.IsNullOrWhiteSpace(texto))
                        continue;

                    if (texto.Equals("CPU", StringComparison.OrdinalIgnoreCase))
                    {
                        cpuSelecionado = true;
                    }
                    else if (texto.Equals("GPU", StringComparison.OrdinalIgnoreCase))
                    {
                        gpuSelecionado = true;
                    }
                }

                if (!cpuSelecionado && !gpuSelecionado)
                {
                    cpuSelecionado = true;
                }

                int[] selectedCores = GetSelectedCores();
                if (cpuSelecionado)
                {
                    tasks.Add(CpuBurn.BurnFullAsync(_cancellationTokenSource.Token, percentual, selectedCores));
                }

                if (gpuSelecionado)
                {
                    tasks.Add(GpuBurn.BurnFullAsync(_cancellationTokenSource.Token, percentual));
                }

                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                // cancel normal
            }
            finally
            {
                button1.Text = "Começar";
                _isBurning = false;

                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private int[] GetSelectedCores()
        {
            List<int> selectedCores = new List<int>();

            for (int i = 0; i < _coresSelection.Items.Count; i++)
            {
                if (_coresSelection.GetItemChecked(i))
                {
                    selectedCores.Add(i);
                }
            }

            return selectedCores.ToArray();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            percentualUso.Text = $"{trackerUso.Value}";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                float cpuUsage = _cpuCounter.NextValue();
                labelCpu.Text = $"CPU: {cpuUsage:F1}%";
            }
            catch (Exception ex)
            {
                labelCpu.Text = $"Erro ao ler: {ex.Message} \n {ex.StackTrace}";
            }

            try
            {
                if (_gpuCounters.Count > 0)
                {
                    float total3D = 0;
                    foreach (var c in _gpuCounters)
                    {
                        total3D += c.NextValue();
                    }

                    labelGpu.Text = $"GPU (3D): {total3D:F1}%";
                }
                else
                {
                    labelGpu.Text = "GPU (3D): não disponível";
                }
            }
            catch (Exception ex)
            {
                labelGpu.Text = $"GPU (3D): erro ({ex.Message})";
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UsoCpu_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
