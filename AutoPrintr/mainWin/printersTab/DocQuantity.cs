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
    public class DocQuantity : NumericUpDown
    {
        public DocumentType type;
        public Printer printer;

        public void init(DocumentType type, Printer printer)
        {
            this.type = type;
            this.printer = printer;
            Value = printer.quantity[type.name];   
            //ValueChanged += DocQuantity_ValueChanged;
        }

        //void DocQuantity_ValueChanged(object sender, EventArgs e)
        //{
        //    printer.quantity[type.name] = (int)Value;            
        //}

        public DocQuantity(){}

        public DocQuantity(DocumentType type, Printer printer) {
            init(type, printer);
        }
    }
}
