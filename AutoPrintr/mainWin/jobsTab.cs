using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoPrintr
{
    public partial class mainWin
    {
        void jobsTabInit()
        {
            log.Info("Removing temp files...");
            Jobs.clearFiles();
        }
    }
}
