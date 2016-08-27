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
    public partial class JobsList : UserControl
    {
        public Dictionary<int, JLJob> items = new Dictionary<int, JLJob>();

        void update(JLJob ji, Job j)
        {
            ji.update(j);
        }
        delegate void updateCb(JLJob ji, Job j);


        void addJobControls(JLJob ji)
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.Controls.Add(ji.lIndex, 0, ji.row);
            table.Controls.Add(ji.lFile, 1, ji.row);
            table.Controls.Add(ji.lState, 2, ji.row);
            table.Controls.Add(ji.lProgress, 3, ji.row);
            table.Controls.Add(ji.lRecived, 4, ji.row);
            table.Controls.Add(ji.lType, 5, ji.row);
            table.Controls.Add(ji.lDocument, 6, ji.row);
            table.Controls.Add(ji.lPrinters, 7, ji.row);
            table.Controls.Add(ji.lUrl, 8, ji.row);
        }
        public delegate void addJobControlsCb(JLJob ji);

        public void add(Job j)
        {
            int row = table.RowCount;
            JLJob ji = new JLJob(j, row, items.Count);

            if (InvokeRequired)
            {
                Invoke(new addJobControlsCb(this.addJobControls), new object[] { ji });
            }
            else
            {
                addJobControls(ji);
            }

            j.onChange += (object sender, Job job) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new updateCb(this.update), new object[] { ji, j });
                }
                else
                {
                    update(ji, j);
                }
            };

            items.Add(row, ji);
        }

        void addColumn(string text)
        {
            table.ColumnCount++;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.Controls.Add(new JLHeaderLabel(text), table.ColumnCount-1, 0);
        }

        public JobsList()
        {
            InitializeComponent();
            table.RowStyles.Clear();
            table.Controls.Add(new JLHeaderLabel("№"), 0, 0);
            addColumn("File");
            addColumn("State");
            addColumn("Progress");
            addColumn("Recived");
            addColumn("Type");
            addColumn("Document");
            addColumn("Printers");
            addColumn("Url");
        }

        public class JLJob : Job
        {
            public Job job;
            public int row;
            public int index;
            public JLLabel lIndex;
            public JLLabel lFile;
            public JLLabel lState;
            public JLLabel lProgress;
            public JLLabel lRecived;
            public JLLabel lType;
            public JLLabel lDocument;
            public JLLabel lPrinters;
            public JLLabel lUrl;

            public JLJob(Job j, int row, int index)
            {
                job = j;
                this.row = row;
                this.index = index;
                lIndex = new JLLabel(index.ToString());
                lFile = new JLLabel(j.documentName);
                lState = new JLLabel(j.state.ToString());
                lProgress = new JLLabel(j.progress.ToString()+"%");
                lRecived = new JLLabel(Util.BytesToString(j.recived));
                lType = new JLLabel(j.type);
                lDocument = new JLLabel(j.documentTitle);
                lPrinters = new JLLabel(string.Join<Printer>(",", j.printers.ToArray()));
                lUrl = new JLLabel(j.file);
            }

            public void update(Job j)
            {
                //lFile.Text = j.documentName.ToString();
                lState.Text = j.state.ToString();
                lProgress.Text = j.progress.ToString() + "%";
                lRecived.Text = Util.BytesToString(j.recived);
            }

        }


        public class JLLabel : Label
        {
            //public Job job;
            //public JLLabel(string text, Job j)
            public JLLabel(string text)
            {
                AutoEllipsis = true;
                Text = text;
                Padding = new Padding(3, 5, 3, 0);
                Margin = new Padding(0, 0, 0, 0);
                Dock = DockStyle.Fill;

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

        public class JLHeaderLabel : Label
        {
            public JLHeaderLabel(string text)
            {
                Text = text;
                Padding = new Padding(3, 5, 3, 0);
                Margin = new Padding(0, 0, 0, 0);
            }
        }
    }
}
