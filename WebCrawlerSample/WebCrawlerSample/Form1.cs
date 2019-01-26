using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System;
using System.Text;

namespace WebCrawlerSample
{
    public partial class Form1 : Form
    {
        public TextBox HyPerLinkTextBox {
            get { return this.txtHyperLink;  }
            set { this.txtHyperLink = value;  }
        }

        public TextBox TitleTextBox
        {
            get { return this.txtTitle; }
            set { this.txtTitle = value; }
        }

        public Form1()
        {
            InitializeComponent();
            txtURL.Text = "naver.com";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                client.Encoding = Encoding.UTF8;
                string sitesource = client.DownloadString("http://" + txtURL.Text);
                txtResult.Text = sitesource;
                Console.WriteLine(sitesource);
                AParser c1 = new AParser();
                c1.ExecuteDemo(sitesource, HyPerLinkTextBox, TitleTextBox);
            }
        }
    }

    public class AParser
    {
        public void ExecuteDemo(string sitesource, TextBox hyperLink, TextBox title)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(sitesource);

            title.Text = doc.DocumentNode.SelectSingleNode("//head/title").InnerText;

            foreach (HtmlNode body in doc.DocumentNode.SelectNodes("//body"))
            {
                Console.WriteLine("Found: " + body.Id);
                foreach (HtmlNode a in body.SelectNodes("//a"))
                {
                    string hrefValue = a.Attributes["href"].Value;
                    hyperLink.Text += hrefValue + "\n";
                    Console.WriteLine("a : " + hrefValue);
                }
            }
            //Console.ReadLine();
        }
    }

    
}
