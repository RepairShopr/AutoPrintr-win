using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Printer document type checkbox
    /// </summary>
    public class pCheckBox : CheckBoxSlider
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Document type
        /// </summary>
        public DocType docType;
        public Printer printer;
        public pCheckBox(DocumentType type, Printer printer)
        {
            this.docType = type.type;
            this.printer = printer;
            Checked = printer.get(docType);
            Margin = new Padding(5, 5, 5, 5);
            Click += pCheckBox_Click;

            // Create the ToolTip and associate with the Form container.
            ToolTip tt = new ToolTip();
            // Set up the delays for the ToolTip.
            tt.AutoPopDelay = 5000;
            tt.InitialDelay = 1000;
            tt.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tt.ShowAlways = true;
            SetToolTip(tt, type.title);
        }
        /// <summary>
        /// Checkbox change event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pCheckBox_Click(object sender, EventArgs e)
        {
            try
            {
                printer.set(docType, Checked);
            }
            catch (Exception err)
            {
                log.Error("Error while saving printers config. Error is: {0}", err);
            }
        }
    }
}
