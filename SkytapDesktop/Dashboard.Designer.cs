namespace SkytapDesktop
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.cbRunOnStart = new System.Windows.Forms.CheckBox();
            this.btnUpdateHosts = new System.Windows.Forms.Button();
            this.txtHostsFile = new System.Windows.Forms.TextBox();
            this.lblHosts = new System.Windows.Forms.Label();
            this.dgvVms = new System.Windows.Forms.DataGridView();
            this.lblVMs = new System.Windows.Forms.Label();
            this.btnChangeState = new System.Windows.Forms.Button();
            this.lblRunState = new System.Windows.Forms.Label();
            this.llblConfig = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblLoggedInAs = new System.Windows.Forms.ToolStripLabel();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.lbConfigurations = new System.Windows.Forms.ListBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblToken = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbConfigStatusTitle = new System.Windows.Forms.GroupBox();
            this.pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVms)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.gbConfigStatusTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.gbConfigStatusTitle);
            this.pnlDashboard.Controls.Add(this.btnRefresh);
            this.pnlDashboard.Controls.Add(this.cbRunOnStart);
            this.pnlDashboard.Controls.Add(this.btnUpdateHosts);
            this.pnlDashboard.Controls.Add(this.txtHostsFile);
            this.pnlDashboard.Controls.Add(this.lblHosts);
            this.pnlDashboard.Controls.Add(this.dgvVms);
            this.pnlDashboard.Controls.Add(this.lblVMs);
            this.pnlDashboard.Controls.Add(this.toolStrip1);
            this.pnlDashboard.Controls.Add(this.lbConfigurations);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(501, 670);
            this.pnlDashboard.TabIndex = 1;
            // 
            // cbRunOnStart
            // 
            this.cbRunOnStart.AutoSize = true;
            this.cbRunOnStart.Location = new System.Drawing.Point(16, 29);
            this.cbRunOnStart.Name = "cbRunOnStart";
            this.cbRunOnStart.Size = new System.Drawing.Size(136, 17);
            this.cbRunOnStart.TabIndex = 13;
            this.cbRunOnStart.Text = "Run this app on startup";
            this.cbRunOnStart.UseVisualStyleBackColor = true;
            this.cbRunOnStart.CheckedChanged += new System.EventHandler(this.cbRunOnStart_CheckedChanged);
            // 
            // btnUpdateHosts
            // 
            this.btnUpdateHosts.Location = new System.Drawing.Point(334, 635);
            this.btnUpdateHosts.Name = "btnUpdateHosts";
            this.btnUpdateHosts.Size = new System.Drawing.Size(144, 23);
            this.btnUpdateHosts.TabIndex = 12;
            this.btnUpdateHosts.Text = "Update Hosts File";
            this.btnUpdateHosts.UseVisualStyleBackColor = true;
            this.btnUpdateHosts.Click += new System.EventHandler(this.btnUpdateHosts_Click);
            // 
            // txtHostsFile
            // 
            this.txtHostsFile.Location = new System.Drawing.Point(22, 461);
            this.txtHostsFile.Multiline = true;
            this.txtHostsFile.Name = "txtHostsFile";
            this.txtHostsFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHostsFile.Size = new System.Drawing.Size(456, 168);
            this.txtHostsFile.TabIndex = 11;
            // 
            // lblHosts
            // 
            this.lblHosts.AutoSize = true;
            this.lblHosts.Location = new System.Drawing.Point(19, 444);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(53, 13);
            this.lblHosts.TabIndex = 10;
            this.lblHosts.Text = "Hosts File";
            // 
            // dgvVms
            // 
            this.dgvVms.AllowUserToAddRows = false;
            this.dgvVms.AllowUserToDeleteRows = false;
            this.dgvVms.AllowUserToOrderColumns = true;
            this.dgvVms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVms.Location = new System.Drawing.Point(19, 320);
            this.dgvVms.Name = "dgvVms";
            this.dgvVms.ReadOnly = true;
            this.dgvVms.Size = new System.Drawing.Size(459, 102);
            this.dgvVms.TabIndex = 9;
            // 
            // lblVMs
            // 
            this.lblVMs.AutoSize = true;
            this.lblVMs.Location = new System.Drawing.Point(16, 303);
            this.lblVMs.Name = "lblVMs";
            this.lblVMs.Size = new System.Drawing.Size(125, 13);
            this.lblVMs.TabIndex = 8;
            this.lblVMs.Text = "VMs in this configuration:";
            // 
            // btnChangeState
            // 
            this.btnChangeState.Location = new System.Drawing.Point(6, 34);
            this.btnChangeState.Name = "btnChangeState";
            this.btnChangeState.Size = new System.Drawing.Size(75, 23);
            this.btnChangeState.TabIndex = 7;
            this.btnChangeState.Text = "[change state]";
            this.btnChangeState.UseVisualStyleBackColor = true;
            this.btnChangeState.Visible = false;
            this.btnChangeState.Click += new System.EventHandler(this.btnChangeState_Click);
            // 
            // lblRunState
            // 
            this.lblRunState.AutoSize = true;
            this.lblRunState.Location = new System.Drawing.Point(87, 38);
            this.lblRunState.Name = "lblRunState";
            this.lblRunState.Size = new System.Drawing.Size(202, 13);
            this.lblRunState.TabIndex = 6;
            this.lblRunState.Text = "Please choose your default configuration.";
            // 
            // llblConfig
            // 
            this.llblConfig.AutoSize = true;
            this.llblConfig.Location = new System.Drawing.Point(11, 18);
            this.llblConfig.Name = "llblConfig";
            this.llblConfig.Size = new System.Drawing.Size(0, 13);
            this.llblConfig.TabIndex = 4;
            this.llblConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblConfig_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lblLoggedInAs,
            this.btnLogout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(501, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Logged In As:";
            // 
            // lblLoggedInAs
            // 
            this.lblLoggedInAs.Name = "lblLoggedInAs";
            this.lblLoggedInAs.Size = new System.Drawing.Size(37, 22);
            this.lblLoggedInAs.Text = "[user]";
            // 
            // btnLogout
            // 
            this.btnLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(49, 22);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lbConfigurations
            // 
            this.lbConfigurations.DisplayMember = "Name";
            this.lbConfigurations.FormattingEnabled = true;
            this.lbConfigurations.Location = new System.Drawing.Point(16, 146);
            this.lbConfigurations.Name = "lbConfigurations";
            this.lbConfigurations.Size = new System.Drawing.Size(462, 147);
            this.lbConfigurations.TabIndex = 1;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblToken);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.txtToken);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(501, 670);
            this.pnlLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(360, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(75, 74);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(41, 13);
            this.lblToken.TabIndex = 3;
            this.lblToken.Text = "Token:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(58, 37);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(122, 71);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(313, 20);
            this.txtToken.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(122, 34);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(313, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(403, 29);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbConfigStatusTitle
            // 
            this.gbConfigStatusTitle.Controls.Add(this.lblRunState);
            this.gbConfigStatusTitle.Controls.Add(this.btnChangeState);
            this.gbConfigStatusTitle.Controls.Add(this.llblConfig);
            this.gbConfigStatusTitle.Location = new System.Drawing.Point(16, 74);
            this.gbConfigStatusTitle.Name = "gbConfigStatusTitle";
            this.gbConfigStatusTitle.Size = new System.Drawing.Size(462, 61);
            this.gbConfigStatusTitle.TabIndex = 15;
            this.gbConfigStatusTitle.TabStop = false;
            this.gbConfigStatusTitle.Text = "My Configuration";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 670);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Text = "Skytap Desktop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Resize += new System.EventHandler(this.Dashboard_Resize);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVms)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.gbConfigStatusTitle.ResumeLayout(false);
            this.gbConfigStatusTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ListBox lbConfigurations;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblLoggedInAs;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.LinkLabel llblConfig;
        private System.Windows.Forms.Label lblRunState;
        private System.Windows.Forms.Button btnChangeState;
        private System.Windows.Forms.DataGridView dgvVms;
        private System.Windows.Forms.Label lblVMs;
        private System.Windows.Forms.Button btnUpdateHosts;
        private System.Windows.Forms.TextBox txtHostsFile;
        private System.Windows.Forms.Label lblHosts;
        private System.Windows.Forms.CheckBox cbRunOnStart;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbConfigStatusTitle;



    }
}

