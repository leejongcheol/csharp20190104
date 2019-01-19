using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Windows.Forms;
namespace ChatServer
{
    public partial class Form1 : Form
    {
        static Encoding encoding = Encoding.GetEncoding("euc-kr");
        static IPAddress ip = IPAddress.Parse("192.168.30.36");
        TcpListener listener = new TcpListener(ip, 5001);

        List<Socket> sockets = new List<Socket>();
        public Form1()
        {
            InitializeComponent();
        }
        public void SetText(string text)
        {
            if (this.txt_Chat.InvokeRequired)
            {
                this.Invoke((Action<string>)SetText, text);
            }
            else
            {
                this.txt_Chat.AppendText(text);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            listener.Stop();
        }
        private void cmd_Start_Click(object sender, EventArgs e)
        {
            if (lbl_Message.Tag.ToString() == "Stop")
            {
               listener.Start();
                new Thread(listen).Start();
                lbl_Message.Text = "Server Start 상태 입니다.";
                lbl_Message.Tag = "Start";
                cmd_Start.Text = "Server Stop";
            }
            else
            {
                listener.Stop();
                foreach (Socket socket in sockets)
                {
                    socket.Close();
                }
                sockets.Clear();
                lbl_Message.Text = "Server Stop 상태 입니다.";
                lbl_Message.Tag = "Stop";
                cmd_Start.Text = "Server Start";
            }
        }
        private void listen()
        {
            Socket socket = null;
            try
            {
                while (true)
                {
                    socket = listener.AcceptSocket();
                    new Thread(() => chat(socket)).Start();
                }
            }
            catch (System.Exception)
            {
                if (socket != null)
                {
                    sockets.Remove(socket);
                }
            }
        }
        private void chat(Socket socket)
        {
            sockets.Add(socket);
            StreamReader reader = new StreamReader(new NetworkStream(socket),
           encoding);
            try
            {
                string line;
                while (reader != null && (line = reader.ReadLine()) != null)
                {
                    SetText(line + "\r\n");
                    lock (sockets)
                    {
                        foreach (Socket s in sockets)
                        {
                            NetworkStream stream = new NetworkStream(s);
                            StreamWriter writer = new StreamWriter(stream, encoding)
                            { AutoFlush = true };
                            writer.WriteLine(line);
                            writer.Close();
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                sockets.Remove(socket);
                }
        }
    }
}