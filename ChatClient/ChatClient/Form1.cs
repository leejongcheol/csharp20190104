using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Encoding encoding = Encoding.GetEncoding("euc-kr");
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;

        // Chat_Class cht_Class = new Chat_Class();
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cmd_Connect.Text != "Login")
            {
                send("<" + txt_Name.Text + "> 님께서 접속해제 하셨습니다.", false);
                logout();
            }
        }
        private void cmd_Connect_Click(object sender, EventArgs e)
        {
            if (cmd_Connect.Text == "Login")
            {
                try
                {
                    IPAddress ipaAddress = IPAddress.Parse(txt_Server_IP.Text);
                    tcpClient = new TcpClient();
                    tcpClient.Connect(ipaAddress, 5001);
                    NetworkStream stream = tcpClient.GetStream();
                    reader = new StreamReader(stream, encoding);
                    writer = new StreamWriter(stream, encoding) { AutoFlush = true };
                    new Thread(post).Start();
                    send("<" + txt_Name.Text + "> 님께서 접속 하셨습니다.", true);
                    cmd_Connect.Text = "Logout";
                }
                catch (System.Exception Err)
                {
                    MessageBox.Show("Chatting Server 오류발생 또는 Start 되지 않았거나\n\n" + Err.Message, "Client");
              }
            }
            else
            {
                string message = "<" + txt_Name.Text + "> 님께서 접속해제 하셨습니다.";
                send(message, false);
                SetText(message + "\r\n");
                cmd_Connect.Text = "Login";
                logout();
            }
        }
        private void txt_Msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmd_Connect.Text == "Logout")
                {
                    send("<" + txt_Name.Text + "> " + txt_Msg.Text, true);
                }
                txt_Msg.Text = "";
                e.Handled = true;
            }
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
        private void send(string message, Boolean Msg)
        {
            try
            {
                writer.WriteLine(message);
            }
            catch (System.Exception Err)
            {
                if (Msg == true)
                {
                    MessageBox.Show("Chatting Server 가 오류발생 또는 Start 되지 않았거나\n\n" + Err.Message, "Client");
                   
                    cmd_Connect.Text = "Login";
                    logout();
                }
            }
        }
        public void post()
        {
            try
            {
                string line;
                while (reader != null && (line = reader.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        SetText(line + "\r\n");
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
                tcpClient.Close();
            }
        }
        public void logout()
        {
            reader.Close();
            reader = null;
        }
    }
}
