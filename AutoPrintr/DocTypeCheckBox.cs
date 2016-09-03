using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Printer document type checkbox
    /// </summary>
    public class DocTypeCheckBox : CheckBoxSlider
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Document type
        /// </summary>
        public DocType docType;
        public Printer printer;

        public DocTypeCheckBox()
        {
            Margin = new Padding(7);
            //Click += DocTypeCheckBox_Click;
        }

        public void init(DocumentType type, Printer printer)
        {
            this.docType = type.type;
            this.printer = printer;
            Checked = printer.typeGet(docType);
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

        public DocTypeCheckBox(DocumentType type, Printer printer) : this()
        {
            init(type, printer);
        }

        ///// <summary>
        ///// Checkbox change event handler
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void DocTypeCheckBox_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        printer.typeSet(docType, Checked);
        //    }
        //    catch (Exception err)
        //    {
        //        log.Error(err, "Error while saving printers config.");
        //    }
        //}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DocTypeCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "DocTypeCheckBox";
            this.Size = new System.Drawing.Size(56, 18);
            this.ResumeLayout(false);
        }
    }
}
