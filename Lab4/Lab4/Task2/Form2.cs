using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            lblResult.Text = "";

            int result = await Task.Run(() =>
            {
                int sum = 0;
                for (int i = 1; i <= 100; i++)
                {
                    sum += i;
                    Thread.Sleep(30);
                }
                return sum;
            });

            lblResult.Text = $"Результат: {result}";
            btnStart.Enabled = true;

            MessageBox.Show("Обчислення завершено!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
