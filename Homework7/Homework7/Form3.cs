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
    public partial class Form3 : Form
    {
        OrderService newOrderService;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(OrderService orderService) : this()
        {
            newOrderService = orderService;
            orderBindingSource.DataSource = newOrderService.orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
