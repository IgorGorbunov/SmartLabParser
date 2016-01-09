using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartLabParser
{
    public static class Indicator
    {
        private static Form1 _form;

        public static void SetForm(Form1 form)
        {
            _form = form;
        }

        public static void IncDownloadImage()
        {
            _form.pbNimages.Increment(1);
            Application.DoEvents();
        }

        public static void SetNcellImages(int num)
        {
            _form.pbNcellImages.Maximum = num;
            _form.pbNcellImages.Value = 0;
        }

        public static void IncRecognizeCellImage()
        {
            _form.pbNcellImages.Increment(1);
            Application.DoEvents();
        }
    }
}
