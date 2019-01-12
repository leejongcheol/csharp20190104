using System;
namespace ConsoleApp1{
    interface Dog {   }
    class A : Dog {
        internal void a() {
            Console.WriteLine("........");
        }
    }
    class Test    {
        static void Main()     {
            A a1 = new A();
            a1 = null;
            a1.a();
            Console.ReadLine();
        }
    }
}
