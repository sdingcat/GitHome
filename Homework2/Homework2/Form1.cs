using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int i = int.Parse(s);
            if(i<2)
            {
                label1.Text = "wrong number";
            }
            else
            {
                int[] f = new int[100];
                int length = 0;
                int nowNumber = 0;
                //先获取小于该数的所有素数
                for (nowNumber = 2; nowNumber <= i; nowNumber++)
                {
                    int times = 0;
                    for (; times<length;times++)
                    {
                        if(nowNumber%(f[times])==0)
                        {
                            break;
                        }
                    }
                    if(times== length)
                    {
                        f[length] = nowNumber;
                        length++;
                    }
                }
                //使用已获取的素数表求解
                label2.Text = "its divisor: ";
                for (int j=0;j<length;j++)
                {
                    if(i%f[j]==0)
                    {
                        label2.Text = label2.Text + f[j]+" ";
                    }
                }
            }
        }
    }
}
