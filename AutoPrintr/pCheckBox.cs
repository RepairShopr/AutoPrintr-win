using System;
using System.Windows.Forms;
namespace AutoPrintr
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
}
