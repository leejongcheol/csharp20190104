using System;
class Program
{
    static void Main()
    {
        //Nullable Type, a가 NULL을 허용한다는 의미 
        int? a = null;
        //int b = a.Value;     // a.Value값 자체가 null 이므로 int? b도 오류
        //Console.WriteLine("Value of b is {0}", b);

        int b;
        if (a.HasValue) b = a.Value;
        else b = 0;
        Console.WriteLine("Value of b is {0}", b);

        int c = a ?? 0;
        Console.WriteLine("Value of c is {0}", c);

        int i = 10;
        int? j = (i > 0) ? 0 : 99;
        Console.WriteLine(j);

        var k = j ?? int.MinValue;
        Console.WriteLine(k.ToString());
        Console.ReadLine();
    }
}

/*
Value of b is 0
Value of c is 0
0
0
*/
