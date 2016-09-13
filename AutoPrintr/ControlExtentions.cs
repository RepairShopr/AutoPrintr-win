using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoPrintr.sharedCode
{
    public static class ControlExtentions
    {
        /// <summary>
        /// Call delegate via control.Invoke, if needed
        /// </summary>
        /// <param name="control">Control item/param>
        /// <param name="doit">Delegate to call</param>
        public static void InvokeIfNeeded(this Control control, Action doit)
        {
            if (control.InvokeRequired)
                control.Invoke(doit);
            else
                doit();
        }
        /// <summary>
        /// Call delegate via control.Invoke, if needed
        /// </summary>
        /// <typeparam name="T">Type of delegate argument</typeparam>
        /// <param name="control">Control item/param>
        /// <param name="doit">Delegate to call</param>
        /// <param name="arg">Delegate argument</param>
        public static void InvokeIfNeeded<T>(this Control control, Action<T> doit, T arg)
        {
            if (control.InvokeRequired)
                control.Invoke(doit, arg);
            else
                doit(arg);
        }
    }
}
