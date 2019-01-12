using System;
namespace ConsoleApp6{
    class Adder : Object   {
        public int Value { get; set; }
        public static Adder operator + (Adder a1, Adder a2) {
            Adder a3 = new Adder();
            a3.Value = a1.Value + a2.Value;
            return a3;
        }      
        public override string ToString() {   return $"Value : {Value}";    }
        public override bool Equals(object a2)         {
            return this.Value == ((Adder)a2).Value;
        }
    }
    class Program     {
        static void Main(string[] args)         {
            Adder a1 = new Adder(); a1.Value = 1;
            Adder a2 = new Adder(); a2.Value = 1;
            Adder a3 = a1 + a2;      Console.WriteLine(a3);
            if (a1 == a2) Console.WriteLine("a1 == a2");  
            if (a1.Equals(a2))  Console.WriteLine("a1.equals(a2)");

        }
    }
}
