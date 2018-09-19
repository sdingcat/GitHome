using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            void getFourProperty(int[] s)
            {
                int maxNumber = s[1], minNumber = s[1], allNumber = 0, length = 0;
                double avgNumber = 0;
                foreach (int i in s)
                {
                    if(i> maxNumber)
                    {
                        maxNumber = i;
                    }
                    if (i < minNumber)
                    {
                        minNumber = i;
                    }
                    allNumber += i;
                    length++;
                }
                avgNumber = allNumber / length;
                Console.WriteLine("maxNumber:" + maxNumber);
                Console.WriteLine("minNumber:" + minNumber);
                Console.WriteLine("allNumber:" + allNumber);
                Console.WriteLine("avgNumber:" + avgNumber);
            }

            int[] IList = { 1, 3, 5, 45, 678, 7, 612, 7689 };

            getFourProperty(IList);
        }
    }
}
