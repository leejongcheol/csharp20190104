using System;
using System.Threading;
namespace EvnetWaitHandleSample
{
    class Program
    {
        private static int count = 0;
        public static EventWaitHandle _waitHandle;

        static void Main(string[] args)
        {
            Console.Write("1:AutoResetEvent\n2:ManualResetEvent\n..................");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    //차단기 올라간 상태
                    _waitHandle = new AutoResetEvent(true);
                    break;
                case '2':
                    _waitHandle = new ManualResetEvent(true);
                    break;
            }
            Console.WriteLine("");
            Thread T1 = new Thread(new ThreadStart(DoWork));
            Thread T2 = new Thread(new ThreadStart(DoWork));
            T1.Start();           
            T2.Start();
            Thread.Sleep(1000);
            Thread T3= new Thread(new ThreadStart(DoWork));
            Thread T4 = new Thread(new ThreadStart(DoWork));
            _waitHandle.Reset();
            T3.Start();
            T4.Start();
        }
        static private void DoWork()
        {
            _waitHandle.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(count++);
                Thread.Sleep(500);
            }
            _waitHandle.Reset();
            // 이부분에서 AutoResetEvent 는 자동으로 Reset 되어 차단기가 내려옴
            // ManualResetEvent 는 자동으로 차단되지 않아 차단기는 계속열려있다.
            // ManualResetEvent는 하나의 쓰레드만 통과시키고 닫는 
            // AutoResetEvent와 달리 한번 열리면 대기중이던 모든 쓰레드를 실행하게 한다. 
        }
    }
}
