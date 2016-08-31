namespace AutoPrintr
{
    partial class mainWin
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWin));
            this.tabs = new System.Windows.Forms.TabControl();
            this.jobsTab = new System.Windows.Forms.TabPage();
            this.jobsTable = new AutoPrintr.JobsList();
            this.printersTab = new System.Windows.Forms.TabPage();
            this.printersTable = new System.Windows.Forms.TableLayoutPanel();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.configSave = new System.Windows.Forms.Button();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.locationsList = new AutoPrintr.CheckBoxList();
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.MaskedTextBox();
            this.logTab = new System.Windows.Forms.TabPage();
            this.logLevelLabel = new System.Windows.Forms.Label();
            this.logLevelSelect = new System.Windows.Forms.ComboBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.licenseText = new System.Windows.Forms.RichTextBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.configSaveStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBoxList1 = new AutoPrintr.CheckBoxList();
            this.tabs.SuspendLayout();
            this.jobsTab.SuspendLayout();
            this.printersTab.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.locationGroupBox.SuspendLayout();
            this.loginGroupBox.SuspendLayout();
            this.logTab.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            resources.ApplyResources(this.tabs, "tabs");
            this.tabs.Controls.Add(this.jobsTab);
            this.tabs.Controls.Add(this.printersTab);
            this.tabs.Controls.Add(this.loginTab);
            this.tabs.Controls.Add(this.logTab);
            this.tabs.Controls.Add(this.aboutTab);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            // 
            // jobsTab
            // 
            resources.ApplyResources(this.jobsTab, "jobsTab");
            this.jobsTab.Controls.Add(this.jobsTable);
            this.jobsTab.Name = "jobsTab";
            this.jobsTab.UseVisualStyleBackColor = true;
            // 
            // jobsTable
            // 
            resources.ApplyResources(this.jobsTable, "jobsTable");
            this.jobsTable.BackColor = System.Drawing.Color.Transparent;
            this.jobsTable.Name = "jobsTable";
            // 
            // printersTab
            // 
            resources.ApplyResources(this.printersTab, "printersTab");
            this.printersTab.Controls.Add(this.printersTable);
            this.printersTab.Name = "printersTab";
            this.printersTab.UseVisualStyleBackColor = true;
            // 
            // printersTable
            // 
            resources.ApplyResources(this.printersTable, "printersTable");
            this.printersTable.Name = "printersTable";
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.configSave);
            this.loginTab.Controls.Add(this.locationGroupBox);
            this.loginTab.Controls.Add(this.loginGroupBox);
            resources.ApplyResources(this.loginTab, "loginTab");
            this.loginTab.Name = "loginTab";
            this.loginTab.UseVisualStyleBackColor = true;
            // 
            // configSave
            // 
            resources.ApplyResources(this.configSave, "configSave");
            this.configSave.Name = "configSave";
            this.configSave.UseVisualStyleBackColor = true;
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.Controls.Add(this.locationsList);
            resources.ApplyResources(this.locationGroupBox, "locationGroupBox");
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.TabStop = false;
            // 
            // locationsList
            // 
            resources.ApplyResources(this.locationsList, "locationsList");
            this.locationsList.Name = "locationsList";
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.loginLabel);
            this.loginGroupBox.Controls.Add(this.submit);
            this.loginGroupBox.Controls.Add(this.login);
            this.loginGroupBox.Controls.Add(this.passwordLabel);
            this.loginGroupBox.Controls.Add(this.password);
            resources.ApplyResources(this.loginGroupBox, "loginGroupBox");
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.TabStop = false;
            // 
            // loginLabel
            // 
            resources.ApplyResources(this.loginLabel, "loginLabel");
            this.loginLabel.Name = "loginLabel";
            // 
            // submit
            // 
            resources.ApplyResources(this.submit, "submit");
            this.submit.Name = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // login
            // 
            resources.ApplyResources(this.login, "login");
            this.login.Name = "login";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.Name = "passwordLabel";
            // 
            // password
            // 
            resources.ApplyResources(this.password, "password");
            this.password.Name = "password";
            this.password.UseSystemPasswordChar = true;
            // 
            // logTab
            // 
            resources.ApplyResources(this.logTab, "logTab");
            this.logTab.Controls.Add(this.logLevelLabel);
            this.logTab.Controls.Add(this.logLevelSelect);
            this.logTab.Controls.Add(this.logTextBox);
            this.logTab.Name = "logTab";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // logLevelLabel
            // 
            resources.ApplyResources(this.logLevelLabel, "logLevelLabel");
            this.logLevelLabel.Name = "logLevelLabel";
            // 
            // logLevelSelect
            // 
            this.logLevelSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logLevelSelect.FormattingEnabled = true;
            resources.ApplyResources(this.logLevelSelect, "logLevelSelect");
            this.logLevelSelect.Name = "logLevelSelect";
            // 
            // logTextBox
            // 
            resources.ApplyResources(this.logTextBox, "logTextBox");
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            // 
            // aboutTab
            // 
            this.aboutTab.BackColor = System.Drawing.Color.Transparent;
            this.aboutTab.Controls.Add(this.licenseText);
            this.aboutTab.Controls.Add(this.helpButton);
            this.aboutTab.Controls.Add(this.versionLabel);
            resources.ApplyResources(this.aboutTab, "aboutTab");
            this.aboutTab.Name = "aboutTab";
            // 
            // licenseText
            // 
            resources.ApplyResources(this.licenseText, "licenseText");
            this.licenseText.Name = "licenseText";
            this.licenseText.ReadOnly = true;
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusServer,
            this.statusSeparator1,
            this.statusLogin,
            this.statusSeparator2,
            this.configSaveStatus});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // statusServer
            // 
            this.statusServer.Name = "statusServer";
            resources.ApplyResources(this.statusServer, "statusServer");
            // 
            // statusSeparator1
            // 
            this.statusSeparator1.Name = "statusSeparator1";
            resources.ApplyResources(this.statusSeparator1, "statusSeparator1");
            // 
            // statusLogin
            // 
            this.statusLogin.Name = "statusLogin";
            resources.ApplyResources(this.statusLogin, "statusLogin");
            // 
            // statusSeparator2
            // 
            this.statusSeparator2.Name = "statusSeparator2";
            resources.ApplyResources(this.statusSeparator2, "statusSeparator2");
            // 
            // configSaveStatus
            // 
            this.configSaveStatus.Name = "configSaveStatus";
            resources.ApplyResources(this.configSaveStatus, "configSaveStatus");
            // 
            // checkBoxList1
            // 
            resources.ApplyResources(this.checkBoxList1, "checkBoxList1");
            this.checkBoxList1.Name = "checkBoxList1";
            // 
            // mainWin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabs);
            this.Name = "mainWin";
            this.tabs.ResumeLayout(false);
            this.jobsTab.ResumeLayout(false);
            this.jobsTab.PerformLayout();
            this.printersTab.ResumeLayout(false);
            this.printersTab.PerformLayout();
            this.loginTab.ResumeLayout(false);
            this.locationGroupBox.ResumeLayout(false);
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.logTab.ResumeLayout(false);
            this.logTab.PerformLayout();
            this.aboutTab.ResumeLayout(false);
            this.aboutTab.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage loginTab;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.MaskedTextBox password;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TabPage printersTab;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusServer;
        private System.Windows.Forms.ToolStripStatusLabel statusLogin;
        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparator1;
        private System.Windows.Forms.Button configSave;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel configSaveStatus;
        private System.Windows.Forms.GroupBox locationGroupBox;
        private CheckBoxList checkBoxList1;
        private CheckBoxList locationsList;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.TabPage jobsTab;
        private System.Windows.Forms.TabPage logTab;
        private JobsList jobsTable;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.TableLayoutPanel printersTable;
        private System.Windows.Forms.RichTextBox licenseText;
        private System.Windows.Forms.Label logLevelLabel;
        private System.Windows.Forms.ComboBox logLevelSelect;
    }
}

