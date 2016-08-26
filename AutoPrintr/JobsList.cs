using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    //static class JobsList
    //{
    //    static List<jItem> items = new List<jItem>();
    //    static public void init()
    //    {
    //        Program.window.jobsList.ColumnStyles.Clear();
    //        Jobs.jobAdded += Jobs_jobAdded;
    //    }

    //    static void addJob(Job j)
    //    {
    //        var jlist = Program.window.jobsList;
    //        jlist.Controls.Add(new jItem(j), 0, jlist.RowCount++);
    //        jlist.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    //    }

    //    static delegate void addJobCB(Job j);

    //    static void Jobs_jobAdded(object sender, Job j)
    //    {
    //        Program.window.Invoke(new addJobCB(addJob), new object[] { j });
    //    }

    //    class jItem : Label
    //    {
    //        public Job job;
    //        public jItem(Job j)
    //        {
    //            Margin = new Padding(2, 3, 2, 0);
    //            Padding = new Padding(0);
    //            Text = j.ToString();
    //            job = j;
    //            items.Add(this);
    //            j.downloaded += j_downloaded;
    //            j.printed += j_printed;
    //        }

    //        void j_printed(object sender, Job j)
    //        {
    //            Text = j.ToString();
    //        }

    //        void j_downloaded(object sender, Job j)
    //        {
    //            Text = j.ToString();
    //        }
    //    }
    //}
    
}
