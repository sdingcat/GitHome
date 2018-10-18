using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //订单明细
    class OrderDetails
    {
        public string name;
        public int number;
        public double price;
        public double allPrice;
    }

    //订单
    class Order
    {
        public int orderNumber=0;
        public double allPrise=0;
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        //新建订单时需要输入订单号
        public Order(int orderNumber)
        {
            this.orderNumber = orderNumber;
        }
        //添加明细
        public void addOrderDetails(string name, int number, double prise)
        {
            OrderDetails newOrderDetails = new OrderDetails();
            newOrderDetails.name = name;
            newOrderDetails.number = number;
            newOrderDetails.price = prise;
            newOrderDetails.allPrice = number * prise;
            allPrise += newOrderDetails.allPrice;
            orderDetails.Add(newOrderDetails);
        }
        //按商品名删除明细
        public void delOrderDetails(string aimName)
        {
            var aimOrderList = from aimOrder in orderDetails where aimOrder.name.Equals(aimName) orderby aimOrder.name descending select aimOrder;
            foreach(var aimOrder in aimOrderList)
            {
                allPrise -= aimOrder.allPrice;
                orderDetails.Remove(aimOrder);
            }
        }
        //输出所有明细
        public void DisOrderDetails()
        {
            foreach (var aimOrder in orderDetails)
            {
                Console.WriteLine(aimOrder);
            }
        }
        //删除所有明细
        public void DesOrderDetails()
        {
            foreach (var aimOrder in orderDetails)
            {
                allPrise -= aimOrder.allPrice;
                orderDetails.Remove(aimOrder);
            }
        }
    }

    //订单服务
    class OrderService
    {
        public List<Order> orders = new List<Order>();
        //添加订单
        public void addOrder(Order newOrder)
        {
            orders.Add(newOrder);
        }
        //按金额删除订单
        public void delOrderByPrise(int aimPrise)
        {
            var aimOrderList = from aimOrder in orders where aimOrder.allPrise>aimPrise orderby aimOrder.orderNumber descending select aimOrder;
            foreach (var aimOrder in aimOrderList)
            {
                orders.Remove(aimOrder);
            }
        }
        //按订单号删除订单
        public void delOrderByNumber(int aimNumber)
        {
            var aimOrderList = from aimOrder in orders where aimOrder.orderNumber.Equals(aimNumber) orderby aimOrder.orderNumber descending select aimOrder;
            foreach (var aimOrder in aimOrderList)
            {
                orders.Remove(aimOrder);
            }
        }
        //输出所有订单(有明细)
        public void DisOrderWithout()
        {
            foreach (var aimOrder in orders)
            {
                Console.WriteLine(aimOrder);
            }
        }
        //删除所有订单
        public void DesOrder()
        {
            foreach (var aimOrder in orders)
            {
                aimOrder.DesOrderDetails();
                orders.Remove(aimOrder);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
