using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPrintr
{
    static class Printers
    {
        public static List<Printer> get()
        {
            List<Printer> list = new List<Printer>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                list.Add(new Printer(printer));
            }
            return list; 
        }
    }

    public struct Printer
    {
        public string name;
        //public string id;
        public Printer(string n)
        {
            name = n;
        }
    }
}
