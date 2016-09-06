using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Logger;
using Common;
using Communication;

namespace PISGPRS
{
    public partial class ucSetRoute : UserControl
    {
        public ucSetRoute()
        {
            InitializeComponent();
        }

        #region MEMBER VARIABLES AND PROPERTIES
        List<string> listSIMNo = new List<string>();
        Dictionary<int, string> listTrainNo = new Dictionary<int, string>();
        //  private int rowIndex = 0;
        private string smsResult = string.Empty;

        private DateTime smsSentTime = DateTime.Now;
        public string msg = string.Empty;
        private string _formName = string.Empty;
        DataTable dtGridData = null;

        public string FormName
        {
            set { lblName.Text = value; }
        }
        #endregion

        #region DELEGATES
        public delegate void DisplayStatus();
        public DisplayStatus StatusDelegate;

        public delegate void UpdateGridStatus();
        public UpdateGridStatus UpdateGridStatusDelegate;

        public UpdateGridStatus GridResizeDelegate;

        public UpdateGridStatus UpdateIPAddressDelegate;
        public UpdateGridStatus UpdateResponseMsgDelegate;

        /// <summary>
        /// Update text for lblMsg label
        /// </summary>
        private void ShowStatus()
        {
            try
            {
                lblMsg.Text = msg;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update text for lblMsg label
        /// </summary>
        public void InvokeStatus()
        {
            try
            {
                lblMsg.Invoke(StatusDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update grid data
        /// </summary>
        public void InvokeGrid()
        {
            try
            {
                dgvCoach.Invoke(UpdateGridStatusDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Update grid data
        /// </summary>
        private void UpdateSMSResponseToGrid()
        {
            try
            {
                if (Constants.CurrentRequest != Constants.Commands.ConnectToClient.ToString())
                {
                    if (!Constants.IsConnectionBreak)
                    {
                        dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["Status"].Value = Constants.MessageSendStatus;
                    }

                    if (!String.IsNullOrEmpty(Constants.MessageSendStatus))
                    {
                        if (Constants.MessageSendStatus != "Fail")
                        {
                            dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["Response"].Value = "Waiting..";
                            dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["SentTime"].Value = smsSentTime.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        else
                        {
                            dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["Response"].Value = string.Empty;
                        }                        
                    }
                }

                UpdateIntoDatabase(dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["SIMNo"].Value.ToString(), Constants.currentTrainNo,
                             Convert.ToInt32(dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["CoachID"].Value.ToString()),
                              dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["CoachNo"].Value.ToString());
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// update grid with IP address when modem connected in GPRS mode
        /// </summary>
        public void InvokeClientIPAddress()
        {
            try
            {
                dgvCoach.Invoke(UpdateIPAddressDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// update grid with IP address when modem connected in GPRS mode
        /// </summary>
        private void UpdateIPAddressToGrid()
        {
            try
            {
                for (int ix = 0; ix < dgvCoach.Rows.Count; ix++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dgvCoach.Rows[ix].Cells["Select"].Value) == true)
                        {

                            dgvCoach.Rows[ix].Cells["IPAddress"].Value = lblClientIPAddress.Text;

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
        /// update grid with Response message
        /// </summary>
        public void InvokeResponseMessageOfGrid()
        {
            try
            {
                dgvCoach.Invoke(UpdateResponseMsgDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// update grid with Response message
        /// </summary>
        private void UpdateResponseMessageToGrid()
        {
            try
            {
                for (int ix = 0; ix < dgvCoach.Rows.Count; ix++)
                {
                    try
                    {
                        if (Convert.ToBoolean(dgvCoach.Rows[ix].Cells["Select"].Value) == true)
                        {
                            dgvCoach.Rows[ix].Cells["ResponseTime"].Value = Convert.ToDateTime(DateTime.Now.Date + " " + DateTime.Now.TimeOfDay).ToString("dd/MM/yyyy HH:mm:ss");
                            dgvCoach.Rows[ix].Cells["Response"].Value = Constants.GPRSReceivedData;
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
        #endregion

        private void SetRoute_Load(object sender, EventArgs e)
        {
            try
            {
                StatusDelegate = new DisplayStatus(ShowStatus);
                UpdateGridStatusDelegate = new UpdateGridStatus(UpdateSMSResponseToGrid);
                UpdateIPAddressDelegate = new UpdateGridStatus(UpdateIPAddressToGrid);
                UpdateResponseMsgDelegate = new UpdateGridStatus(UpdateResponseMessageToGrid);

                BindTrainNos();
                BindSearchBy();
                cboTrainNo.MouseWheel += new MouseEventHandler(cboTrainNo_MouseWheel);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void cboTrainNo_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                //Cast the MouseEventArgs to HandledMouseEventArgs
                HandledMouseEventArgs mwe = (HandledMouseEventArgs)e;

                //Indicate that this event was handled
                //(prevents the event from being sent to its parent control)
                mwe.Handled = true;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Get all trains list and Bind to Combobox
        /// </summary>
        public void BindTrainNos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BaseClass._BAL.GetAllTrainDetails();

                listTrainNo = dt.AsEnumerable().ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
                    row => (row.Field<string>(1) + " - " + row.Field<string>(2)));

                listTrainNo.Add(0, "Select");
                cboTrainNo.DataSource = new BindingSource(listTrainNo.OrderBy(m => m.Key), null);
                cboTrainNo.ValueMember = "key";
                cboTrainNo.DisplayMember = "value";
                cboTrainNo.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Bind Default search fields to Combobox
        /// </summary>
        public void BindSearchBy()
        {
            try
            {
                List<string> list = new List<string>();
                list.Add("Select");
                list.Add("Coach No");
                list.Add("SIM No");
                list.Add("Status");
                list.Add("Response");

                cboSearchBy.DataSource = list;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Bind Default grid with checkbox, where user can start processing with
        /// SMS and GPRS communication
        /// </summary>
        public void BindGrid_withSelect_Deselect_Status_Route()
        {
            try
            {
                dtGridData = new DataTable();
                this.chkAll.Visible = true;
                if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
                {
                    this.panelStatus.Visible = true;
                }
                else
                {
                    this.panelStatus.Visible = false;
                }

                this.panelButtons.Visible = true;

                chkAll.Checked = false;

                if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                {
                    string trainNo = cboTrainNo.Text;
                    string[] split = trainNo.Split('-');
                    if (split.Length == 2)
                    {
                        trainNo = split[0].ToString().Trim();
                    }

                    dtGridData = BaseClass._BAL.GetCoachDetailsByTrainID(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key);
                    dtGridData.Columns.Add("IPAddress");

                    if (dtGridData.Rows.Count > 0)
                    {
                        listSIMNo = dtGridData.AsEnumerable().Select(r => r.Field<string>("SIMNo")).ToList();

                        dtGridData = BaseClass._BAL.AutoNumberedTable(dtGridData);
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;
                        dgvCoach.DataSource = dtGridData;

                        BindGridWithSelectColumn();

                    }
                    else
                    {
                        dgvCoach.DataSource = dtGridData;
                    }
                    lblInformation.Text = "Train No " + trainNo + " Coach Details";

                }
                else
                {
                    dgvCoach.Columns.Clear();
                    dgvCoach.DataSource = null;
                    lblInformation.Text = "COACH DETAILS";
                }

                if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
                {
                    this.panelStatus.Visible = true;
                }
                else
                {
                    this.panelStatus.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Bind grid with Previous Select Route Details
        /// </summary>
        public void BindGrid_withSelectRouteStatus()
        {
            try
            {
                this.chkAll.Visible = false;
                this.panelButtons.Visible = false;
                chkAll.Checked = false;

                dtGridData = new DataTable();
                string trainNo = cboTrainNo.Text;
                string[] split = trainNo.Split('-');
                if (split.Length == 2)
                {
                    trainNo = split[0].ToString().Trim();
                }

                if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                {
                    dtGridData = BaseClass._BAL.GetCoachDetailsByTrainIDForMessages(trainNo, ((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key, BaseClass.FormNames.Select_Route.ToString().Replace('_', ' '));

                    if (dtGridData.Rows.Count > 0)
                    {
                        listSIMNo = dtGridData.AsEnumerable().Select(r => r.Field<string>("SIMNo")).ToList();

                        dtGridData = BaseClass._BAL.AutoNumberedTable(dtGridData);
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;

                        dgvCoach.DataSource = dtGridData;

                        dgvCoach.Columns["SNo"].Width = 50;
                        dgvCoach.Columns["CoachNo"].Width = 120;
                        dgvCoach.Columns["SIMNo"].Width = 150;
                        dgvCoach.Columns["SentTime"].Width = 120;
                        dgvCoach.Columns["Status"].Width = 120;
                        dgvCoach.Columns["ResponseTime"].Width = 120;
                        dgvCoach.Columns["Response"].Width = 250;

                        dgvCoach.Columns["CoachNo"].HeaderText = "Coach No";
                        dgvCoach.Columns["SIMNo"].HeaderText = "SIM No";
                        dgvCoach.Columns["SentTime"].HeaderText = "Sent Time";
                        dgvCoach.Columns["ResponseTime"].HeaderText = "Response Time";

                        // dgvCoach.Columns["SNo"].Visible = false;
                        dgvCoach.Columns["CoachID"].Visible = false;
                        dgvCoach.Columns["TrainID"].Visible = false;
                        dgvCoach.Columns["TrainNo"].Visible = false;

                        for (int i = 0; i < dgvCoach.Columns.Count; i++)
                        {
                            dgvCoach.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        dgvCoach.Columns["SNo"].DisplayIndex = 0;
                        dgvCoach.Columns["CoachNo"].DisplayIndex = 1;
                        dgvCoach.Columns["TrainNo"].DisplayIndex = 2;
                        dgvCoach.Columns["SIMNo"].DisplayIndex = 3;
                        dgvCoach.Columns["SentTime"].DisplayIndex = 4;
                        dgvCoach.Columns["Status"].DisplayIndex = 5;
                        dgvCoach.Columns["ResponseTime"].DisplayIndex = 6;
                        dgvCoach.Columns["Response"].DisplayIndex = 7;


                        dgvCoach.Columns["Response"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dgvCoach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        #region lblInformation label information
                        DataTable ddd = new DataTable();

                        DataView dv = new DataView(dtGridData);
                        dv.Sort = "ResponseTime desc";
                        ddd = dv.ToTable();

                        //DateTime newDate = Convert.ToDateTime(ddd.Rows[0]["ResponseTime"].ToString());
                        if (ddd.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(ddd.Rows[0]["ResponseTime"].ToString()))
                            {
                                //lblInformation.Text = trainNo + " Route Select Status as on " + newDate.ToString("dd/MM/yyyy HH:mm:ss"); // ddd.Rows[0]["ResponseTime"].ToString();
                                lblInformation.Text = trainNo + " Route Select Status as on " + ddd.Rows[0]["ResponseTime"].ToString();
                            }

                            else
                            {
                                lblInformation.Text = "COACH DETAILS";
                            }
                        }
                        #endregion


                    }
                    else
                    {
                        dgvCoach.DataSource = dtGridData;
                        lblInformation.Text = "COACH DETAILS";
                    }
                }
                else
                {
                    dgvCoach.Columns.Clear();
                    dgvCoach.DataSource = null;
                    lblInformation.Text = "COACH DETAILS";
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Bind grid with Previous Deselect Route Details
        /// </summary>
        public void BindGrid_withDeSelectRouteStatus()
        {
            try
            {
                this.chkAll.Visible = false;
                this.panelButtons.Visible = false;
                chkAll.Checked = false;

                dtGridData = new DataTable();
                if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                {
                    string trainNo = cboTrainNo.Text;
                    string[] split = trainNo.Split('-');
                    if (split.Length == 2)
                    {
                        trainNo = split[0].ToString().Trim();
                    }

                    dtGridData = BaseClass._BAL.GetCoachDetailsByTrainIDForMessages(trainNo, ((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key, BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' '));

                    if (dtGridData.Rows.Count > 0)
                    {
                        listSIMNo = dtGridData.AsEnumerable().Select(r => r.Field<string>("SIMNo")).ToList();

                        dtGridData = BaseClass._BAL.AutoNumberedTable(dtGridData);
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;

                        dgvCoach.DataSource = dtGridData;

                        dgvCoach.Columns["SNo"].Width = 50;
                        dgvCoach.Columns["CoachNo"].Width = 120;
                        dgvCoach.Columns["SIMNo"].Width = 150;
                        dgvCoach.Columns["SentTime"].Width = 120;
                        dgvCoach.Columns["Status"].Width = 120;
                        dgvCoach.Columns["ResponseTime"].Width = 120;
                        dgvCoach.Columns["Response"].Width = 250;

                        dgvCoach.Columns["CoachNo"].HeaderText = "Coach No";
                        dgvCoach.Columns["SIMNo"].HeaderText = "SIM No";
                        dgvCoach.Columns["SentTime"].HeaderText = "Sent Time";
                        dgvCoach.Columns["ResponseTime"].HeaderText = "Response Time";

                        //  dgvCoach.Columns["SNo"].Visible = false;
                        dgvCoach.Columns["CoachID"].Visible = false;
                        dgvCoach.Columns["TrainID"].Visible = false;
                        dgvCoach.Columns["TrainNo"].Visible = false;

                        for (int i = 0; i < dgvCoach.Columns.Count; i++)
                        {
                            dgvCoach.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }

                        dgvCoach.Columns["SNo"].DisplayIndex = 0;
                        dgvCoach.Columns["CoachNo"].DisplayIndex = 1;
                        dgvCoach.Columns["TrainNo"].DisplayIndex = 2;
                        dgvCoach.Columns["SIMNo"].DisplayIndex = 3;
                        dgvCoach.Columns["SentTime"].DisplayIndex = 4;
                        dgvCoach.Columns["Status"].DisplayIndex = 5;
                        dgvCoach.Columns["Response"].DisplayIndex = 6;
                        dgvCoach.Columns["ResponseTime"].DisplayIndex = 7;

                        dgvCoach.Columns["Response"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dgvCoach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        #region lblInformation label information
                        DataTable ddd = new DataTable();

                        DataView dv = new DataView(dtGridData);
                        dv.Sort = "ResponseTime desc";
                        ddd = dv.ToTable();
                        // DateTime newDate = Convert.ToDateTime(ddd.Rows[0]["ResponseTime"].ToString());

                        if (ddd.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(ddd.Rows[0]["ResponseTime"].ToString()))
                            {
                                //                                lblInformation.Text = trainNo + " Route Deselect Status as on " + newDate.ToString("dd/MM/yyyy HH:mm:ss"); // ddd.Rows[0]["ResponseTime"].ToString();
                                lblInformation.Text = trainNo + " Route Deselect Status as on " + ddd.Rows[0]["ResponseTime"].ToString();
                            }

                            else
                            {
                                lblInformation.Text = "COACH DETAILS";
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        dgvCoach.DataSource = dtGridData;
                        lblInformation.Text = "COACH DETAILS";
                    }
                }
                else
                {
                    dgvCoach.Columns.Clear();
                    dgvCoach.DataSource = null;
                    lblInformation.Text = "COACH DETAILS";
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Bind grid with Previous Route Status Details
        /// </summary>
        public void BindGrid_withPreviousRouteStatus()
        {
            try
            {
                this.chkAll.Visible = false;
                this.panelButtons.Visible = false;
                chkAll.Checked = false;
                dtGridData = new DataTable();

                if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                {
                    string trainNo = cboTrainNo.Text;
                    string[] split = trainNo.Split('-');
                    if (split.Length == 2)
                    {
                        trainNo = split[0].ToString().Trim();
                    }

                    dtGridData = BaseClass._BAL.GetCoachDetailsByTrainIDForMessages(trainNo, ((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key, BaseClass.FormNames.Route_Status.ToString().Replace('_', ' '));

                    if (dtGridData.Rows.Count > 0)
                    {
                        listSIMNo = dtGridData.AsEnumerable().Select(r => r.Field<string>("SIMNo")).ToList();

                        dtGridData = BaseClass._BAL.AutoNumberedTable(dtGridData);
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;

                        dgvCoach.DataSource = dtGridData;

                        dgvCoach.Columns["SNo"].Width = 50;
                        dgvCoach.Columns["CoachNo"].Width = 120;
                        dgvCoach.Columns["SIMNo"].Width = 150;
                        dgvCoach.Columns["Status"].Width = 120;
                        dgvCoach.Columns["Response"].Width = 250;

                        dgvCoach.Columns["CoachNo"].HeaderText = "Coach No";
                        dgvCoach.Columns["SIMNo"].HeaderText = "SIM No";

                        // dgvCoach.Columns["SNo"].Visible = false;
                        dgvCoach.Columns["CoachID"].Visible = false;
                        dgvCoach.Columns["TrainID"].Visible = false;
                        dgvCoach.Columns["TrainNo"].Visible = false;

                        for (int i = 0; i < dgvCoach.Columns.Count; i++)
                        {
                            dgvCoach.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        dgvCoach.Columns["SNo"].DisplayIndex = 0;
                        dgvCoach.Columns["CoachNo"].DisplayIndex = 1;
                        dgvCoach.Columns["TrainNo"].DisplayIndex = 2;
                        dgvCoach.Columns["SIMNo"].DisplayIndex = 3;
                        dgvCoach.Columns["SentTime"].DisplayIndex = 4;
                        dgvCoach.Columns["Status"].DisplayIndex = 5;
                        dgvCoach.Columns["ResponseTime"].DisplayIndex = 6;
                        dgvCoach.Columns["Response"].DisplayIndex = 7;

                        dgvCoach.Columns["Response"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dgvCoach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        #region lblInformation label information
                        DataTable ddd = new DataTable();

                        DataView dv = new DataView(dtGridData);
                        dv.Sort = "ResponseTime desc";
                        ddd = dv.ToTable();
                        //  DateTime newDate = Convert.ToDateTime(ddd.Rows[0]["ResponseTime"].ToString());

                        if (ddd.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(ddd.Rows[0]["ResponseTime"].ToString()))
                            {
                                //lblInformation.Text = trainNo + " Route Status as on " + newDate.ToString("dd/MM/yyyy HH:mm:ss"); // ddd.Rows[0]["ResponseTime"].ToString();
                                lblInformation.Text = trainNo + " Route Status as on " + ddd.Rows[0]["ResponseTime"].ToString();
                            }

                            else
                            {
                                lblInformation.Text = "COACH DETAILS";
                            }
                        }
                        #endregion

                    }
                    else
                    {
                        dgvCoach.DataSource = dtGridData;
                        lblInformation.Text = "COACH DETAILS";
                    }
                }
                else
                {
                    dgvCoach.Columns.Clear();
                    dgvCoach.DataSource = null;
                    lblInformation.Text = "COACH DETAILS";
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will fire, when user clicks on any record of grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCoach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvCoach.Columns.Count - 1)
                {

                    if (Convert.ToBoolean(dgvCoach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                        dgvCoach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        chkAll.Checked = false;
                    }
                    else
                    {
                        dgvCoach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will fire, when user selects Train No from combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTrainNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ProcessWithGridDataBinding();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Based on train selection Bind the Data
        /// </summary>
        private void ProcessWithGridDataBinding()
        {
            cboSearchBy.SelectedIndex = 0;
            txtSearchText.Text = string.Empty;

            if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
            {
                BindGrid_withSelect_Deselect_Status_Route();
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route_Status))
            {
                BindGrid_withSelectRouteStatus();
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
            {
                BindGrid_withSelect_Deselect_Status_Route();
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route_Status))
            {
                BindGrid_withDeSelectRouteStatus();
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
            {
                if (rbtnLatest.Checked)
                {
                    BindGrid_withSelect_Deselect_Status_Route();
                }
                else if (rbtnPrevious.Checked)
                {
                    BindGrid_withPreviousRouteStatus();
                }
            }

            if (dtGridData.Rows.Count > 0)
            {
                gpSearch.Enabled = true;
            }
            else
            {
                gpSearch.Enabled = false;
            }
        }

        /// <summary>
        /// This event will fire, when user check or uncheck the checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvCoach.Rows.Count; i++)
                {
                    if (chkAll.Checked)
                    {
                        dgvCoach.Rows[i].Cells["Select"].Value = true;
                    }
                    else
                    {
                        dgvCoach.Rows[i].Cells["Select"].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will fire, when user clicks on Cancel button
        /// Which will stop the SMS sending process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // this.Visible = false;

                string Msg = "Are you sure to Cancel SMS Sending Process?";
                DialogResult result = MessageBox.Show(Msg, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Constants.IsProcessCancelled = true;
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will fire, when user clicks on Send button
        /// which will start the SMS sending process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string Msg = string.Empty;
                BaseClass.dgvRowIndex = 0;

                for (int i = 0; i < dgvCoach.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvCoach.Rows[i].Cells["Select"].Value) == true)
                    {
                        BaseClass.ListSelectedDgvRows.Add(i);
                    }
                }

                if (Constants.IsModemConnected)
                {
                    if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                    {
                        if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
                        {
                            Msg = "Are you sure to Select " + GetTrainNofromCombobox() + " Train No ?";
                            DialogResult result = MessageBox.Show(Msg, "Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                ProcessRoute(BaseClass.SMSRequestFrom.Send.ToString());
                            }
                        }
                        else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
                        {
                            Msg = "Are you sure to Deselect " + GetTrainNofromCombobox() + " Train No ?";
                            DialogResult result = MessageBox.Show(Msg, "Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                ProcessRoute(BaseClass.SMSRequestFrom.Send.ToString());
                            }
                        }
                        else
                        {
                            ProcessRoute(BaseClass.SMSRequestFrom.Send.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select TrainNo");
                    }
                }
                else
                {
                    MessageBox.Show("Please check Modem connection");
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Start sending SMS
        /// </summary>
        private void ProcessRoute(string requestFrom)
        {
            try
            {                

                Boolean isCoachSelected = false;

                isCoachSelected = ValidateCoaches(string.Empty);

                if (isCoachSelected)
                {
                    string trainNo = cboTrainNo.Text;
                    string[] split = trainNo.Split('-');
                    if (split.Length == 2)
                    {
                        trainNo = split[0].ToString().Trim();
                    }

                    if (requestFrom == BaseClass.SMSRequestFrom.Connect.ToString())
                    {
                        msg = "Please wait, Connecting to Coach....";
                        InvokeStatus();
                    }
                    else
                    {
                        msg = "Please wait, SMS sending process inprogress....";
                        InvokeStatus();
                    }
                    SetControlStatus(false);
                    BaseClass.IsSendOperationInprocess = true;

                    Constants.SMSMessage = GenerateSMSMessage(requestFrom);
                    Constants.currentTrainNo = trainNo;
                    if (BaseClass.ListSelectedDgvRows.Count != 0)
                    {
                        Constants.MessageSendStatus = string.Empty;
                        SMSProcess();
                    }
                }
                else
                {
                    if (dgvCoach.Rows.Count > 0)
                    {
                        MessageBox.Show("Please Select Coach");

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Check Coach(s) selected or not
        /// </summary>
        /// <param name="callFrom"></param>
        /// <returns></returns>
        public Boolean ValidateCoaches(string callFrom)
        {
            BaseClass.CurrentProcess = Constants.Commands.MessageSend.ToString();
            Boolean isCoachSelected = false;
            try
            {

                for (int i = 0; i < dgvCoach.Rows.Count; i++)
                {
                    if (callFrom == "FailCall")
                    {
                        if (dgvCoach.Rows[i].Cells["Select"].Value != null)
                        {
                            if (dgvCoach.Rows[i].Cells["Select"].Value.ToString() == "True")
                            {
                                isCoachSelected = true;
                            }
                        }
                    }
                    else
                    {
                        if (chkAll.Checked)
                        {
                            isCoachSelected = true;
                            dgvCoach.Rows[i].Cells["Status"].Value = string.Empty;
                            dgvCoach.Rows[i].Cells["Response"].Value = string.Empty;
                            dgvCoach.Rows[i].Cells["SentTime"].Value = string.Empty;
                            dgvCoach.Rows[i].Cells["ResponseTime"].Value = string.Empty;
                        }
                        else
                        {
                            if (dgvCoach.Rows[i].Cells["Select"].Value != null)
                            {
                                if (dgvCoach.Rows[i].Cells["Select"].Value.ToString() == "True")
                                {
                                    dgvCoach.Rows[i].Cells["Status"].Value = string.Empty;
                                    dgvCoach.Rows[i].Cells["Response"].Value = string.Empty;
                                    dgvCoach.Rows[i].Cells["SentTime"].Value = string.Empty;
                                    dgvCoach.Rows[i].Cells["ResponseTime"].Value = string.Empty;
                                    isCoachSelected = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return isCoachSelected;
        }

        /// <summary>
        /// Generate Message to send SMS
        /// </summary>
        /// <returns></returns>
        public string GenerateSMSMessage(string requestFrom)
        {
            string message = string.Empty;
            string trainNo = GetTrainNofromCombobox();

            try
            {
                if (requestFrom == BaseClass.SMSRequestFrom.Connect.ToString())
                {
                    Constants.CurrentCommandRequest = Constants.Commands.ConnectToClient.ToString();
                }
                else
                {
                    if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
                    {
                        Constants.CurrentCommandRequest = Constants.Commands.SelectRoute.ToString();

                        message = "route " + trainNo;
                    }
                    else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
                    {
                        Constants.CurrentCommandRequest = Constants.Commands.DeselectRoute.ToString();

                        message = "deselect";
                    }
                    else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
                    {
                        Constants.CurrentCommandRequest = Constants.Commands.RouteStatus.ToString();

                        message = "status";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return message;
        }

        /// <summary>
        /// Retrive Selected trainNo from Combobox
        /// </summary>
        /// <returns></returns>
        private string GetTrainNofromCombobox()
        {
            string trainNo = string.Empty;
            try
            {
                trainNo = cboTrainNo.Text.ToString();
                string[] split = trainNo.Split('-');

                if (split.Length == 2)
                {
                    trainNo = split[0].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return trainNo;
        }

        /// <summary>
        /// Send the SMS
        /// </summary>
        public void SMSProcess()
        {
            try
            {
                if (Constants.MessageSendStatus == Constants.MessageSendProcess.Fail.ToString() && BaseClass.SentMsgCount <= 3)
                {
                    Constants.MessageSendStatus = string.Empty;
                    SendSMS(dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["SIMNo"].Value.ToString(),
                        Constants.currentTrainNo,
                           Convert.ToInt32(dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["CoachID"].Value.ToString()),
                           dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["CoachNo"].Value.ToString());

                    //Start timer
                    BaseClass.timeCounter = 40000;
                    BaseClass.counterWatch.Start();
                    BaseClass.SentMsgCount = BaseClass.SentMsgCount + 1;
                }
                else
                {
                    if (BaseClass.ListSelectedDgvRows.Count > 0)
                    {
                        BaseClass.SentMsgCount = 1;
                        BaseClass.dgvRowIndex = BaseClass.ListSelectedDgvRows[0];

                        SendSMS(dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["SIMNo"].Value.ToString(),
                            Constants.currentTrainNo,
                               Convert.ToInt32(dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["CoachID"].Value.ToString()),
                               dgvCoach.Rows[BaseClass.dgvRowIndex].Cells["CoachNo"].Value.ToString());

                        //Start timer
                        BaseClass.timeCounter = 40000;
                        BaseClass.counterWatch.Start();

                        BaseClass.ListSelectedDgvRows.Remove(BaseClass.dgvRowIndex);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

        }

        /// <summary>
        /// Send SMS to connect with GPRS
        /// </summary>
        /// <param name="phoneno"></param>
        /// <param name="trainNo"></param>
        /// <param name="coachId"></param>
        /// <param name="coachNo"></param>
        /// <returns></returns>
        public string SendSMS(string phoneno, string trainNo, int coachId, string coachNo)
        {
            string statusmsg = string.Empty;
            try
            {
                smsSentTime = DateTime.Now;
                SplitMessage outmsg = new SplitMessage();
                string responseMsg = string.Empty;

                ////While connected to GPRS mode
                if (Constants.GPRSConnectionStatus == Constants.GPRSConnection.Connected.ToString()
                    && string.IsNullOrEmpty(Constants.GPRSClientIPAddress))
                {
                    string commandMsg = Constants.SMSMessage;
                    Constants.SMSMessage = "Connect GPRS IP:" + Constants.GPRSServerIPAddress + ", PortNo:" + Constants.GPRSPortNo;
                    BaseClass.SRPortComm.SendMessage(phoneno);
                }
                else if (Constants.ServerStatus == Constants.GPRSConnection.Listening.ToString()
                    && !string.IsNullOrEmpty(Constants.GPRSClientIPAddress))
                {
                    BaseClass.SRPortComm.SendGPRSMessage(Constants.SMSMessage);
                }
                //In SMS mode
                else
                {
                    BaseClass.SRPortComm.SendMessage(phoneno);
                }



            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return statusmsg;
        }

        /// <summary>
        /// Update the SMS details into database
        /// </summary>
        /// <param name="phoneno"></param>
        /// <param name="trainNo"></param>
        /// <param name="coachId"></param>
        /// <param name="coachNo"></param>
        private void UpdateIntoDatabase(string phoneno, string trainNo, int coachId, string coachNo)
        {
            string currentCommand = string.Empty;
            string responseMsg = string.Empty;

            if (Constants.MessageSendStatus == Constants.MessageSendProcess.Msg_Sent.ToString().Replace('_', ' '))
            {
                responseMsg = "Waiting ..";
            }


            if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route))
            {
                currentCommand = BaseClass.FormNames.Select_Route.ToString().Replace('_', ' ');
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route_Status))
            {
                currentCommand = BaseClass.FormNames.Select_Route_Status.ToString().Replace('_', ' ');
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route))
            {
                currentCommand = BaseClass.FormNames.Deselect_Route.ToString().Replace('_', ' ');
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route_Status))
            {
                currentCommand = BaseClass.FormNames.Deselect_Route_Status.ToString().Replace('_', ' ');
            }
            else if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status))
            {
                currentCommand = BaseClass.FormNames.Route_Status.ToString().Replace('_', ' ');
            }

            BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Insert, 0, trainNo, coachId, BaseClass.MessageType.Request.ToString(),
             currentCommand, smsSentTime, smsSentTime, coachNo,
              phoneno, Constants.SMSMessage, Constants.MessageSendStatus, null, responseMsg);
            Constants.MessageSendStatus = string.Empty;


            if (BaseClass.ListSelectedDgvRows.Count == 0)
            {
                msg = string.Empty;
                InvokeStatus();
                SetControlStatus(true);
                BaseClass.CurrentProcess = string.Empty;
                BaseClass.IsSendOperationInprocess = false;
            }
        }

        public void SetControlStatus(bool status)
        {
            try
            {
                this.dgvCoach.Enabled = status;
                this.chkAll.Enabled = status;
                this.btnSend.Enabled = status;
                this.btnClose.Enabled = status;
                this.panelStatus.Enabled = status;
                gpSearch.Enabled = status;
                InvokeStatus();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void rbtnPrevious_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid_withPreviousRouteStatus();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void rbtnLatest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid_withSelect_Deselect_Status_Route();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGridData.Rows.Count > 0)
                {
                    if (IsValidSearch())
                    {
                        DataView dv = new DataView(dtGridData);

                        if (cboSearchBy.Text == "Coach No")
                        {
                            dv.RowFilter = "CoachNo like '%" + txtSearchText.Text + "%'";
                        }
                        else if (cboSearchBy.Text == "SIM No")
                        {
                            dv.RowFilter = "SIMNo like '%" + txtSearchText.Text + "%'";
                        }
                        else if (cboSearchBy.Text == "Status")
                        {
                            dv.RowFilter = "Status like '%" + txtSearchText.Text + "%'";
                        }
                        else if (cboSearchBy.Text == "Response")
                        {
                            dv.RowFilter = "Response like '%" + txtSearchText.Text + "%'";
                        }

                        DataTable dtShow = new DataTable();
                        dtShow = dv.ToTable();
                        if (dtShow != null)
                        {
                            if (dtShow.Rows.Count > 0)
                            {
                                dtShow = BaseClass._BAL.AutoNumberedTable(dtShow);
                                dgvCoach.Columns.Clear();
                                dgvCoach.DataSource = null;
                                dgvCoach.DataSource = dtShow;

                                if (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Select_Route) ||
                                    (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Deselect_Route)) ||
                                    (BaseClass.SelectedMenuCommand == Convert.ToInt32(BaseClass.FormNames.Route_Status) && rbtnLatest.Checked))
                                {
                                    BindGridWithSelectColumn();
                                }

                            }
                            else
                            {
                                dgvCoach.DataSource = null;
                                MessageBox.Show("Data not found");
                            }
                        }
                        else
                        {
                            dgvCoach.DataSource = null;
                            MessageBox.Show("Data not found");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select TrainNo");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void BindGridWithSelectColumn()
        {
            DataGridViewCheckBoxColumn dgvLink = new DataGridViewCheckBoxColumn();
            dgvLink.HeaderText = "Select";
            dgvLink.Name = "Select";
            dgvLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLink.FlatStyle = FlatStyle.Standard;
            dgvLink.TrueValue = "1";
            dgvLink.FalseValue = "0";
            dgvCoach.Columns.Add(dgvLink);

            dgvCoach.Columns["SNo"].Width = 50;
            dgvCoach.Columns["Select"].Width = 80;
            dgvCoach.Columns["CoachNo"].Width = 120;
            dgvCoach.Columns["SIMNo"].Width = 120;
            dgvCoach.Columns["IPAddress"].Width = 120;
            dgvCoach.Columns["SentTime"].Width = 120;
            dgvCoach.Columns["Status"].Width = 120;
            dgvCoach.Columns["ResponseTime"].Width = 120;
            dgvCoach.Columns["Response"].Width = 280;
            dgvCoach.Columns["CoachNo"].HeaderText = "Coach No";
            dgvCoach.Columns["SIMNo"].HeaderText = "SIM No";

            dgvCoach.Columns["CoachID"].Visible = false;
            dgvCoach.Columns["TrainID"].Visible = false;
            dgvCoach.Columns["TrainNo"].Visible = false;
            dgvCoach.Columns["PISUnitID"].Visible = false;
            dgvCoach.Columns["HardwareID"].Visible = false;
            if (Constants.GPRSConnectionStatus == Constants.GPRSConnection.Connected.ToString())
            {
                dgvCoach.Columns["IPAddress"].Visible = true;
            }
            else
            {
                dgvCoach.Columns["IPAddress"].Visible = false;
            }

            for (int i = 0; i < dgvCoach.Columns.Count; i++)
            {
                dgvCoach.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCoach.Columns["SNo"].DisplayIndex = 0;
            dgvCoach.Columns["Select"].DisplayIndex = 1;
            dgvCoach.Columns["CoachNo"].DisplayIndex = 2;
            dgvCoach.Columns["TrainNo"].DisplayIndex = 3;
            dgvCoach.Columns["SIMNo"].DisplayIndex = 4;
            dgvCoach.Columns["IPAddress"].DisplayIndex = 5;
            dgvCoach.Columns["SentTime"].DisplayIndex = 6;
            dgvCoach.Columns["Status"].DisplayIndex = 7;
            dgvCoach.Columns["ResponseTime"].DisplayIndex = 8;
            dgvCoach.Columns["Response"].DisplayIndex = 9;


            dgvCoach.Columns["Response"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCoach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private Boolean IsValidSearch()
        {
            Boolean valid = true;
            try
            {
                if (cboSearchBy.Text == "Select")
                {
                    valid = false;
                    MessageBox.Show("Select Search By value");
                }
                else if (string.IsNullOrEmpty(txtSearchText.Text))
                {
                    valid = false;
                    MessageBox.Show("Enter Search Text value");
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

            return valid;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessWithGridDataBinding();
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
                string Msg = string.Empty;

                for (int i = 0; i < dgvCoach.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvCoach.Rows[i].Cells["Select"].Value) == true)
                    {
                        BaseClass.ListSelectedDgvRows.Add(i);
                    }
                }

                if (Constants.IsModemConnected)
                {
                    if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                    {
                        Msg = "Are you sure to Connect to " + GetTrainNofromCombobox() + " Train No ?";
                        DialogResult result = MessageBox.Show(Msg, "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ProcessRoute(BaseClass.SMSRequestFrom.Connect.ToString());
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select TrainNo");
                    }
                }
                else
                {
                    MessageBox.Show("Please check Modem connection");
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }
    }
}
