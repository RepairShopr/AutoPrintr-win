using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    /// <summary>
    /// Printer trigger checkbox
    /// </summary>
    class TriggerCheckBox : CheckBoxSlider
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// DocType 
        /// </summary>
        public DocType docType;
        /// <summary>
        /// Printer
        /// </summary>
        public Printer printer;
        /// <summary>
        /// Tool tip text
        /// </summary>
        const string ttText = "Turning on/off automatically print from triggers will make it so you can send print jobs here by clicking the 'Print' button in the web app, but jobs won't auto-print when things happen - like after a payment. You'll have to click 'Print'";
        
        void init(DocumentType type, Printer printer)
        {
            this.docType = type.type;
            this.printer = printer;
            Checked = printer.triggerGet(docType);
            // Create the ToolTip and associate with the Form container.
            ToolTip tt = new ToolTip();
            // Set up the delays for the ToolTip.
            tt.AutoPopDelay = 5000;
            tt.InitialDelay = 1000;
            tt.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tt.ShowAlways = true;
            SetToolTip(tt, ttText);
        }

        public TriggerCheckBox()
        {
            Margin = new Padding(7);
            //Click += TriggerCheckBox_Click;
        }

        public TriggerCheckBox(DocumentType type, Printer printer) : this()
        {
            init(type, printer);
        }

        //void TriggerCheckBox_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        printer.triggerSet(docType, Checked);
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
            // TriggerCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "TriggerCheckBox";
            this.Size = new System.Drawing.Size(56, 18);
            this.ResumeLayout(false);
        }
    }
}
