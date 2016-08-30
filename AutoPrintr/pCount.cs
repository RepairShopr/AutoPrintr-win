using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Printer document type number documents to print 
    /// </summary>
    public class pCount : NumericUpDown
    {
        public DocumentType type;
        public Printer printer;

        public void init(DocumentType type, Printer printer)
        {
            this.type = type;
            this.printer = printer;
            ValueChanged += pCount_ValueChanged;
        }

        void pCount_ValueChanged(object sender, EventArgs e)
        {
            printer.quantity = (int)Value;
        }

        public pCount(){}

        public pCount(DocumentType type, Printer printer) {
            init(type, printer);
        }
    }
}
