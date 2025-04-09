using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            lblResult.Text = "";
            lblProgress.Text = "0%";
            progressBar1.Value = 0;

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
                    sum += i;
                    (progress as IProgress<int>)?.Report(i);
                    Thread.Sleep(30);
                }
                return sum;
            });

            lblResult.Text = $"Результат: {result}";
            btnStart.Enabled = true;

            MessageBox.Show("Обчислення завершено!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
