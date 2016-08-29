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

namespace AutoPrintr
{
    public partial class mainWin : Form
    {        
        static Logger log = LogManager.GetLogger("WinPrintr"); 
        const string mailto = "help@repairshopr.com";
        const string subject = "Support request from AutoPrintr";
        const string body = "last 100 lines from log and full configuration dump";
            
        public mainWin()
        {
            InitializeComponent();
            Program.config = new Config(err =>
            {
                MessageBox.Show(err.ToString());
            });
            configTabInit();
            createPrintersUI();
            this.Shown += mainWin_Shown;
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            versionLabel.Text = "RepairShopr AutoPrintr - v." + version;

            //System.Windows.
        }

        void mainWin_Shown(object sender, EventArgs e)
        {
            //srvConnect();
            //JobsList.init();
            if (Program.config.channel.Length > 0)
            {
                srvConnect(Program.config.channel);
                statusLogin.Text = "logged in";
            }

            if (Program.config.login.Length > 0)
            {
                login.Text = Program.config.login;
            }

            // Jobs list initialization
            //jobsList.setColumns(new Dictionary<string, string>()
            //{
            //    {"documentName", "File"},
            //    {"state", "State"},
            //    {"progress", "Progress"},
            //    {"recived", "Recived"},
            //    {"type", "Type"},
            //    {"document", "Document"}
            //});            
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
                Printers.init();
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

            // Printers table header
            // Adding first column header
            printersTable.Controls.Add(new tabelLabel(), 0, 0);
            // Clear column styles (in other case columns will have wrong width)
            printersTable.ColumnStyles.Clear();

            int column = 1;
            foreach (Printer p in Program.config.printers)
            {
                printersTable.ColumnCount++;
                printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                // Printer label
                printersTable.Controls.Add(new pLabel(p), column++, 0);
            }


            int row = 0;
            foreach (DocumentType type in DocumentTypes.list)
            {
                column = 0;
                printersTable.RowCount++;
                printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                // Add header label
                printersTable.Controls.Add(new tabelLabel(type.title), column++, ++row);
                foreach (Printer p in Program.config.printers)
                {
                    printersTable.Controls.Add(new pCheckBox(type, p), column++, row);
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
            List<Listener> msgWrokers = new List<Listener> {
                Jobs.init(channel,  (ex, job) =>
                {
                    jobsList.add(job);
                    //if (Program.config.location.Exists(i => i == job.location))
                    //{
                    //    if (ex == null)
                    //    {
                    //        //MessageBox.Show("New job: " + job.ToString());
                    //        Log.Info("New job: " + job.ToString());
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Job wrong format: " + job.ToString());
                    //        Log.Error("Job wrong format: " + ex.ToString());
                    //    }
                    //}
                })
            };

            Action<PusherException> onError = (err) =>
            {
                MessageBox.Show(err.ToString());
                //Log.Info("Server error: " + err.ToString());
                //log.Text += "Server error: " + err.ToString() + "\r\n";
            };

            Action<String> onStateChanged = (state) =>
            {
                //statusText.Text = state;
                Invoke(new setStatusCb(this.setStatus), new object[] { state });
                //Log.Info("Server change state: " + state);
                //log.Text += "Server change state: " + state + "\r\n";
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
            saveConfig.Click += saveConfig_Click;
            //locationList.Text = WinPrintr.Properties.Settings.Default.Location;
            //pusherKey.Text = WinPrintr.Properties.Settings.Default.PucherKey;
            //pusherKey.Text = Program.config.serverKey;
            configSaveStatus.Text = "config loaded";

            locationsList.SelectedChanged += config_TextChanged;
            //pusherKey.TextChanged += config_TextChanged;
        }

        void config_TextChanged(object sender, EventArgs e)
        {
            if (!saveConfig.Enabled)
            {
                saveConfig.Enabled = true;
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
            //Program.config.serverKey = pusherKey.Text;
            Program.config.save();
            configSaveStatus.Text = "config saved";
            settingsTab.Focus();
            saveConfig.Enabled = false;
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
                    settingsTab.Focus();
                    submit.Enabled = false;
                }                
            }
        }

        private void submit_Click(object sender, EventArgs ev)
        {
            if (Credentials.SrvXT == null || Credentials.SrvXT.Length == 0)
            {
                MessageBox.Show("Jobs server API key is empty - can't connect to jobs server.");
                return;
            }

            settingsTab.Focus();
            login.Enabled = false;
            password.Enabled = false;
            submit.Enabled = false;
            LoginResponse resp = null;
            try
            {
                resp = LoginServer.login(login.Text, password.Text);
            }
            catch (Exception err)
            {
                //Log.Error("Login error: {0}", err.ToString());
                MessageBox.Show("Login error: " + err.Message);
                //MessageBox.Show("Login error: " + err.ToString());
            }

            if (resp != null)
            {
                statusLogin.Text = "logged in";
                if (LoginServer.locationsArr != null)
                {
                    locationsList.Items.Clear();

                    // Check for setting the default location
                    bool checkForDedault = (LoginServer.defaultLocation != null) & (Program.config.locations.Count == 0);
                    foreach (Location loc in LoginServer.locationsArr)
                    {
                        CheckBoxListItem item = locationsList.add(loc.name, loc);
                        if (checkForDedault)
                        {
                            if (LoginServer.defaultLocation.id == loc.id)
                            {
                                item.Selected = true;
                            }                                                   
                        }
                        foreach (int n in Program.config.locations)
                        {
                            if (n == loc.id) {
                                item.Selected = true;

                            }
                        }
                    }                
                }

                Program.config.login = login.Text;
                Program.config.channel = LoginServer.channel;
                Program.config.save();
                saveConfig.Enabled = false;
                srvConnect(LoginServer.channel);
            }

            login.Enabled = true;
            password.Enabled = true;
            submit.Enabled = true;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {            
            Process.Start(
                String.Format(
                    "mailto:{0}?subject={1}&body={2}",
                    mailto,
                    subject,
                    body
                )
            );
        }       
    }
}
