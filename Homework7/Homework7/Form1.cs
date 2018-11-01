using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Homework7
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        
        public Form1()
        {
            InitializeComponent();
            Order order1 = new Order(001, "cat");
            order1.addOrderDetails("food1", 100, 20);
            order1.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order1);
            Order order2 = new Order(002, "dog");
            order2.addOrderDetails("food3", 10, 200);
            order2.addOrderDetails("food2", 200, 40);
            orderService.addOrder(order2);
            Order order3 = new Order(001, "cat");
            order3.addOrderDetails("food1", 10, 20);
            order3.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order3);
            Order order4 = new Order(002, "dog");
            order4.addOrderDetails("food3", 10, 200);
            order4.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order4);
            Order order5 = new Order(001, "cat");
            order5.addOrderDetails("food1", 1000, 20);
            order5.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order5);
            Order order6 = new Order(002, "dog");
            order6.addOrderDetails("food3", 10, 200);
            order6.addOrderDetails("food2", 2000, 40);
            orderService.addOrder(order6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2(orderService).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form3(orderService).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form4(orderService, 1).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form4(orderService, 2).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form5(orderService, 1).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form5(orderService, 2).Show();
        }
    }

}
