using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logger;

namespace PISGPRS
{
    public partial class Routes : Form
    {
        int trainID = 0;
        int currentOperation = 0;
        int noOfCoaches = 0;
        List<string> listTrainNo = new List<string>();

        public Routes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the form
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ResetTrainDetails();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        /// <summary>
        /// Clear all the input boxes, to enter new Train details.
        /// </summary>
        private void ResetTrainDetails()
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                lblTrainID.Text = string.Empty;
                txtTrainNo.Text = string.Empty;
                txtTrainName.Text = string.Empty;
                txtNoofCoaches.Text = string.Empty;
                txtSource.Text = string.Empty;
                txtDestination.Text = string.Empty;
                txtDistance.Text = string.Empty;
                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;
                txtNoofHours.Text = string.Empty;
                txtVia.Text = string.Empty;
                txtLatitude.Text = string.Empty;
                txtLongitude.Text = string.Empty;
                lnkAddCoaches.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void lnkAddCoaches_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                trainID = Convert.ToInt32(lblTrainID.Text);
                noOfCoaches = Convert.ToInt32(txtNoofCoaches.Text);
                Coaches frm = new Coaches(trainID, noOfCoaches);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void Routes_Load(object sender, EventArgs e)
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                lnkAddCoaches.Enabled = false;
                BindGrid();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void BindGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = BaseClass._BAL.GetAllTrainDetails();

                if (dt.Rows.Count > 0)
                {
                    dt = BaseClass._BAL.AutoNumberedTable(dt);

                    listTrainNo = dt.AsEnumerable().Select(r => r.Field<string>("TrainNo")).ToList();

                    dgvRoute.Columns.Clear();
                    dgvRoute.DataSource = null;
                    dgvRoute.DataSource = dt;

                    DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
                    dgvLink.HeaderText = "Edit";
                    dgvLink.Name = "Edit";
                    dgvLink.LinkColor = Color.Blue;
                    dgvLink.TrackVisitedState = true;
                    dgvLink.Text = "Edit";
                    dgvLink.UseColumnTextForLinkValue = true;
                    dgvRoute.Columns.Add(dgvLink);

                    DataGridViewLinkColumn dgvLink1 = new DataGridViewLinkColumn();
                    dgvLink1.HeaderText = "Delete";
                    dgvLink1.Name = "Delete";
                    dgvLink1.LinkColor = Color.Blue;
                    dgvLink1.TrackVisitedState = true;
                    dgvLink1.Text = "Delete";
                    dgvLink1.UseColumnTextForLinkValue = true;
                    dgvRoute.Columns.Add(dgvLink1);

                    dgvRoute.Columns["SNo"].Width = 50;
                    dgvRoute.Columns["TrainNo"].Width = 60;
                    dgvRoute.Columns["TrainName"].Width = 200;
                    dgvRoute.Columns["NoOfCoaches"].Width = 80;
                    dgvRoute.Columns["Source"].Width = 120;
                    dgvRoute.Columns["Destination"].Width = 120;
                    dgvRoute.Columns["Via"].Width = 120;
                    dgvRoute.Columns["Distance"].Width = 80;
                    dgvRoute.Columns["FromTime"].Width = 80;
                    dgvRoute.Columns["ToTime"].Width = 80;
                    dgvRoute.Columns["NoOfHours"].Width = 80;                   
                    dgvRoute.Columns["Edit"].Width = 60;
                    dgvRoute.Columns["Delete"].Width = 60;

                    dgvRoute.Columns["TrainNo"].HeaderText = "Train No";
                    dgvRoute.Columns["TrainName"].HeaderText = "Train Name";
                    dgvRoute.Columns["NoOfCoaches"].HeaderText = "No of Coaches";
                    dgvRoute.Columns["FromTime"].HeaderText = "From Time";
                    dgvRoute.Columns["ToTime"].HeaderText = "To Time";
                    dgvRoute.Columns["NoOfHours"].HeaderText = "No of Hours";

                    dgvRoute.Columns["TrainId"].Visible = false;
                    dgvRoute.Columns["Distance"].Visible = false;
                    dgvRoute.Columns["FromTime"].Visible = false;
                    dgvRoute.Columns["ToTime"].Visible = false;
                    dgvRoute.Columns["NoOfHours"].Visible = false;
                    dgvRoute.Columns["Via"].Visible = false;

                    for (int i = 0; i < dgvRoute.Columns.Count; i++)
                    {
                        dgvRoute.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void txtNoofHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    lblMsg.Text = "Please enter valid No of Hours";
                    e.Handled = true;
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
        }

        private void txtTrainNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    lblMsg.Text = "Please enter valid Train No";
                    e.Handled = true;
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
        }

        private void txtNoofCoaches_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    lblMsg.Text = "Please enter valid No of Coaches";
                    e.Handled = true;
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
        }

        private void txtDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    lblMsg.Text = "Please enter valid Distance";
                    e.Handled = true;
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTrain())
                {
                    if (!string.IsNullOrEmpty(lblTrainID.Text))
                    {
                        trainID = Convert.ToInt32(lblTrainID.Text);
                    }
                    lnkAddCoaches.Enabled = true;
                    noOfCoaches = Convert.ToInt32(txtNoofCoaches.Text);
                    int hrs=0;
                    if (!string.IsNullOrEmpty(txtNoofHours.Text))
                    {
                        hrs = Convert.ToInt32(txtNoofHours.Text.Trim());
                    }

                    int dis=0;
                    if(!string.IsNullOrEmpty(txtDistance.Text))
                    {dis=Convert.ToInt32(txtDistance.Text.Trim());}

                  
                    int result = BaseClass._BAL.SaveTrainDetails(currentOperation, trainID, txtTrainNo.Text.Trim(),
                        txtTrainName.Text.Trim(), Convert.ToInt32(txtNoofCoaches.Text.Trim()), txtSource.Text.Trim(),
                        txtDestination.Text.Trim(),dis , dtpFrom.Value.ToString("HH:mm:ss"),
                        dtpTo.Value.ToString("HH:mm:ss"),
                   hrs , txtVia.Text.Trim());

                    if (result == 1)
                    {
                        MessageBox.Show("Train/Route details saved Successfully");
                        BindGrid();
                        //ResetTrainDetails();

                        if (currentOperation == (int)BaseClass.CRUDOperations.Insert)
                        {
                            lnkAddCoaches.Enabled = true;
                        }

                        for (int i = 0; i < dgvRoute.Rows.Count; i++)
                        {
                            if (dgvRoute.Rows[i].Cells["TrainNo"].Value.ToString() == txtTrainNo.Text.Trim())
                            {
                                lblTrainID.Text = dgvRoute.Rows[i].Cells["TrainID"].Value.ToString();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Insertion Fail");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public Boolean ValidateTrain()
        {
            Boolean isValid = true;
            lblMsg.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtTrainNo.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Train No";
                    txtTrainNo.Focus();
                }
                else if (txtTrainNo.Text.Length < 5)
                {
                    isValid = false;
                    lblMsg.Text = "Train No should be 5 to 6 digits";
                    txtTrainNo.Focus();
                }
                else if (listTrainNo.Contains(txtTrainNo.Text.Trim()) && string.IsNullOrEmpty(lblTrainID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Train No already exist";
                    txtTrainNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtTrainName.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Train Name";
                    txtTrainName.Focus();
                }
                else if (string.IsNullOrEmpty(txtNoofCoaches.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter No of Coaches";
                    txtNoofCoaches.Focus();
                }
                else if (txtNoofCoaches.Text == "0")
                {
                    isValid = false;
                    lblMsg.Text = "Invalid No of Coaches";
                    txtNoofCoaches.Focus();
                }
                else if (string.IsNullOrEmpty(txtSource.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Source";
                    txtSource.Focus();
                }
                else if (string.IsNullOrEmpty(txtDestination.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Destination";
                    txtDestination.Focus();
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

            return isValid;
        }

        private void dgvRoute_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvRoute.Columns.Count-1)
                {

                    string delMsg = "Are you sure to delete " + dgvRoute.Rows[e.RowIndex].Cells["TrainNo"].Value + " Train No ?";
                    DialogResult result = MessageBox.Show(delMsg, "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        DeleteRoute(e.RowIndex);
                    }

                }
                else if (e.ColumnIndex == dgvRoute.Columns.Count - 2)
                {
                    DisplayRecordsInDetail(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void DisplayRecordsInDetail(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    currentOperation = (int)BaseClass.CRUDOperations.Update;
                    lblTrainID.Text = dgvRoute.Rows[rowIndex].Cells["TrainID"].Value.ToString();
                    txtTrainNo.Text = dgvRoute.Rows[rowIndex].Cells["TrainNo"].Value.ToString();
                    txtTrainName.Text = dgvRoute.Rows[rowIndex].Cells["TrainName"].Value.ToString();
                    txtNoofCoaches.Text = dgvRoute.Rows[rowIndex].Cells["NoOfCoaches"].Value.ToString();
                    txtSource.Text = dgvRoute.Rows[rowIndex].Cells["Source"].Value.ToString();
                    txtDestination.Text = dgvRoute.Rows[rowIndex].Cells["Destination"].Value.ToString();
                    txtDistance.Text = dgvRoute.Rows[rowIndex].Cells["Distance"].Value.ToString();
                    dtpFrom.Value = Convert.ToDateTime(dgvRoute.Rows[rowIndex].Cells["FromTime"].Value);
                    dtpTo.Value = Convert.ToDateTime(dgvRoute.Rows[rowIndex].Cells["ToTime"].Value);
                    txtNoofHours.Text = dgvRoute.Rows[rowIndex].Cells["NoOfHours"].Value.ToString();
                    txtVia.Text = dgvRoute.Rows[rowIndex].Cells["Via"].Value.ToString();
                    txtLongitude.Text = dgvRoute.Rows[rowIndex].Cells["Longitude"].Value.ToString();
                    txtLatitude.Text = dgvRoute.Rows[rowIndex].Cells["Latitude"].Value.ToString();
                    lnkAddCoaches.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void DeleteRoute(int rowIndex)
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Delete;
                if (rowIndex >= 0)
                {
                    int result = BaseClass._BAL.SaveTrainDetails(currentOperation,
                        Convert.ToInt32(dgvRoute.Rows[rowIndex].Cells["TrainID"].Value.ToString()),
                        dgvRoute.Rows[rowIndex].Cells["TrainNo"].Value.ToString(),
                        dgvRoute.Rows[rowIndex].Cells["TrainName"].Value.ToString(),
                   Convert.ToInt32(dgvRoute.Rows[rowIndex].Cells["NoOfCoaches"].Value.ToString()),
                        dgvRoute.Rows[rowIndex].Cells["Source"].Value.ToString(),
                        dgvRoute.Rows[rowIndex].Cells["Destination"].Value.ToString(),
                      Convert.ToInt32(dgvRoute.Rows[rowIndex].Cells["Distance"].Value.ToString()),
                           dgvRoute.Rows[rowIndex].Cells["FromTime"].Value.ToString(),
                              dgvRoute.Rows[rowIndex].Cells["ToTime"].Value.ToString(),
                              Convert.ToInt32(dgvRoute.Rows[rowIndex].Cells["NoOfHours"].Value.ToString()),
                               dgvRoute.Rows[rowIndex].Cells["Via"].Value.ToString());

                    if (result == 1)
                    {
                        MessageBox.Show("Train/Route Details Deleted Successfully");
                        BindGrid();
                        ResetTrainDetails();
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

        private void txtLatitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
                {
                    lblMsg.Text = string.Empty;
                    e.Handled = false;
                }
                else
                {
                    lblMsg.Text = "Please enter valid Latitude";
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void txtLongitude_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
                {
                    lblMsg.Text = string.Empty;
                    e.Handled = false;
                }
                else
                {
                    lblMsg.Text = "Please enter valid Longitude";
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

    }
}
