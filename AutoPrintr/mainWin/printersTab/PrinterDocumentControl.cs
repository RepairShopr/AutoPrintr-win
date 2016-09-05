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
        DocumentType type;
        Printer printer;
        DocTypeCheckBox docTypeCheckBox;
        TriggerCheckBox triggerCheckBox;
        DocQuantity qty;

        const int cbMargin = 7;
        const int qtyMargin = cbMargin - 2;

        void init(DocumentType type, Printer printer)
        {
            this.printer = printer;
            this.type = type;

            docTypeCheckBox = new DocTypeCheckBox(type, printer);
            qty = new DocQuantity(type, printer);
            triggerCheckBox = new TriggerCheckBox(type, printer);

            Margin = new Padding(0);
            Padding = new Padding(0);

            docTypeCheckBox.Top = cbMargin;
            docTypeCheckBox.Left = cbMargin;
            docTypeCheckBox.Anchor = AnchorStyles.None;

            qty.Top = qtyMargin;
            qty.Left = docTypeCheckBox.Width + cbMargin * 2 + qtyMargin;
            qty.Width = 40;
            qty.Anchor = AnchorStyles.None;

            triggerCheckBox.Top = 6;
            triggerCheckBox.Left = qty.Left + qty.Width + qtyMargin + cbMargin;

            Height = qty.Height + qtyMargin*2;
            Width = docTypeCheckBox.Width + qty.Width + triggerCheckBox.Width + qtyMargin * 2 + cbMargin*4;

            qty.ValueChanged += qty_Changed;
            docTypeCheckBox.Click += checkBox_Click;
            triggerCheckBox.Click += trigger_Click;

            Controls.Add(docTypeCheckBox);
            Controls.Add(qty);
            Controls.Add(triggerCheckBox);

            checkBox_Click(null, null);
        }


        void savePrinterConfig()
        {
            printer.triggerSet(type.type, triggerCheckBox.Checked);
            printer.typeSet(type.type, docTypeCheckBox.Checked);
            printer.quantity[type.name] = (int)qty.Value;
            Program.config.save(); 
        }

        void qty_Changed(object sender, EventArgs e)
        {
            if (qty.Value == 0)
            {
                if (docTypeCheckBox.Checked | triggerCheckBox.Checked)
                {
                    triggerCheckBox.Checked = docTypeCheckBox.Checked = false;
                }
            }
            else if (!docTypeCheckBox.Checked | !triggerCheckBox.Checked)
            {
                triggerCheckBox.Checked = docTypeCheckBox.Checked = true;
            }
            savePrinterConfig();
        }

        void checkBox_Click(object sender, EventArgs e)
        {
            if (docTypeCheckBox.Checked & qty.Value == 0)
            {
                triggerCheckBox.Checked = true;
                qty.Value = 1;
            }
            else if (!docTypeCheckBox.Checked)
            {
                triggerCheckBox.Checked = false;
                qty.Value = 0;
            }
            else
            {
                savePrinterConfig();
            }
        }

        void trigger_Click(object sender, EventArgs e)
        {
            if (triggerCheckBox.Checked & qty.Value == 0)
            {
                docTypeCheckBox.Checked = true;
                qty.Value = 1;
            }
            else
            {
                savePrinterConfig();
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
