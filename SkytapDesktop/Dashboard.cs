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
using System.Windows.Forms;
using Microsoft.Win32;
using SkytapApi;

namespace SkytapDesktop
{
    public partial class Dashboard : Form
    {
        #region Private Variables

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private MenuItem configTitleMenuItem;
        private MenuItem stateChangeMenuItem;
        private MenuItem refreshState;
        private Icon skytapIcon;
        private Icon skytapSuspendedIcon;
        private Icon skytapStoppedIcon;
        private Icon skytapRunningIcon;
        private Icon skytapBusyIcon;
        private Timer monitorBusyTimer = new Timer();
        private const string CONFIG_STOPPED = "stopped";
        private const string CONFIG_SUSPENDED = "suspended";
        private const string CONFIG_RUNNING = "running";
        private const string HOSTFILE = @"C:\windows\system32\drivers\etc\hosts";
        private const string REGKEY = "SkytapDesktop";

        #endregion

        #region Constructor
        public Dashboard()
        {
            // set up a 5 minute timer to check for idle
            var idleTimer = new Timer();
            idleTimer.Interval = 300000;
            idleTimer.Tick += IdleTimerEvent;
            idleTimer.Enabled = true;
            skytapIcon = new Icon("icons\\skytap.ico");
            skytapSuspendedIcon = new Icon("icons\\skytap-suspended.ico");
            skytapStoppedIcon = new Icon("icons\\skytap-suspended.ico");
            skytapRunningIcon = new Icon("icons\\skytap-running.ico");
            skytapBusyIcon = new Icon("icons\\skytap-busy.ico");
            InitializeComponent();
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appPath = Application.ExecutablePath.ToString();

            cbRunOnStart.Checked = (rkApp.GetValue(REGKEY) == null);

            if (rkApp.GetValue(REGKEY) == null)
            {
                rkApp.SetValue(REGKEY, appPath);
            }
            else
            {
                rkApp.DeleteValue(REGKEY, false);
            } 
            AddTrayIcon();
            LoadHostsFile();
            RunningStateChanged += Dashboard_RunningStateChanged;
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
        #endregion

        #region Event Related

        public event EventHandler RunningStateChanged;

        protected virtual void OnRunningStateChanged(EventArgs e)
        {
            EventHandler handler = RunningStateChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        void Dashboard_RunningStateChanged(object sender, EventArgs e)
        {
            SetConfigStateUIElements();
        }

        private void OnTrayRefreshClick(object sender, EventArgs eventArgs)
        {
            SetOrRefreshConfig();
        }

        private void OnTrayStateChangeClick(object sender, EventArgs eventArgs)
        {
            ChangeRunningState();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(500);
            this.Hide();
        }


        void openForm(object sender, EventArgs e)
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
            configTitleMenuItem.Text = "No Configuration Chosen";
            stateChangeMenuItem.Visible = false;
            trayIcon.Text = "Skytap Desktop";
            trayIcon.Icon = skytapIcon;
            Program.DefaultConfiguration = new Configuration();
            pnlLogin.Show();

            // clear out data first then:
            pnlDashboard.Hide();
        }

        private void lbConfigurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOrRefreshConfig();
        }

        private void llblConfig_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var configLink = e.Link.LinkData as string;
            Process.Start(configLink);
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            ChangeRunningState();
        }


        private void MonitorBusyTimerEvent(object sender, EventArgs e)
        {
            Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
            Program.DefaultConfiguration = client.GetConfiguration(Program.DefaultConfiguration.Id);

            if (Program.DefaultConfiguration.RunState == CONFIG_RUNNING ||
                Program.DefaultConfiguration.RunState == CONFIG_STOPPED ||
                Program.DefaultConfiguration.RunState == CONFIG_SUSPENDED)
            {
                monitorBusyTimer.Enabled = false;
                OnRunningStateChanged(EventArgs.Empty);
            }
        }

        private void btnUpdateHosts_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(HOSTFILE, txtHostsFile.Text);
                MessageBox.Show("Host file Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to host file: " + ex.Message);
                throw;
            }
        }

        #endregion

        #region Private Methods

        private void LoadHostsFile()
        {
            try
            {
                var text = File.ReadAllText(HOSTFILE);
                txtHostsFile.Text = text;
            }
            catch (Exception)
            {
                txtHostsFile.Enabled = false;
                btnUpdateHosts.Enabled = false;
            }
        }
        
        private void IdleTimerEvent(object sender, EventArgs e)
        {
            // This number (GetIdleTickCount()) will only rise if there is no user activity on this machine
            // so if it is under 5 minutes (300M ticks), and our config is running, go ahead a keep the config alive.
            if (Program.DefaultConfiguration.RunState == "running" && WindowsUtilities.GetIdleTickCount() < 300000000)
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

        private void AddTrayIcon()
        {
            trayMenu = new ContextMenu();
            stateChangeMenuItem = new MenuItem("No Configuration Chosen", OnTrayStateChangeClick);
            stateChangeMenuItem.Visible = false;
            refreshState = new MenuItem("Refresh Current State", OnTrayRefreshClick);
            refreshState.Visible = false;
            configTitleMenuItem = new MenuItem("No Configuration Chosen", openForm);
            configTitleMenuItem.DefaultItem = true;
            trayMenu.MenuItems.Add(configTitleMenuItem);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(stateChangeMenuItem);
            trayMenu.MenuItems.Add(refreshState);
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
            trayIcon.Visible = true;
            trayIcon.Click += openForm;
            trayIcon.DoubleClick += openForm;
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
                SetOrRefreshConfig();
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

        private void SetOrRefreshConfig()
        {
            var selectedConfig = lbConfigurations.SelectedItem as Configuration;
            if (selectedConfig != null)
            {
                llblConfig.Text = selectedConfig.Name;
                configTitleMenuItem.Text = selectedConfig.Name;
                Properties.Settings.Default.DefaultConfigId = selectedConfig.Id;
                Properties.Settings.Default.Save();
                Program.DefaultConfiguration = selectedConfig;
                LinkLabel.Link link = new LinkLabel.Link();
                link.LinkData = selectedConfig.Url;
                llblConfig.Links.Clear();
                llblConfig.Links.Add(link);
                Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
                Program.DefaultConfiguration = client.GetConfiguration(Program.DefaultConfiguration.Id);
                client.HydrateIPs(Program.DefaultConfiguration);
                dgvVms.DataSource = Program.DefaultConfiguration.VMs;
                OnRunningStateChanged(EventArgs.Empty);
            }
            else
            {
                llblConfig.Text = "";
                llblConfig.Links.Clear();
            }
        }

        private void SetConfigStateUIElements()
        {
            try
            {
                switch (Program.DefaultConfiguration.RunState)
                {
                    case CONFIG_RUNNING:
                        btnChangeState.Text = "Suspend";
                        btnChangeState.Enabled = true;
                        stateChangeMenuItem.Text = "Suspend this config";
                        stateChangeMenuItem.Visible = true;
                        stateChangeMenuItem.Enabled = true;
                        refreshState.Visible = true;
                        trayIcon.Icon = skytapRunningIcon;
                        SetTrayText();
                        break;
                    case CONFIG_SUSPENDED:
                        btnChangeState.Text = "Run";
                        btnChangeState.Enabled = true;
                        stateChangeMenuItem.Text = "Run this config";
                        stateChangeMenuItem.Visible = true;
                        stateChangeMenuItem.Enabled = true;
                        refreshState.Visible = true;
                        trayIcon.Icon = skytapSuspendedIcon;
                        SetTrayText();
                        break;
                    case CONFIG_STOPPED:
                        btnChangeState.Text = "Run";
                        btnChangeState.Enabled = true;
                        stateChangeMenuItem.Text = "Run this config";
                        stateChangeMenuItem.Visible = true;
                        stateChangeMenuItem.Enabled = true;
                        refreshState.Visible = true;
                        trayIcon.Icon = skytapStoppedIcon;
                        SetTrayText();
                        break;
                    default:
                        lblRunState.Text = "Busy...";
                        btnChangeState.Text = "Busy";
                        btnChangeState.Enabled = false;
                        stateChangeMenuItem.Text = "Busy";
                        stateChangeMenuItem.Visible = true;
                        stateChangeMenuItem.Enabled = false;
                        refreshState.Visible = true;
                        trayIcon.Icon = skytapBusyIcon;
                        SetTrayText("Busy");
                        break;
                }
                btnChangeState.Visible = true;
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

        private void SetTrayText(string state = null)
        {
            if (string.IsNullOrEmpty(state))
            {
                state = Program.DefaultConfiguration.RunState;
            }
            var trayString = state + " - " + Program.DefaultConfiguration.Name;
            if (trayString.Length > 64)
            {
                trayString = trayString.Substring(0, 63);
            }
            trayIcon.Text = trayString;
        }

        private void ChangeRunningState()
        {
            Client client = new Client(Properties.Settings.Default.Username, Properties.Settings.Default.Token);
            switch (Program.DefaultConfiguration.RunState)
            {
                case CONFIG_RUNNING:
                    client.SetConfigurationState(Program.DefaultConfiguration.Id, "suspended");
                    MonitorBusyState();
                    break;
                case CONFIG_SUSPENDED:
                    client.SetConfigurationState(Program.DefaultConfiguration.Id, "running");
                    MonitorBusyState();
                    break;
                case CONFIG_STOPPED:
                    client.SetConfigurationState(Program.DefaultConfiguration.Id, "running");
                    MonitorBusyState();
                    break;
                default:
                    break;
            }
            Program.DefaultConfiguration.RunState = "busy";
            OnRunningStateChanged(EventArgs.Empty);
        }

        private void MonitorBusyState()
        {
            monitorBusyTimer.Tick += MonitorBusyTimerEvent;
            monitorBusyTimer.Interval = 5000;
            monitorBusyTimer.Start();
            monitorBusyTimer.Enabled = true;
        }

        #endregion

        private void cbRunOnStart_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appPath = Application.ExecutablePath.ToString();


            if (cbRunOnStart.Checked)
            {
                rkApp.SetValue(REGKEY, appPath);
            }
            else
            {
                rkApp.DeleteValue(REGKEY, false);
            } 
        }

    }
}
