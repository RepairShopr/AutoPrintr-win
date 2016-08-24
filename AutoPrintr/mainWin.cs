using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PusherClient;
using System.Threading;
using NLog;

namespace AutoPrintr
{
    public partial class mainWin : Form
    {
        public static Logger Log = LogManager.GetLogger("WinPrintr"); 
        
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
        }


        // -------------------------------------------------------------------
        // Status bar code
        void mainWin_Shown(object sender, EventArgs e)
        {
            //srvConnect();
        }
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
            printersTable.Controls.Add(new tabelLabel("Printer"), 0, 0);
            // Clear column styles (in other case columns will have wrong widht)
            printersTable.ColumnStyles.Clear();

            // Adding rest columns and headers
            int column = 1;
            foreach (PrintType type in PrintTypes.list)
            {
                // Add colmn
                printersTable.ColumnCount++;
                // Set column style
                printersTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                // Add header label
                printersTable.Controls.Add(new tabelLabel(type.title), column++, 0);
            }

            // Adding rows
            int row = 1;
            
            //foreach (Printer p in Printers.list)
            foreach (Printer p in Program.config.printers)
            {
                // Row creating
                printersTable.RowCount++;
                printersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                // Printer label
                printersTable.Controls.Add(new pLabel(p), 0, row);
                // Prnter checkboxes
                column = 1;
                foreach (PrintType t in PrintTypes.list)
                {
                    printersTable.Controls.Add(new pCheckBox(t.type, p) { }, column, row);
                }
                row++; 
            }

            //itemsList.add("test 1");
            //itemsList.add("test 2");
            //itemsList.add("test 3");
            //itemsList.add("test 4");
            //itemsList.add("test 5");
            //itemsList.add("test 6");
            //itemsList.add("test 7");
        }



        // -------------------------------------------------------------------
        /// <summary>
        /// Server connect
        /// </summary>
        public void srvConnect()
        {
            List<Listener> msgWrokers = new List<Listener> {
                Jobs.init("test_channel",  (ex, job) =>
                {
                    if (Program.config.location.Exists(i => i == job.location))
                    {
                        if (ex == null)
                        {
                            MessageBox.Show("New job: " + job.ToString());
                            Log.Info("New job: " + job.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Job wrong format: " + job.ToString());
                            Log.Error("Job wrong format: " + ex.ToString());
                        }
                    }
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

            Srv.connect(msgWrokers, onError, onStateChanged);
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
            pusherKey.Text = Program.config.serverKey;
            configSaveStatus.Text = "config loaded";

            locationsList.SelectedChanged += config_TextChanged;
            pusherKey.TextChanged += config_TextChanged;
        }

        void config_TextChanged(object sender, EventArgs e)
        {
            saveConfig.Enabled = true;
            configSaveStatus.Text = "config changed";
        }

        void saveConfig_Click(object sender, EventArgs e)
        {
            //saveConfig.Enabled = false; 

            //Program.config.location = locationsList.SelectedItems.Cast<ListViewItem>(
                //).Select( i => LoginServer.locations[i.Text] ).ToList();

            Program.config.location = 
                locationsList.Selected.Cast<CBListItem>().Select(
                    i => ((Location)i.userData).id
                ).ToList();
            Program.config.serverKey = pusherKey.Text;
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
                submit.Enabled = true;
            }
            else
            {
                settingsTab.Focus();
                submit.Enabled = false;
            }
        }

        private void submit_Click(object sender, EventArgs ev)
        {
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
            }           

            if (resp != null)
            {
                statusLogin.Text = "logged in";
                if (LoginServer.locationsArr != null)
                {
                    locationsList.Items.Clear();
                    bool selectDefault = Program.config.location.Count == 0;
                    foreach (Location loc in LoginServer.locationsArr)
                    {
                        CBListItem item = locationsList.add(loc.name, loc);
                        if (selectDefault & LoginServer.defaultLocation.id == loc.id)
                        {
                            item.Selected = true;
                        }
                        foreach (int n in Program.config.location)
                        {
                            if (n == loc.id) {
                                item.Selected = true;
                            }
                        }
                    }                
                }
                srvConnect();
            }

            login.Enabled = true;
            password.Enabled = true;
            submit.Enabled = true;
        }
    }
}
