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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWin));
            this.tabs = new System.Windows.Forms.TabControl();
            this.jobsTab = new System.Windows.Forms.TabPage();
            this.jobsTable = new AutoPrintr.JobsList();
            this.printersTab = new System.Windows.Forms.TabPage();
            this.printersTable = new System.Windows.Forms.TableLayoutPanel();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.serviceSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.autorunModeDD = new System.Windows.Forms.ComboBox();
            this.serviceSaveBtn = new System.Windows.Forms.Button();
            this.serviceTestBtn = new System.Windows.Forms.Button();
            this.passwordInputService = new System.Windows.Forms.MaskedTextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.domainInput = new System.Windows.Forms.TextBox();
            this.serviceUserLoginLabel = new System.Windows.Forms.Label();
            this.serviceUserPasswordLabel = new System.Windows.Forms.Label();
            this.serviceUserDomainLabel = new System.Windows.Forms.Label();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.locationsList = new AutoPrintr.CheckBoxList();
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.loginInput = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.MaskedTextBox();
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
            this.statusSeparatorUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.progressBarValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBoxList1 = new AutoPrintr.CheckBoxList();
            this.tabs.SuspendLayout();
            this.jobsTab.SuspendLayout();
            this.printersTab.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.serviceSettings.SuspendLayout();
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
            this.loginTab.Controls.Add(this.serviceSettings);
            this.loginTab.Controls.Add(this.locationGroupBox);
            this.loginTab.Controls.Add(this.loginGroupBox);
            resources.ApplyResources(this.loginTab, "loginTab");
            this.loginTab.Name = "loginTab";
            this.loginTab.UseVisualStyleBackColor = true;
            // 
            // serviceSettings
            // 
            this.serviceSettings.Controls.Add(this.label1);
            this.serviceSettings.Controls.Add(this.autorunModeDD);
            this.serviceSettings.Controls.Add(this.serviceSaveBtn);
            this.serviceSettings.Controls.Add(this.serviceTestBtn);
            this.serviceSettings.Controls.Add(this.passwordInputService);
            this.serviceSettings.Controls.Add(this.usernameInput);
            this.serviceSettings.Controls.Add(this.domainInput);
            this.serviceSettings.Controls.Add(this.serviceUserLoginLabel);
            this.serviceSettings.Controls.Add(this.serviceUserPasswordLabel);
            this.serviceSettings.Controls.Add(this.serviceUserDomainLabel);
            resources.ApplyResources(this.serviceSettings, "serviceSettings");
            this.serviceSettings.Name = "serviceSettings";
            this.serviceSettings.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // autorunModeDD
            // 
            this.autorunModeDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autorunModeDD.FormattingEnabled = true;
            resources.ApplyResources(this.autorunModeDD, "autorunModeDD");
            this.autorunModeDD.Name = "autorunModeDD";
            // 
            // serviceSaveBtn
            // 
            resources.ApplyResources(this.serviceSaveBtn, "serviceSaveBtn");
            this.serviceSaveBtn.Name = "serviceSaveBtn";
            this.serviceSaveBtn.UseVisualStyleBackColor = true;
            // 
            // serviceTestBtn
            // 
            resources.ApplyResources(this.serviceTestBtn, "serviceTestBtn");
            this.serviceTestBtn.Name = "serviceTestBtn";
            this.serviceTestBtn.UseVisualStyleBackColor = true;
            // 
            // passwordInputService
            // 
            resources.ApplyResources(this.passwordInputService, "passwordInputService");
            this.passwordInputService.Name = "passwordInputService";
            this.passwordInputService.UseSystemPasswordChar = true;
            // 
            // usernameInput
            // 
            resources.ApplyResources(this.usernameInput, "usernameInput");
            this.usernameInput.Name = "usernameInput";
            // 
            // domainInput
            // 
            resources.ApplyResources(this.domainInput, "domainInput");
            this.domainInput.Name = "domainInput";
            // 
            // serviceUserLoginLabel
            // 
            resources.ApplyResources(this.serviceUserLoginLabel, "serviceUserLoginLabel");
            this.serviceUserLoginLabel.Name = "serviceUserLoginLabel";
            // 
            // serviceUserPasswordLabel
            // 
            resources.ApplyResources(this.serviceUserPasswordLabel, "serviceUserPasswordLabel");
            this.serviceUserPasswordLabel.Name = "serviceUserPasswordLabel";
            // 
            // serviceUserDomainLabel
            // 
            resources.ApplyResources(this.serviceUserDomainLabel, "serviceUserDomainLabel");
            this.serviceUserDomainLabel.Name = "serviceUserDomainLabel";
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
            this.loginGroupBox.Controls.Add(this.loginInput);
            this.loginGroupBox.Controls.Add(this.passwordLabel);
            this.loginGroupBox.Controls.Add(this.passwordInput);
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
            // loginInput
            // 
            resources.ApplyResources(this.loginInput, "loginInput");
            this.loginInput.Name = "loginInput";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.Name = "passwordLabel";
            // 
            // passwordInput
            // 
            resources.ApplyResources(this.passwordInput, "passwordInput");
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.UseSystemPasswordChar = true;
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
            this.configSaveStatus,
            this.statusSeparatorUpdate,
            this.updateStatus,
            this.progressBar,
            this.progressBarValue});
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
            // statusSeparatorUpdate
            // 
            this.statusSeparatorUpdate.Name = "statusSeparatorUpdate";
            resources.ApplyResources(this.statusSeparatorUpdate, "statusSeparatorUpdate");
            // 
            // updateStatus
            // 
            this.updateStatus.Name = "updateStatus";
            resources.ApplyResources(this.updateStatus, "updateStatus");
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // progressBarValue
            // 
            this.progressBarValue.Name = "progressBarValue";
            resources.ApplyResources(this.progressBarValue, "progressBarValue");
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.trayIcon, "trayIcon");
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
            this.DoubleBuffered = true;
            this.Name = "mainWin";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.tabs.ResumeLayout(false);
            this.jobsTab.ResumeLayout(false);
            this.jobsTab.PerformLayout();
            this.printersTab.ResumeLayout(false);
            this.printersTab.PerformLayout();
            this.loginTab.ResumeLayout(false);
            this.serviceSettings.ResumeLayout(false);
            this.serviceSettings.PerformLayout();
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
        private System.Windows.Forms.MaskedTextBox passwordInput;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox loginInput;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TabPage printersTab;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusServer;
        private System.Windows.Forms.ToolStripStatusLabel statusLogin;
        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparator1;
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
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripStatusLabel updateStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel progressBarValue;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparatorUpdate;
        private System.Windows.Forms.GroupBox serviceSettings;
        private System.Windows.Forms.Button serviceTestBtn;
        private System.Windows.Forms.MaskedTextBox passwordInputService;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox domainInput;
        private System.Windows.Forms.Label serviceUserLoginLabel;
        private System.Windows.Forms.Label serviceUserPasswordLabel;
        private System.Windows.Forms.Label serviceUserDomainLabel;
        private System.Windows.Forms.Button serviceSaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox autorunModeDD;
    }
}

