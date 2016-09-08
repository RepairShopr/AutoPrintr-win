using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutoPrintr
{
    public partial class mainWin
    {
        const string serviceName = "AutoPrintrService";
        const string serviceExe = "AutoPrintrService.exe";
        
        /// <summary>
        /// Configuration tab initialization
        /// </summary>
        public void configTabInit()
        {
            if (!ServiceControl.isInstalled(serviceName))
            {
                Process p = Process.Start(new ProcessStartInfo() { 
                    FileName = serviceExe,
                    Arguments = "/i",                
                    WindowStyle = ProcessWindowStyle.Hidden
                });
                p.WaitForExit(30000);
            }
            bool srvState = ServiceControl.isRunning(serviceName);
            //bool srvState = true;
            Console.WriteLine("srvState " + srvState);
            Program.isService = srvState;
            serviceEnabledCheckBox.Checked = srvState;
            serviceEnabledCheckBox.Enabled = true;
            serviceEnabledCheckBox.CheckedChanged += serviceCheckBox_CheckedChanged;

            // Login section
            loginInput.TextChanged += loginPass_TextChanged;
            passwordInput.TextChanged += loginPass_TextChanged;
            
            // Service section
            usernameInput.Text = Program.config.serviceLogin;
            passwordInputService.Text = "";
            domainInput.Text = Program.config.serviceDomain;
            loadUserProfileCheckBox.Checked = Program.config.loadUserProfile;

            //configSave.Click += saveConfig_Click;

            //configSaveStatus.Text = "config loaded";

            //locationsList.SelectedChanged += config_TextChanged;

            log.Info("Cheking config for saved credentials...");
            if (Program.config.channel.Length == 0)
            {
                tabs.SelectTab("loginTab");
            }
            else
            {
                Console.WriteLine("configTabInit srvConnect()");
                srvConnect(Program.config.channel);
            }
            loginSetState();

            locationsList.SelectedChanged += locationsList_SelectedChanged;

            serviceSaveBtn.Click += serviceSaveBtn_Click;
            serviceTestBtn.Click += serviceTestBtn_Click;
            loadUserProfileCheckBox.CheckedChanged += loadUserProfileCheckBox_CheckedChanged;
        }

        void loadUserProfileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.config.loadUserProfile = loadUserProfileCheckBox.Checked;
            Program.config.save();
        }

        void serviceTestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var pass = passwordInputService.Text;
                //if ((pass.Length == 0) && (Program.config.servicePass != null) && (Program.config.servicePass.Length > 0))
                //{
                //    pass = tools.Decrypt(Program.config.servicePass);
                //}
                Process.Start(
                    "calc.exe",
                    usernameInput.Text,
                    tools.secureString(pass),
                    domainInput.Text
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test error:\n" + ex.Message);
            }
        }

        void serviceSaveBtn_Click(object sender, EventArgs e)
        {            
            Program.config.serviceLogin = usernameInput.Text;
            Program.config.servicePass = tools.Encrypt(passwordInputService.Text);
            Program.config.serviceDomain = domainInput.Text;
            Program.config.loadUserProfile = loadUserProfileCheckBox.Checked;
            Program.config.save();
        }

        void serviceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.isService = serviceEnabledCheckBox.Checked;
            service(serviceEnabledCheckBox.Checked);
        }

        bool isLoggedIn(){
            return Program.config.channel.Length > 0;
        }

        public void loginSetState()
        {
            if (isLoggedIn())
            {
                //srvConnect(Program.config.channel);
                statusLogin.Text = "logged in";
                submit.Text = "Logout";
                submit.Enabled = true;
            } else {
                statusLogin.Text = "not logged";
                submit.Text = "Login";
            }

            if (Program.config.login.Length > 0)
            {
                loginInput.Text = Program.config.login;
            }
        }

        void locationsList_SelectedChanged(object sender, EventArgs e)
        {
            Program.config.locations =
                locationsList.Selected.Cast<CheckBoxListItem>().Select(
                    i => ((Location)i.userData).id
                ).ToList();
            Program.config.save();
        }

        void config_TextChanged(object sender, EventArgs e)
        {
            //if (!configSave.Enabled)
            //{
            //    configSave.Enabled = true;
            //}
            //configSaveStatus.Text = "config changed";
        }

        //void saveConfig_Click(object sender, EventArgs e)
        //{
        //    //saveConfig.Enabled = false; 

        //    //Program.config.locations =
        //    //    locationsList.Selected.Cast<CheckBoxListItem>().Select(
        //    //        i => ((Location)i.userData).id
        //    //    ).ToList();

        //    Program.config.save();
        //    configSaveStatus.Text = "config saved";
        //    loginTab.Focus();
        //    configSave.Enabled = false;
        //}

        void loginPass_TextChanged(object sender, EventArgs e)
        {
            loginPassCheck();
        }

        void loginPassCheck()
        {
            if (loginInput.Text.Length > 0 & passwordInput.Text.Length > 0)
            {
                if (!submit.Enabled)
                {
                    submit.Enabled = true;
                }
            }
            else
            {
                if (submit.Enabled & !isLoggedIn())
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

            if (isLoggedIn())
            {
                JobsServer.disconnect();
                Program.config.channel = "";
                Program.config.login = "";
                Program.config.save();
                loginInput.Text = "";
                passwordInput.Text = "";
                loginSetState();
                return;
            }

            loginTab.Focus();
            loginInput.Enabled = false;
            passwordInput.Enabled = false;
            submit.Enabled = false;
            LoginResponse resp = null;

            log.Info("Connecting to login server...");
            try
            {
                resp = LoginServer.login(loginInput.Text, passwordInput.Text);
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
                Registers.Add(LoginServer.registers);
                //foreach (Register r in LoginServer.registers)
                //{
                //    Registers.Add(r);
                //}

                foreach (RegisterDD rdd in registersDD)
                {
                    rdd.setItems(Program.config.registers);
                }

                Program.config.login = loginInput.Text;
                Program.config.channel = LoginServer.channel;
                Program.config.availableLocations = LoginServer.locations;
                Program.config.save();
                //configSave.Enabled = false;
                srvConnect(LoginServer.channel);
            }
            else
            {
                log.Error("Login error: empty response");
            }

            loginInput.Enabled = true;
            passwordInput.Enabled = true;
            //submit.Enabled = true;
            loginSetState();
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


        public void service(bool state)
        {
            //bool installed = ServiceControl.isInstalled(serviceName);
            //if (!ServiceControl.isInstalled(serviceName))
            //{                
            //    
            //}

            if (state)
            {
                try
                {
                    ServiceControl.start(serviceName, 5000);
                    JobsServer.disconnect();
                    if (Program.config.channel.Length > 0)
                    {
                        srvConnect(Program.config.channel);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex, "Error while starting service");
                    serviceEnabledCheckBox.Checked = false;
                }
            }
            else
            {
                try
                {
                    ServiceControl.stop(serviceName, 5000);
                    if (Program.config.channel.Length > 0)
                    {
                        srvConnect(Program.config.channel);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex, "Error while stopping service");
                    serviceEnabledCheckBox.Checked = true;
                }
            }
        }


    }
}
