using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CpuBurn
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private bool _isBurning = false;
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _gpuCounter;
        private readonly PerformanceCounter _diskCounter;
        private readonly PerformanceCounter _memoryCounter;
        private readonly System.Windows.Forms.Timer _timer;

        public Form1()
        {
            InitializeComponent();

            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _diskCounter = new PerformanceCounter("PhysicalDisk", "% Idle Time", "_Total");
            _memoryCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            _gpuCounter = new PerformanceCounter("GPU Engine", "Utilization Percentage");

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
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
                var tasks = new List<Task>();

                bool cpuSelecionado = false;
                bool gpuSelecionado = false;
                bool discoSelecionado = false;
                bool memoriaSelecionado = false;

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    bool marcado = checkedListBox1.GetItemChecked(i);
                    string? texto = checkedListBox1.Items[i]?.ToString();

                    if (!marcado || string.IsNullOrWhiteSpace(texto))
                        continue;

                    if (texto.Equals("CPU", StringComparison.OrdinalIgnoreCase))
                        cpuSelecionado = true;
                    else if (texto.Equals("GPU", StringComparison.OrdinalIgnoreCase))
                        gpuSelecionado = true;
                }

                if (!cpuSelecionado && !gpuSelecionado)
                {
                    cpuSelecionado = true;
                }

                if (cpuSelecionado)
                {
                    tasks.Add(CpuBurn.BurnFullAsync(_cancellationTokenSource.Token, percentual));
                }

                if (gpuSelecionado)
                {
                    tasks.Add(GpuBurn.BurnFullAsync(_cancellationTokenSource.Token, percentual));
                }

                if (memoriaSelecionado)
                {
                    tasks.Add(MemoryBurn.BurnFullAsync(_cancellationTokenSource.Token, percentual, 2045));
                }

                if (discoSelecionado)
                {
                    tasks.Add(DiskBurn.BurnFullAsync(_cancellationTokenSource.Token, @"C:\Users\helen\Documents\IISExpress", percentual));
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            percentualUso.Text = $"{trackerUso.Value}";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                float cpuUsage = _cpuCounter.NextValue();
                float gpuUsage = 0;
                float diskUsage = _diskCounter.NextValue();
                float memoryUsage = _memoryCounter.NextValue();
                labelCpu.Text = $"CPU: {cpuUsage:F1}%";
                labelDisk.Text = $"Disco: {diskUsage:F1}%";
                labelGpu.Text = $"GPU: {gpuUsage:F1}%";
                labelMemory.Text = $"Memória: {memoryUsage:F1}%";
            }
            catch (Exception ex)
            {
                labelCpu.Text = $"Erro ao ler: {ex.Message} \n {ex.StackTrace}";
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
    }
}
