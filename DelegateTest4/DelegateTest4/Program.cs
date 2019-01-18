using System;

using System.IO;

namespace DelegateAppl
{
    class PrintString
    {
        static FileStream fs;
        static StreamWriter sw;

        // 델리게이트 선언
        public delegate void printString(string s);

      // 콘솔화면에 출력
      public static void WriteToScreen(string str)
        {
            Console.WriteLine("The String is: {0}", str);
        }
        //파일에 출력
        public static void WriteToFile(string s)
        {
            fs = new FileStream("d:\\message.txt",FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        // 델리게이트를 인자로 받아 실행
        // 결국 델리게이트가 참조하는 메소드 실행된다.
        public static void sendString(printString ps)
        {
            ps("The String is: Hello Korea~");
 }
        static void Main(string[] args)
        {
            printString ps1 = new printString(WriteToScreen);
            printString ps2 = new printString(WriteToFile);
            sendString(ps1);
            sendString(ps2);

            Console.ReadKey();
        }
    }
}