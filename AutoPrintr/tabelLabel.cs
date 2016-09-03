using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Label for porinters table 
    /// </summary>
    public class tabelLabel : Label
    {
        public tabelLabel(string text) : this()
        {
            Text = text;
        }
        public tabelLabel()
        {
            //AutoEllipsis = true;
            Margin = new Padding(0, 0, 0, 0);
            Padding = new Padding(5, 5, 5, 5);
            AutoSize = true;
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            //Dock = DockStyle.Fill;
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }
    }

    /// <summary>
    /// Printer label
    /// </summary>
    public class pLabel : tabelLabel
    {
        public Printer printer;
        public pLabel(Printer p) : base(p.name)
        {
            printer = p;
            Text = p.name;
        }
    }
}
