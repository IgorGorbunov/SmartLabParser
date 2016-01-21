using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLabParser
{
    public static class Statistics
    {
        public static void AddStats(DateTime date)
        {
            Dictionary <string, string> dict = new Dictionary <string, string>();
            SetKodesList(dict);
        }

        public static void SetKodesList(Dictionary<string, string> dict)
        {
            OpenFileDialog xlsBooks = new OpenFileDialog();
            xlsBooks.Title = "Выберите файл Excel с кодами";
            xlsBooks.DefaultExt = "xlsx";
            xlsBooks.Filter = "Файлы Excel (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            if (xlsBooks.ShowDialog() != DialogResult.OK)
                return;

            ExcelClass xls = new ExcelClass();
            try
            {
                xls.OpenDocument(xlsBooks.FileName, false);
                try
                {
                    int iCol = 1;
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
    }
}
