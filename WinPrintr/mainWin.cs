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
        public class pCheckBox : CheckBox
        {
            public PType pType;
            public Printer printer;
            public pCheckBox(PType pt, Printer pr)
            {
                pType = pt;
                printer = pr;
                Checked = printer.get(pType);
                Margin = new Padding(5, 0, 5, 0);
                Click += pCheckBox_Click;
            }

            void pCheckBox_Click(object sender, EventArgs e)
            {
                try
                {
                    printer.set(pType, Checked);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error while saving printers config. Error is:" + err.Message.ToString());
                }
            }
        }

        public mainWin()
        {
            InitializeComponent();

            printersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            try
            {
                Printers.get();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error while loading printers local config. Config will be wiped. Error is: " + e1.Message.ToString());
                try
                {
                    Printers.save();
                    Printers.get();
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Great Scott! Unexpected error was expected and catched. Application will exit. Error is:" + e2.Message.ToString());
                    Application.Exit();
                }                
            }
            
            //List<Printer> printers = Printers.get();
            int row = 1;
            Label pName;
             //= Printers.list;
            foreach (Printer p in Printers.list)
            {
                //printer = p;
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
