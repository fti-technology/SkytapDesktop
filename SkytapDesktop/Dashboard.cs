using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SkytapApi;

namespace SkytapDesktop
{
    public partial class Dashboard : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private Icon skytapIcon;
        private Icon skytapSuspendedIcon;
        private Icon skytapStoppedIcon;
        private Icon skytapRunningIcon;
        

        public Dashboard()
        {
            // set up a 5 minute timer to check for idle
            var idleTimer = new System.Timers.Timer(300000);
            idleTimer.Elapsed += IdleTimerEvent;
            idleTimer.AutoReset = true;
            idleTimer.Enabled = true;
            skytapIcon = new Icon("icons\\skytap.ico");
            skytapSuspendedIcon = new Icon("icons\\skytap-suspended.ico");
            skytapStoppedIcon = new Icon("icons\\skytap-suspended.ico");
            skytapRunningIcon = new Icon("icons\\skytap-running.ico");
            InitializeComponent();
            AddTrayIcon();
            if (string.IsNullOrEmpty(Properties.Settings.Default.Username))
            {
                pnlDashboard.Hide();
                pnlLogin.Show();
            }
            else
            {
                lblLoggedInAs.Text = Properties.Settings.Default.Username;

                DoLogin();
                pnlDashboard.Show();
                pnlLogin.Hide();
                TryLoadDefaultConfig();
            }
        }

        private void IdleTimerEvent(object sender, ElapsedEventArgs e)
        {
            // This number (GetIdleTickCount()) will only rise if there is no user activity on this machine
            // so if it is close to 0, and our config is running, go ahead a keep the config alive.
            if (Program.DefaultConfiguration.RunState == "running" && WindowsUtilities.GetIdleTickCount() < 500)
            {
                Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
                Program.DefaultConfiguration = client.GetConfiguration(Program.DefaultConfiguration.Id);
            }
        }

        private void TryLoadDefaultConfig()
        {
            if (Properties.Settings.Default.DefaultConfigId > 0)
            {
                var selectedConfig =
                    Program.Configurations.Single(x => x.Id == Properties.Settings.Default.DefaultConfigId);
                var index = lbConfigurations.FindString(selectedConfig.Name);
                if (index > 0)
                {
                    lbConfigurations.SetSelected(index, true);
                }
            }
        }

        public void AddTrayIcon()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "SkyTap Desktop";
            trayIcon.BalloonTipTitle = "SkyTap Desktop minimizes to the taskbar";
            trayIcon.BalloonTipText = "Click to change your default configuration.  Right click to take actions on your default configuration.";
            trayIcon.Icon = skytapIcon;

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = false;
            trayIcon.Click += trayIcon_Click;
            trayIcon.DoubleClick += trayIcon_Click;
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(500);
            this.Hide();
        }

        void trayIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = txtUsername.Text;
            Properties.Settings.Default.Token = txtToken.Text;
            Properties.Settings.Default.Save();
            DoLogin();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = "";
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.DefaultConfigId = -1;
            Properties.Settings.Default.Save();
            pnlLogin.Show();

            // clear out data first then:
            pnlDashboard.Hide();
        }

        private void lbConfigurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDefaultConfig();
        }

        private void DoLogin()
        {
            // go ahead and try to get the configurations here and if successful save user/token

            try
            {
                Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
                Program.Configurations = client.GetConfigurations().OrderBy(x => x.Name).ToList();
                lbConfigurations.DataSource = Program.Configurations;
                lbConfigurations.SelectedIndex = -1;
                lbConfigurations.SelectedIndexChanged += lbConfigurations_SelectedIndexChanged;
                SetDefaultConfig();
                lblLoggedInAs.Text = Properties.Settings.Default.Username;
                pnlLogin.Hide();
                pnlDashboard.Show();
            }
            catch (Exception ex)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Token = "";
                Properties.Settings.Default.Save();
                throw ex;
            }

            // else show error
        }

        private void SetDefaultConfig()
        {
            var selectedConfig = lbConfigurations.SelectedItem as Configuration;
            if (selectedConfig != null)
            {
                llblConfig.Text = selectedConfig.Name;
                Properties.Settings.Default.DefaultConfigId = selectedConfig.Id;
                Properties.Settings.Default.Save();
                Program.DefaultConfiguration = selectedConfig;
                LinkLabel.Link link = new LinkLabel.Link();
                link.LinkData = selectedConfig.Url;
                llblConfig.Links.Clear();
                llblConfig.Links.Add(link);
                SetDefaultConfigState();
            }
            else
            {
                llblConfig.Text = "";
                llblConfig.Links.Clear();
            }
        }

        private void SetDefaultConfigState()
        {
            try
            {
                Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
                Program.DefaultConfiguration = client.GetConfiguration(Program.DefaultConfiguration.Id);
                switch (Program.DefaultConfiguration.RunState)
                {
                    case "running":
                        btnChangeState.Text = "Suspend";
                        trayIcon.Icon = skytapRunningIcon;
                        break;
                    case "suspended":
                        btnChangeState.Text = "Run";
                        trayIcon.Icon = skytapSuspendedIcon;
                        break;
                    case "stopped":
                        btnChangeState.Text = "Run";
                        trayIcon.Icon = skytapStoppedIcon;
                        break;
                    default:
                        break;
                }
                btnChangeState.Visible = true;
                var trayString = Program.DefaultConfiguration.RunState + " - " + Program.DefaultConfiguration.Name;
                if (trayString.Length > 64)
                {
                    trayString = trayString.Substring(0, 63);
                }
                trayIcon.Text = trayString;
                lblRunState.Text = Program.DefaultConfiguration.RunState;
            }
            catch (Exception ex)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Token = "";
                Properties.Settings.Default.Save();
                throw ex;
            }

        }

        private void llblConfig_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var configLink = e.Link.LinkData as string;
            Process.Start(configLink);
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
            switch (Program.DefaultConfiguration.RunState)
            {
                case "running":
                    lblRunState.Text = "Busy...";
                    btnChangeState.Text = "Busy";
                    btnChangeState.Enabled = false;
                    client.SetConfigurationState(Program.DefaultConfiguration.Id, "suspended");
                    break;
                case "suspended":
                    lblRunState.Text = "Busy...";
                    btnChangeState.Text = "Busy";
                    btnChangeState.Enabled = false;
                    client.SetConfigurationState(Program.DefaultConfiguration.Id, "running");
                    break;
                case "stopped":
                    lblRunState.Text = "Busy...";
                    btnChangeState.Text = "Busy";
                    btnChangeState.Enabled = false;
                    client.SetConfigurationState(Program.DefaultConfiguration.Id, "running");
                    break;
                default:
                    break;
            }
        }


    }
}
