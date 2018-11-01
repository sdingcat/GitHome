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
    public partial class Form4 : Form
    {
        public OrderService newOrderService;
        public string KeyWord { get; set; }
        int status=0;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(OrderService orderService ,int e):this()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case 1:
                    orderBindingSource.DataSource = newOrderService.orders.Where(s => s.allPrise >= int.Parse(KeyWord));
                    break;
                case 2:
                    orderBindingSource.DataSource = newOrderService.orders.Where(s => s.customer.Equals(KeyWord));
                    break;
            }
        }
    }
}
