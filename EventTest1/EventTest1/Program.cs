using System;
namespace ConsoleApplication1
{
    //이벤트 게시자 클래스, 이벤트를 발생시키는 객체
    class EventPublisher
    {
        public delegate void MyEventHandler(); //이벤트처리를위한델리게이트정의
        MyEventHandler handler;
        public event MyEventHandler MyEvent
        {
            add
            {
                handler += value;
            }
            remove
            {
                handler -= value;
            }
        }

        public void Do()
        {
            //MyEvent?.Invoke();
            //MyEvent();
            handler();
            handler?.Invoke();
        }
    }

    //구독자 클래스
    class Subscriber
    {
        static void Main(string[] args)
        {           
            EventPublisher p = new EventPublisher();
            p.MyEvent += new EventPublisher.MyEventHandler(doAction);
            p.Do();
        }
        //MyEvent 라는 이벤트가 발생하면 호출되는 메소드
        static void doAction()
        {
            Console.WriteLine("MyEvent 라는 이벤트 발생...");
        }
    }
}