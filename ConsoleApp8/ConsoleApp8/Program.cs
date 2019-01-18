using System;
using System.Threading;
public class ThreadTest2 {
    public bool sleep = false;
    public void FirstWork()     {
        for (int i = 0; i < 10; i++)    {
            Thread.Sleep(1000);
            Console.WriteLine("F{0}", i);
            if (i == 5)   {
                sleep = true;
                Console.WriteLine("");
                Console.WriteLine("first 쉼...");
                Thread.CurrentThread.Suspend();
            }
        }
    }
    public static void Main()  {
        ThreadTest2 t = new ThreadTest2();
        Thread first = new Thread(new ThreadStart(t.FirstWork));
        first.Start();
        while (t.sleep == false) { }
        Console.WriteLine("first를 깨웁니다...2초후 깨어 납니다.");
        Thread.Sleep(2000);
        first.Resume();
    }
}