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
            this.btnChangeState = new System.Windows.Forms.Button();
            this.lblRunState = new System.Windows.Forms.Label();
            this.lblConfigStateTitle = new System.Windows.Forms.Label();
            this.llblConfig = new System.Windows.Forms.LinkLabel();
            this.lblSelectedConfig = new System.Windows.Forms.Label();
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
            this.lblVMs = new System.Windows.Forms.Label();
            this.dgvVms = new System.Windows.Forms.DataGridView();
            this.pnlDashboard.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVms)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Controls.Add(this.dgvVms);
            this.pnlDashboard.Controls.Add(this.lblVMs);
            this.pnlDashboard.Controls.Add(this.btnChangeState);
            this.pnlDashboard.Controls.Add(this.lblRunState);
            this.pnlDashboard.Controls.Add(this.lblConfigStateTitle);
            this.pnlDashboard.Controls.Add(this.llblConfig);
            this.pnlDashboard.Controls.Add(this.lblSelectedConfig);
            this.pnlDashboard.Controls.Add(this.toolStrip1);
            this.pnlDashboard.Controls.Add(this.lbConfigurations);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(490, 454);
            this.pnlDashboard.TabIndex = 1;
            // 
            // btnChangeState
            // 
            this.btnChangeState.Location = new System.Drawing.Point(403, 69);
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
            this.lblRunState.Location = new System.Drawing.Point(162, 76);
            this.lblRunState.Name = "lblRunState";
            this.lblRunState.Size = new System.Drawing.Size(202, 13);
            this.lblRunState.TabIndex = 6;
            this.lblRunState.Text = "Please choose your default configuration.";
            // 
            // lblConfigStateTitle
            // 
            this.lblConfigStateTitle.AutoSize = true;
            this.lblConfigStateTitle.Location = new System.Drawing.Point(13, 76);
            this.lblConfigStateTitle.Name = "lblConfigStateTitle";
            this.lblConfigStateTitle.Size = new System.Drawing.Size(142, 13);
            this.lblConfigStateTitle.TabIndex = 5;
            this.lblConfigStateTitle.Text = "Current Configuration Status:";
            // 
            // llblConfig
            // 
            this.llblConfig.AutoSize = true;
            this.llblConfig.Location = new System.Drawing.Point(145, 55);
            this.llblConfig.Name = "llblConfig";
            this.llblConfig.Size = new System.Drawing.Size(0, 13);
            this.llblConfig.TabIndex = 4;
            this.llblConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblConfig_Click);
            // 
            // lblSelectedConfig
            // 
            this.lblSelectedConfig.AutoSize = true;
            this.lblSelectedConfig.Location = new System.Drawing.Point(13, 55);
            this.lblSelectedConfig.Name = "lblSelectedConfig";
            this.lblSelectedConfig.Size = new System.Drawing.Size(126, 13);
            this.lblSelectedConfig.TabIndex = 3;
            this.lblSelectedConfig.Text = "My Default Configuration:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lblLoggedInAs,
            this.btnLogout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(490, 25);
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
            this.lbConfigurations.Location = new System.Drawing.Point(16, 112);
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
            this.pnlLogin.Size = new System.Drawing.Size(490, 454);
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
            // lblVMs
            // 
            this.lblVMs.AutoSize = true;
            this.lblVMs.Location = new System.Drawing.Point(16, 279);
            this.lblVMs.Name = "lblVMs";
            this.lblVMs.Size = new System.Drawing.Size(125, 13);
            this.lblVMs.TabIndex = 8;
            this.lblVMs.Text = "VMs in this configuration:";
            // 
            // dgvVms
            // 
            this.dgvVms.AllowUserToAddRows = false;
            this.dgvVms.AllowUserToDeleteRows = false;
            this.dgvVms.AllowUserToOrderColumns = true;
            this.dgvVms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVms.Location = new System.Drawing.Point(19, 296);
            this.dgvVms.Name = "dgvVms";
            this.dgvVms.ReadOnly = true;
            this.dgvVms.Size = new System.Drawing.Size(459, 102);
            this.dgvVms.TabIndex = 9;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 454);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Text = "Skytap Desktop";
            this.Resize += new System.EventHandler(this.Dashboard_Resize);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVms)).EndInit();
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
        private System.Windows.Forms.Label lblSelectedConfig;
        private System.Windows.Forms.LinkLabel llblConfig;
        private System.Windows.Forms.Label lblConfigStateTitle;
        private System.Windows.Forms.Label lblRunState;
        private System.Windows.Forms.Button btnChangeState;
        private System.Windows.Forms.DataGridView dgvVms;
        private System.Windows.Forms.Label lblVMs;



    }
}

