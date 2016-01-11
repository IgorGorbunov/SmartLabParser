using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Puma.Net;

namespace SmartLabParser
{
    public static class Recognizer
    {
        public static string Recognize(Bitmap bitmap)
        {
            string result = "";
            using (PumaPage image = new PumaPage(bitmap))
            {
                image.FileFormat = PumaFileFormat.TxtAnsi;
                image.AutoRotateImage = false;
                image.EnableSpeller = false;
                image.RecognizeTables = false;
                image.FontSettings.DetectItalic = true;
                image.FontSettings.DetectBold = true;
                image.FontSettings.SerifName = "Arial";
                image.Language = PumaLanguage.RussianEnglish;
            
                try
                {
                    result = image.RecognizeToString();
                }
                catch (RecognitionEngineException exception)
                {
                    //сложно разобрать?
                    if (exception.ErrorCode == 0)
                    {
                    
                    }
                    else
                    {
                        throw;
                    }
                
                }
            }
            return result;
        }

        public static string Recognize(Bitmap bitmap, int series)
        {
            Dictionary <string, int> versions = new Dictionary <string, int>();

            using (ImageClass image = new ImageClass(bitmap))
            {
                for (int i = 0; i < series; i++)
                {
                    string result = "";
                    try
                    {
                        using (Bitmap b = new Bitmap(image.BitImage))
                        {
                            result = Recognize(b);
                        }
                    }
                    catch (RecognitionEngineException exception)
                    {
                        //если ошибка из-за отсутствия текста
                        if (exception.ErrorCode == 6553609)
                        {
                            if (!versions.ContainsKey(result))
                            {
                                versions.Add(result, 1);
                            }
                            break;
                        }
                        //если ошибка из-за отсутствия текста[2]
                        if (exception.ErrorCode == 6684676)
                        {
                            if (!versions.ContainsKey(result))
                            {
                                versions.Add(result, 1);
                            }
                            break;
                        }
                        bitmap.Save(Path.Combine(Application.StartupPath, bitmap.GetHashCode().ToString() + ".png"), ImageFormat.Png);
                        throw;
                    }
                    if (versions.ContainsKey(result))
                    {
                        versions[result]++;
                    }
                    else
                    {
                        versions.Add(result, 1);
                    }
                    image.Resize(0.9);
                }
            }

            int max = 0;
            string sMax = "";
            foreach (KeyValuePair <string, int> pair in versions)
            {
                if (string.IsNullOrEmpty(pair.Key))
                    continue;
                if (pair.Value > max)
                {
                    sMax = pair.Key;
                    max = pair.Value;
                }
            }
            return sMax;
        }
    }
}

