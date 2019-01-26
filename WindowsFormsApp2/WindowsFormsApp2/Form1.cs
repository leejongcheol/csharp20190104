using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }
        /*

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument hd = webBrowser1.Document;
            HtmlElement user = hd.GetElementById("mb_id");
            HtmlElement password = hd.GetElementById("mb_password");
            HtmlElement loginform = hd.GetElementById("sidebar_outlogin");

            user.SetAttribute("value", "oracletest");
            password.SetAttribute("value", "oracletest");
            loginform.InvokeMember("submit");
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            string loginData = "mb_id=oracletest&mb_password=oracletest";

            WebClient wc = new WebClient();

            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.56 Safari/536.5");
            wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            wc.Headers.Add("Accept-Encoding", "identity");
            wc.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            wc.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            wc.Headers.Add("ContentType", "application/x-www-form-urlencoded");

            txtResult.Text = wc.UploadString("http://ojc.asia/bbs/login_check.php", "POST", loginData);
        }
    }
}
