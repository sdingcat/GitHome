using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form2 : Form
    {
        OrderService newOrderService;

        Order newOrder = new Order();

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(OrderService orderService) : this()
        {
            newOrderService = orderService;

            orderBindingSource.DataSource = newOrder.orderDetails;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(int.Parse(textBox1.Text)!=0&&textBox2.Text!=null)
            {
                newOrder.orderNumber = int.Parse(textBox1.Text);
                newOrder.customer = textBox2.Text;
                newOrderService.addOrder(newOrder);
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != null && int.Parse(textBox4.Text) != 0)
            {
                newOrder.addOrderDetails(textBox3.Text, int.Parse(textBox4.Text), double.Parse(textBox5.Text));
                orderBindingSource.DataSource = null;
                orderBindingSource.DataSource = newOrder.orderDetails;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
