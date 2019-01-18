using System;
namespace DelegateTest {
    // delegate int SumDelegate(int i, int j);  //1. 선언
    class Adder     {
        internal  void Sum(int i, int j)       {  Console.WriteLine(i + j);        }
        internal  void Gop(int i, int j)        { Console.WriteLine(i + j);        }
    }
    class Program     {
        static void Main(string[] args)         {
            //2. 생성, 생성자 인자로 참조할 메소드 이름을 기술
            Adder a = new Adder();
            Action<int, int> s = new Action<int, int>(a.Sum);
            s(1, 2) ;  //3. 실행
            Action<int, int> s1 = a.Gop;
            s1(1, 2);
            MyMethod(new Action<int, int>(a.Sum));
            MyMethod(a.Gop);
        }
        static void MyMethod(Action<int, int> s)   {
            s(5, 2);
        }
    }
}
