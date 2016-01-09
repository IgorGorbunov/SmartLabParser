using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace SmartLabParser
{
    public class ImageClass 
    {
        private string _fullPath;
        private readonly string _fileName;
        public Image Image;

        //private const string TableBorderColorName = "ffdfe1e2";   // x3,0
        private const string TableBorderColorName = "ffdfe1e2";     // x10,0
        private const int StartBorderX = 30;
        private const int StartBorderY = 30;
        private List <int> _verticalBorderNums;
        private List <int> _horizontalBorderNums;

        public ImageClass(string fullPath)
        {
            _fullPath = fullPath;
            _fileName = Path.GetFileName(_fullPath);
            Image = new Bitmap(_fullPath);
        }

        public ImageClass(Bitmap bitmap)
        {
            Image = bitmap;
        }


        public void Resize(double ratio)
        {
            int width = (int) Math.Round(Image.Size.Width * ratio);
            int height = (int)Math.Round(Image.Size.Height * ratio);
            Image result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(Image, 0, 0, width, height);
                g.Dispose();
            }
            Image = result;
        }

        public void SaveAs(string newPath)
        {
            _fullPath = Path.Combine(newPath, _fileName);
            Image.Save(_fullPath);
        }

        public void RecognizeToExcel(string excelPath, string excelName)
        {
            Bitmap b = new Bitmap(Image);
            _verticalBorderNums = new List <int>();
            for (int i = StartBorderX; i < Image.Size.Width; i++)
            {
                Color color = b.GetPixel(i, StartBorderY);
                if (color.R > 220 && color.R < 230)
                {
                    //MessageBox.Show("Test");
                }
                if (color.Name == TableBorderColorName)
                {
                    _verticalBorderNums.Add(i);
                    i += StartBorderY;
                }
            }
            _verticalBorderNums.Add(Image.Size.Width);

            _horizontalBorderNums = new List<int>();
            for (int j = StartBorderY; j < Image.Size.Height; j++)
            {
                Color color = b.GetPixel(StartBorderX, j);
                if (color.Name == TableBorderColorName)
                {
                    _horizontalBorderNums.Add(j);
                    j += StartBorderX;
                }
            }
            _horizontalBorderNums.Add(Image.Size.Height);

            Bitmap[,] bitmaps = GetTableCellImages();
            string[,] texts = Recognize(bitmaps);
        }

        private static string[,] Recognize(Bitmap[,] bitmaps)
        {
            string[,] result = new string[bitmaps.GetLength(0), bitmaps.GetLength(1)];
            for (int i = 0; i < bitmaps.GetLength(0); i++)
            {
                for (int j = 0; j < bitmaps.GetLength(1); j++)
                {
                    result[i, j] = Recognizer.Recognize(bitmaps[i, j], 10);
                }
            }
            return result;
        }

        private Bitmap[,] GetTableCellImages()
        {
            int y1 = 0;
            Bitmap[,] bitmaps = new Bitmap[_horizontalBorderNums.Count, _verticalBorderNums.Count];
            for (int i = 0; i < _horizontalBorderNums.Count; i++)
            {
                int x1 = 0;
                int y2 = _horizontalBorderNums[i];
                for (int j = 0; j < _verticalBorderNums.Count; j++)
                {
                    int x2 = _verticalBorderNums[j];
                    bitmaps[i, j] = GetSubImage(x1, y1, x2, y2);
                    x1 = x2;
                }
                y1 = y2;
            }
            return bitmaps;
        }

        private Bitmap GetSubImage(int x1, int y1, int x2, int y2)
        {
            Rectangle cropRect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(Image, new Rectangle(0, 0, target.Width, target.Height),
                            cropRect,
                            GraphicsUnit.Pixel);
            }
            return target;
        }
    }
}

