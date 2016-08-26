using System;
using System.Windows.Forms;
namespace AutoPrintr
{
    public class pCheckBox : CheckBox
    {
        public PType pType;
        public Printer printer;
        public pCheckBox(PrintType pt, Printer pr)
        {
            pType = pt.type;
            printer = pr;
            Checked = printer.get(pType);
            Margin = new Padding(5, 0, 5, 0);
            Click += pCheckBox_Click;

            // Create the ToolTip and associate with the Form container.
            ToolTip tt = new ToolTip();
            // Set up the delays for the ToolTip.
            tt.AutoPopDelay = 5000;
            tt.InitialDelay = 1000;
            tt.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tt.ShowAlways = true;
            tt.SetToolTip(this, pt.title);
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
