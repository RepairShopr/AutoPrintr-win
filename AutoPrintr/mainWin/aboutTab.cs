using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;

namespace AutoPrintr
{
    public partial class mainWin
    {
        /// <summary>
        /// About tab initialization
        /// </summary>
        void aboutTabInit()
        {
            licenseText.Text = getLicenseText();
            versionLabel.Text = String.Format("RepairShopr AutoPrintr - v.{0}", tools.shortVersion);
        }
        
        /// <summary>
        /// Help button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_Click(object sender, EventArgs e)
        {
            log.Info("Help button pressed. Processing help request");
            //var body =
            //   String.Format( userMessageTemplate, "%0D%0A") +
            //   string.Join( "%0D%0A",
            //        LogWatcher.text.Split('\n').Reverse().Take(lastLinesOfLog).ToArray()
            //   ) 
            //   + "%0D%0A%0D%0A%0D%0Aconfig.json%0D%0A%0D%0A" +                
            //   string.Join( "%0D%0A",
            //        Program.config.ToString().Split('\n').Reverse().ToArray()
            //   )       
            //;

            var body = userMessageTemplate +
                "\n\n" +
                string.Join("\n", LogWatcher.text.Split('\n').Reverse().Take(lastLinesOfLog).ToArray()) +
                "\n\n\nconfig.json\n\n" + Program.config.ToString()
            ;

            Process.Start(
                String.Format(
                    "mailto:{0}?subject={1}&body={2}",
                    mailto,
                    subject,
                    HttpUtility.UrlEncode(body)
                )
            );
        }


        /// <summary>
        /// Return license text
        /// </summary>
        /// <returns>License string</returns>
        string getLicenseText()
        {
            return String.Format(
                "The MIT License (MIT)\n\nCopyright (c) {0} RepairShopr \n\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: \n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. \n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.\n"
                , DateTime.Now.Year.ToString()
            );
        }
    }
}
