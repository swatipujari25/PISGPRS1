using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PISGPRS
{
    public partial class Coaches : Form
    {
        #region Member Variables
        int currentTrainID = 0;
        List<string> listSIMNo = new List<string>();
        List<string> listCoachNo = new List<string>();
        List<string> listPISUnitNo = new List<string>();
        Dictionary<int, string> listTrainNo = new Dictionary<int, string>();
        int currentOperation = 0;
        int noOfCoaches = 0;
        #endregion

        /// <summary>
        /// Initialize the form objects
        /// </summary>
        public Coaches()
        {
            try
            {
            InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Parameterized constructor
        /// This form will call with the parameters
        /// </summary>
        /// <param name="trainID"></param>
        /// <param name="nCoaches"></param>
        public Coaches(int trainID, int nCoaches)
        {
            try
            {
            currentTrainID = trainID;
            noOfCoaches = nCoaches;
            InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call, at the time of current form load
        /// Here Binding with default information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Coaches_Load(object sender, EventArgs e)
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                BindTrainNos();
                cboTrainNo.SelectedValue = currentTrainID;
                BindGrid();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call, when user clicks on Save button
        /// it will save data into database
        /// </summary>
        /// <param name="sender">sender is the object, which raise the event</param>
        /// <param name="e">it contains event data, which provides a value to use for events</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (ValidateCoach())
                    {

                        int coachID = 0;
                        if (!string.IsNullOrEmpty(lblCoachID.Text))
                        {
                            coachID = Convert.ToInt32(lblCoachID.Text);
                        }

                        string trainNo = cboTrainNo.Text;
                        string[] split = trainNo.Split('-');
                        if (split.Length == 2)
                        {
                            trainNo = split[0].ToString().Trim();
                        }


                        int result = BaseClass._BAL.SaveCoachDetails(currentOperation, coachID, txtCoachNo.Text.Trim(),
                           Convert.ToInt32(cboTrainNo.SelectedValue), trainNo, txtPISUnitNo.Text.Trim(), "+91" + txtSimNo.Text.Trim(),
                            txtHardwareID.Text.Trim());

                        if (result == 1)
                        {
                            MessageBox.Show("Coach details saved Successfully");
                            BindGrid();
                            //  ResetCoachDetails();                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Logger.WriteLog(ex);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Before saving the data into database, check for is user entered data is valid or not
        /// </summary>
        /// <returns></returns>
        public Boolean ValidateCoach()
        {
            Boolean isValid = true;
            lblMsg.Text = string.Empty;
            try
            {
                // if (cboTrainNo.SelectedValue =="0")
                if (cboTrainNo.SelectedIndex == listTrainNo.Count - 1)
                {
                    isValid = false;
                    lblMsg.Text = "Select Train No";
                    cboTrainNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtCoachNo.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Coach No";
                    txtCoachNo.Focus();
                }
                else if (listCoachNo.Contains(txtCoachNo.Text.Trim()) && string.IsNullOrEmpty(lblCoachID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Coach No already exist";
                    txtCoachNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtPISUnitNo.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter PIS Unit No";
                    txtPISUnitNo.Focus();
                }
                else if (listPISUnitNo.Contains(txtPISUnitNo.Text.Trim()) && string.IsNullOrEmpty(lblCoachID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "PIS Unit No already exist";
                    txtPISUnitNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtHardwareID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Hardware No";
                    txtHardwareID.Focus();
                }
                else if (string.IsNullOrEmpty(txtSimNo.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter SIM No";
                    txtSimNo.Focus();
                }
                else if (listSIMNo.Contains("+91" + txtSimNo.Text.Trim()) && string.IsNullOrEmpty(lblCoachID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "SIM No already exist";
                    txtSimNo.Focus();
                }
                else if (noOfCoaches <= dgvCoach.Rows.Count && string.IsNullOrEmpty(lblCoachID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "No of Coaches limit is " + noOfCoaches.ToString() + ", It should not be exceed";
                }


            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

            return isValid;
        }

        /// <summary>
        /// This event will call, when user clicks on New button
        /// It will clear all the textboxes and it will show default data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ResetCoachDetails();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

        }

        /// <summary>
        /// This method will Clear all the input/ textboxes 
        /// </summary>
        private void ResetCoachDetails()
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                lblCoachID.Text = string.Empty;
                //  cboTrainNo.SelectedIndex = listTrainNo.Count-1;
                txtCoachNo.Text = string.Empty;
                txtPISUnitNo.Text = string.Empty;
                txtHardwareID.Text = string.Empty;
                txtSimNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call, when user clicks on Cancel button
        /// which will close the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This event will call, when user clicks on row/ cell of datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCoach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //call for Delete the record
                if (e.ColumnIndex == dgvCoach.Columns.Count - 1)
                {
                    string delMsg = "Are you sure to delete " + dgvCoach.Rows[e.RowIndex].Cells["CoachNo"].Value + " Coach No ?";
                    DialogResult result = MessageBox.Show(delMsg, "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        DeleteCoach(e.RowIndex);
                    }

                }
                //Call for Edit the record
                else if (e.ColumnIndex == dgvCoach.Columns.Count - 2)
                {
                    DisplayRecordsInDetail(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Delete selected coach
        /// </summary>
        /// <param name="rowIndex">selected rowindex </param>
        public void DeleteCoach(int rowIndex)
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Delete;

                if (rowIndex >= 0)
                {
                    int result = BaseClass._BAL.SaveCoachDetails(currentOperation,
                        Convert.ToInt32(dgvCoach.Rows[rowIndex].Cells["CoachID"].Value.ToString()),
                        dgvCoach.Rows[rowIndex].Cells["CoachNo"].Value.ToString(),
                        Convert.ToInt32(dgvCoach.Rows[rowIndex].Cells["TrainID"].Value.ToString()),
                       string.Empty,
                        dgvCoach.Rows[rowIndex].Cells["PISUnitID"].Value.ToString(),
                        dgvCoach.Rows[rowIndex].Cells["SIMNo"].Value.ToString(),
                        dgvCoach.Rows[rowIndex].Cells["HardwareID"].Value.ToString());

                    if (result == 1)
                    {
                        MessageBox.Show("Coach Details Deleted Successfully");
                        BindGrid();
                        ResetCoachDetails();
                    }
                    else
                    {
                        MessageBox.Show("Delete operation fail");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// When user click on Edit, the correspondent coach details will 
        /// bind to the textboxes        
        /// </summary>
        /// <param name="rowIndex"></param>
        public void DisplayRecordsInDetail(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    currentOperation = (int)BaseClass.CRUDOperations.Update;
                    lblCoachID.Text = dgvCoach.Rows[rowIndex].Cells["CoachID"].Value.ToString();
                    cboTrainNo.SelectedValue = Convert.ToInt32(dgvCoach.Rows[rowIndex].Cells["TrainID"].Value.ToString());
                    txtCoachNo.Text = dgvCoach.Rows[rowIndex].Cells["CoachNo"].Value.ToString();
                    txtPISUnitNo.Text = dgvCoach.Rows[rowIndex].Cells["PISUnitID"].Value.ToString();
                    txtSimNo.Text = dgvCoach.Rows[rowIndex].Cells["SIMNo"].Value.ToString().Remove(0, 3);
                    txtHardwareID.Text = dgvCoach.Rows[rowIndex].Cells["HardwareID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Get the existing train details and Bind TrainNos to combobox
        /// </summary>
        private void BindTrainNos()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BaseClass._BAL.GetAllTrainDetails();

                listTrainNo = dt.AsEnumerable().ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
                    row => (row.Field<string>(1) + " - " + row.Field<string>(2)));

                listTrainNo.Add(0, "Select");
                cboTrainNo.DataSource = new BindingSource(listTrainNo, null);
                cboTrainNo.ValueMember = "key";
                cboTrainNo.DisplayMember = "value";
                cboTrainNo.SelectedIndex = listTrainNo.Count - 1;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Get the train details for selected train
        /// </summary>
        public void GetTrainDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BaseClass._BAL.GetTrainDetailsByTrainID(Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key));
                if (dt.Rows.Count > 0)
                {
                    noOfCoaches = Convert.ToInt32(dt.Rows[0]["NoOfCoaches"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Based on train selection, bind datagridview with correspondent data
        /// </summary>
        public void BindGrid()
        {
            try
            {
                if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                {
                    DataTable dt = new DataTable();
                    dt = BaseClass._BAL.GetCoachDetailsByTrainID(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key);
                    listSIMNo = dt.AsEnumerable().Select(r => r.Field<string>("SIMNo")).ToList();
                    listCoachNo = dt.AsEnumerable().Select(r => r.Field<string>("CoachNo")).ToList();
                    listPISUnitNo = dt.AsEnumerable().Select(r => r.Field<string>("PISUnitID")).ToList();

                    if (dt.Rows.Count > 0)
                    {

                        dt = BaseClass._BAL.AutoNumberedTable(dt);
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;
                        dgvCoach.DataSource = dt;

                        DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
                        dgvLink.HeaderText = "Edit";
                        dgvLink.Name = "Edit";
                        dgvLink.LinkColor = Color.Blue;
                        dgvLink.TrackVisitedState = true;
                        dgvLink.Text = "Edit";
                        dgvLink.UseColumnTextForLinkValue = true;
                        dgvCoach.Columns.Add(dgvLink);

                        DataGridViewLinkColumn dgvLink1 = new DataGridViewLinkColumn();
                        dgvLink1.HeaderText = "Delete";
                        dgvLink1.Name = "Delete";
                        dgvLink1.LinkColor = Color.Blue;
                        dgvLink1.TrackVisitedState = true;
                        dgvLink1.Text = "Delete";
                        dgvLink1.UseColumnTextForLinkValue = true;
                        dgvCoach.Columns.Add(dgvLink1);

                        dgvCoach.Columns["SNo"].Width = 50;
                        dgvCoach.Columns["CoachNo"].Width = 100;
                        dgvCoach.Columns["PISUnitID"].Width = 100;
                        dgvCoach.Columns["HardwareID"].Width = 100;
                        dgvCoach.Columns["SIMNo"].Width = 100;
                        dgvCoach.Columns["Edit"].Width = 60;
                        dgvCoach.Columns["Delete"].Width = 60;

                        dgvCoach.Columns["CoachNo"].HeaderText = "Coach No";
                        dgvCoach.Columns["PISUnitID"].HeaderText = "PIS Unit No";
                        dgvCoach.Columns["HardwareID"].HeaderText = "Hardware No";
                        dgvCoach.Columns["SIMNo"].HeaderText = "SIM No";

                        dgvCoach.Columns["CoachID"].Visible = false;
                        dgvCoach.Columns["TrainID"].Visible = false;
                        dgvCoach.Columns["Status"].Visible = false;
                        dgvCoach.Columns["Response"].Visible = false;
                        dgvCoach.Columns["TrainNo"].Visible = false;
                        dgvCoach.Columns["SentTime"].Visible = false;
                        dgvCoach.Columns["ResponseTime"].Visible = false;

                        for (int i = 0; i < dgvCoach.Columns.Count; i++)
                        {
                            dgvCoach.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    else
                    {
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Restrict the user about to enter Invalid data in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSimNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    lblMsg.Text = "Please enter valid SIM No";
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// This event will call, when user selects the Train
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTrainNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                GetTrainDetails();
                BindGrid();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }
    }
}
