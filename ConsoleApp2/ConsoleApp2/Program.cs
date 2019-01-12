using System;
namespace ConsoleApp1{
    class Test    {
        static void Main()        {
            object a = 10;
            object b = 20;
            object c = a ?? b;
            Console.WriteLine("Value of c is {0}", c);
        }
    }
}