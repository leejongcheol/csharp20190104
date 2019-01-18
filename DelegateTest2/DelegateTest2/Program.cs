using System;
class Program
{
    delegate void Deli(string s);
    static void Main()
    {
        Deli d = delegate (string s)
                    {
                        Console.WriteLine(s);
                    };
        d( "안녕" );
        d.Invoke("안녕");

        // Specify delegate with Lambda Expression
        Deli d0 = (s) => Console.WriteLine(s);

        //Invoke delegate.
        d0.Invoke("OJC");
        // Specify delegate with new Constructor
        Deli d1 = new Deli(d);
        d1.Invoke("OJC");
        // Specify delegate with method name
        Deli d2 = d;
        d2.Invoke("OJC");
    }
    static void d(string s)
    {
        Console.WriteLine(s);
    }
}