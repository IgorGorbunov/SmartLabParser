using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLabParser
{
    public partial class Form1 : Form
    {
        private static WebClient _wClient;
        private static WebRequest request;
        private static WebResponse response;

        private static Encoding encode = System.Text.Encoding.GetEncoding("utf-8");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string Encoding = "ISO-8859-1";
            HtmlDocument hd;
            mshtml.IHTMLDocument2 axObj;

            webBrowser1.DocumentText = "";
            webBrowser1.Document.Encoding = Encoding;
            hd = webBrowser1.Document;
            axObj = hd.DomDocument as mshtml.IHTMLDocument2;
            axObj.designMode = "On";
            webBrowser1.Navigate("http://smart-lab.ru/my/RomanAndreev/blog/all/");
            //_wClient = new WebClient();

            //_wClient.Proxy = null;
            //_wClient.Encoding = encode;

            //webBrowser1.Navigate(new Uri("htpp:\\ya.ru"));
            //HtmlDocument html = webBrowser1.Document;

            //html.LoadHtml(_wClient.DownloadString("https://habr.ru/job"));
        }
    }
}
