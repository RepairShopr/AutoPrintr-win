using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintr
{
    public partial class mainWin
    {
        /// <summary>
        /// Set status string
        /// </summary>
        /// <param name="str"></param>
        public void setStatus(string str)
        {
            statusServer.Text = str;
        }
        /// <summary>
        /// Delegate for settin status string
        /// </summary>
        /// <param name="str"></param>
        public delegate void setStatusCb(string str);

    }
}
