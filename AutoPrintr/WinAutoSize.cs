using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace AutoPrintr
{
    /// <summary>
    /// Window resizer
    /// </summary>
    static class WinAutoSize
    {
        /// <summary>
        /// Calculate client position of control in window
        /// </summary>
        /// <param name="win"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        static Point getClientLocation(mainWin win, Control control)
        {
            Control c = control.Parent;
            Point loc = control.Location;
            while (c.Parent != win)
            {
                loc.X += c.Location.X + c.Margin.Left;
                loc.Y += c.Location.Y + c.Margin.Top;
                c = c.Parent;
            }
            return loc;
        }

        /// <summary>
        /// Resize window to fit content
        /// </summary>
        /// <param name="win"></param>
        /// <param name="controls"></param>
        public static void apply(mainWin win, Control[] controls)
        {
            int winW = win.Width
                , newW = 0
                , maxW = Screen.PrimaryScreen.WorkingArea.Width
                //, winH = win.Height
                //, newH = 0
                //, maxH = Screen.PrimaryScreen.WorkingArea.Height
            ;
            Point location;

            foreach (Control control in controls)
            {
                location = getClientLocation(win, control);
                newW = Math.Max(location.X * 2 + control.Width, newW);
                //newH = Math.Max(location.Y * 2 + control.Height, newH);
            }

            newW = Math.Min(newW, maxW);
            //newH = Math.Min(newH, maxH);
            win.ClientSize = new Size(newW, win.ClientSize.Height);
        }
    }
}
