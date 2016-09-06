

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Common;
using Logger;
using Communication;

namespace PISGPRS
{
    public partial class ModemConfiguration : Form
    {        
        public ModemConfiguration()
        {
            InitializeComponent();
        }

        #region Delegates Declaration
        string statusMessage = string.Empty;
        Color lblColor = Color.Green;

        public delegate void StatusMsg();
        public StatusMsg ConnectionStatusDelegate;
        #endregion

        private void InvokeCheckConnection()
        {
            try
            {
                lblStatus.Invoke(ConnectionStatusDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void StatusUpdate()
        {
            try
            {            
                lblStatus.Text = statusMessage;
                lblStatus.ForeColor = lblColor;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void ModemConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectionStatusDelegate = new StatusMsg(StatusUpdate);
                BindComPorts();
                BindBaudRate();
                BindDataBits();
                BindParity();
                BindStopBits();
                DefaultSettings();

                if (Constants.ConnectionStatus == Constants.Connectivity.Connected.ToString())
                {
                    statusMessage = "Connected to " + cboPortNo.SelectedItem.ToString();
                   
                 //   lblStatus.Text = "Connected to " + cboPortNo.SelectedItem.ToString();
                    lblColor = Color.Green;
                    InvokeCheckConnection();
                    btnDisConnect.Enabled = true;
                    btnConnect.Enabled = false;
                    Constants.IsModemConnected = true;
                }
                else if (Constants.ConnectionStatus == Constants.Connectivity.Disconnected.ToString())
                {
                    statusMessage = "Not Connected";
                    lblColor = Color.Red;
                    InvokeCheckConnection();
                    Constants.IsModemConnected = false;
                    btnDisConnect.Enabled = false;
                    btnConnect.Enabled = true;
                }
                else
                {
                    statusMessage = "Not Connected";
                    lblColor = Color.Red;
                    InvokeCheckConnection();
                    Constants.IsModemConnected = false;
                    btnDisConnect.Enabled = false;
                    btnConnect.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Get all the sytem ports
        /// </summary>
        private void BindComPorts()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();

                foreach (string port in ports)
                {
                    cboPortNo.Items.Add(port);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// list of the BaudRates
        /// </summary>
        private void BindBaudRate()
        {
            try
            {
                List<int> list = new List<int>();
                list.Add(110);
                list.Add(300);
                list.Add(1200);
                list.Add(2400);
                list.Add(4800);
                list.Add(9600);
                list.Add(19200);
                list.Add(38400);
                list.Add(57600);
                list.Add(115200);
                list.Add(230400);
                list.Add(460800);
                list.Add(921600);
                cboBitsPerSec.DataSource = list;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Bind dataBits list
        /// </summary>
        private void BindDataBits()
        {
            try
            {
                List<int> list = new List<int>();
                list.Add(5);
                list.Add(6);
                list.Add(7);
                list.Add(8);
                cboDataBits.DataSource = list;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void BindParity()
        {
            try
            {
                List<string> list = new List<string>();
                list.Add("Even");
                list.Add("Odd");
                list.Add("None");
                list.Add("Mark");
                list.Add("Space");
                cboParity.DataSource = list;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void BindStopBits()
        {
            try
            {
                List<double> list = new List<double>();
                list.Add(1);
                list.Add(1.5);
                list.Add(2);
                cboStopBits.DataSource = list;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void DefaultSettings()
        {
            try
            {
                if (Constants.ConnectionStatus == Constants.Connectivity.Connected.ToString())
                {
                    cboPortNo.SelectedIndex = cboPortNo.FindStringExact(BaseClass.SRPortComm.PortName.ToString());
                    cboBitsPerSec.SelectedIndex = cboBitsPerSec.FindStringExact(BaseClass.SRPortComm.BaudRt.ToString());
                    cboDataBits.SelectedIndex = cboDataBits.FindStringExact(BaseClass.SRPortComm.DataBits.ToString());
                    cboParity.SelectedIndex = cboParity.FindStringExact(BaseClass.SRPortComm.pParity.ToString());

                    double bitVal = 1;
                    if (BaseClass.SRPortComm.StopBits == StopBits.One)
                    {
                        bitVal = 1.0;
                    }
                    else if (BaseClass.SRPortComm.StopBits == StopBits.OnePointFive)
                    {
                        bitVal = 1.5;
                    }
                    else if (BaseClass.SRPortComm.StopBits == StopBits.Two)
                    {
                        bitVal = 2;
                    }
                    cboStopBits.SelectedIndex = cboStopBits.FindStringExact(bitVal.ToString());
                }
                else
                {
                    //cboPortNo.SelectedItem = "COM14";               
                    cboBitsPerSec.SelectedItem = 19200;
                    cboDataBits.SelectedItem = 8;
                    cboParity.SelectedItem = "None";
                    cboStopBits.SelectedItem = 1;

                    cboPortNo.SelectedIndex = 0;
                    // cboBitsPerSec.SelectedIndex = 0;
                    //cboDataBits.SelectedIndex = 0;
                    //cboParity.SelectedIndex = 0;
                    //cboStopBits.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private Boolean IsValid()
        {
            Boolean valid = true;
            try
            {
                if (string.IsNullOrEmpty(cboPortNo.SelectedItem.ToString()))
                {
                    lblMsg.Text = "Select Port No";
                    valid = false;
                }
                else
                {
                    lblMsg.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return valid;
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            try
            {
                
                BaseClass.SRPortComm.Close();
                statusMessage = "Not Connected"; 
                lblColor = Color.Red;
                InvokeCheckConnection();
               
                Constants.ConnectionStatus = Constants.Connectivity.Disconnected.ToString();
                btnDisConnect.Enabled = false;
               
                btnConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                statusMessage = "Connection establishing...";
                lblColor = Color.Green;
                InvokeCheckConnection();
                
                if (IsValid())
                {                  

                    BaseClass.SRPortComm.SerialPortSettings(cboPortNo.SelectedItem.ToString(), Convert.ToInt32(cboBitsPerSec.SelectedItem), cboParity.SelectedItem.ToString(),
                      Convert.ToInt32(cboDataBits.SelectedItem), Convert.ToDouble(cboStopBits.SelectedItem));

                    if (BaseClass.SRPortComm.Connect())
                    {
                        if (BaseClass.SRPortComm.CommunicationTestCommand())
                        {
                            BaseClass.SRPortComm.EcoOFFCommand();
                            MessageBox.Show("Connection established Successfully");

                            statusMessage = "Connected to " + cboPortNo.SelectedItem.ToString();
                            lblColor = Color.Green;  
                            InvokeCheckConnection();
                           
                            Constants.ConnectionStatus = Constants.Connectivity.Connected.ToString();
                            btnConnect.Enabled = false;
                            btnDisConnect.Enabled = true;
                            BaseClass.SelectRoute = true;
                            BaseClass.SelectRouteStatus = true;
                            BaseClass.DeselectRoute = true;
                            BaseClass.DeselectRouteStatus = true;
                            BaseClass.RouteStatus = true;                            
                            BaseClass.GPRSMode = true;
                            this.Close();
                        }
                        else
                        {
                           // MessageBox.Show("Invalid Port");
                            statusMessage = "Please Check connection";
                            lblColor = Color.Red;
                            InvokeCheckConnection();
                            
                            Constants.ConnectionStatus = Constants.Connectivity.Disconnected.ToString();
                            btnDisConnect.Enabled = false;
                            btnConnect.Enabled = true;
                            BaseClass.SelectRoute = false;
                            BaseClass.SelectRouteStatus = false;
                            BaseClass.DeselectRoute = false;
                            BaseClass.DeselectRouteStatus = false;
                            BaseClass.RouteStatus = false;
                            
                            BaseClass.GPRSMode = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Connection Fail");
                        statusMessage= "Not Connected";
                        lblColor = Color.Red;
                        InvokeCheckConnection();
                        
                        Constants.ConnectionStatus = Constants.Connectivity.Disconnected.ToString();
                        btnDisConnect.Enabled = false;
                        btnConnect.Enabled = true;
                        
                        BaseClass.SelectRoute = false;
                        BaseClass.SelectRouteStatus = false;
                        BaseClass.DeselectRoute = false;
                        BaseClass.DeselectRouteStatus = false;
                        BaseClass.RouteStatus = false;
                        BaseClass.GPRSMode = false;
                    }

                    Common.Constants.GSMConnectionStatus = lblStatus.Text;                   
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

    }
}
