using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPrintr
{
    public partial class mainWin
    {
        /// <summary>
        /// Log tab initialization
        /// </summary>
        void logTabInit()
        {
            foreach (string logLevel in LogConfig.LogLevels)
            {
                logLevelSelect.Items.Add(logLevel);
            }
            //MessageBox.Show("Log level:" + LogConfig.logLevel());
            logLevelSelect.Text = LogConfig.logLevel();
            logLevelSelect.SelectedValueChanged += logLevelSelect_SelectedValueChanged;

            LogWatcher.onChange = onLogChange;
            LogWatcher.init();
        }

        /// <summary>
        /// Evevent handler for log change event
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void onLogChange(object o, EventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                logTextBox.Text = LogWatcher.text;
            }));
        }
        
        void logLevelSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            LogConfig.logLevel(logLevelSelect.Text);
        }
    }
}
