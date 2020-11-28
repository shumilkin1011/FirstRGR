using System;
using System.Drawing;
using System.Windows.Forms;

namespace RGR_SHUMILKIN
{
    public partial class Form1 : Form
    {
        private int angle = 0; //положение(угол) точки на окружности

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000; //интервал таймера
            timer1.Enabled = true; //включение таймера
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int xMax = pictureBox1.Width; int yMax = pictureBox1.Height; //границы picturebox по x,y
            float xCen = pictureBox1.Width / 2.0f; float yCen = pictureBox1.Height / 2.0f; //центр picturebox
            int margin = 20; //отступ от краёв picturbox
            float radius = xCen - margin; //радиус окружности
            angle += 6; //изменение положения точки


            float x = xCen + radius * (float)Math.Cos(2 * Math.PI * angle / 360); //координаты точки
            float y = yCen + radius * (float)Math.Sin(2 * Math.PI * angle / 360); //касания
            float x1 = x + 50 * (float)Math.Sin(2 * Math.PI * angle / 360); //координаты 
            float y1 = y - 50 * (float)Math.Cos(2 * Math.PI * angle / 360); //начала
            float x2 = x - 50 * (float)Math.Sin(2 * Math.PI * angle / 360); //и конца
            float y2 = y + 50 * (float)Math.Cos(2 * Math.PI * angle / 360); //касательной

            if (radioButton1.Checked) //проверка отметки radiobox1 
            {
                using (Pen myPen = new Pen(Color.Purple, 3)) //создание своего пера
                {
                    g.DrawEllipse(myPen, margin, margin, radius * 2, radius * 2);
                    ////отрисовка окружности
                }
            }

            using (Pen myPen = new Pen(Color.DarkRed, 3)) //создание своего пера
            {
                g.DrawLine //отрисовка касательной
                  (
                  myPen,
                  x1,
                  y1,
                  x2,
                  y2
                  );
                g.FillEllipse(Brushes.DarkRed, x - 3, y - 3, 6, 6);
                //отрисовка точки касания
            }
            using (Font fnt = new Font("Courier New", 7, FontStyle.Bold))
            {   //Вывод значения ползунка trackbar на экран
                g.DrawString("Значение trackbar = " + trackBar1.Value, fnt, Brushes.Violet, 0, 0);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1000-trackBar1.Value;
            //расчёт интервала таймера в зависимости от значения trackbar1
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh(); //перерисовка picturebox
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh(); //перерисовка picturebox
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "DPI  is  the  best!"; 
            //изменение выводимой надписи при клике на label2
        }
    }
}
