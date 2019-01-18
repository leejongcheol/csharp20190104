using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {

        static void Main(string[] args)
        {
            bool sr = false;
            int sum = 0;
            string a = "";


            for (int i = 1; i <= 1000; i++)
            {
                Console.WriteLine(".");
                for (int j = 0; j < i.ToString().Length; i++)
                {
                    a = i.ToString().Substring(j, i.ToString().Length - 1);

                    if (a.Contains("7"))
                    {
                        sr = true;

                    }
                    else
                        sr = false;



                    if (sr)
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine("7은 몇개 : " + sum);
        }
    }
}