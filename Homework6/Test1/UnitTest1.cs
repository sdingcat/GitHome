using System;
using Homework6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(001, "cat");
            order1.addOrderDetails("food1", 100, 20);
            order1.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order1);
            Order order2 = new Order(002, "dog");
            order2.addOrderDetails("food3", 10, 200);
            order2.addOrderDetails("food2", 200, 40);
            orderService.addOrder(order2);
            Assert.IsTrue(orderService.orders[0] == order1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(001, "cat");
            order1.addOrderDetails("food1", 100, 20);
            order1.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order1);
            Order order2 = new Order(002, "dog");
            order2.addOrderDetails("food3", 10, 200);
            order2.addOrderDetails("food2", 200, 40);
            orderService.addOrder(order2);
            orderService.DesOrder();
            Assert.IsTrue(orderService.orders==null);
        }
        [TestMethod]
        public void TestMethod3()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(1, "cat");
            order1.addOrderDetails("food1", 100, 20);
            order1.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order1);
            Order order2 = new Order(2, "dog");
            order2.addOrderDetails("food3", 10, 200);
            order2.addOrderDetails("food2", 200, 40);
            orderService.addOrder(order2);
            orderService.delOrderByNumber(1);
            Assert.IsFalse(orderService.orders[0] == order1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            OrderService orderService = new OrderService();
            Order order1 = new Order(001, "cat");
            order1.addOrderDetails("food1", 100, 200);
            order1.addOrderDetails("food2", 20, 40);
            orderService.addOrder(order1);
            Order order2 = new Order(002, "dog");
            order2.addOrderDetails("food3", 10, 200);
            order2.addOrderDetails("food2", 200, 40);
            orderService.addOrder(order2);
            orderService.delOrderByPrise(10000);
            Assert.IsFalse(orderService.orders[0] == order1);
        }
    }
}
