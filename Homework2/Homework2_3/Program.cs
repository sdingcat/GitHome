using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberLine = new int[99];
            for(int i=0;i< numberLine.Length;i++)
            {
                numberLine[i] = i + 2;
            }
            for(int divition=2; divition<=100; divition++)
            {
                for(int i = 0; i < numberLine.Length; i++)
                {
                    if (numberLine[i] % divition == 0 && numberLine[i] != divition)
                    {
                        numberLine[i] = -1;
                    }
                }
            }
            foreach(int i in numberLine)
            {
                if(i!=-1)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
