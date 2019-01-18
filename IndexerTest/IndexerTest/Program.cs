using System;
namespace IndexerTest
{
    class Dept
    {
        public string[] emps = new string[3];
        public string this[int i]
        {
            get { return emps[i]; }
            set { emps[i] = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dept d1 = new Dept();
            d1.emps[0] = "사원1"; d1.emps[1] = "사원2"; d1.emps[2] = "사원3";

            d1[0] = "사원1"; d1[1] = "사원2"; d1[2] = "사원3";
            Console.WriteLine(d1[0]);
        }
    }
}
