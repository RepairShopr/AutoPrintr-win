using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPrintr
{
    public partial class mainWin : Form
    {
        public enum PType : byte { fullSize, receipt, label }
        
        public class pCheckBox : CheckBox
        {
            public PType pType;
            public Printer printer;
            //public override void InitLayout()
            //{
            //    base.InitLayout();              
            //}
            public pCheckBox(PType pt, Printer pr)
            {
                pType = pt;
                printer = pr;
                Margin = new Padding(5, 0, 5, 0);
                Click += pCheckBox_Click;
            }

            void pCheckBox_Click(object sender, EventArgs e)
            {
                //MessageBox.Show(pType.ToString());
                //throw new NotImplementedException();
            }
        }

        public mainWin()
        {
            InitializeComponent();

            printersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            
            List<Printer> printers = Printers.get();
            int row = 1;
            Label pName;
            foreach (Printer p in printers)
            {
                // Row creating
                printersTable.RowCount++;
                printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                // Printer label
                pName = new Label() { Text = p.name };
                pName.Margin = new Padding(5,5,5,0);
                pName.Padding = new Padding(0);
                printersTable.Controls.Add(pName, 0, row);
                // Prnter checkboxes
                printersTable.Controls.Add(new pCheckBox(PType.fullSize, p) { }, 1, row);
                printersTable.Controls.Add(new pCheckBox(PType.receipt, p) { }, 2, row);
                printersTable.Controls.Add(new pCheckBox(PType.label, p) { }, 3, row++);
            }
            
        }
    }
}
