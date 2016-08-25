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
            this.tabs = new System.Windows.Forms.TabControl();
            this.printersTab = new System.Windows.Forms.TabPage();
            this.printersTable = new System.Windows.Forms.TableLayoutPanel();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.saveConfig = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pusherKey = new System.Windows.Forms.TextBox();
            this.pusherLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSeparator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.configSaveStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.locationsList = new AutoPrintr.CheckBoxList();
            this.checkBoxList1 = new AutoPrintr.CheckBoxList();
            this.tabs.SuspendLayout();
            this.printersTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.printersTab);
            this.tabs.Controls.Add(this.settingsTab);
            this.tabs.Location = new System.Drawing.Point(1, 1);
            this.tabs.Margin = new System.Windows.Forms.Padding(1);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(0, 0);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1081, 252);
            this.tabs.TabIndex = 0;
            // 
            // printersTab
            // 
            this.printersTab.AutoScroll = true;
            this.printersTab.Controls.Add(this.printersTable);
            this.printersTab.Location = new System.Drawing.Point(4, 22);
            this.printersTab.Name = "printersTab";
            this.printersTab.Padding = new System.Windows.Forms.Padding(3);
            this.printersTab.Size = new System.Drawing.Size(1073, 226);
            this.printersTab.TabIndex = 0;
            this.printersTab.Text = "Printers";
            this.printersTab.UseVisualStyleBackColor = true;
            // 
            // printersTable
            // 
            this.printersTable.AutoScroll = true;
            this.printersTable.AutoSize = true;
            this.printersTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.printersTable.ColumnCount = 1;
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.printersTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.printersTable.Location = new System.Drawing.Point(3, 3);
            this.printersTable.Name = "printersTable";
            this.printersTable.RowCount = 1;
            this.printersTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.printersTable.Size = new System.Drawing.Size(1067, 2);
            this.printersTable.TabIndex = 0;
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.saveConfig);
            this.settingsTab.Controls.Add(this.groupBox3);
            this.settingsTab.Controls.Add(this.groupBox2);
            this.settingsTab.Controls.Add(this.groupBox1);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(1073, 226);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Setting";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // saveConfig
            // 
            this.saveConfig.Enabled = false;
            this.saveConfig.Location = new System.Drawing.Point(3, 197);
            this.saveConfig.Name = "saveConfig";
            this.saveConfig.Size = new System.Drawing.Size(80, 23);
            this.saveConfig.TabIndex = 5;
            this.saveConfig.Text = "Save";
            this.saveConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.locationsList);
            this.groupBox3.Location = new System.Drawing.Point(287, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 118);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Location";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pusherKey);
            this.groupBox2.Controls.Add(this.pusherLabel);
            this.groupBox2.Location = new System.Drawing.Point(492, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 117);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // pusherKey
            // 
            this.pusherKey.Location = new System.Drawing.Point(88, 13);
            this.pusherKey.Name = "pusherKey";
            this.pusherKey.Size = new System.Drawing.Size(185, 20);
            this.pusherKey.TabIndex = 5;
            // 
            // pusherLabel
            // 
            this.pusherLabel.AutoSize = true;
            this.pusherLabel.Location = new System.Drawing.Point(6, 16);
            this.pusherLabel.Name = "pusherLabel";
            this.pusherLabel.Size = new System.Drawing.Size(60, 13);
            this.pusherLabel.TabIndex = 6;
            this.pusherLabel.Text = "Pusher key";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loginLabel);
            this.groupBox1.Controls.Add(this.submit);
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.passwordLabel);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 118);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(6, 22);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(36, 13);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Login:";
            // 
            // submit
            // 
            this.submit.Enabled = false;
            this.submit.Location = new System.Drawing.Point(6, 80);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(261, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "Login";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(82, 19);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(185, 20);
            this.login.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(6, 48);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(82, 45);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(185, 20);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
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
            this.statusStrip.Location = new System.Drawing.Point(0, 254);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1082, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 17);
            this.statusLabel.Text = "Status:";
            // 
            // statusServer
            // 
            this.statusServer.Name = "statusServer";
            this.statusServer.Size = new System.Drawing.Size(84, 17);
            this.statusServer.Text = "not connected";
            // 
            // statusSeparator1
            // 
            this.statusSeparator1.Name = "statusSeparator1";
            this.statusSeparator1.Size = new System.Drawing.Size(10, 17);
            this.statusSeparator1.Text = "|";
            // 
            // statusLogin
            // 
            this.statusLogin.Name = "statusLogin";
            this.statusLogin.Size = new System.Drawing.Size(65, 17);
            this.statusLogin.Text = "not logged";
            // 
            // statusSeparator2
            // 
            this.statusSeparator2.Name = "statusSeparator2";
            this.statusSeparator2.Size = new System.Drawing.Size(10, 17);
            this.statusSeparator2.Text = "|";
            // 
            // configSaveStatus
            // 
            this.configSaveStatus.Name = "configSaveStatus";
            this.configSaveStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // locationsList
            // 
            this.locationsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationsList.AutoScroll = true;
            this.locationsList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.locationsList.Location = new System.Drawing.Point(6, 14);
            this.locationsList.MinimumSize = new System.Drawing.Size(20, 20);
            this.locationsList.Name = "locationsList";
            this.locationsList.Size = new System.Drawing.Size(187, 98);
            this.locationsList.TabIndex = 0;
            // 
            // checkBoxList1
            // 
            this.checkBoxList1.AutoScroll = true;
            this.checkBoxList1.AutoSize = true;
            this.checkBoxList1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.checkBoxList1.Location = new System.Drawing.Point(0, 0);
            this.checkBoxList1.MinimumSize = new System.Drawing.Size(20, 20);
            this.checkBoxList1.Name = "checkBoxList1";
            this.checkBoxList1.Size = new System.Drawing.Size(200, 150);
            this.checkBoxList1.TabIndex = 0;
            // 
            // mainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1082, 276);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabs);
            this.Name = "mainWin";
            this.Text = "AutoPrintr";
            this.tabs.ResumeLayout(false);
            this.printersTab.ResumeLayout(false);
            this.printersTab.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.MaskedTextBox password;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TabPage printersTab;
        private System.Windows.Forms.TableLayoutPanel printersTable;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusServer;
        private System.Windows.Forms.ToolStripStatusLabel statusLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox pusherKey;
        private System.Windows.Forms.Label pusherLabel;
        private System.Windows.Forms.Button saveConfig;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel configSaveStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private CheckBoxList checkBoxList1;
        private CheckBoxList locationsList;
    }
}

