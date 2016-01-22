using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SmartLabParser
{
    public static class Statistics
    {
        private const string PagesFolder = @"D:\Work\Coding\Github\repos\SmartLabParser\SmartLabParser\bin\Debug\smart-lab.ru\rAndreevLists";
        private const string CsvFolder = @"D:\Work\Coding\Github\repos\SmartLabParser\SmartLabParser\bin\Debug\smart-lab.ru\xlsx";


        public static void AddStats(DateTime date)
        {
            Dictionary <string, string> dict = new Dictionary <string, string>();
            SetKodesList(dict);
            DateTime toDate = new DateTime(2015, 07, 31);
            ReadLists(date, toDate, PagesFolder, dict);
        }

        private static void SetKodesList(Dictionary<string, string> dict)
        {
            OpenFileDialog xlsBooks = new OpenFileDialog
                {
                        Title = "Выберите файл Excel с кодами",
                        DefaultExt = "xlsx",
                        Filter = "Файлы Excel (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*"
                };
            if (xlsBooks.ShowDialog() != DialogResult.OK)
                return;

            ExcelClass xls = new ExcelClass();
            try
            {
                xls.OpenDocument(xlsBooks.FileName, false);
                try
                {
                    const int iCol = 1;
                    int iRow = 1;
                    string key = xls.GetCellStringValue(iCol, iRow);
                    while (!string.IsNullOrEmpty(key))
                    {
                        dict.Add(key, xls.GetCellStringValue(2, iRow));
                        iRow++;
                        key = xls.GetCellStringValue(iCol, iRow);
                    }

                }
                finally
                {
                    xls.CloseDocument(false);
                }
            }
            finally
            {
                xls.Dispose();
            }
        }

        private static void ReadLists(DateTime fromDate, DateTime toDate, string folderPath, Dictionary <string, string> kodes)
        {
            List <DateTime> dates = new List <DateTime>();
            DateTime date = fromDate;
            while (date.Date <= toDate.Date)
            {
                dates.Add(date);
                date = date.AddDays(1);
            }

            for (int i = dates.Count - 1; i >= 0; i--)
            {
                string fileName = dates[i].ToString("dd.MM.yyyy") + ".xlsx";
                string fullPath = Path.Combine(folderPath, fileName);
                if (File.Exists(fullPath))
                {
                    ReadPage(fullPath, kodes);
                }
            }
        }

        private static void ReadPage(string fileName, Dictionary <string, string> kodes)
        {
            ExcelClass xls = new ExcelClass();
            try
            {
                xls.OpenDocument(fileName, false);
                try
                {
                    string date = GetDate(xls.GetCellStringValue(2, 2));
                    int iRow = 9;
                    string name = xls.GetCellStringValue(2, iRow);
                    while (!string.IsNullOrEmpty(name))
                    {
                        string orientation = xls.GetCellStringValue(3, iRow);
                        if (kodes.ContainsKey(name))
                        {
                            string buyCost = xls.GetCellStringValue(4, iRow);
                            string stopCost = xls.GetCellStringValue(5, iRow);
                            string profitLoss = xls.GetCellStringValue(6, iRow);
                            SetRow(kodes, date, name, orientation, buyCost, stopCost, profitLoss);
                        }
                        else
                        {
                            if (orientation != "ЛОНГ" || 
                                orientation != "шорт")
                            {
                                break;
                            }
                            MessageBox.Show(name);
                        }
                        iRow++;
                        name = xls.GetCellStringValue(2, iRow);
                    }
                }
                finally
                {
                    xls.CloseDocument(false);
                }
            }
            finally
            {
                xls.Dispose();
            }
            
        }

        private static void SetRow(Dictionary <string, string> kodes, string date, string name, string orientation, string buyCost, string stopCost, string profitLoss)
        {
            string file = GetFilename(name, kodes);
            ExcelClass xls = new ExcelClass();
            try
            {
                xls.OpenDocument(file, false);
                try
                {
                    string csvDate;
                    int iRow;
                    string lastNum = xls.GetCellStringValue(11, 1);
                    if (string.IsNullOrEmpty(lastNum))
                    {
                        iRow = 2;
                        csvDate = xls.GetCellStringValue(3, iRow);
                        while (!string.IsNullOrEmpty(csvDate))
                        {
                            iRow++;
                            csvDate = xls.GetCellStringValue(3, iRow);
                        }
                        iRow--;
                    }
                    else
                    {
                        iRow = int.Parse(lastNum) - 1;
                    }
                    

                    csvDate = GetCsvDate(xls.GetCellStringValue(3, iRow));
                    while (true)
                    {
                        if (csvDate == date)
                        {
                            SetNumValue(xls, 11, iRow, orientation);
                            SetNumValue(xls, 12, iRow, buyCost);
                            SetNumValue(xls, 13, iRow, stopCost);
                            SetNumValue(xls, 14, iRow, profitLoss);

                            xls.SetCellValue(11, 1, iRow.ToString());
                            break;
                        }
                        iRow--;
                        csvDate = GetCsvDate(xls.GetCellStringValue(3, iRow));
                    }
                }
                finally
                {
                    xls.CloseDocument(true);
                }
            }
            finally
            {
                xls.Dispose();
            }
        }

        private static void SetNumValue(ExcelClass xls, int iCol, int iRow, string value)
        {
            double d;
            string s;
            if (double.TryParse(value, out d))
            {
                s = value;
            }
            else
            {
                s = GetNum(value);
            }
            xls.SetCellValue(iCol, iRow, s);
        }

        private static string GetFilename(string stockName, Dictionary <string, string> kodes)
        {
            string[] csvFiles = Directory.GetFiles(CsvFolder);
            string kode = kodes[stockName];
            string file = "";
            foreach (string csvFile in csvFiles)
            {
                string[] split = Path.GetFileName(csvFile).Split('_');
                if (kode == split[0])
                {
                    file = csvFile;
                    break;
                }
            }
            return file;
        }

        private static string GetDate(string kindOfDate)
        {
            if (string.IsNullOrEmpty(kindOfDate))
            {
                return "";
            }
            string[] split = kindOfDate.Trim().Split('.', ' ');
            string result = "";
            foreach (string s in split)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    int n;
                    string sNum;
                    if (int.TryParse(s, out n))
                    {
                        sNum = s;
                    }
                    else
                    {
                        sNum = GetNum(s);
                    }
                    result += sNum + '.';
                }
            }
            return result.Substring(0, result.Length - 1);
        }

        private static string GetCsvDate(string kindOfDate)
        {
            string year = "20" + kindOfDate.Substring(kindOfDate.Length - 2);
            string month = kindOfDate.Substring(kindOfDate.Length - 4, 2);
            string day;
            if (kindOfDate.Length == 6)
            {
                day = kindOfDate.Substring(0, 2);
            }
            else
            {
                day = "0" + kindOfDate[0];
            }
            return string.Format("{0}.{1}.{2}", day, month, year);
        }

        private static string GetNum(string sNum)
        {
            string s = "";
            foreach (char c in sNum)
            {
                if (c == 'O' ||
                    c == 'О')
                {
                    s += '0';
                }
                else if (c == 'б')
                {
                    s += '6';
                }
                else if (c == 'S')
                {
                    s += '8';
                }
                else if (c == 'З')
                {
                    s += '3';
                }
                else if (c == 'l')
                {
                    s += '1';
                }
                else if (c == ' ')
                {

                }
                else
                {
                    s += c;
                }
            }
            return s;
        }
    }
}
