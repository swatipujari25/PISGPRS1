using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Common;
using Communication;
using Logger;

namespace PISGPRS
{
    public partial class Main : Form
    {
        #region MEMBER VARIABLES
        List<string> listSIMNos = new List<string>();
        string latitude = string.Empty;
        string longitude = string.Empty;
        Dictionary<int, string> listTrainNo = new Dictionary<int, string>();
        DataTable dtTrain = new DataTable();
        StringBuilder queryAddress = new StringBuilder();
        Stopwatch watch = new Stopwatch();

        Stopwatch watchForAtCommand = new Stopwatch();
        TimeSpan stopWatchTime = new TimeSpan();
        DialogResult result = new DialogResult();
        int StopWatchMinutes = 0;
        int minAtCommand = 0;


        double rW = 0;
        double rH = 0;
        int fH = 0;
        int fW = 0;
        int fX = 0;
        int fY = 0;
        float fFontSize = (float)5.5;

        # endregion

        #region DELEGATES DECLARATION
        public delegate void SMSResponse();
        public SMSResponse smsResponseDelegate;

        public SMSResponse updateResponseDelegate;

        public delegate void CheckConnection();
        public CheckConnection chkConnectionDelegate;
        public CheckConnection chkBrokenConDelegate;

        public delegate void DisplaySigalStrength();
        public DisplaySigalStrength displaySignalStrengthDelegate;

        public delegate void Display();

        public Display IPAddressDelegate;

        public Display PortNoDelegate;

        #endregion

        public Main()
        {
            try
            {
                InitializeComponent();
                setRouteControl.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update sent messages responses
        /// </summary>
        private void InvokeIPAddress()
        {
            try
            {
                lblIPAddress.Invoke(IPAddressDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update sent messages responses
        /// </summary>
        private void InvokePortNo()
        {
            try
            {
                lblPortNo.Invoke(PortNoDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update sent messages responses
        /// </summary>
        private void InvokeResponseSMS()
        {
            try
            {
                setRouteControl.dgvCoach.Invoke(smsResponseDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// When modem is fail/disconnected, this method will call
        /// </summary>
        private void InvokeCheckConnection()
        {
            try
            {
                lblConnectionStatus.Invoke(chkConnectionDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update Broken connection connected status
        /// </summary>
        private void InvokeConnectBrokenConnection()
        {
            try
            {
                lblConnectionStatus.Invoke(chkBrokenConDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update connection break status
        /// </summary>
        private void CheckForBrokenConnection()
        {
            try
            {
                #region Connection break
               
                if (!string.IsNullOrEmpty(BaseClass.CurrentProcess))
                {
                    setRouteControl.msg = string.Empty;
                    BaseClass.IsSendOperationInprocess = false;
                    setRouteControl.SetControlStatus(true);
                    BaseClass.CurrentProcess = string.Empty;
                }
                Constants.ConnectionStatus = string.Empty;
                lblConnectionStatus.Text = BaseClass.ModemStatus.MODEM_FAIL.ToString().Replace('_', ' ');
                Constants.IsModemConnected = false;
                watchForAtCommand.Start();
                Constants.IsConnectionBreak = false;

                #endregion
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Try to connect broken connection 
        /// </summary>
        private void ConnectBrokenConnection()
        {
            try
            {
                //if (!Constants.IsBrokenConnectionEstablished)
                //{
                //    BaseClass.SRPortComm.Close();
                //    BaseClass.SRPortComm.SerialPortSettings(BaseClass.SRPortComm.PortName, BaseClass.SRPortComm.BaudRt, "None",
                //             BaseClass.SRPortComm.DataBits, 1.0);
                //}

                //  Constants.IsConnectingToModem = true;

                //if (BaseClass.SRPortComm.Connect())
                //{
                BaseClass.timeCounter = 5000;
                if (BaseClass.SRPortComm.CommunicationTestCommand())
                {
                    //#region After connection established
                    //lblConnectionStatus.Text = BaseClass.ModemStatus.Modem_Connected.ToString().Replace('_', ' ');
                    //Constants.IsModemConnected = true;
                    //Constants.IsBrokenConnectionEstablished = false;

                    //if (connectToPortControl.Visible)
                    //{
                    //    connectToPortControl.statusMessage = "Connected to " + BaseClass.SRPortComm.PortName;
                    //    connectToPortControl.displayForeColor = Color.Green;
                    //    connectToPortControl.InvokeCheckConnection();

                    //    Constants.ConnectionStatus = Constants.Connectivity.Connected.ToString();
                    //    connectToPortControl.btnConnectStatus = false;
                    //    connectToPortControl.InvokeConnectDisplay();
                    //    connectToPortControl.btnDisConnectStatus = true;
                    //    connectToPortControl.InvokeDisconnectDisplay();

                    //    BaseClass.SelectRoute = true;
                    //    BaseClass.SelectRouteStatus = true;
                    //    BaseClass.DeselectRoute = true;
                    //    BaseClass.DeselectRouteStatus = true;
                    //    BaseClass.RouteStatus = true;
                    //    BaseClass.GPRSMode = true;
                    //    Constants.IsModemConnected = true;
                    //    connectToPortControl.InvokeCurrentUCDisplay();
                    //}
                    //#endregion
                }
                //}

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void InvokeDisplaySignalStrengthImage()
        {
            try
            {
                signalStrengthControl.Invoke(displaySignalStrengthDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void updateSignalStrength()
        {
            try
            {
                signalStrengthControl.DrawSignals();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }      

        /// <summary>
        /// To close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisposeObjects();
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// dispose the running objects
        /// </summary>
        private void DisposeObjects()
        {
            try
            {
                BaseClass.SRPortComm.Close();
                timer1.Stop();
               
                signalStrengthControl.pen.Dispose();
                signalStrengthControl.brush.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }    

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                #region update current Modem Status

                if (Constants.ConnectionStatus == Constants.Connectivity.Connected.ToString())
                {
                    lblConnectionStatus.Text = BaseClass.ModemStatus.Modem_Connected.ToString().Replace('_', ' ');
                    Constants.IsModemConnected = true;
                    lblConnectionStatus.Visible = true;

                }
                else if (Constants.ConnectionStatus == Constants.Connectivity.Disconnected.ToString())
                {
                    lblConnectionStatus.Text = BaseClass.ModemStatus.Modem_Disconnected.ToString().Replace('_', ' ');
                    Constants.IsModemConnected = false;
                    lblConnectionStatus.Visible = true;
                }
                else if (!string.IsNullOrEmpty(Constants.ConnectionStatus))
                {
                    // this.connectToPortControl.Visible = true;
                    lblConnectionStatus.Text = BaseClass.ModemStatus.MODEM_FAIL.ToString().Replace('_', ' ');
                    Constants.IsModemConnected = false;
                }
                #endregion

                #region Modem Fail lable should blink
                if (!Constants.IsConnectingToModem && lblConnectionStatus.Text == BaseClass.ModemStatus.MODEM_FAIL.ToString().Replace('_', ' '))
                {
                    if (lblConnectionStatus.Visible)
                    {
                        lblConnectionStatus.Visible = false;
                    }
                    else
                    {
                        lblConnectionStatus.Visible = true;
                    }
                }
                #endregion

                #region Connecting to Modem
                if (Constants.IsConnectingToModem)
                {
                    //At command succeed below code will execute
                    if (Constants.CurrentRequest == Constants.Commands.AT.ToString())
                    {
                        if (Constants.receivingInprocess)
                        {
                            BaseClass.CalculateCounterTime();

                            if (BaseClass.timeCounter <= BaseClass.milliTime)
                            {
                                Constants.IsResponseSuccess = false;
                                Constants.receivingInprocess = false;
                                Stop_Reset_D_Counter();
                            }
                        }
                        else if (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                        {
                            Stop_Reset_D_Counter();
                            BaseClass.SRPortComm.EcoOFFCommand();
                            BaseClass.timeCounter = 5000;
                            BaseClass.counterWatch.Start();
                        }
                        else if (!Constants.receivingInprocess && !Constants.IsResponseSuccess)
                        {
                            connectToPortControl.statusMessage = "Please select valid COM port" + Environment.NewLine + " And Check Modem Power supply";
                            connectToPortControl.displayForeColor = Color.Red;
                            connectToPortControl.InvokeCheckConnection();

                            Constants.ConnectionStatus = Constants.Connectivity.Not_Connected.ToString().Replace('_', ' ');

                            connectToPortControl.btnConnectStatus = true;
                            connectToPortControl.InvokeConnectDisplay();
                            connectToPortControl.btnDisConnectStatus = false;
                            connectToPortControl.InvokeDisconnectDisplay();

                            BaseClass.SelectRoute = false;
                            BaseClass.SelectRouteStatus = false;
                            BaseClass.DeselectRoute = false;
                            BaseClass.DeselectRouteStatus = false;
                            BaseClass.RouteStatus = false;
                            BaseClass.GPRSMode = false;
                            Constants.IsModemConnected = false;
                            Constants.IsConnectingToModem = false;

                        }
                    }
                    //ATE0 Eco command Succeed below code will excute
                    else if (Constants.CurrentRequest == Constants.Commands.ATE0.ToString())
                    {

                        if (Constants.receivingInprocess)
                        {
                            BaseClass.CalculateCounterTime();

                            if (BaseClass.timeCounter <= BaseClass.milliTime)
                            {
                                Constants.IsResponseSuccess = false;
                                Constants.receivingInprocess = false;
                                Stop_Reset_D_Counter();
                            }
                        }
                        else if (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                        {
                            Stop_Reset_D_Counter();
                            BaseClass.SRPortComm.CheckSIMRegistartion();
                            BaseClass.timeCounter = 5000;
                            BaseClass.counterWatch.Start();
                        }
                        //ATE0 Eco command fail below code will excute
                        else if (!Constants.receivingInprocess && !Constants.IsResponseSuccess)
                        {
                            Constants.IsConnectingToModem = false;
                        }
                    }
                    //CREG command Succeed below code will excute
                    else if (Constants.CurrentRequest == Constants.Commands.CREG.ToString())
                    {
                        if (Constants.receivingInprocess)
                        {
                            BaseClass.CalculateCounterTime();

                            if (BaseClass.timeCounter <= BaseClass.milliTime)
                            {
                                Constants.IsResponseSuccess = false;
                                Constants.receivingInprocess = false;
                                Stop_Reset_D_Counter();
                            }
                        }
                        else if (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                        {
                            Stop_Reset_D_Counter();
                            BaseClass.SelectRoute = true;
                            BaseClass.SelectRouteStatus = true;
                            BaseClass.DeselectRoute = true;
                            BaseClass.DeselectRouteStatus = true;
                            BaseClass.RouteStatus = true;

                            Constants.CommunicationMode = BaseClass.CommunicationMode.SMS.ToString();
                            BaseClass.SRPortComm.CheckGPRSService();

                            BaseClass.timeCounter = 10000;
                            BaseClass.counterWatch.Start();

                            connectToPortControl.btnConnectStatus = false;
                            connectToPortControl.InvokeConnectDisplay();
                            connectToPortControl.btnDisConnectStatus = true;
                            connectToPortControl.InvokeDisconnectDisplay();

                            Constants.ConnectionStatus = Constants.Connectivity.Connected.ToString();
                            MessageBox.Show("Connection Established Successfully");

                            Constants.IsModemConnected = true;
                            connectToPortControl.InvokeCurrentUCDisplay();
                        }
                        //ATE0 Eco command fail below code will excute
                        else if (!Constants.receivingInprocess && !Constants.IsResponseSuccess)
                        {
                            Stop_Reset_D_Counter();
                            MessageBox.Show("SIM not registered");
                            BaseClass.SelectRoute = false;
                            BaseClass.SelectRouteStatus = false;
                            BaseClass.DeselectRoute = false;
                            BaseClass.DeselectRouteStatus = false;
                            BaseClass.RouteStatus = false;
                            BaseClass.GPRSMode = false;
                            Constants.IsConnectingToModem = false;
                            Constants.CurrentRequest = string.Empty;
                        }
                    }
                    //CGATT command succeed below code will execute
                    else if (Constants.CurrentRequest == Constants.Commands.CGATT.ToString())
                    {
                        if (Constants.receivingInprocess)
                        {
                            BaseClass.CalculateCounterTime();

                            if (BaseClass.timeCounter <= BaseClass.milliTime)
                            {
                                Constants.IsResponseSuccess = false;
                                Constants.receivingInprocess = false;
                                Stop_Reset_D_Counter();
                                BaseClass.GPRSMode = false;

                                Constants.IsConnectingToModem = false;
                            }
                        }
                        else if (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                        {
                            BaseClass.GPRSMode = true;
                            this.setRouteControl.Visible = false;
                            this.gprsConnectControl.Visible = false;
                            this.uploadFileControl.Visible = false;
                           Stop_Reset_D_Counter();

                            Constants.IsConnectingToModem = false;
                        }
                        else if (!Constants.receivingInprocess && !Constants.IsResponseSuccess)
                        {
                            BaseClass.GPRSMode = false;
                            Stop_Reset_D_Counter();

                            Constants.IsConnectingToModem = false;
                        }
                    }
                }
                #endregion

                #region  Send messages
                //while SMS sending process this block will execute       

                else if (BaseClass.CurrentProcess == Constants.Commands.MessageSend.ToString())
                {
                    if (BaseClass.IsSendOperationInprocess)
                    {
                        if (Constants.receivingInprocess)
                        {
                            BaseClass.CalculateCounterTime();

                            if (BaseClass.timeCounter <= BaseClass.milliTime)
                            {
                                Constants.IsResponseSuccess = false;
                                Constants.receivingInprocess = false;
                                Constants.IsConnectionBreak = true;
                                Stop_Reset_D_Counter();
                                Constants.CurrentRequest = string.Empty;
                                Constants.MessageSendStatus = Constants.MessageSendProcess.Fail.ToString();
                                setRouteControl.InvokeGrid();                            

                                if (BaseClass.SentMsgCount < 3)
                                {
                                    setRouteControl.SMSProcess();
                                }
                                else if (BaseClass.SentMsgCount == 3)
                                {
                                    setRouteControl.InvokeGrid();
                                }
                                else if (BaseClass.ListSelectedDgvRows.Count != 0)
                                {
                                    Constants.MessageSendStatus = string.Empty;
                                    setRouteControl.SMSProcess();
                                }
                            }
                        }
                        else if (Constants.MessageSendStatus == Constants.MessageSendProcess.Msg_Sent.ToString().Replace('_', ' '))// (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                        {
                            Stop_Reset_D_Counter();
                            setRouteControl.InvokeGrid();

                            string xx = Constants.CurrentRequest;
                            if (BaseClass.ListSelectedDgvRows.Count != 0)
                            {
                                Constants.MessageSendStatus = string.Empty;
                                setRouteControl.SMSProcess();
                            }
                            
                        }
                        else if (Constants.MessageSendStatus == Constants.MessageSendProcess.Fail.ToString())
                        {
                            Constants.IsResponseSuccess = false;
                            Constants.receivingInprocess = false;
                            Stop_Reset_D_Counter();
                            Constants.CurrentRequest = string.Empty;

                            if (BaseClass.SentMsgCount < 3)
                            {
                                setRouteControl.SMSProcess();
                            }
                            else if (BaseClass.SentMsgCount == 3)
                            {
                                setRouteControl.InvokeGrid();
                            }
                            else if (BaseClass.ListSelectedDgvRows.Count != 0)
                            {
                                Constants.MessageSendStatus = string.Empty;
                                setRouteControl.SMSProcess();
                            }
                        }

                        #region Stop the SMS sending process
                        if (Constants.IsProcessCancelled || Constants.IsConnectionBreak)
                        {
                            BaseClass.ListSelectedDgvRows.Clear();
                            setRouteControl.msg = string.Empty;
                            setRouteControl.InvokeStatus();
                            setRouteControl.SetControlStatus(true);
                            BaseClass.CurrentProcess = string.Empty;
                            BaseClass.IsSendOperationInprocess = false;
                            Constants.IsProcessCancelled = false;
                        }
                        #endregion
                    }
                }

                #endregion

                #region Read Messages
                else if (Constants.CurrentRequest == Constants.Commands.UnRead.ToString())
                {
                    if (Constants.receivingInprocess)
                    {
                        BaseClass.CalculateCounterTime();

                        if (BaseClass.timeCounter <= BaseClass.milliTime)
                        {
                            Constants.IsResponseSuccess = false;
                            Constants.receivingInprocess = false;
                            Stop_Reset_D_Counter();
                            Constants.CurrentRequest = string.Empty;
                        }
                    }
                    else if (Constants.listMessages.Count > 0)// (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                    {
                        Constants.IsResponseSuccess = false;
                        Constants.receivingInprocess = false;
                        Stop_Reset_D_Counter();
                        InvokeGridWithResponse();
                        Constants.CurrentRequest = string.Empty;
                    }
                }
                #endregion

                #region Delete Messages
                else if (Constants.CurrentRequest == Constants.Commands.Delete.ToString())
                {
                    if (Constants.receivingInprocess)
                    {
                        BaseClass.CalculateCounterTime();

                        if (BaseClass.timeCounter <= BaseClass.milliTime)
                        {
                            Constants.IsResponseSuccess = false;
                            Constants.receivingInprocess = false;
                            Stop_Reset_D_Counter();
                            Constants.CurrentRequest = string.Empty;
                        }
                    }
                    else if (Constants.listMessages.Count > 0)// (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                    {
                        Stop_Reset_D_Counter();
                        Constants.CurrentRequest = string.Empty;
                    }
                }
                #endregion

                #region New message
                //If application found any new message, then it will start reading received messages
                else if (Constants.IsNewMsg && !BaseClass.IsSendOperationInprocess)
                {
                    InvokeResponseSMS();
                    Constants.IsNewMsg = false;
                }
                #endregion

                #region Check connection breaks
                else if (Constants.IsConnectionBreak)
                {
                    Thread.Sleep(1000);
                    InvokeCheckConnection();
                }
                #endregion

                #region Broken connectin established
                else if (Constants.IsBrokenConnectionEstablished)
                {
                    // InvokeConnectBrokenConnection();
                 
                    BaseClass.SRPortComm.CommunicationTestCommand();
                    BaseClass.timeCounter = 5000;
                    BaseClass.counterWatch.Start();
                }
                #endregion

                #region At Command response when broken connection Established
                else if (Constants.IsBrokenConnectionEstablished && Constants.CurrentRequest == Constants.Commands.AT.ToString())
                {

                    if (Constants.receivingInprocess)
                    {
                        BaseClass.CalculateCounterTime();

                        if (BaseClass.timeCounter <= BaseClass.milliTime)
                        {
                            Constants.IsResponseSuccess = false;
                            Constants.receivingInprocess = false;
                            Stop_Reset_D_Counter();
                            Constants.CurrentRequest = string.Empty;

                            Constants.IsConnectionBreak = true;

                        }
                    }
                    else if (!Constants.receivingInprocess && Constants.IsResponseSuccess)
                    {
                        Stop_Reset_D_Counter();
                        Constants.CurrentRequest = string.Empty;

                        Constants.IsBrokenConnectionEstablished = false;
                        Constants.ConnectionStatus = Constants.Connectivity.Connected.ToString();
                    }

                }
                #endregion

                #region To Check the Failed messages
                else if (StopWatchMinutes == 30 && setRouteControl.Visible)
                {
                    //CheckFailSentMessages();
                    //watch.Stop();
                    //watch.Reset();
                }
                #endregion                

                #region GPRS Connectivity 
                //while GPRS connectivity process started, below block will execute
                else if (Constants.IsGPRSConnectivityStarted)
                {
                    if (Constants.receivingInprocess)
                    {
                        BaseClass.CalculateCounterTime();

                        if (BaseClass.timeCounter <= BaseClass.milliTime)
                        {
                            Constants.IsResponseSuccess = false;
                            Constants.receivingInprocess = false;
                            Constants.IsConnectionBreak = true;
                            Stop_Reset_D_Counter();
                            Constants.CurrentRequest = string.Empty;
                            Constants.GPRSConnectionStatus = Constants.GPRSConnection.Fail.ToString();                           
                        }
                    }
                    //After successfully GPRS connected, below block will execute
                    else if (!Constants.receivingInprocess && Constants.GPRSConnectionStatus == Constants.GPRSConnection.Connected.ToString())
                    {                                               
                        gprsConnectControl.ConnectivityProcessMsg = string.Empty;
                        Constants.IsGPRSConnectivityStarted = false;
                        gprsConnectControl.InvokeGPRSConnectivity();
                        gprsConnectControl.InvokeIPAddress();
                        gprsConnectControl.InvokeSignalStrength();

                        lblPortNo.Text = "Port: " + Constants.GPRSPortNo;
                        lblIPAddress.Text = "IP: " + Constants.GPRSServerIPAddress;

                        InvokeDisplaySignalStrengthImage();

                        result = MessageBox.Show("GPRS Connection Established", "", MessageBoxButtons.OK);
                       
                        
                    }
                    else if (!Constants.receivingInprocess && Constants.GPRSConnectionStatus == Constants.GPRSConnection.Fail.ToString())
                    {
                        gprsConnectControl.ConnectivityProcessMsg = string.Empty;
                        Constants.IsGPRSConnectivityStarted = false;
                        gprsConnectControl.InvokeGPRSConnectivity();
                        result = MessageBox.Show("GPRS Connection Fail", "", MessageBoxButtons.OK);
                        
                    }
                }
#endregion

                #region GPRS Disconnecting
                else if (Constants.IsGPRSDeactivated)
                {
                    if (Constants.receivingInprocess)
                    {
                        BaseClass.CalculateCounterTime();

                        if (BaseClass.timeCounter <= BaseClass.milliTime)
                        {
                            Constants.IsResponseSuccess = false;
                            Constants.receivingInprocess = false;
                            Constants.IsConnectionBreak = true;
                            Stop_Reset_D_Counter();
                            Constants.CurrentRequest = string.Empty;
                            Constants.GPRSConnectionStatus = Constants.GPRSConnection.Fail.ToString();
                        }
                    }                    
                    else  if (Constants.GPRSConnectionStatus == Constants.GPRSConnection.Disconnected.ToString())
                    {
                        Stop_Reset_D_Counter();
                        Constants.IsGPRSDeactivated = false;

                       // InvokeDisplaySignalStrengthImage();

                        result = MessageBox.Show("GPRS connection Disconnected", "", MessageBoxButtons.OK);
                       
                    }
                    //else if (Constants.GPRSConnectionStatus == Constants.GPRSConnection.Fail.ToString())
                    //{
                    //    Thread.Sleep(1000);
                    //    if (BaseClass.messageThread != null)
                    //    {
                    //        BaseClass.messageThread.Abort();
                    //        Logger.Logger.Messages("Thread aborded in timer");
                    //    }
                    //    gprsConnectControl.ConnectivityProcessMsg = string.Empty;
                    //    Constants.IsGPRSConnectivityStarted = false;
                    //    gprsConnectControl.InvokeGPRSConnectivity();
                    //    result = MessageBox.Show("GPRS Connection Fail", "", MessageBoxButtons.OK);
                    //    if (result == DialogResult.OK)
                    //    {

                    //    }
                    //}
                }
#endregion

                #region Server GPRS in Listening mode
                else if (Constants.ServerStatus == Constants.GPRSConnection.Listening.ToString())
                {
                    if (Constants.IsConnectedToClient)
                    {
                        setRouteControl.lblClientIPAddress.Text = Constants.GPRSClientIPAddress;
                        setRouteControl.InvokeClientIPAddress();
                        Constants.IsConnectedToClient = false;
                        if (!string.IsNullOrEmpty(Constants.GPRSClientIPAddress))
                        {
                            result = MessageBox.Show("Connected to Client ", "", MessageBoxButtons.OK);
                        }                       
                    }
                    else if (Constants.CurrentRequest == Constants.Commands.GPRSDataReceiving.ToString() && 
                        !string.IsNullOrEmpty(Constants.GPRSReceivedData))
                    {
                        if (setRouteControl.Visible)
                        {
                            setRouteControl.InvokeResponseMessageOfGrid();
                        }
                    }

                

                }
                #endregion

                #region SERVER disconnected
                else if (Constants.ServerStatus == Constants.GPRSConnection.Fail.ToString())
                {

                    setRouteControl.lblClientIPAddress.Text = string.Empty;
                    Constants.ServerStatus = string.Empty;
                    Constants.IsConnectedToClient = false;
                    result = MessageBox.Show("GPRS connection Fail ", "", MessageBoxButtons.OK);

                    if (result == DialogResult.OK)
                    {
                        Constants.GPRSSignalStrength = string.Empty;
                        Constants.GPRSServerIPAddress = string.Empty;
                        Constants.GPRSPortNo = string.Empty;

                        InvokeIPAddress();
                        InvokePortNo();
                        InvokeDisplaySignalStrengthImage();
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private static void Stop_Reset_D_Counter()
        {
            BaseClass.counterWatch.Stop();
            BaseClass.counterWatch.Reset();
        }

        private void ScrollingEffect()
        {
            try
            {

                if (panelScroll.Location.X <= -panelScroll.Width)
                {
                    panelScroll.Location = new Point(this.Width, panelScroll.Location.Y);
                }
                else
                {
                    panelScroll.Location = new Point(panelScroll.Location.X - 5, panelScroll.Location.Y);
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// while sending the messages, some messages are fail, in that scenario
        /// application has try to send messages for every 30 mins
        /// </summary>
        private void CheckFailSentMessages()
        {
            try
            {
                Boolean isCoachSelected = false;
                isCoachSelected = setRouteControl.ValidateCoaches("FailCall");

                if (isCoachSelected)
                {
                    BaseClass.IsSendOperationInprocess = true;
                    string message = setRouteControl.GenerateSMSMessage(string.Empty);
                   // BaseClass.messageThread = new Thread(new ThreadStart(() => SendFailMessagesProcess(message)));
                   // BaseClass.messageThread.Start();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// After every 30 mins check wether failed messages are exist or not
        /// If failed messages are exist, then send the message
        /// </summary>
        /// <param name="message"></param>
        private void SendFailMessagesProcess(string message)
        {
            try
            {
                for (int i = 0; i < setRouteControl.dgvCoach.Rows.Count; i++)
                {
                    string msgS = string.Empty;
                    if (Convert.ToBoolean(setRouteControl.dgvCoach.Rows[i].Cells["Select"].Value) == true &&
                        setRouteControl.dgvCoach.Rows[i].Cells["Status"].Value.ToString() == "Fail")
                    {
                        msgS = setRouteControl.SendSMS(setRouteControl.dgvCoach.Rows[i].Cells["SIMNo"].Value.ToString(),
                           cboTrainNo.SelectedText, Convert.ToInt32(setRouteControl.dgvCoach.Rows[i].Cells["CoachID"].Value.ToString()),
                            setRouteControl.dgvCoach.Rows[i].Cells["CoachNo"].Value.ToString());

                        setRouteControl.dgvCoach.Rows[i].Cells["Status"].Value = msgS;
                        setRouteControl.dgvCoach.Rows[i].Cells["Response"].Value = "Waiting..";

                        Thread.Sleep(1000);
                    }
                    if (i == setRouteControl.dgvCoach.Rows.Count - 1)
                    {
                        BaseClass.IsSendOperationInprocess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// application closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DisposeObjects();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call when user clicks on Set Route Command(s) menu under Commands menu.
        /// This will display Set Route Panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setRouteControl.dgvCoach.DataSource = null;
                if (Constants.GPRSConnectionStatus == Constants.GPRSConnection.Connected.ToString())
                {
                    setRouteControl.btnConnect.Visible = true;
                }
                else
                {
                    setRouteControl.btnConnect.Visible = false;
                }
                setRouteControl.Visible = true;
                gprsConnectControl.Visible = false;
                setRouteControl.BindTrainNos();
                setRouteControl.cboTrainNo.SelectedIndex = 0;
                setRouteControl.chkAll.Checked = false;
                setRouteControl.BindGrid_withSelect_Deselect_Status_Route();
                setRouteControl.SetControlStatus(true);

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        ///This event will call when user clicks on User Details menu under User menu, 
        ///which will open User Details window where user can check the application User details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                Users frm = new Users();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call when user clicks on Train Details menu under Configuration menu, 
        /// which will open Train Details window where user can check the Route information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trainDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();

                Routes frm = new Routes();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void DisablePanels()
        {
            this.connectToPortControl.Visible = false;
            this.gprsConnectControl.Visible = false;
            this.uploadFileControl.Visible = false;
            this.setRouteControl.Visible = false;
        }

        /// <summary>
        /// This event will call when user clicks on Coach Details menu under Configuration menu, 
        /// which will open Coach Details window where user can check the Coach information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coachDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                Coaches frm = new Coaches();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call when user clicks on Reset Password menu under User menu,
        /// which will open Reset Password window where current login 
        /// user can reset the application login password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                ResetPassword frm = new ResetPassword();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call when user clicks on SMS Mode menu under Configure menu.
        /// This will open Port Settings window, 
        /// where user will Connect OR Disconnect to serial port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EstablishConnection();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Establish the connection with serial port
        /// </summary>
        private void EstablishConnection()
        {
            try
            {
                this.setRouteControl.Visible = false;
                this.gprsConnectControl.Visible = false;
                this.connectToPortControl.Visible = true;
                this.uploadFileControl.Visible = false;

                connectToPortControl.statusMessage = string.Empty;
                connectToPortControl.InvokeCheckConnection();

                connectToPortControl.btnConnectStatus = true;
                connectToPortControl.InvokeConnectDisplay();

                connectToPortControl.btnDisConnectStatus = false;
                connectToPortControl.InvokeDisconnectDisplay();

                Constants.CommunicationMode = BaseClass.CommunicationMode.SMS.ToString();

                gPRSModeToolStripMenuItem.Enabled = BaseClass.GPRSMode;

                connectToPortControl.DefaultConnectedStatus();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GPRSModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Constants.CommunicationMode = BaseClass.CommunicationMode.GPRS.ToString();
                this.setRouteControl.Visible = false;
                gprsConnectControl.Visible = true;

                gprsConnectControl.ConnectivityProcessMsg = string.Empty;
                gprsConnectControl.InvokeGPRSConnectivity();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer2.Start();
                smsResponseDelegate = new SMSResponse(MessagesReadingProcess);
                updateResponseDelegate = new SMSResponse(UpdateGridWithNewMessages);
                chkConnectionDelegate = new CheckConnection(CheckForBrokenConnection);
                chkBrokenConDelegate = new CheckConnection(ConnectBrokenConnection);
                displaySignalStrengthDelegate = new DisplaySigalStrength(updateSignalStrength);

                trainDetailsToolStripMenuItem.Enabled = BaseClass.TrainDetails;
                coachDetailsToolStripMenuItem.Enabled = BaseClass.CoachDetails;
                userDetailsToolStripMenuItem.Enabled = BaseClass.UserDetails;

                selectRouteToolStripMenuItem.Enabled = BaseClass.SelectRoute;
                selectRouteStatusToolStripMenuItem.Enabled = BaseClass.SelectRouteStatus;
                deselectRouteToolStripMenuItem.Enabled = BaseClass.DeselectRoute;
                deselectRouteStatusToolStripMenuItem.Enabled = BaseClass.DeselectRouteStatus;
                routeStatusToolStripMenuItem.Enabled = BaseClass.RouteStatus;
                lblLoginPerson.Text = "Welcome " + Constants.LoginPersonName;

                if (!string.IsNullOrEmpty(BaseClass.SRPortComm.PortName))
                {
                    InvokeResponseSMS();
                }

                #region Resize the control
                // Put values in the variables
                rW = this.Width;
                rH = this.Height;

                fW = this.Width;
                fH = this.Height;
                fX = this.Location.X;
                fY = this.Location.Y;
                // Loop through the controls inside the  form  Container
                foreach (Control c in this.Controls)
                {
                    c.Tag = c.Name + "/" + c.Left + "/" + c.Top + "/" + c.Width + "/" + c.Height + "/" + (float)c.Font.Size;

                    GetControls(c);

                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private static void GetControls(Control c)
        {
            try
            {
                if (c.Controls.Count > 0)
                {
                    foreach (Control j in c.Controls)
                    {
                        j.Tag = j.Name + "/" + j.Left + "/" + j.Top + "/" + j.Width + "/" + j.Height + "/" + (float)j.Font.Size;
                        if (j.Controls.Count > 0)
                        {
                            GetControls(j);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();

                SMSDetails frm = new SMSDetails();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constants.IsModemConnected)
                {
                    selectRouteToolStripMenuItem.Enabled = BaseClass.SelectRoute;
                    selectRouteStatusToolStripMenuItem.Enabled = BaseClass.SelectRouteStatus;
                    deselectRouteToolStripMenuItem.Enabled = BaseClass.DeselectRoute;
                    deselectRouteStatusToolStripMenuItem.Enabled = BaseClass.DeselectRouteStatus;
                    routeStatusToolStripMenuItem.Enabled = BaseClass.RouteStatus;
                }
                else
                {
                    selectRouteToolStripMenuItem.Enabled = false;
                    selectRouteStatusToolStripMenuItem.Enabled = false;
                    deselectRouteToolStripMenuItem.Enabled = false;
                    deselectRouteStatusToolStripMenuItem.Enabled = false;
                    routeStatusToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Click on About menu to call About window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                About frm = new About();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        //     private void MessagesReadingProcess()
        //{
        //    try
        //    {
        //        Thread.Sleep(1000);
        //        DataTable dtSMS = new DataTable();
        //        Constants.CurrentRequest = Constants.Commands.UnRead.ToString();
        //        BaseClass.SRPortComm.ReadMessage();
        //        string trainNo = string.Empty;
        //        int coachId = 0;
        //        string status = string.Empty;
        //        string date = string.Empty;
        //        string tTime = string.Empty;
        //        string dttime = string.Empty;
        //        string[] split = new string[1];
        //        string coachNo = string.Empty;
        //        int Id = 0;

        //        string selectedTrainNo = setRouteControl.cboTrainNo.Text;
        //        string[] splitx = selectedTrainNo.Split('-');
        //        if (splitx.Length == 2)
        //        {
        //            selectedTrainNo = splitx[0].ToString().Trim();
        //        }

        //        if (Constants.listMessages.Count > 0)
        //        {
        //            for (int msgcount = 0; msgcount < Constants.listMessages.Count; msgcount++)
        //            {
        //                SplitMessage msgModel = Constants.listMessages[msgcount];

        //                #region Get Date and Time from message
        //                try
        //                {
        //                    dttime = Constants.listMessages[msgcount].Sent.ToString();
        //                    split = dttime.Split(',');

        //                    if (split.Length == 2)
        //                    {
        //                        string val = split[0];
        //                        int day = Convert.ToInt32(val.Substring(6, 2));
        //                        int mth = Convert.ToInt32(val.Substring(3, 2));
        //                        int yr = Convert.ToInt32("20" + val.Substring(0, 2));
        //                        DateTime dated = new DateTime(yr, mth, day);

        //                        date = dated.ToString("MM/dd/yyyy");
        //                        tTime = split[1].Remove(8, 3);
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Logger.Logger.WriteLog(ex);
        //                }

        //                #endregion

        //                // CHECK SIMNO EXIST
        //                if (BaseClass._BAL.CheckSIMNo(msgModel.Sender.ToString()))
        //                {

        //                    #region Get TrainNo from message
        //                    try
        //                    {
        //                        if (msgModel.Message.Contains("RtNo:"))
        //                        {
        //                            string[] splitmsg = new string[] { "RtNo:" };
        //                            string[] splitColan = msgModel.Message.Split(splitmsg, StringSplitOptions.None);

        //                            if (splitColan.Length >= 2)
        //                            {
        //                                trainNo = splitColan[1].ToString().Trim();

        //                                string[] splitComma = trainNo.Split(',');
        //                                if (splitComma.Length >= 2)
        //                                {
        //                                    trainNo = splitComma[0].ToString();
        //                                }
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Logger.Logger.WriteLog(ex);
        //                    }
        //                    #endregion

        //                    #region Check current application selected command
        //                    string selectedCommand = string.Empty;

        //                    if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
        //                    {
        //                        selectedCommand = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
        //                    }
        //                    else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
        //                    {
        //                        selectedCommand = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
        //                    }
        //                    else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
        //                    {
        //                        selectedCommand = BaseClass.FormNames.Route_Status.ToString().Replace('_', ' ');
        //                    }
        //                    else
        //                    {
        //                        selectedCommand = string.Empty;
        //                    }
        //                    #endregion

        //                    #region Check command from received message
        //                    string command = string.Empty;

        //                    if (msgModel.Message.Contains(" select") || msgModel.Message.Contains(" Select"))
        //                    {
        //                        command = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
        //                    }
        //                    else if (msgModel.Message.Contains("deselect") || msgModel.Message.Contains("Deselect"))
        //                    {
        //                        command = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
        //                    }
        //                    else if (msgModel.Message.Contains("status") || msgModel.Message.Contains("Status"))
        //                    {
        //                        command = BaseClass.FormNames.Route_Status.ToString().Replace('_', ' ');
        //                    }
        //                    else
        //                    {
        //                        command = string.Empty;
        //                    }
        //                    #endregion


        //                    try
        //                    {
        //                        #region code commented
        //                        //if (!string.IsNullOrEmpty(trainNo))
        //                        //{
        //                        //    dtSMS = BaseClass._BAL.GetCurrentUpdates(trainNo, msgModel.Sender.ToString(), command);
        //                        //        DataRow dr = dtSMS.NewRow();
        //                        //        if (dtSMS != null)
        //                        //        {
        //                        //            if (dtSMS.Rows.Count > 0)
        //                        //            {
        //                        //                dr = dtSMS.Rows[0];
        //                        //                coachId = Convert.ToInt32(dr["CoachId"].ToString());
        //                        //                status = dr["Status"].ToString();
        //                        //                Id = Convert.ToInt32(dr["CurrentUpdateId"].ToString());

        //                        //                #region Save data into SMSDetails table and update Lateststatus table into database
        //                        //                BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Update, Id, trainNo, coachId, BaseClass.MessageType.Response.ToString(),
        //                        //                       command, Convert.ToDateTime(date + " " + tTime), Convert.ToDateTime(date + " " + tTime), string.Empty,
        //                        //                         msgModel.Sender.ToString(), msgModel.Message.ToString(),
        //                        //                         status, Convert.ToDateTime(date + " " + tTime),
        //                        //                        msgModel.Message);
        //                        //                #endregion
        //                        //            }
        //                        //        }

        //                        //}
        //                        //else
        //                        //{
        //                        //    dtSMS = BaseClass._BAL.GetCurrentUpdates(trainNo, msgModel.Sender.ToString(), command);
        //                        //    if (dtSMS != null)
        //                        //    {
        //                        //        if (dtSMS.Rows.Count > 0)
        //                        //        {
        //                        //            foreach (DataRow dr in dtSMS.Rows)
        //                        //            {
        //                        //                coachId = Convert.ToInt32(dr["CoachId"].ToString());
        //                        //                status = dr["Status"].ToString();
        //                        //                msgModel.Message = "Route not set";

        //                        //                #region Save data into SMSDetails table and update Lateststatus table into database
        //                        //                BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Update, Id, trainNo, coachId, BaseClass.MessageType.Response.ToString(),
        //                        //                   command, Convert.ToDateTime(date + " " + tTime), Convert.ToDateTime(date + " " + tTime), string.Empty,
        //                        //                     msgModel.Sender.ToString(), msgModel.Message.ToString(),
        //                        //                     status, Convert.ToDateTime(date + " " + tTime),
        //                        //                    msgModel.Message);
        //                        //                #endregion
        //                        //                trainNo = string.Empty;
        //                        //            }
        //                        //        }
        //                        //    }
        //                        //}
        //                        #endregion

        //                       try
        //                       {
        //                            dtSMS = BaseClass._BAL.GetCurrentUpdates(trainNo, msgModel.Sender.ToString(), command);
        //                            DataRow dr = dtSMS.NewRow();
        //                            if (dtSMS != null)
        //                            {
        //                                if (dtSMS.Rows.Count > 0)
        //                                {
        //                                    dr = dtSMS.Rows[0];
        //                                    coachId = Convert.ToInt32(dr["CoachId"].ToString());
        //                                    status = dr["Status"].ToString();
        //                                    Id = Convert.ToInt32(dr["CurrentUpdateId"].ToString());

        //                                    #region Save data into SMSDetails table and update Lateststatus table into database
        //                                    BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Update, Id, trainNo, coachId, BaseClass.MessageType.Response.ToString(),
        //                                           command, Convert.ToDateTime(date + " " + tTime), Convert.ToDateTime(date + " " + tTime), string.Empty,
        //                                             msgModel.Sender.ToString(), msgModel.Message.ToString(),
        //                                             status, Convert.ToDateTime(date + " " + tTime),
        //                                            msgModel.Message);
        //                                    #endregion
        //                                }
        //                            }
        //                       }
        //                       catch (Exception ex)
        //                       {
        //                           Logger.Logger.WriteLog(ex);
        //                       }

        //                        #region Update status in Datagridview

        //                        for (int ix = 0; ix < setRouteControl.dgvCoach.Rows.Count; ix++)
        //                        {
        //                            try
        //                            {
        //                                //if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route) ||
        //                                //    BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route) ||
        //                                //    BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
        //                                //{
        //                                    if (msgModel.Sender.ToString() == setRouteControl.dgvCoach.Rows[ix].Cells["SIMNo"].Value.ToString())
        //                                    {                                                
        //                                        if (!string.IsNullOrEmpty(trainNo) && !string.IsNullOrEmpty(command))
        //                                        {
        //                                            //if (selectedTrainNo != trainNo &&
        //                                            //   command == BaseClass.FormNames.Select_Route.ToString().Replace('_', ' '))
        //                                            //{
        //                                            //    setRouteControl.dgvCoach.Rows[ix].Cells["ResponseTime"].Value = Convert.ToDateTime(date + " " + tTime).ToString("dd/MM/yyyy HH:mm:ss");
        //                                            //    setRouteControl.dgvCoach.Rows[ix].Cells["Response"].Value = trainNo + " route is selected";
        //                                            //}
        //                                            //if (selectedTrainNo != trainNo &&
        //                                            //   command == BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' '))
        //                                            //{
        //                                            //    setRouteControl.dgvCoach.Rows[ix].Cells["ResponseTime"].Value = Convert.ToDateTime(date + " " + tTime).ToString("dd/MM/yyyy HH:mm:ss");
        //                                            //    setRouteControl.dgvCoach.Rows[ix].Cells["Response"].Value = trainNo + " route is deselected";
        //                                            //}
        //                                            //if (selectedTrainNo != trainNo &&
        //                                            //   command == BaseClass.FormNames.Route_Status.ToString().Replace('_', ' '))
        //                                            //{
        //                                            //    setRouteControl.dgvCoach.Rows[ix].Cells["ResponseTime"].Value = Convert.ToDateTime(date + " " + tTime).ToString("dd/MM/yyyy HH:mm:ss");
        //                                            //    setRouteControl.dgvCoach.Rows[ix].Cells["Response"].Value = trainNo + " route is running";
        //                                            //}
        //                                            //else
        //                                            //{
        //                                            

        //                                            if((selectedCommand==command)
        //                                                && selectedTrainNo == trainNo && dtSMS!=null)
        //                                            {
        //                                                if (dtSMS.Rows.Count > 0)
        //                                                {
        //                                                    setRouteControl.dgvCoach.Rows[ix].Cells["ResponseTime"].Value = Convert.ToDateTime(date + " " + tTime).ToString("dd/MM/yyyy HH:mm:ss");
        //                                                    setRouteControl.dgvCoach.Rows[ix].Cells["Response"].Value = msgModel.Message;
        //                                                }
        //                                            }

        //                                        }

        //                                    }
        //                                //}
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                Logger.Logger.WriteLog(ex);
        //                            }
        //                            //}
        //                        }
        //                        #endregion
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Logger.Logger.WriteLog(ex);
        //                    }  
        //                }

        //                setRouteControl.dgvCoach.Columns["Response"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //                setRouteControl.dgvCoach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        //                #region Delete all the received messages from Modem Inbox
        //                Constants.CurrentRequest = Constants.Commands.Delete.ToString();
        //                BaseClass.SRPortComm.DeleteMessage();
        //                #endregion
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Logger.WriteLog(ex);
        //    }
        //}

        private void MessagesReadingProcess()
        {
            try
            {
                Thread.Sleep(1000);

                Constants.CurrentRequest = Constants.Commands.UnRead.ToString();
                BaseClass.SRPortComm.ReadMessage();
                BaseClass.timeCounter = 10000;
                BaseClass.counterWatch.Start();

                // UpdateGridWithNewMessages();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void InvokeGridWithResponse()
        {
            try
            {
               setRouteControl.dgvCoach.Invoke(updateResponseDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void UpdateGridWithNewMessages()
        {
            try
            {
                DataTable dtSMS = new DataTable();
                string trainNo = string.Empty;
                int coachId = 0;
                string status = string.Empty;
                string date = string.Empty;
                string tTime = string.Empty;
                string dttime = string.Empty;
                string[] split = new string[1];
                string coachNo = string.Empty;
                int Id = 0;

                string selectedTrainNo = setRouteControl.cboTrainNo.Text;
                string[] splitx = selectedTrainNo.Split('-');
                if (splitx.Length == 2)
                {
                    selectedTrainNo = splitx[0].ToString().Trim();
                }

                if (Constants.listMessages.Count > 0)
                {
                    for (int msgcount = 0; msgcount < Constants.listMessages.Count; msgcount++)
                    {
                        SplitMessage msgModel = Constants.listMessages[msgcount];

                        #region Get Date and Time from message
                        try
                        {
                            dttime = Constants.listMessages[msgcount].Sent.ToString();
                            split = dttime.Split(',');

                            if (split.Length == 2)
                            {
                                string val = split[0];
                                int day = Convert.ToInt32(val.Substring(6, 2));
                                int mth = Convert.ToInt32(val.Substring(3, 2));
                                int yr = Convert.ToInt32("20" + val.Substring(0, 2));
                                DateTime dated = new DateTime(yr, mth, day);

                                date = dated.ToString("MM/dd/yyyy");
                                tTime = split[1].Remove(8, 3);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Logger.WriteLog(ex);
                        }

                        #endregion

                        // CHECK SIMNO EXIST
                        if (BaseClass._BAL.CheckSIMNo(msgModel.Sender.ToString()))
                        {

                            #region Get TrainNo from message
                            try
                            {
                                if (msgModel.Message.Contains("RtNo:"))
                                {
                                    string[] splitmsg = new string[] { "RtNo:" };
                                    string[] splitColan = msgModel.Message.Split(splitmsg, StringSplitOptions.None);

                                    if (splitColan.Length >= 2)
                                    {
                                        trainNo = splitColan[1].ToString().Trim();

                                        string[] splitComma = trainNo.Split(',');
                                        if (splitComma.Length >= 2)
                                        {
                                            trainNo = splitComma[0].ToString();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Logger.WriteLog(ex);
                            }
                            #endregion

                            #region Check current application selected command
                            string selectedCommand = string.Empty;

                            if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
                            {
                                selectedCommand = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
                            }
                            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route_Status))
                            {
                                selectedCommand = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
                            }
                            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
                            {
                                selectedCommand = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
                            }
                            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route_Status))
                            {
                                selectedCommand = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
                            }
                            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
                            {
                                selectedCommand = BaseClass.FormNames.Route_Status.ToString().Replace('_', ' ');
                            }
                            else
                            {
                                selectedCommand = string.Empty;
                            }
                            #endregion

                            #region Check command from received message
                            string command = string.Empty;

                            if (msgModel.Message.Contains(" select") || msgModel.Message.Contains(" Select"))
                            {
                                command = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
                            }
                            else if (msgModel.Message.Contains("deselect") || msgModel.Message.Contains("Deselect"))
                            {
                                command = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
                            }
                            else if (msgModel.Message.Contains("status") || msgModel.Message.Contains("Status"))
                            {
                                command = BaseClass.FormNames.Route_Status.ToString().Replace('_', ' ');
                            }
                            else
                            {
                                command = string.Empty;
                            }
                            #endregion


                            try
                            {
                                try
                                {
                                    dtSMS = BaseClass._BAL.GetCurrentUpdates(trainNo, msgModel.Sender.ToString(), command);
                                    DataRow dr = dtSMS.NewRow();
                                    if (dtSMS != null)
                                    {
                                        if (dtSMS.Rows.Count > 0)
                                        {
                                            dr = dtSMS.Rows[0];
                                            coachId = Convert.ToInt32(dr["CoachId"].ToString());
                                            status = dr["Status"].ToString();
                                            dr["Response"] = msgModel.Message;
                                            dr["ResponseTime"] = Convert.ToDateTime(date + " " + tTime);
                                            Id = Convert.ToInt32(dr["CurrentUpdateId"].ToString());

                                            #region Save data into SMSDetails table and update Lateststatus table into database
                                            BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Update, Id, trainNo, coachId, BaseClass.MessageType.Response.ToString(),
                                                   command, Convert.ToDateTime(date + " " + tTime), Convert.ToDateTime(date + " " + tTime), string.Empty,
                                                     msgModel.Sender.ToString(), msgModel.Message.ToString(),
                                                     status, Convert.ToDateTime(date + " " + tTime),
                                                    msgModel.Message);
                                            #endregion
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Logger.Logger.WriteLog(ex);
                                }

                                #region Update status in Datagridview

                                for (int ix = 0; ix < setRouteControl.dgvCoach.Rows.Count; ix++)
                                {
                                    try
                                    {
                                        if (msgModel.Sender.ToString() == setRouteControl.dgvCoach.Rows[ix].Cells["SIMNo"].Value.ToString())
                                        {
                                            if (!string.IsNullOrEmpty(trainNo) && !string.IsNullOrEmpty(command))
                                            {
                                                                                         

                                                if ((selectedCommand == command)
                                                    && selectedTrainNo == trainNo && dtSMS != null)
                                                {
                                                    if (dtSMS.Rows.Count > 0)
                                                    {
                                                        setRouteControl.dgvCoach.Rows[ix].Cells["ResponseTime"].Value = Convert.ToDateTime(date + " " + tTime).ToString("dd/MM/yyyy HH:mm:ss");
                                                        setRouteControl.dgvCoach.Rows[ix].Cells["Response"].Value = msgModel.Message;
                                                    }
                                                }

                                            }

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Logger.WriteLog(ex);
                                    }
                                }
                                #endregion


                                #region lblInformation label information
                                DataTable ddd = new DataTable();

                                DataView dv = new DataView(dtSMS);
                                dv.Sort = "ResponseTime desc";
                                ddd = dv.ToTable();


                                int mth = 0;
                                int yr = 0;
                                int day = 0;
                                int hr = 0;
                                int mins = 0;
                                int secs = 0;
                                string tt = string.Empty;
                                DateTime newDate = DateTime.Now;

                                if (ddd.Rows.Count > 0)
                                {
                                    string strDate = ddd.Rows[0]["ResponseTime"].ToString();
                                    if (!string.IsNullOrEmpty(strDate))
                                    {
                                        string[] splitSlash = strDate.Split('/');

                                        if (splitSlash.Length >= 3)
                                        {
                                            mth = Convert.ToInt32(splitSlash[0]);
                                            day = Convert.ToInt32(splitSlash[1]);

                                            string[] splitSpace = splitSlash[2].ToString().Split(' ');

                                            if (splitSpace.Length == 3)
                                            {
                                                yr = Convert.ToInt32(splitSpace[0]);

                                                string[] splitColan = splitSpace[1].ToString().Split(':');

                                                if (splitColan.Length == 3)
                                                {
                                                    hr = Convert.ToInt32(splitColan[0]);
                                                    mins = Convert.ToInt32(splitColan[1]);
                                                    secs = Convert.ToInt32(splitColan[2]);

                                                }
                                                tt = splitSpace[2].ToString();

                                                if (tt == "PM")
                                                {
                                                    if (hr < 12)
                                                    {
                                                        hr = hr + 12;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    newDate = new DateTime(yr, mth, day, hr, mins, secs);



                                    if (!string.IsNullOrEmpty(ddd.Rows[0]["ResponseTime"].ToString()))
                                    {
                                        if (selectedTrainNo == trainNo && (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route)) ||
                                            (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route_Status)))
                                        {
                                            setRouteControl.lblInformation.Text = trainNo + " Route Select Status as on " + newDate.ToString("dd/MM/yyyy HH:mm:ss"); // ddd.Rows[0]["ResponseTime"].ToString();
                                            //setRouteControl.lblInformation.Text = trainNo + " Route Select Status as on " +  ddd.Rows[0]["ResponseTime"].ToString();
                                        }
                                        else if (selectedTrainNo == trainNo && (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route)) ||
                                            (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route_Status)))
                                        {
                                            setRouteControl.lblInformation.Text = trainNo + " Route Deselect Status as on " + newDate.ToString("dd/MM/yyyy HH:mm:ss"); // ddd.Rows[0]["ResponseTime"].ToString();
                                            //setRouteControl.lblInformation.Text = trainNo + " Route Deselect Status as on " + ddd.Rows[0]["ResponseTime"].ToString();
                                        }
                                        else if (selectedTrainNo == trainNo && BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
                                        {
                                            setRouteControl.lblInformation.Text = trainNo + " Route Status as on " + newDate.ToString("dd/MM/yyyy HH:mm:ss"); // ddd.Rows[0]["ResponseTime"].ToString();
                                            // setRouteControl.lblInformation.Text = trainNo + " Route Status as on " +  ddd.Rows[0]["ResponseTime"].ToString();
                                        }
                                    }

                                    else
                                    {
                                        setRouteControl.lblInformation.Text = "COACH DETAILS";
                                    }
                                }
                                #endregion
                            }
                            catch (Exception ex)
                            {
                                Logger.Logger.WriteLog(ex);
                            }
                        }

                        setRouteControl.dgvCoach.Columns["Response"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        setRouteControl.dgvCoach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    }
                }

                #region Delete all the received messages from Modem Inbox
                Constants.CurrentRequest = Constants.Commands.Delete.ToString();
                BaseClass.SRPortComm.DeleteMessage();
                BaseClass.timeCounter = 10000;
                BaseClass.counterWatch.Start();
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

     

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void selectRouteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                setRouteControl.FormName = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
                BaseClass.SelectedMenuCommand = Convert.ToInt32(BaseClass.FormNames.Select_Route);
                DisplaySetRoute();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void selectRouteStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setRouteControl.FormName = BaseClass.FormNames.Select_Route_Status.ToString().Replace('_', ' ');
                BaseClass.SelectedMenuCommand = Convert.ToInt32(BaseClass.FormNames.Select_Route_Status);
                DisplaySetRoute();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void deselectRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setRouteControl.FormName = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
                BaseClass.SelectedMenuCommand = Convert.ToInt32(BaseClass.FormNames.Deselect_Route);
                DisplaySetRoute();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void deselectRouteStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setRouteControl.FormName = BaseClass.FormNames.Deselect_Route_Status.ToString().Replace('_', ' ');
                BaseClass.SelectedMenuCommand = Convert.ToInt32(BaseClass.FormNames.Deselect_Route_Status);
                DisplaySetRoute();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void routeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setRouteControl.FormName = BaseClass.FormNames.Route_Status.ToString().Replace('_', ' ');
                BaseClass.SelectedMenuCommand = Convert.ToInt32(BaseClass.FormNames.Route_Status);
                DisplaySetRoute();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void DisplaySetRoute()
        {
            try
            {
                setRouteControl.dgvCoach.DataSource = null;
                this.connectToPortControl.Visible = false;
                this.gprsConnectControl.Visible = false;
                this.uploadFileControl.Visible = false;
                this.setRouteControl.Visible = true;


                if (Constants.GPRSConnectionStatus == Constants.GPRSConnection.Connected.ToString())
                {
                    setRouteControl.btnConnect.Visible = true;
                    setRouteControl.btnSend.Enabled = false;
                }
                else
                {
                    setRouteControl.btnConnect.Visible = false;
                    setRouteControl.btnSend.Enabled = true;
                }
                setRouteControl.BindTrainNos();
                setRouteControl.cboTrainNo.SelectedItem = 0;
                setRouteControl.chkAll.Checked = false;
                setRouteControl.SetControlStatus(true);

                if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
                {
                    setRouteControl.BindGrid_withSelect_Deselect_Status_Route();
                }
                else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route_Status))
                {
                    setRouteControl.BindGrid_withSelectRouteStatus();
                    setRouteControl.panelStatus.Visible = false;
                }
                else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
                {
                    setRouteControl.BindGrid_withSelect_Deselect_Status_Route();
                }
                else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route_Status))
                {
                    setRouteControl.BindGrid_withDeSelectRouteStatus();
                    setRouteControl.panelStatus.Visible = false;
                }
                else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
                {
                    setRouteControl.BindGrid_withSelect_Deselect_Status_Route();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                ScrollingEffect();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        #region Desktop screen COMPATIBILITY
        /// <summary>
        /// Resizing all Child controls of User control
        /// </summary>
        public void ResizeAllChild()
        {
            try
            {
                string[] s = null;

                if (this.Width < fW || this.Height < fH)
                {
                    this.Width = (int)fW;
                    this.Height = (int)fH;
                }

                foreach (Control c in this.Controls)
                {
                    try
                    {
                        double rRW = (this.Width > rW ? this.Width / (rW) : rW / this.Width);
                        double rRH = (this.Height > rH ? this.Height / (rH) : rH / this.Height);

                        s = c.Tag.ToString().Split('/');

                        if (c.Name == s[0].ToString())
                        {
                            //Use integer casting
                            c.Width = (int)(Convert.ToInt32(s[3]) * rRW);
                            c.Height = (int)(Convert.ToInt32(s[4]) * rRH);
                            c.Left = (int)(Convert.ToInt32(s[1]) * rRW);
                            c.Top = (int)(Convert.ToInt32(s[2]) * rRH);

                            float fsize = 0;
                            if (this.WindowState != FormWindowState.Maximized)
                            {
                                fsize = (float)(Convert.ToDouble(s[5]));
                            }
                            else
                            {
                                if (c.Name == "lblCompanyName" || c.Name == "lblConnectionStatus")
                                {
                                    fsize = (float)(Convert.ToDouble(s[5]) * (rRH));
                                }
                                else
                                {
                                    fsize = (float)(Convert.ToDouble(s[5]) * (rRH - 0.2));
                                }

                            }

                            c.Font = new Font(c.Font.FontFamily, fsize, c.Font.Style);
                        }

                        if (c.Controls.Count > 0)
                        {
                            ResizeControls(s, c, rRW, rRH);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Logger.WriteLog(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Resizing the child controls excluding Ax controls and also Relocatiing Ax controls
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <param name="rRW"></param>
        /// <param name="rRH"></param>
        private void ResizeControls(string[] s, Control c, double rRW, double rRH)
        {
            try
            {
                foreach (Control ctrl in c.Controls)
                {
                    try
                    {
                        s = ctrl.Tag.ToString().Split('/');
                        if (c.Name == "picBrowser")
                        {
                            // ResizeGridview();
                        }
                        if (ctrl.Name == s[0].ToString())
                        {
                            //Use integer casting
                            ctrl.Width = (int)(Convert.ToInt32(s[3]) * rRW);
                            ctrl.Height = (int)(Convert.ToInt32(s[4]) * rRH);
                            ctrl.Left = (int)(Convert.ToInt32(s[1]) * rRW);
                            ctrl.Top = (int)(Convert.ToInt32(s[2]) * rRH);

                            float fsize = 0;
                            if (this.WindowState != FormWindowState.Maximized)
                            {
                                fsize = (float)(Convert.ToDouble(s[5]));
                            }
                            else
                            {
                                if (c.Name == "lblCompanyName" || c.Name == "lblConnectionStatus")
                                {
                                    fsize = (float)(Convert.ToDouble(s[5]) * (rRH));
                                }
                                else
                                {
                                    fsize = (float)(Convert.ToDouble(s[5]) * (rRH - 0.2));
                                }
                            }

                            ctrl.Font = new Font(ctrl.Font.FontFamily, fsize, ctrl.Font.Style);

                        }

                        if (ctrl.Controls.Count > 0)
                        {
                            ResizeControls(s, ctrl, rRW, rRH);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Logger.WriteLog(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void ResizeGridview()
        {
            try
            {
                setRouteControl.dgvCoach.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
                setRouteControl.dgvCoach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                // setRouteControl.dgvCoach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewcell.AutoSize;
                setRouteControl.dgvCoach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
                setRouteControl.dgvCoach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }
        #endregion

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                Contactus frm = new Contactus();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                var screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

                this.Hide();
                if (this.WindowState == FormWindowState.Maximized)
                {
                    var width = screen.Width;
                    var height = screen.Height;
                    this.Location = new Point(5, 5);
                    this.Width = width;
                    this.Height = height - 60;
                }
                else
                {
                    var width = fW;
                    var height = fH;
                    this.Location = new Point(fX, fY);
                    this.Width = width;
                    this.Height = height;
                }

                ResizeAllChild();
                this.Show();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void gPRSModeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                gPRSModeToolStripMenuItem.Enabled = BaseClass.GPRSMode;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gPRSModeToolStripMenuItem.Enabled = BaseClass.GPRSMode;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void configurationToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                gPRSModeToolStripMenuItem.Enabled = BaseClass.GPRSMode;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DisablePanels();
                string helpFilePath = Application.StartupPath + "\\Help\\PIS UserManual.PDF";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "PIS UserManual.PDF";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("File Downloading Completed", "PIS");
                }

                string[] split = saveDialog.FileName.Split('\\');
                string fileName = split[(split.Length - 1)].ToString();
                string folderName = string.Empty;
                if (split.Length > 1)
                {
                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        if (string.IsNullOrEmpty(folderName))
                        {
                            folderName = split[i].ToString() + "\\";
                        }
                        else
                        {
                            folderName = folderName + split[i].ToString() + "\\";
                        }
                    }
                }
                System.IO.File.Copy(helpFilePath, System.IO.Path.Combine(folderName, fileName), true);


            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void uploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.setRouteControl.Visible = false;
            this.gprsConnectControl.Visible = false;
            this.connectToPortControl.Visible = false;
            this.uploadFileControl.Visible = true;
        }

    }
}
