using System.Diagnostics;
using System.Threading.Tasks;

namespace CpuBurn
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private bool _isBurning = false;
        private readonly PerformanceCounter _cpuCounter;
        private readonly System.Windows.Forms.Timer _timer;

        public Form1()
        {
            InitializeComponent();

            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

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

                _cancellationTokenSource = null;

                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();

            _isBurning = true;

            button1.Text = "Parar";

            int percentual = trackerUso.Value;

            try
            {
                await CpuBurn.BurnFullAsync(_cancellationTokenSource.Token, percentual);
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                button1.Text = "Começar";

                _isBurning = false;
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
                UsoCpu.Text = $"Uso atual: {cpuUsage:F1}%";
            }
            catch (Exception ex)
            {
                UsoCpu.Text = $"Erro ao ler CPU: {ex.Message}";
            }
        }
    }
}
