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
    /// <summary>
    /// Jobs list UI control
    /// </summary>
    public partial class JobsList : UserControl
    {
        /// <summary>
        /// JobsList job list
        /// </summary>
        public Dictionary<int, UIJob> items = new Dictionary<int, UIJob>();

        /// <summary>
        /// Update job in UI
        /// </summary>
        /// <param name="uiJob"></param>
        /// <param name="j"></param>
        void update(UIJob uiJob, Job job)
        {
            uiJob.update(job);
            updateTableWidth();
        }

        /// <summary>
        /// Delegate for updating job in UI
        /// </summary>
        /// <param name="uiJob"></param>
        /// <param name="job"></param>
        delegate void updateCb(UIJob uiJob, Job job);

        /// <summary>
        /// List of jobs table header items
        /// </summary>
        public List<JLHeaderLabel> headerItems = new List<JLHeaderLabel>(){};

        /// <summary>
        /// Add controls for job
        /// </summary>
        /// <param name="uiJob"></param>
        void addJobControls(UIJob uiJob)
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            int column = 0;
            table.Controls.Add(uiJob.repeatBtn, column++, uiJob.row);
            table.Controls.Add(uiJob.lIndex,    column++, uiJob.row);
            table.Controls.Add(uiJob.lFile,     column++, uiJob.row);
            table.Controls.Add(uiJob.lQuantity, column++, uiJob.row);
            table.Controls.Add(uiJob.lState,    column++, uiJob.row);
            table.Controls.Add(uiJob.lProgress, column++, uiJob.row);
            table.Controls.Add(uiJob.lRecived,  column++, uiJob.row);
            //table.Controls.Add(uiJob.lType,     column++, uiJob.row);
            table.Controls.Add(uiJob.lDocument, column++, uiJob.row);
            table.Controls.Add(uiJob.lPrinter,  column++, uiJob.row);
            //table.Controls.Add(uiJob.lUrl,      column++, uiJob.row);

            updateTableWidth();
        }

        /// <summary>
        /// Delegate for adding controls for job in UI
        /// </summary>
        /// <param name="uiJob"></param>
        public delegate void addJobControlsCb(UIJob uiJob);

        /// <summary>
        /// Add job to UI
        /// </summary>
        /// <param name="job"></param>
        public void add(Job job)
        {
            // Get row number
            int row = table.RowCount;
            // Creating new UI Job
            UIJob uiJob = new UIJob(job, row, items.Count);

            if (InvokeRequired)
            {
                Invoke(new addJobControlsCb(this.addJobControls), new object[] { uiJob });
            }
            else
            {
                addJobControls(uiJob);
            }

            job.onChange += (object sender, Job evJob) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new updateCb(this.update), new object[] { uiJob, evJob });
                }
                else
                {
                    update(uiJob, evJob);
                }
            };

            items.Add(row, uiJob);            
        }

        /// <summary>
        /// Add column with selected name
        /// </summary>
        /// <param name="name"></param>
        void addColumn(string name)
        {
            JLHeaderLabel control = new JLHeaderLabel(name);
            table.ColumnCount++;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.Controls.Add(control, table.ColumnCount - 1, 0);
            control.Parent = table;
            headerItems.Add(control);
        }

        void updateTableWidth()
        {
            // Recalculate table items width
            int columns = table.ColumnCount
                , column = 0
                , w
            ;

            // Array for columns width
            int[] colw = Enumerable.Repeat(0, columns).ToArray();

            // For each control in table find most wide item
            foreach (Control control in table.Controls)
            {
                if (column == columns) { column = 0; }
                colw[column] = Math.Max(
                    control.Width, 
                    colw[column]
                ); 
                column++;
            }

            // And set each item width to same value
            column = 0;
            foreach (Control control in table.Controls)
            {
                if (column == columns) { column = 0; }
                w = colw[column];
                if (control.Width != w) { 
                    control.Width = w - control.Margin.Left - control.Margin.Right;
                }
                column++;
            }
        }


        /// <summary>
        /// Create new jobs list
        /// </summary>
        public JobsList()
        {
            InitializeComponent();
            table.RowStyles.Clear();
            table.Controls.Add(new JLHeaderLabel("Repeat printing"), 0, 0);
            addColumn("№");
            addColumn("File");
            addColumn("Quantity");
            addColumn("State");
            addColumn("Progress");
            addColumn("Recived");
            //addColumn("Type");
            addColumn("Document");
            addColumn("Printer");
            //addColumn("Url");
        }

        

        /// <summary>
        /// UI job class
        /// </summary>
        public class UIJob
        {
            public Job job;
            public int row;
            public int index;
            public JobsListLabel lIndex;
            public JobsListLabel lFile;
            public JobsListLabel lQuantity;
            public JobsListLabel lState;
            public JobsListLabel lProgress;
            public JobsListLabel lRecived;
            //public JobsListLabel lType;
            public JobsListLabel lDocument;
            public JobsListLabel lPrinter;
            //public JobsListLabel lUrl;
            public JLRepeatBtn repeatBtn;
            
            /// <summary>
            /// Create new UI job instance
            /// </summary>
            /// <param name="job"></param>
            /// <param name="row"></param>
            /// <param name="index"></param>
            public UIJob(Job job, int row, int index)
            {
                this.job = job;
                this.row = row;
                this.index = index;

                //foreach(Printer printer in job.printers){
                
                repeatBtn = new JLRepeatBtn(this);
                lIndex = new JobsListLabel(index.ToString());
                lFile = new JobsListLabel(job.localFileName);
                lQuantity = new JobsListLabel(job.quantity().ToString());
                lState = new JobsListLabel(job.state.ToString() + job.stateDetails);
                lProgress = new JobsListLabel(job.progress.ToString()+"%");
                lRecived = new JobsListLabel(tools.BytesToString(job.recived));
                //lType = new JobsListLabel(job.type);
                lDocument = new JobsListLabel(job.documentTitle);
                lPrinter = new JobsListLabel(job.printer.name);
                //lUrl = new JobsListLabel(job.file);

                //lPrinters = new JobsListLabel(string.Join<Printer>(",", job.printers.ToArray()));
                //foreach (Printer p in job.printers)
                //{
                //}

                //lPrinter = new JobsListLabel(
                //    string.Join(
                //        ",", 
                //        job.printers.Select( 
                //            p => p.name + "[" + p.quantity[job.document] + "]"
                //        ).ToArray()
                //    ) 
                //);
            }
            /// <summary>
            /// Update job in UI
            /// </summary>
            /// <param name="job"></param>
            public void update(Job job)
            {
                lState.Text = job.state.ToString() + job.stateDetails;
                lProgress.Text = job.progress.ToString() + "%";
                lRecived.Text = tools.BytesToString(job.recived);
            }
        }

        /// <summary>
        /// Label in JobsList
        /// </summary>
        public class JobsListLabel : Label
        {
            /// <summary>
            /// Create new label for jobs list
            /// </summary>
            /// <param name="text"></param>
            public JobsListLabel(string text)
            {
                //AutoEllipsis = true;
                Text = text;
                Padding = new Padding(5, 5, 5, 5);
                Margin = new Padding(0, 0, 0, 0);

                //AutoSize = true;
                //Anchor = AnchorStyles.None;
                //TextAlign = ContentAlignment.MiddleLeft;
                //Dock = DockStyle.Fill;

                AutoSize = true;
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                TextAlign = ContentAlignment.MiddleLeft;

                // Create the ToolTip and associate with the Form container.
                ToolTip tt = new ToolTip();
                // Set up the delays for the ToolTip.
                tt.AutoPopDelay = 5000;
                tt.InitialDelay = 1000;
                tt.ReshowDelay = 500;
                // Force the ToolTip text to be displayed whether or not the form is active.
                tt.ShowAlways = true;
                tt.SetToolTip(this, text);
            }
        }
        /// <summary>
        /// Label for JobsList header
        /// </summary>
        public class JLHeaderLabel : Label
        {
            /// <summary>
            /// Create new label for JobsList header
            /// </summary>
            /// <param name="text"></param>
            public JLHeaderLabel(string text)
            {
                Text = text;
                Padding = new Padding(3, 5, 3, 0);
                Margin = new Padding(0, 0, 0, 0);
            }
        }

        public class JLRepeatBtn : Button
        {
            public UIJob uijob;
            int cnt = 0;
            public JLRepeatBtn(UIJob job)
                : base()
            {
                this.uijob = job;
                Text = "Reprint";
                Click += JLRepeatBtn_Click;
                Margin = new Padding(5);
            }

            void JLRepeatBtn_Click(object sender, EventArgs e)
            {
                cnt++;
                Text = "Repeat (" + cnt + ")";
                uijob.job.print((err) => { });
            }
        }
    }
}
