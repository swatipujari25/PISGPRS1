namespace PISGPRS
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectToPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPRSModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRouteStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectRouteStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SMSDetailstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coachDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AbouttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelScroll = new System.Windows.Forms.Panel();
            this.lblBottom = new System.Windows.Forms.Label();
            this.picBottomlogo = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboTrainNo = new System.Windows.Forms.ComboBox();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picBrowser = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.picSCSLogo = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblLoginPerson = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblPortNo = new System.Windows.Forms.Label();
            this.gprsConnectControl = new PISGPRS.ucGPRSConnect();
            this.uploadFileControl = new PISGPRS.ucUploadFile();
            this.connectToPortControl = new PISGPRS.ucConnectToPort();
            this.setRouteControl = new PISGPRS.ucSetRoute();
            this.signalStrengthControl = new PISGPRS.ucSignalStrength();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomlogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSCSLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.SMSDetailstoolStripMenuItem,
            this.dataConfigurationToolStripMenuItem,
            this.userToolStripMenuItem,
            this.contactToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.AbouttoolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToPortToolStripMenuItem,
            this.gPRSModeToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.configurationToolStripMenuItem.Text = "Configure";
            this.configurationToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.configurationToolStripMenuItem_MouseMove);
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // ConnectToPortToolStripMenuItem
            // 
            this.ConnectToPortToolStripMenuItem.Name = "ConnectToPortToolStripMenuItem";
            this.ConnectToPortToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ConnectToPortToolStripMenuItem.Text = "Connect To Port";
            this.ConnectToPortToolStripMenuItem.Click += new System.EventHandler(this.SMSModeToolStripMenuItem_Click);
            // 
            // gPRSModeToolStripMenuItem
            // 
            this.gPRSModeToolStripMenuItem.Name = "gPRSModeToolStripMenuItem";
            this.gPRSModeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.gPRSModeToolStripMenuItem.Text = "GPRS Mode";
            this.gPRSModeToolStripMenuItem.Visible = false;
            this.gPRSModeToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gPRSModeToolStripMenuItem_MouseMove);
            this.gPRSModeToolStripMenuItem.Click += new System.EventHandler(this.GPRSModeToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectRouteToolStripMenuItem,
            this.selectRouteStatusToolStripMenuItem,
            this.deselectRouteToolStripMenuItem,
            this.deselectRouteStatusToolStripMenuItem,
            this.routeStatusToolStripMenuItem,
            this.uploadFileToolStripMenuItem,
            this.downloadFileToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsToolStripMenuItem.Text = "Commands";
            this.commandsToolStripMenuItem.MouseHover += new System.EventHandler(this.commandsToolStripMenuItem_Click);
            this.commandsToolStripMenuItem.Click += new System.EventHandler(this.commandsToolStripMenuItem_Click);
            // 
            // selectRouteToolStripMenuItem
            // 
            this.selectRouteToolStripMenuItem.Name = "selectRouteToolStripMenuItem";
            this.selectRouteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.selectRouteToolStripMenuItem.Text = "Select Route";
            this.selectRouteToolStripMenuItem.Click += new System.EventHandler(this.selectRouteToolStripMenuItem1_Click);
            // 
            // selectRouteStatusToolStripMenuItem
            // 
            this.selectRouteStatusToolStripMenuItem.Name = "selectRouteStatusToolStripMenuItem";
            this.selectRouteStatusToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.selectRouteStatusToolStripMenuItem.Text = "Select Route Status";
            this.selectRouteStatusToolStripMenuItem.Click += new System.EventHandler(this.selectRouteStatusToolStripMenuItem_Click);
            // 
            // deselectRouteToolStripMenuItem
            // 
            this.deselectRouteToolStripMenuItem.Name = "deselectRouteToolStripMenuItem";
            this.deselectRouteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deselectRouteToolStripMenuItem.Text = "Deselect Route";
            this.deselectRouteToolStripMenuItem.Click += new System.EventHandler(this.deselectRouteToolStripMenuItem_Click);
            // 
            // deselectRouteStatusToolStripMenuItem
            // 
            this.deselectRouteStatusToolStripMenuItem.Name = "deselectRouteStatusToolStripMenuItem";
            this.deselectRouteStatusToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.deselectRouteStatusToolStripMenuItem.Text = "Deselect Route Status";
            this.deselectRouteStatusToolStripMenuItem.Click += new System.EventHandler(this.deselectRouteStatusToolStripMenuItem_Click);
            // 
            // routeStatusToolStripMenuItem
            // 
            this.routeStatusToolStripMenuItem.Name = "routeStatusToolStripMenuItem";
            this.routeStatusToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.routeStatusToolStripMenuItem.Text = "Route Status";
            this.routeStatusToolStripMenuItem.Click += new System.EventHandler(this.routeStatusToolStripMenuItem_Click);
            // 
            // uploadFileToolStripMenuItem
            // 
            this.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
            this.uploadFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.uploadFileToolStripMenuItem.Text = "Upload File";
            this.uploadFileToolStripMenuItem.Visible = false;
            this.uploadFileToolStripMenuItem.Click += new System.EventHandler(this.uploadFileToolStripMenuItem_Click);
            // 
            // downloadFileToolStripMenuItem
            // 
            this.downloadFileToolStripMenuItem.Name = "downloadFileToolStripMenuItem";
            this.downloadFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.downloadFileToolStripMenuItem.Text = "Download File";
            this.downloadFileToolStripMenuItem.Visible = false;
            // 
            // SMSDetailstoolStripMenuItem
            // 
            this.SMSDetailstoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMSMessagesToolStripMenuItem});
            this.SMSDetailstoolStripMenuItem.Name = "SMSDetailstoolStripMenuItem";
            this.SMSDetailstoolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.SMSDetailstoolStripMenuItem.Text = "SMS Details";
            // 
            // sMSMessagesToolStripMenuItem
            // 
            this.sMSMessagesToolStripMenuItem.Name = "sMSMessagesToolStripMenuItem";
            this.sMSMessagesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.sMSMessagesToolStripMenuItem.Text = "SMS Messages";
            this.sMSMessagesToolStripMenuItem.Click += new System.EventHandler(this.SMSMessagesToolStripMenuItem_Click);
            // 
            // dataConfigurationToolStripMenuItem
            // 
            this.dataConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainDetailsToolStripMenuItem,
            this.coachDetailsToolStripMenuItem});
            this.dataConfigurationToolStripMenuItem.Name = "dataConfigurationToolStripMenuItem";
            this.dataConfigurationToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.dataConfigurationToolStripMenuItem.Text = "Data Configuration";
            // 
            // trainDetailsToolStripMenuItem
            // 
            this.trainDetailsToolStripMenuItem.Name = "trainDetailsToolStripMenuItem";
            this.trainDetailsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.trainDetailsToolStripMenuItem.Text = "Train Details";
            this.trainDetailsToolStripMenuItem.Click += new System.EventHandler(this.trainDetailsToolStripMenuItem_Click);
            // 
            // coachDetailsToolStripMenuItem
            // 
            this.coachDetailsToolStripMenuItem.Name = "coachDetailsToolStripMenuItem";
            this.coachDetailsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.coachDetailsToolStripMenuItem.Text = "Coach Details";
            this.coachDetailsToolStripMenuItem.Click += new System.EventHandler(this.coachDetailsToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userDetailsToolStripMenuItem,
            this.resetPasswordToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // userDetailsToolStripMenuItem
            // 
            this.userDetailsToolStripMenuItem.Name = "userDetailsToolStripMenuItem";
            this.userDetailsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.userDetailsToolStripMenuItem.Text = "User Details";
            this.userDetailsToolStripMenuItem.Click += new System.EventHandler(this.userDetailsToolStripMenuItem_Click);
            // 
            // resetPasswordToolStripMenuItem
            // 
            this.resetPasswordToolStripMenuItem.Name = "resetPasswordToolStripMenuItem";
            this.resetPasswordToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.resetPasswordToolStripMenuItem.Text = "Reset Password";
            this.resetPasswordToolStripMenuItem.Click += new System.EventHandler(this.resetPasswordToolStripMenuItem_Click);
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.contactToolStripMenuItem.Text = "Contact us";
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.contactToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.userManualToolStripMenuItem.Text = "User Manual";
            this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
            // 
            // AbouttoolStripMenuItem
            // 
            this.AbouttoolStripMenuItem.Name = "AbouttoolStripMenuItem";
            this.AbouttoolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AbouttoolStripMenuItem.Text = "About";
            this.AbouttoolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.panelScroll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 617);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1074, 35);
            this.panel2.TabIndex = 3;
            // 
            // panelScroll
            // 
            this.panelScroll.Controls.Add(this.lblBottom);
            this.panelScroll.Controls.Add(this.picBottomlogo);
            this.panelScroll.Location = new System.Drawing.Point(1, 1);
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.Size = new System.Drawing.Size(900, 34);
            this.panelScroll.TabIndex = 0;
            // 
            // lblBottom
            // 
            this.lblBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBottom.AutoSize = true;
            this.lblBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottom.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBottom.Location = new System.Drawing.Point(44, 8);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Size = new System.Drawing.Size(852, 20);
            this.lblBottom.TabIndex = 80;
            this.lblBottom.Text = "UNIVERSAL CONTROLS  Ph: 040-27144794, Telefax: 040-27120187, Email: info@universa" +
                "l-controls.com";
            // 
            // picBottomlogo
            // 
            this.picBottomlogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picBottomlogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBottomlogo.BackgroundImage")));
            this.picBottomlogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBottomlogo.Location = new System.Drawing.Point(1, 1);
            this.picBottomlogo.Name = "picBottomlogo";
            this.picBottomlogo.Size = new System.Drawing.Size(38, 33);
            this.picBottomlogo.TabIndex = 81;
            this.picBottomlogo.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cboTrainNo);
            this.panel1.Controls.Add(this.lblTrainName);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(280, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 590);
            this.panel1.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(333, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 30);
            this.btnSearch.TabIndex = 113;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            // 
            // cboTrainNo
            // 
            this.cboTrainNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainNo.FormattingEnabled = true;
            this.cboTrainNo.Location = new System.Drawing.Point(86, 10);
            this.cboTrainNo.Name = "cboTrainNo";
            this.cboTrainNo.Size = new System.Drawing.Size(216, 21);
            this.cboTrainNo.TabIndex = 111;
            this.cboTrainNo.Visible = false;
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(11, 16);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(54, 15);
            this.lblTrainName.TabIndex = 112;
            this.lblTrainName.Text = "Train No";
            this.lblTrainName.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picBrowser);
            this.panel3.Controls.Add(this.webBrowser1);
            this.panel3.Location = new System.Drawing.Point(41, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 500);
            this.panel3.TabIndex = 114;
            // 
            // picBrowser
            // 
            this.picBrowser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBrowser.BackgroundImage")));
            this.picBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBrowser.Location = new System.Drawing.Point(29, 0);
            this.picBrowser.Name = "picBrowser";
            this.picBrowser.Size = new System.Drawing.Size(707, 497);
            this.picBrowser.TabIndex = 116;
            this.picBrowser.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(739, 500);
            this.webBrowser1.TabIndex = 110;
            this.webBrowser1.Visible = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConnectionStatus.Location = new System.Drawing.Point(58, 97);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(0, 24);
            this.lblConnectionStatus.TabIndex = 115;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(12, 593);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 77;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(49, 154);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(207, 213);
            this.picLogo.TabIndex = 80;
            this.picLogo.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCompanyName.Location = new System.Drawing.Point(34, 551);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(242, 24);
            this.lblCompanyName.TabIndex = 79;
            this.lblCompanyName.Text = "UNIVERSAL CONTROLS";
            // 
            // picSCSLogo
            // 
            this.picSCSLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSCSLogo.BackgroundImage")));
            this.picSCSLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSCSLogo.Location = new System.Drawing.Point(49, 368);
            this.picSCSLogo.Name = "picSCSLogo";
            this.picSCSLogo.Size = new System.Drawing.Size(207, 180);
            this.picSCSLogo.TabIndex = 78;
            this.picSCSLogo.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblLoginPerson
            // 
            this.lblLoginPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginPerson.AutoSize = true;
            this.lblLoginPerson.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblLoginPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginPerson.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblLoginPerson.Location = new System.Drawing.Point(885, 2);
            this.lblLoginPerson.Name = "lblLoginPerson";
            this.lblLoginPerson.Size = new System.Drawing.Size(0, 20);
            this.lblLoginPerson.TabIndex = 116;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblIPAddress.Location = new System.Drawing.Point(8, 34);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(0, 16);
            this.lblIPAddress.TabIndex = 117;
            // 
            // lblPortNo
            // 
            this.lblPortNo.AutoSize = true;
            this.lblPortNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPortNo.Location = new System.Drawing.Point(8, 64);
            this.lblPortNo.Name = "lblPortNo";
            this.lblPortNo.Size = new System.Drawing.Size(0, 16);
            this.lblPortNo.TabIndex = 118;
            // 
            // gprsConnectControl
            // 
            this.gprsConnectControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gprsConnectControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gprsConnectControl.Location = new System.Drawing.Point(350, 150);
            this.gprsConnectControl.Name = "gprsConnectControl";
            this.gprsConnectControl.Size = new System.Drawing.Size(355, 340);
            this.gprsConnectControl.TabIndex = 0;
            this.gprsConnectControl.Visible = false;
            // 
            // uploadFileControl
            // 
            this.uploadFileControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.uploadFileControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uploadFileControl.Location = new System.Drawing.Point(350, 150);
            this.uploadFileControl.Name = "uploadFileControl";
            this.uploadFileControl.Size = new System.Drawing.Size(388, 325);
            this.uploadFileControl.TabIndex = 0;
            this.uploadFileControl.Visible = false;
            // 
            // connectToPortControl
            // 
            this.connectToPortControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.connectToPortControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectToPortControl.Location = new System.Drawing.Point(375, 150);
            this.connectToPortControl.Name = "connectToPortControl";
            this.connectToPortControl.Size = new System.Drawing.Size(327, 326);
            this.connectToPortControl.TabIndex = 0;
            this.connectToPortControl.Visible = false;
            // 
            // setRouteControl
            // 
            this.setRouteControl.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.setRouteControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.setRouteControl.Location = new System.Drawing.Point(280, 28);
            this.setRouteControl.Name = "setRouteControl";
            this.setRouteControl.Size = new System.Drawing.Size(790, 560);
            this.setRouteControl.TabIndex = 0;
            this.setRouteControl.Visible = false;
            // 
            // signalStrengthControl
            // 
            this.signalStrengthControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.signalStrengthControl.Location = new System.Drawing.Point(228, 27);
            this.signalStrengthControl.Name = "signalStrengthControl";
            this.signalStrengthControl.Size = new System.Drawing.Size(48, 48);
            this.signalStrengthControl.TabIndex = 0;
            this.signalStrengthControl.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1074, 652);
            this.Controls.Add(this.lblPortNo);
            this.Controls.Add(this.lblIPAddress);
            this.Controls.Add(this.gprsConnectControl);
            this.Controls.Add(this.uploadFileControl);
            this.Controls.Add(this.connectToPortControl);
            this.Controls.Add(this.lblLoginPerson);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.setRouteControl);
            this.Controls.Add(this.signalStrengthControl);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.picSCSLogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passenger Information System";
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelScroll.ResumeLayout(false);
            this.panelScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomlogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSCSLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem ConnectToPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPRSModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coachDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AbouttoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboTrainNo;
        private System.Windows.Forms.Label lblTrainName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.PictureBox picSCSLogo;
        private PISGPRS.ucSetRoute setRouteControl ;
        private PISGPRS.ucGPRSConnect gprsConnectControl;
        private PISGPRS.ucSignalStrength signalStrengthControl;
        private PISGPRS.ucConnectToPort connectToPortControl;
        private PISGPRS.ucUploadFile uploadFileControl;
        private System.Windows.Forms.ToolStripMenuItem SMSDetailstoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSMessagesToolStripMenuItem;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.PictureBox picBottomlogo;
        private System.Windows.Forms.ToolStripMenuItem selectRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectRouteStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectRouteStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routeStatusToolStripMenuItem;
        private System.Windows.Forms.PictureBox picBrowser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.Label lblLoginPerson;
        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblPortNo;
        private System.Windows.Forms.ToolStripMenuItem uploadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadFileToolStripMenuItem;


    }
}