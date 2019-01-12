using System;
namespace GenericExam
{
    //일반화 클래스
    class SumTest<T>    {
        internal int Sum(T i, T j)   {           return (dynamic)i +(dynamic)j;     }
    }
    //일반화 메소드
    class SumTest2    {
        internal int Sum<T>(T i, T j) { return (dynamic)i + (dynamic)j; }
    }
    class Program    {
        static void Main(string[] args)        {
            SumTest<int> s1 = new SumTest<int>();
            Console.WriteLine(s1.Sum(1, 2));
            SumTest2 s2 = new SumTest2();
            Console.WriteLine(s2.Sum<int>(1, 2));
        }
    }
}
