namespace WindowsTenPrivacy
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetPrivacy = new System.Windows.Forms.Button();
            this.rchtxtLogMessages = new System.Windows.Forms.RichTextBox();
            this.grpPrivacyOptions = new System.Windows.Forms.GroupBox();
            this.chkEtcHosts = new System.Windows.Forms.CheckBox();
            this.chkOneDrive = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkWindowsServices = new System.Windows.Forms.CheckBox();
            this.grpPrivacyOptions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetPrivacy
            // 
            this.btnGetPrivacy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetPrivacy.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetPrivacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPrivacy.Location = new System.Drawing.Point(3, 204);
            this.btnGetPrivacy.Name = "btnGetPrivacy";
            this.btnGetPrivacy.Size = new System.Drawing.Size(495, 108);
            this.btnGetPrivacy.TabIndex = 0;
            this.btnGetPrivacy.Text = "Get your privacy back";
            this.btnGetPrivacy.UseVisualStyleBackColor = false;
            this.btnGetPrivacy.Click += new System.EventHandler(this.btnGetPrivacy_Click);
            // 
            // rchtxtLogMessages
            // 
            this.rchtxtLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchtxtLogMessages.Location = new System.Drawing.Point(3, 16);
            this.rchtxtLogMessages.Name = "rchtxtLogMessages";
            this.rchtxtLogMessages.Size = new System.Drawing.Size(489, 103);
            this.rchtxtLogMessages.TabIndex = 2;
            this.rchtxtLogMessages.Text = "";
            this.rchtxtLogMessages.WordWrap = false;
            // 
            // grpPrivacyOptions
            // 
            this.grpPrivacyOptions.Controls.Add(this.chkWindowsServices);
            this.grpPrivacyOptions.Controls.Add(this.chkEtcHosts);
            this.grpPrivacyOptions.Controls.Add(this.chkOneDrive);
            this.grpPrivacyOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrivacyOptions.Location = new System.Drawing.Point(3, 3);
            this.grpPrivacyOptions.Name = "grpPrivacyOptions";
            this.grpPrivacyOptions.Size = new System.Drawing.Size(495, 195);
            this.grpPrivacyOptions.TabIndex = 3;
            this.grpPrivacyOptions.TabStop = false;
            this.grpPrivacyOptions.Text = "Privacy restoring options";
            // 
            // chkEtcHosts
            // 
            this.chkEtcHosts.AutoSize = true;
            this.chkEtcHosts.Checked = true;
            this.chkEtcHosts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEtcHosts.Location = new System.Drawing.Point(6, 42);
            this.chkEtcHosts.Name = "chkEtcHosts";
            this.chkEtcHosts.Size = new System.Drawing.Size(200, 17);
            this.chkEtcHosts.TabIndex = 1;
            this.chkEtcHosts.Tag = "EtcHosts";
            this.chkEtcHosts.Text = "Block tracking domains in /etc/hosts";
            this.chkEtcHosts.UseVisualStyleBackColor = true;
            // 
            // chkOneDrive
            // 
            this.chkOneDrive.AutoSize = true;
            this.chkOneDrive.Checked = true;
            this.chkOneDrive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOneDrive.Location = new System.Drawing.Point(6, 19);
            this.chkOneDrive.Name = "chkOneDrive";
            this.chkOneDrive.Size = new System.Drawing.Size(114, 17);
            this.chkOneDrive.TabIndex = 0;
            this.chkOneDrive.Tag = "OneDrive";
            this.chkOneDrive.Text = "Remove OneDrive";
            this.chkOneDrive.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(501, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rchtxtLogMessages);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 122);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Technical Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpPrivacyOptions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGetPrivacy, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.56883F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.76996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.66122F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(501, 443);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // chkWindowsServices
            // 
            this.chkWindowsServices.AutoSize = true;
            this.chkWindowsServices.Checked = true;
            this.chkWindowsServices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWindowsServices.Location = new System.Drawing.Point(6, 65);
            this.chkWindowsServices.Name = "chkWindowsServices";
            this.chkWindowsServices.Size = new System.Drawing.Size(191, 17);
            this.chkWindowsServices.TabIndex = 2;
            this.chkWindowsServices.Tag = "WindowsServices";
            this.chkWindowsServices.Text = "Disable relevant Windows services";
            this.chkWindowsServices.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 467);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows 10 Privacy";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpPrivacyOptions.ResumeLayout(false);
            this.grpPrivacyOptions.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetPrivacy;
        private System.Windows.Forms.RichTextBox rchtxtLogMessages;
        private System.Windows.Forms.GroupBox grpPrivacyOptions;
        private System.Windows.Forms.CheckBox chkOneDrive;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkEtcHosts;
        private System.Windows.Forms.CheckBox chkWindowsServices;
    }
}

