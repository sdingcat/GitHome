using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(graphics==null)
            {
                graphics = this.CreateGraphics();
            }
            drawCayleyTree(10, 200, 310, 100,100, -Math.PI / 2);
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.6;

        void drawCayleyTree(int n, double x0, double y0, double lengl, double leng2, double th)
        {
            if (n == 0)
            {
                return;
            }

            double x1 = x0 + lengl * Math.Cos(th);
            double y1 = y0 + lengl * Math.Sin(th);
            double x2 = x0 + leng2 * Math.Cos(th);
            double y2 = y0 + leng2 * Math.Sin(th);

            drawLine(x0, y0, x1, y1, x2, y2);

            th1 = int.Parse(textBox1.Text) * Math.PI / 180;
            th2 = int.Parse(textBox2.Text) * Math.PI / 180;
            
            drawCayleyTree(n - 1, x1, y1, per1 * lengl, per2 * leng2, th + th1);
            drawCayleyTree(n - 1, x2, y2, per1 * lengl, per2 * leng2, th - th2);
        }

        void drawLine(double x0,double y0,double x1,double y1,double x2, double y2)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x2, (int)y2);
        }
    }
}
