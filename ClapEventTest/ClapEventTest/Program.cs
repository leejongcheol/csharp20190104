using System;

namespace ClapEventTest
{
    class Program
    {
        public delegate void ClapDelegate(int i);
        public event ClapDelegate ClapEvent;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.ClapEvent += new ClapDelegate(p.Clap);
            Console.Write("숫자를 입력하세요. ");
            int num = int.Parse(Console.ReadLine());

            for(int i=1; i <= num; i++)   {  if (i % 2 == 0) p.ClapEvent(i);   }
        }

        void Clap(int n)
        {
            Console.WriteLine($"짝({n})");
        }
    }
}
