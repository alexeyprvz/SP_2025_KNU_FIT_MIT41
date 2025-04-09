using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task4
{
    public partial class Form4 : Form
    {
        private CancellationTokenSource _cts;

        public Form4()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            lblResult.Text = "";
            lblProgress.Text = "0%";
            progressBar1.Value = 0;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var progress = new Progress<int>(value =>
            {
                progressBar1.Value = value;
                lblProgress.Text = $"{value}%";
            });

            int result = await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 1; i <= 100; i++)
                {
                    if (token.IsCancellationRequested)
                        return -1; // ознака скасування

                    sum += i;
                    (progress as IProgress<int>)?.Report(i);
                    Thread.Sleep(30);
                }
                return sum;
            });

            btnStart.Enabled = true;
            btnCancel.Enabled = false;

            if (result == -1)
            {
                lblResult.Text = "Операцію скасовано.";
                MessageBox.Show("Операцію скасовано.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                

            else
            {
                lblResult.Text = $"Результат: {result}";
                MessageBox.Show("Обчислення завершено!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }
    }
}
