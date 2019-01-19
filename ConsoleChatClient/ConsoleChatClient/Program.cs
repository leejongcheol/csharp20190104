using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class ServerHandler
{
    StreamReader reader = null;
    public ServerHandler(StreamReader reader)
    {
        this.reader = reader;
    }
    //서버에서 불특정하게 날아오는 다른 Client가 쓴 내용을
    //받기 위해 클라이언트의 글읽는 부분을 쓰레드로 처리
    public void chat()
    {
        try
        {
            while (true)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
class TcpClientTest
{
    static void Main(string[] args)
    {
        TcpClient client = null;
        try
        {
            //LocalHost에 지정 포트로 TCP Connection을 생성하고 데이터를 송수신 하기
            //위한 스트림을 얻는다. 

        client = new TcpClient();
            client.Connect("192.168.30.36", 5001);
            NetworkStream stream = client.GetStream();
            Encoding encode = System.Text.Encoding.GetEncoding("euc-kr");
            StreamReader reader = new StreamReader(stream, encode);
            StreamWriter writer = new StreamWriter(stream, encode)
            { AutoFlush = true };

            //글읽는 부분을 ServerHandler에서 처리하도록 쓰레드로 만든다.
            ServerHandler serverHandler = new ServerHandler(reader);
            Thread t = new Thread(new ThreadStart(serverHandler.chat));
            t.Start();
            string dataToSend = Console.ReadLine();
            while (true)
            {
                writer.WriteLine(dataToSend);
                if (dataToSend.IndexOf("<EOF>") > -1) break;
                dataToSend = Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            client.Close();
            client = null;
        }
    }
}