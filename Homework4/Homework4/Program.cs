using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    //声明参数类型
    public class ClockEventArgs:EventArgs
    {
        public bool alert;
    }

    //声明委托类型
    public delegate void ClockEventHandler(object sender, ClockEventArgs e);

    //定义事件源
    public class Theclock
    {
        //设置当前时间
        public int nowHour, nowMinute, nowSecond;
        public void GetNowTime()
        {
            nowHour = DateTime.Now.Hour;
            nowMinute = DateTime.Now.Minute;
            nowSecond = DateTime.Now.Second;
        }

        //设置闹钟
        public int aimHour=-1, aimMinute=-1, aimSecond=-1;
        public void SetAlertTime()
        {
            Console.WriteLine("依次输入时， 分， 秒（每输入一个数字敲一次回车）：");
            aimHour = int.Parse(Console.ReadLine());
            aimMinute = int.Parse(Console.ReadLine());
            aimSecond = int.Parse(Console.ReadLine());
        }

        //对比是否到达时间
        public bool IsTime()
        {
            if(nowHour == aimHour&&nowMinute == aimMinute&&nowSecond == aimSecond)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //声明事件
        public event ClockEventHandler ClockSound;

        public void TheClock()
        {
            while(true)
            {
                System.Threading.Thread.Sleep(1000);
                GetNowTime();
                if(IsTime())
                {
                    ClockEventArgs args = new ClockEventArgs();
                    args.alert = true;
                    ClockSound(this, args);
                }
            }
        }
    }
    class Program
    {
        static void ShowAlert(object sender,ClockEventArgs e)
        {
            Console.WriteLine("时间到"+ e.alert);
        }

        static void Main(string[] args)
        {
            var clock = new Theclock();
            clock.SetAlertTime();
            //注册事件
            clock.ClockSound += ShowAlert;
            clock.TheClock();
        }
    }
}
