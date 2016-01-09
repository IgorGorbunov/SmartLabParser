using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using mshtml;


namespace SmartLabParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string encoding = "ISO-8859-1";

            webBrowser1.DocumentText = "";
            webBrowser1.Document.Encoding = encoding;
            HtmlDocument hd = webBrowser1.Document;
            IHTMLDocument2 axObj = hd.DomDocument as IHTMLDocument2;
            axObj.designMode = "On";
            webBrowser1.Navigate("http://smart-lab.ru/my/RomanAndreev/blog/all/");
        }

        private static void DownloadFiles(string site)
        {
            WebClient client = new WebClient();

            // Получаем содержимое страницы
            string data;
            using (Stream stream = client.OpenRead(site))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();
                }
            }

            // Парсим теги изображений
            Regex regex = new Regex
                    (@"\<img.+?src=\""(?<imgsrc>.+?)\"".+?\>", RegexOptions.ExplicitCapture);
            MatchCollection matches = regex.Matches(data);

            // Регекс для проверки на корректную ссылку картинки
            //Regex fileRegex = new Regex(@"[^\s\/]\.(jpg|png|gif|bmp)\z", RegexOptions.Compiled);
            Regex fileRegex = new Regex(@"[^\s\/]\.(png)\z", RegexOptions.Compiled);

            // Получаем ссылки на картинки
            var imagesUrl = matches
                    .Cast <Match>()
                    // Данный из группы регулярного выражения
                    .Select(m => m.Groups["imgsrc"].Value.Trim())
                    // Добавляем название сайта, если ссылки относительные
                    .Select
                    (url => url.Contains("http://")
                                    ? url
                                    : (site + url))
                    // Получаем название картинки
                    .Select
                    (url => new
                        {
                                url,
                                name = url.Split(new[] {'/'}).Last()
                        })
                    // Проверяем его
                    .Where(a => fileRegex.IsMatch(a.name))
                    // Удаляем повторяющиеся элементы
                    .Distinct()
                    ;

            // Загружаем картинки
            foreach (var value in imagesUrl)
            {
                string[] split = value.url.Split('/');
                if (value.name.Length != 10 || split.Length != 12 || split[3] != "uploads")
                {
                    continue;
                }

                string directory = Path.Combine(Application.StartupPath, new Uri(site).Host, "originals");
                Directory.CreateDirectory(directory);
                string path = Path.GetFullPath(Path.Combine(directory, GetPictureData(value.url)));
                client.DownloadFile(value.url, path);
                ImageClass imageClass = new ImageClass(path);
                imageClass.Resize(10);
                directory = Path.Combine(Application.StartupPath, new Uri(site).Host, "zoomed");
                Directory.CreateDirectory(directory);
                imageClass.SaveAs(directory);
                imageClass.RecognizeToExcel(@"D:\Work\Coding\Github\repos\SmartLabParser\SmartLabParser\bin\Debug\smart-lab.ru\rAndreevLists", "1.xlsx");
                //ImageToText(path);
            }
        }

        private static string GetPictureData(string url)
        {
            string[] split = url.Split('/');
            return string.Format("{0}.{1}.{2}.png", split[10], split[9], split[8]);
        }

        private void bttnStart_Click(object sender, EventArgs e)
        {
            int nPages = (int) nudNpages.Value;
            pbNpages.Maximum = nPages;
            const string url = "http://smart-lab.ru/my/RomanAndreev/blog/all/";
            for (int i = 0; i < nPages; i++)
            {
                string page;
                if (i == 0)
                {
                    page = url;
                }
                else
                {
                    page = string.Format("{0}page{1}/", url, i + 1);
                }
                DownloadFiles(page);
                pbNpages.Increment(1);
                Application.DoEvents();
            }
        }


    }
}
