using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _009
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Начальное значение X
            textBox1.Text = "1";
            // значения x0, xk, dx и b
            textBox2.Text = "2,2";
            textBox3.Text = "0,2";
            textBox4.Text = "3,2";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double x0;
            double xk;
            double dx;
            double b;

            if (!double.TryParse(textBox1.Text, out x0) ||
                !double.TryParse(textBox2.Text, out xk) ||
                !double.TryParse(textBox3.Text, out dx) ||
                !double.TryParse(textBox4.Text, out b))
            {
                MessageBox.Show("Некорректный ввод данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dx > Math.Abs(xk - x0))
            {
                MessageBox.Show("Некорректный ввод данных! Значение dx больше разности между xk и x0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Код для построения графиков функций

      

            // Считываем с формы требуемые значения
            x0 = double.Parse(textBox1.Text);
            xk = double.Parse(textBox2.Text);
            dx = double.Parse(textBox3.Text);
            b = double.Parse(textBox4.Text);

                

            double x = x0;
            while (x <= xk)
            {
                double y1 = 9 * (Math.Pow(x, 3) + Math.Pow(b, 3)) * Math.Tan(x);
                chart1.Series[0].Points.AddXY(x, y1);
                double y2 = 2 * Math.Pow(x, 2) + 3 * x - 4;
                chart1.Series[1].Points.AddXY(x, y2);

                x += dx;

            }
            chart1.Size = new Size(800, 500);
        }
    }
}
