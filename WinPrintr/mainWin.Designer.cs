namespace WinPrintr
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
            this.loginTab = new System.Windows.Forms.TabPage();
            this.submit = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.MaskedTextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.printersTab = new System.Windows.Forms.TabPage();
            this.printersTable = new System.Windows.Forms.TableLayoutPanel();
            this.labelPrinter = new System.Windows.Forms.Label();
            this.labelFullSize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.printersTab.SuspendLayout();
            this.printersTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.printersTab);
            this.tabs.Controls.Add(this.loginTab);
            this.tabs.Location = new System.Drawing.Point(1, 1);
            this.tabs.Margin = new System.Windows.Forms.Padding(1);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(0, 0);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(475, 263);
            this.tabs.TabIndex = 0;
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.submit);
            this.loginTab.Controls.Add(this.password);
            this.loginTab.Controls.Add(this.passwordLabel);
            this.loginTab.Controls.Add(this.login);
            this.loginTab.Controls.Add(this.loginLabel);
            this.loginTab.Location = new System.Drawing.Point(4, 22);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(3);
            this.loginTab.Size = new System.Drawing.Size(467, 237);
            this.loginTab.TabIndex = 1;
            this.loginTab.Text = "Login";
            this.loginTab.UseVisualStyleBackColor = true;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(19, 81);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(276, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "Login";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(134, 43);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(161, 20);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(16, 46);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(134, 11);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(161, 20);
            this.login.TabIndex = 1;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(16, 14);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(36, 13);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Login:";
            // 
            // printersTab
            // 
            this.printersTab.Controls.Add(this.printersTable);
            this.printersTab.Location = new System.Drawing.Point(4, 22);
            this.printersTab.Name = "printersTab";
            this.printersTab.Padding = new System.Windows.Forms.Padding(3);
            this.printersTab.Size = new System.Drawing.Size(467, 237);
            this.printersTab.TabIndex = 0;
            this.printersTab.Text = "Printers";
            this.printersTab.UseVisualStyleBackColor = true;
            // 
            // printersTable
            // 
            this.printersTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printersTable.AutoSize = true;
            this.printersTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.printersTable.ColumnCount = 4;
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.printersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.printersTable.Controls.Add(this.labelPrinter, 0, 0);
            this.printersTable.Controls.Add(this.labelFullSize, 1, 0);
            this.printersTable.Controls.Add(this.label3, 2, 0);
            this.printersTable.Controls.Add(this.label4, 3, 0);
            this.printersTable.Location = new System.Drawing.Point(7, 6);
            this.printersTable.Name = "printersTable";
            this.printersTable.RowCount = 1;
            this.printersTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.printersTable.Size = new System.Drawing.Size(446, 23);
            this.printersTable.TabIndex = 0;
            // 
            // labelPrinter
            // 
            this.labelPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrinter.AutoSize = true;
            this.labelPrinter.Location = new System.Drawing.Point(5, 5);
            this.labelPrinter.Margin = new System.Windows.Forms.Padding(5);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(37, 13);
            this.labelPrinter.TabIndex = 0;
            this.labelPrinter.Text = "Printer";
            // 
            // labelFullSize
            // 
            this.labelFullSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFullSize.AutoSize = true;
            this.labelFullSize.Location = new System.Drawing.Point(52, 5);
            this.labelFullSize.Margin = new System.Windows.Forms.Padding(5);
            this.labelFullSize.Name = "labelFullSize";
            this.labelFullSize.Size = new System.Drawing.Size(110, 13);
            this.labelFullSize.TabIndex = 1;
            this.labelFullSize.Text = "Full Size (Letter or A4)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Receipt 80mm";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Label (Address label size, 1.3\" x 3\" ~)";
            // 
            // mainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 264);
            this.Controls.Add(this.tabs);
            this.Name = "mainWin";
            this.Text = "Win Printr";
            this.tabs.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.printersTab.ResumeLayout(false);
            this.printersTab.PerformLayout();
            this.printersTable.ResumeLayout(false);
            this.printersTable.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel printersTable;
        private System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.Label labelFullSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

