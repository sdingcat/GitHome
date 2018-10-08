using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*本次作业采用链表存储*/

namespace Homework4_2
{
    //订单明细
    class OrderDetails
    {
        public string name;
        public int number;
        public double price;
        public double allprise;
        public OrderDetails next;
        public OrderDetails(string name, int number, double price)
        {
            this.name = name;
            this.number = number;
            this.price = price;
            allprise = this.number * this.price;
            next = null;
        }
    }

    //订单
    class Order
    {
        public int orderNumber;
        public OrderDetails head;
        public Order next;
        //初始化
        public Order(int orderNumber)
        {
            this.orderNumber = orderNumber;
            head = null;
            next = null;
        }
        //添加明细
        public void addOrderDetails(OrderDetails head)
        {
            Console.WriteLine("依次输入商品名称，购买数量，单价：");
            string name = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            double prise = double.Parse(Console.ReadLine());
            OrderDetails newOrderDetails = new OrderDetails(name,number,prise);
            newOrderDetails.next = head.next;
            head.next = newOrderDetails;
        }
        //按商品名删除明细
        public void delOrderDetails(OrderDetails head)
        {
            Console.WriteLine("输入要删除的商品名称：");
            string aimName = Console.ReadLine();
            OrderDetails pre = head, p = head.next;
            while (p != null)
            {
                if(string.Equals(aimName,p.name))
                {
                    pre.next = p.next;
                    p = pre.next;
                }
                else
                {
                    pre = pre.next;
                    p = p.next;
                }
            }
        }
        //输出所有明细
        void DisOrderDetails(OrderDetails head)
        {
            OrderDetails p = head.next;
            while (p != null)
            {
                Console.WriteLine(p.name + "\t" + p.number + "\t" + p.price + "\t" + p.allprise);
                p = p.next;
            }
            Console.WriteLine("\n");
        }
        //删除所有明细
        public void DesOrderDetails(OrderDetails head)
        {
            head = null;
        }
    }

    //订单服务
    class OrderService
    {
        public Order first;
        //初始化
        public OrderService()
        {
            first = null;
        }
        //添加订单,返回当前订单
        public Order addOrder(Order first)
        {
            Console.WriteLine("输入订单号");
            int number = int.Parse(Console.ReadLine());
            Order newOrder = new Order(number);
            newOrder.next = first.next;
            first.next = newOrder;
            return newOrder;
        }
        //按订单号删除订单
        public void delOrder(Order first)
        {
            Console.WriteLine("输入要删除的订单号：");
            int aimNumber =int.Parse(Console.ReadLine());
            Order pre = first, p = first.next;
            bool isFind = false;
            while (p != null)
            {
                if (int.Equals(aimNumber, p.orderNumber))
                {
                    pre.next = p.next;
                    p = pre.next;
                    isFind = true;
                }
                else
                {
                    pre = pre.next;
                    p = p.next;
                }
            }
            if(!isFind)
            {
                Console.WriteLine("无该订单");
            }
        }
        //输出所有订单(无明细)
        void DisOrderWith(Order first)
        {
            if(first.next==null)
            {
                Console.WriteLine("没有订单");
            }
            else
            {
                Order p = first.next;
                while (p != null)
                {
                    Console.WriteLine(p.orderNumber);
                    p = p.next;
                }
                Console.WriteLine("\n");
            }
        }
        //输出所有订单(有明细)
        void DisOrderWithout(Order first)
        {
            if (first.next == null)
            {
                Console.WriteLine("没有订单");
            }
            else
            {
                Order p = first.next;
                while (p != null)
                {
                    Console.WriteLine(p.orderNumber);
                    p.DesOrderDetails(p.head);
                    p = p.next;
                }
                Console.WriteLine("\n");
            }
        }
        //删除所有订单
        public void DesOrder(Order first)
        {
            first = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderService newOrderService = new OrderService();
            int again = 0;
            do
            {
                Console.WriteLine("添加订单按1，查找订单按2，输出订单按3，删除订单按4：");
                int myChoice = int.Parse(Console.ReadLine());
                switch (myChoice)
                {
                    case 1:
                        Order newOrder = newOrderService.addOrder(newOrderService.first);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("非法输入");
                        break;
                }
                Console.WriteLine("是否继续输入：1-继续，其他任意键-退出");
                again = int.Parse(Console.ReadLine());
            } while (again==1);
            
        }
    }
}
