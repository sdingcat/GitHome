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
    public partial class Form5 : Form
    {
        public OrderService newOrderService;
        public string KeyWord { get; set; }
        int status = 0;
        List<Order> tempOrders = new List<Order>() ;

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(OrderService orderService, int e) : this()
        {
            newOrderService = orderService;
            status = e;

            switch (status)
            {
                case 1:
                    label1.Text = "请输入最低金额：";
                    break;
                case 2:
                    label1.Text = "请输入客户名：";
                    break;
            }
            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            switch (status)
            {
                case 1:
                    var aimOrders = newOrderService.orders.Where(i => i.allPrise <= int.Parse(KeyWord));
                    foreach (var i in aimOrders)
                    {
                        tempOrders.Add(i);
                    }
                    newOrderService.orders = tempOrders;
                    tempOrders = null;
                    break;
                case 2:
                    var aimOrder = newOrderService.orders.Where(i => !i.customer.Equals(KeyWord));
                    foreach (var i in aimOrder)
                    {
                        tempOrders.Add(i);
                    }
                    newOrderService.orders = tempOrders;
                    tempOrders = null;
                    break;
            }
            this.Close();
        }
    }
}
