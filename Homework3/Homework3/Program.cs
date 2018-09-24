using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    //图形类基类
    public abstract class Shape
    {
        private string myId;
        public Shape(string s)
        {
            Id = s;
        }
        public string Id
        {
            get
            {
                return myId;
            }
            set
            {
                myId = value;
            }
        }
        public abstract double Area
        {
            get;
        }
        public virtual void Draw()
        {
            Console.WriteLine("Draw Shape Icon");
        }

        public override string ToString()
        {
            return Id + "Area = " + string.Format("{0:F2}",Area);
        }
    }

    //正方形类
    public class Square : Shape
    {
        private int mySide;

        public Square(int side, string id) : base(id)
        {
            mySide = side;
            Console.Out.WriteLine("创建正方形！");
        }

        public override double Area
        {
            get
            {
                return mySide * mySide;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("Draw 4 Side:" + mySide);
        }
    }

    //圆类
    public class Circle : Shape
    {
        private int myRadius;

        public Circle(int radius, string id) : base(id)
        {
            myRadius = radius;
            Console.Out.WriteLine("创建圆形！");
        }

        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Circle:" + myRadius);
        }
    }

    //矩形类
    public class Rectangle : Shape
    {
        private int myWidth;
        private int myHeight;

        public Rectangle(int width, int height, string id) : base(id)
        {
            myWidth = width;
            myHeight = height; 
            Console.Out.WriteLine("创建矩形！");
        }

        public override double Area
        {
            get
            {
                return myWidth * myHeight;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle:" + myWidth + "*" + myHeight);
        }
    }

    //三角形类
    public class Triangle : Shape
    {
        private int myWidth;
        private int myHeight;

        public Triangle(int width, int height, string id) : base(id)
        {
            myWidth = width;
            myHeight = height;
            Console.Out.WriteLine("创建三角形！");
        }

        public override double Area
        {
            get
            {
                return myWidth * myHeight / 2;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("Draw Triangle:" + myWidth + "*" + myHeight);
        }
    }

    //图表工厂类  
    class ShapeFactory
    {
        //静态工厂方法  
        public static Shape getShape(String type)
        {
            Shape shape = null;
            if (type.Equals("Square")) 
            {
                Console.Out.WriteLine("输入正方形边长：");
                string tempS = Console.In.ReadLine();
                int side = int.Parse(tempS);
                shape = new Square(side, "Square");
                Console.Out.WriteLine("初始化设置正方形！");
            }
            else if (type.Equals("Circle"))
            {
                Console.Out.WriteLine("输入圆形半径：");
                string tempS = Console.In.ReadLine();
                int radius = int.Parse(tempS);
                shape = new Circle(radius, "Circle");
                Console.Out.WriteLine("初始化设置圆形！");
            }
            else if (type.Equals("Rectangle"))
            {
                Console.Out.WriteLine("输入矩形长：");
                string tempS = Console.In.ReadLine();
                int width = int.Parse(tempS);
                Console.Out.WriteLine("输入矩形宽："); 
                tempS = Console.In.ReadLine();
                int height = int.Parse(tempS);
                shape = new Rectangle(width, height, "Rectangle");
                Console.Out.WriteLine("初始化设置矩形！");
            }
            else if (type.Equals("Triangle"))
            {
                Console.Out.WriteLine("输入三角形底长：");
                string tempS = Console.In.ReadLine();
                int width = int.Parse(tempS);
                Console.Out.WriteLine("输入三角形高："); 
                tempS = Console.In.ReadLine();
                int height = int.Parse(tempS);
                shape = new Triangle(width, height, "Rectangle");
                Console.Out.WriteLine("初始化设置三角形！");
            }
            return shape;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = null;
            shape = ShapeFactory.getShape("Rectangle");
            shape.Draw();
        }
    }
}
