using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoPrintr
{
    public partial class mainWin
    {
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

            log.Info("Cheking config for saved credentials...");
            if (Program.config.channel.Length == 0)
            {
                tabs.SelectTab("loginTab");
            }
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
                foreach (Register r in LoginServer.registers)
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
        /// Render locations
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="defaultLocation"></param>
        /// <returns></returns>
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
                        if (!locs.Exists(i => i == loc.id))
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
                        if (!locs.Exists(i => i == loc.id))
                        {
                            locs.Add(loc.id);
                        }
                    }
                }

            }
            return locs;
        }
    }
}
