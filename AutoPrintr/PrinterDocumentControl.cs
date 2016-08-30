using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    public partial class PrinterDocumentControl : UserControl
    {
        pCheckBox checkBox;
        pCount qty;

        void init(DocumentType type, Printer printer)
        {
            //checkBox.init(type, printer);
            //qty.init(type, printer);
            checkBox = new pCheckBox(type, printer);
            qty = new pCount(type, printer);

            Margin = new Padding(0);
            Padding = new Padding(0);

            checkBox.Top = 6;
            checkBox.Left = 6;
            checkBox.Anchor = AnchorStyles.None;

            qty.Top = 4;
            qty.Left = checkBox.Width + 12;
            qty.Width = 40;
            qty.Anchor = AnchorStyles.None;
            
            Height = qty.Height + 8;
            Width = checkBox.Width + qty.Width + 24;

            qty.ValueChanged += qty_Changed;
            checkBox.Click += checkBox_Click;

            Controls.Add(checkBox);
            Controls.Add(qty);

            checkBox_Click(null, null);
        }

        void qty_Changed(object sender, EventArgs e)
        {
            //MessageBox.Show("qty " + qty.Value);
            if (qty.Value == 0)
            {
                checkBox.Checked = false;
            }
            else if (!checkBox.Checked)
            {
                checkBox.Checked = true;
            }
        }

        void checkBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("checkBox_Click " + qty.Value);
            if (checkBox.Checked & qty.Value == 0)
            {
                qty.Value = 1;
            }
            else if (!checkBox.Checked & qty.Value != 0)
            {
                qty.Value = 0;
            }
        }
        
        public PrinterDocumentControl()
        {
            InitializeComponent();
        }

        public PrinterDocumentControl(DocumentType type, Printer printer)
        {
            this.init(type, printer);
        }
    }
}
