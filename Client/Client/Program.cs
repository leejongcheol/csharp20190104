﻿using System;
using System.IO;
using System.Net.Sockets;
class TcpClientTest
{
    static void Main(string[] args)
    {
        TcpClient client = null;
        try
        {
            //LocalHost에 지정 포트로 TCP Connection을 생성하고 데이터를 송수신  하기
             //위한 스트림을 얻는다.
             client = new TcpClient();
            client.Connect("192.168.30.36", 5001);
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
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
        }
    }
}