using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PusherClient;
using System.Threading;
using System.Reflection;
using NLog;
using System.Diagnostics;
using System.Web;


 //Log levels:
 // - Fatal
 // - Error
 // - Warn
 // - Info
 // - Debug
 // - Trace

namespace AutoPrintr
{
    public partial class mainWin : Form
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
       
        const string mailto = "help@repairshopr.com";
        const string subject = "Support request from AutoPrintr";
        const string userMessageTemplate = "Hi!\n\nI'm user of AutoPrintr and need help.\n<My problem is...>\n\nHere the last 100 lines of AutoPrintr log file:\n\n";
        const int lastLinesOfLog = 100;
        const int pusherReconnectDelay = 20000;
       

        List<RegisterDD> registersDD = new List<RegisterDD>();
        public mainWin()
        {
            Printers.init();

            log.Info("Removing temp files...");
            Jobs.clearFiles();

            log.Info("GUI Initialization start...");
            InitializeComponent();

            log.Info("Loading config start...");
            Program.config = new Config(err =>
            {
                log.Error(err, "Config loading error.");
            });
            
            log.Info("Login tab initialization start...");
            configTabInit();

            log.Info("Priters tab initialization start...");
            createPrintersUI();

            log.Info("Log tab initialization start...");
            logTabInit();

            log.Info("Setting application version in UI...");
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            versionLabel.Text = "RepairShopr AutoPrintr - v." + version;

            log.Info("Cheking config for saved credentials...");
            if (Program.config.channel.Length == 0)
            {
                tabs.SelectTab("loginTab");
            }

            licenseText.Text = getLicenseText();

            trayIcon.Click += trayIcon_Click;

            this.Shown += mainWin_Shown;
            this.Resize += mainWin_Resize;

            WinAutoSize.apply(this, new Control[]{printersTable, jobsTable.table});
        }

        void trayIcon_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        void onLogChange(object o, EventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                logTextBox.Text = LogWatcher.text;
            }));
        }

        void mainWin_Shown(object sender, EventArgs e)
        {
            log.Info("LogWatcher starting...");
            LogWatcher.onChange = onLogChange;
            LogWatcher.init();

            log.Info("Cheking config for saved credentials...");
            if (Program.config.channel.Length > 0)
            {
                srvConnect(Program.config.channel);
                statusLogin.Text = "logged in";
            }

            if (Program.config.login.Length > 0)
            {
                login.Text = Program.config.login;
            }

            log.Info("Skin initialization...");
            Skins.load();
            
            if (Program.config.locations != null)
            {
                updateLocations(Program.config.availableLocations);
            }

            log.Info("Application started...");
        }


        // -------------------------------------------------------------------
        // Status bar code
        public void setStatus(string str)
        {
            statusServer.Text = str;
        }
        public delegate void setStatusCb(string str);



        // -------------------------------------------------------------------
        /// <summary>
        /// Generate printers UI
        /// </summary>
        public void createPrintersUI()
        {
            printersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            
            try
            {
                Printers.get();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error while loading printers local config. Config will be wiped. Error is: " + e1.Message.ToString());
                try
                {
                    Program.config.save();
                    Printers.get();
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Great Scott! Unexpected error was expected and catched. Application will exit. Error is:" + e2.Message.ToString());
                    Application.Exit();
                }
            }

            // Clear column styles (in other case columns will have wrong width)
            printersTable.ColumnStyles.Clear();
            // Printers table header
            // Adding first column header
            printersTable.Controls.Add(new tabelLabel("Printers:"), 0, 0);

            int column = 1;
            foreach (Printer p in Program.config.printers)
            {
                printersTable.ColumnCount++;
                printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                // Printer label
                printersTable.Controls.Add(new pLabel(p), column++, 0);

                // Printer qty
                //printersTable.ColumnCount++;
                //printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                //column++;
            }

            printersTable.RowStyles.Clear();
            printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            int row = 1;
            column = 0;
            printersTable.RowCount++;
            printersTable.Controls.Add(new tabelLabel("Documents"), column++, row);
            foreach (Printer p in Program.config.printers)
            {
                printersTable.Controls.Add(new tabelLabel("Enabled | Quantity | Print from triggers"), column++, row);
            }

            foreach (DocumentType type in DocumentTypes.list)
            {
                column = 0;
                printersTable.RowCount++;
                printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                // Add header label
                printersTable.Controls.Add(new tabelLabel(type.title), column++, ++row);
                foreach (Printer p in Program.config.printers)
                {
                    printersTable.Controls.Add(new PrinterDocumentControl(type, p), column, row);
                    column++;
                }
            }

            column = 0;
            printersTable.RowCount++;
            printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            printersTable.Controls.Add(new tabelLabel("Print method"), column++, ++row);
            foreach (Printer p in Program.config.printers)
            {
                printersTable.Controls.Add(new PrintEngineDD(p), column++, row);
            }

            column = 0;
            printersTable.RowCount++;
            printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            printersTable.Controls.Add(new tabelLabel("Register"), column++, ++row);
            RegisterDD rdd;
            foreach (Printer p in Program.config.printers)
            {
                rdd = new RegisterDD(p, Program.config.registers);
                registersDD.Add(rdd);
                printersTable.Controls.Add(rdd, column++, row);
            }

            //
            // Adding rest columns and headers
            //int column = 1;
            //foreach (PrintType type in PrintTypes.list)
            //{
            //    // Add colmn
            //    printersTable.ColumnCount++;
            //    // Set column style
            //    printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            //    // Add header label
            //    printersTable.Controls.Add(new tabelLabel(type.title), column++, 0);
            //}

            //// Adding rows
            //int row = 1;

            //foreach (Printer p in Program.config.printers)
            //{
            //    // Row creating
            //    printersTable.RowCount++;
            //    printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //    // Printer label
            //    printersTable.Controls.Add(new pLabel(p), 0, row);
            //    // Prnter checkboxes
            //    column = 1;
            //    foreach (PrintType t in PrintTypes.list)
            //    {
            //        printersTable.Controls.Add(new pCheckBox(t.type, p) { }, column, row);
            //    }
            //    row++; 
            //}
            
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //MessageBox.Show(Path.GetTempPath());
        }



        // -------------------------------------------------------------------
        /// <summary>
        /// Server connect
        /// </summary>
        public void srvConnect(string channel)
        {
            log.Info("Connecting to jobs server...");
            List<Listener> msgWrokers = new List<Listener> {
                Jobs.init(channel,  (ex, job) =>
                {
                    log.Info("New print job event. Job is: {0}", job);
                    jobsTable.add(job);
                })
            };

            Action<PusherException> onError = (err) =>
            {
                log.Error("Pusher error: {0}", err);
            };

            Action<String> onStateChanged = (state) =>
            {
                Invoke(new setStatusCb(this.setStatus), new object[] { state });
                log.Info("Pusher state changed to: {0}", state);
                switch (state)
                {
                    case "disconnected":
                        log.Warn("Pusher state is disconnected");
                        break;
                    case "unavailable":
                        Thread.Sleep(pusherReconnectDelay);
                        srvConnect(channel);
                        log.Warn("Pusher state is unavailable. Reconnecting in {0} seconds.", pusherReconnectDelay / 1000);
                        break;
                    default:
                        break;
                }
            };
            JobsServer.connect(msgWrokers, onError, onStateChanged);
        }



        // -------------------------------------------------------------------
        /// <summary>
        /// Configuration tab initialization
        /// </summary>
        public void configTabInit()
        {
            // Login section
            login.TextChanged += loginPass_TextChanged;
            password.TextChanged += loginPass_TextChanged;

            // Other section
            configSave.Click += saveConfig_Click;
            //locationList.Text = WinPrintr.Properties.Settings.Default.Location;
            //pusherKey.Text = WinPrintr.Properties.Settings.Default.PucherKey;
            //pusherKey.Text = Program.config.serverKey;
            configSaveStatus.Text = "config loaded";

            locationsList.SelectedChanged += config_TextChanged;
            //pusherKey.TextChanged += config_TextChanged;
        }

        void config_TextChanged(object sender, EventArgs e)
        {
            if (!configSave.Enabled)
            {
                configSave.Enabled = true;
            }
            configSaveStatus.Text = "config changed";
        }

        void saveConfig_Click(object sender, EventArgs e)
        {
            //saveConfig.Enabled = false; 

            //Program.config.location = locationsList.SelectedItems.Cast<ListViewItem>(
                //).Select( i => LoginServer.locations[i.Text] ).ToList();

            Program.config.locations =
                locationsList.Selected.Cast<CheckBoxListItem>().Select(
                    i => ((Location)i.userData).id
                ).ToList();
            //Program.config.locations =
            //    locationsList.Selected.Cast<CheckBoxListItem>().Select(
            //        i => (Location)i.userData
            //    ).ToList();
            //Program.config.serverKey = pusherKey.Text;
            Program.config.save();
            configSaveStatus.Text = "config saved";
            loginTab.Focus();
            configSave.Enabled = false;
        }

        void loginPass_TextChanged(object sender, EventArgs e)
        {
            loginPassCheck();
        }

        void loginPassCheck()
        {
            if (login.Text.Length > 3 & password.Text.Length > 3)
            {
                if (!submit.Enabled)
                {
                    submit.Enabled = true;
                }                
            }
            else
            {
                if (submit.Enabled)
                {
                    loginTab.Focus();
                    submit.Enabled = false;
                }                
            }
        }

        /// <summary>
        /// Login button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void submit_Click(object sender, EventArgs ev)
        {
            log.Info("Submit click event");
            if (Credentials.SrvXT == null || Credentials.SrvXT.Length == 0)
            {
                MessageBox.Show("Jobs server API key is empty - can't connect to jobs server.");
                return;
            }

            loginTab.Focus();
            login.Enabled = false;
            password.Enabled = false;
            submit.Enabled = false;
            LoginResponse resp = null;

            log.Info("Connecting to login server...");
            try
            {
                resp = LoginServer.login(login.Text, password.Text);
            }
            catch (Exception err)
            {
                log.Error(err, "Login error.");
            }

            if (resp != null)
            {
                statusLogin.Text = "logged in";
                if (LoginServer.locations != null)
                {
                    Program.config.locations = updateLocations(LoginServer.locations, LoginServer.defaultLocation);
                }

                // Registers
                foreach (LoginServer.Register r in LoginServer.registers)
                {
                    Program.config.registers.Add(r);
                }

                foreach (RegisterDD rdd in registersDD)
                {
                    rdd.setItems(Program.config.registers);
                }

                Program.config.login = login.Text;
                Program.config.channel = LoginServer.channel;
                Program.config.availableLocations = LoginServer.locations;
                Program.config.save();
                configSave.Enabled = false;
                srvConnect(LoginServer.channel);
            }
            else
            {
                log.Error("Login error: empty response");
            }

            login.Enabled = true;
            password.Enabled = true;
            submit.Enabled = true;
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
                string.Join( "\n", LogWatcher.text.Split('\n').Reverse().Take(lastLinesOfLog).ToArray() ) + 
                "\n\n\nconfig.json\n\n" + Program.config.ToString()
            ;

            Process.Start(
                String.Format(
                    "mailto:{0}?subject={1}&body={2}",
                    mailto,
                    subject,
                    HttpUtility.UrlEncode( body )
                )
            );
        }

        List<int> updateLocations(List<Location> locations, Location defaultLocation = null)
        {
            locationsList.clear();
            //locationsList.Contr
            // Check for setting the default location
            //bool checkForDedault = (LoginServer.defaultLocation != null) & (Program.config.locations.Count == 0);
            bool checkForDedault = (defaultLocation != null) & (Program.config.locations.Count == 0);
            List<int> locs = new List<int>();

            foreach (Location loc in locations)
            {
                CheckBoxListItem item = locationsList.add(loc.name, loc);
                if (checkForDedault)
                {
                    if (defaultLocation.id == loc.id)
                    {
                        item.Selected = true;
                        if ( !locs.Exists( i => i == loc.id))
                        {
                            locs.Add(loc.id);
                        }
                    }
                }                
                foreach (int id in Program.config.locations)
                {
                    if (id == loc.id)
                    {
                        item.Selected = true;
                        if ( !locs.Exists(i => i == loc.id))
                        {
                            locs.Add(loc.id);
                        }
                    }
                }
                
            }
            return locs;
        }

        void logTabInit()
        {
            foreach (string logLevel in LogConfig.LogLevels)
            {
                logLevelSelect.Items.Add(logLevel);
            }
            //MessageBox.Show("Log level:" + LogConfig.logLevel());
            logLevelSelect.Text = LogConfig.logLevel();
            logLevelSelect.SelectedValueChanged += logLevelSelect_SelectedValueChanged;
        }

        void logLevelSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            LogConfig.logLevel(logLevelSelect.Text);
        }

        string getLicenseText()
        {
            return String.Format(
                "The MIT License (MIT)\n\nCopyright (c) {0} RepairShopr \n\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: \n\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. \n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.\n"
                , DateTime.Now.Year.ToString()
            );
        }

        /// <summary>
        /// Tray icon in minimize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWin_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                trayIcon.Visible = true;
                trayIcon.ShowBalloonTip(1000);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                trayIcon.Visible = false;
            }
        }


        //protected override void OnSizeChanged(EventArgs e)
        //{

        //    if (this.Handle != null)
        //    {

        //        this.BeginInvoke((MethodInvoker)delegate
        //        {

        //            base.OnSizeChanged(e);

        //        });

        //    }

        //}
    }
}
