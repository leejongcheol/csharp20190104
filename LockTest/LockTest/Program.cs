using System;
using System.Threading;
public class ThreadTest3
{
    public string lockString = "Hello";
    private object obj = new object();
    public void Print(string rank)
    {
        //lock을 걸어준 구문은 처음 쓰레드가 끝날때 까지 다른 쓰레드가 접근 금지
        lock (obj)
        {

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Thread.Sleep(100);
                    Console.Write(",");
                }
                Console.WriteLine("{0}{1} ", rank, lockString);
            }
        }
    }
    public void FirstWork() { Print("F"); }
    public void SecondWork() { Print("S"); }
}
class TestMain
{
    [MTAThread]
    public static void Main()
    {
        ThreadTest3 t = new ThreadTest3();
        Thread first = new Thread(new ThreadStart(t.FirstWork));
        Thread second = new Thread(new ThreadStart(t.SecondWork));
        first.Start();
        second.Start();
    }
}