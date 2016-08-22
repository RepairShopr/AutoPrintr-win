using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPrintr
{
    static class Printers
    {
        public static Printer[] get()
        {
            Printer[] list = null;
            int i = 0;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                list[i++] = new Printer { name = printer };
            }
            return list;
        }
    }

    struct Printer
    {
        public string name;
        public string id;
    }
}
