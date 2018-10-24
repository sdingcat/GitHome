using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Homework6
{
    //订单明细
    public class OrderDetails
    {
        public string name;
        public int number;
        public double price;
        public double allPrice;
        public override string ToString()
        {
            return "\t商品名：" + name + "\t数量：" + number + "\t单价：" + price + "\t总价：" + allPrice;
        }
    }

    //订单
    public class Order
    {
        public int orderNumber = 0;
        public string customer = null;
        public double allPrise = 0;
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public Order() { }
        public override string ToString()
        {
            string outString = "订单名：" + orderNumber + "\t客户名" + customer + "\t总价" + allPrise+"\n";
            foreach(var aimOrder in orderDetails)
            {
                outString += aimOrder + "\n";
            }
            outString += "\n";
            return outString;
        }
        //新建订单时需要输入订单号和客户名
        public Order(int orderNumber,string customer)
        {
            this.orderNumber = orderNumber;
            this.customer = customer;
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
            foreach (var aimOrder in aimOrderList)
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
            allPrise = 0;
            orderDetails = null;
        }
    }

    //订单服务
    [Serializable]
    public class OrderService
    {
        public List<Order> orders = new List<Order>();
        //添加订单
        public void addOrder(Order newOrder)
        {
            orders.Add(newOrder);
        }
        //按客户名查找并打印订单
        public List<Order> FindOrderByCustomer(string name)
        {
            List < Order > aimOrders= new List<Order>();
            var aimOrderList = from aimOrder in orders where aimOrder.customer.Equals(name) orderby aimOrder.orderNumber descending  select aimOrder;
            foreach (var aimOrder in aimOrderList)
            {
                Console.WriteLine(aimOrder);
            }
            return aimOrders;
        }
        //按金额删除订单
        public void delOrderByPrise(int aimPrise)
        {
            var aimOrderList = from aimOrder in orders where aimOrder.allPrise > aimPrise orderby aimOrder.orderNumber descending select aimOrder;
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
        public void DisOrderWith()
        {
            Console.WriteLine("================================================");
            foreach (var aimOrder in orders)
            {
                Console.WriteLine(aimOrder);
            }
            Console.WriteLine("================================================");
        }
        //删除所有订单
        public void DesOrder()
        {
            orders = null;
        }
        //生成XML文件
        public void ToXML()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream("temp.xml", FileMode.Create);
            xmlser.Serialize(fs, orders);
            fs.Close();
        }
        //从XML文件载入订单
        public void FromXML()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            FileStream fs = new FileStream("temp.xml", FileMode.Open, FileAccess.Read);
            List<Order> newOrders = (List<Order>)xmlser.Deserialize(fs);
            foreach(var temp in newOrders)
            {
                orders.Add(temp);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            orderService.DisOrderWith();
            orderService.FromXML();
            orderService.DisOrderWith();
        }
    }
}
