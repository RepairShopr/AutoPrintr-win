﻿using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrintr
{
    public partial class mainWin
    {
        void trayIconInit()
        {
            trayIcon.Click += trayIcon_Click;
            Resize += mainWin_Resize;
        }


        void trayIconState(bool state)
        {
            if (state)
            {
                trayIcon.Visible = true;
                this.Hide();
            }
            else
            {
                trayIcon.Visible = false;
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        void trayIcon_Click(object sender, EventArgs e)
        {
            trayIconState(false);
            //trayIcon.Visible = false;
            //Show();
            //WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Minimize application to tray icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWin_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                //trayIcon.Visible = true;
                //this.Hide();
                trayIconState(true);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                trayIcon.Visible = false;
            }
        }

    }
}
