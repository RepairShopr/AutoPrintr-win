using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    public class tabelLabel : Label
    {
        public tabelLabel(string text)
        {
            Text = text;
            Margin = new Padding(3, 5, 3, 0);
            Padding = new Padding(0);
        }
        public tabelLabel()
        {
            Margin = new Padding(3, 5, 3, 0);
            Padding = new Padding(0);
        }
    }

    public class pLabel : tabelLabel
    {
        public Printer printer;
        public pLabel(Printer p)
        {
            printer = p;
            Text = p.name;
            //Margin = new Padding(5, 5, 5, 0);
            //Padding = new Padding(0);
        }
    }
}
