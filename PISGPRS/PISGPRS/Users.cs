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
    public partial class Users : Form
    {

        List<string> listRoles = new List<string>();
        List<string> listUserName = new List<string>();
        List<string> listContactNo = new List<string>();
        int currentOperation = 0;

        public Users()
        {
            InitializeComponent();
        }        

        public void BindRoles()
        {
            try
            {
                cboRole.Items.Clear();
                cboRole.Items.Add(BaseClass.Roles.Admin.ToString());
                cboRole.Items.Add(BaseClass.Roles.User.ToString());
                cboRole.SelectedItem = "User";
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public Boolean ValidateUser()
        {
            Boolean isValid = true;
            lblMsg.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter First Name";
                    txtFirstName.Focus();
                }
                else if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Last Name";
                    txtLastName.Focus();
                }
                else if (string.IsNullOrEmpty(txtContactNo.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Contact No";
                    txtContactNo.Focus();
                }
                else if (txtContactNo.Text.Length < 10)
                {
                    isValid = false;
                    lblMsg.Text = "Contact No should be 10 Characters";
                    txtContactNo.Focus();
                }
                else if (listContactNo.Contains(txtContactNo.Text.Trim()) && string.IsNullOrEmpty(lblUserID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Contact No already exist";
                    txtContactNo.Focus();
                }
                else if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter UserName";
                    txtUserName.Focus();
                }
                else if (listUserName.Contains(txtUserName.Text.Trim()) && string.IsNullOrEmpty(lblUserID.Text))
                {
                    isValid = false;
                    lblMsg.Text = "UserName already exist";
                    txtUserName.Focus();
                }
                else if (string.IsNullOrEmpty(mtxtPassword.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Password";
                    mtxtPassword.Focus();
                }
                else if (mtxtPassword.Text.Length > 15 || mtxtPassword.Text.Length < 3)
                {
                    isValid = false;
                    lblMsg.Text = "Password should be 3 to 15 Characters";
                    mtxtPassword.Focus();
                }
                else if (string.IsNullOrEmpty(mtxtConfirmPwd.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Confirm Password";
                    mtxtConfirmPwd.Focus();
                }
                else if (mtxtConfirmPwd.Text != mtxtPassword.Text)
                {
                    isValid = false;
                    lblMsg.Text = "Password and Confirm Password should be same";
                    mtxtConfirmPwd.Focus();
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }

            return isValid;
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

        private void Users_Load(object sender, EventArgs e)
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                BindRoles();
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
                string imagePath = Application.StartupPath + "\\Images\\";
                DataTable dt = new DataTable();
                dt = BaseClass._BAL.GetAllUserDetails();              

                if (dt.Rows.Count > 0)
                {
                    dt = BaseClass._BAL.AutoNumberedTable(dt);

                    listUserName = dt.AsEnumerable().Select(r => r.Field<string>("UserName")).ToList();
                    listContactNo = dt.AsEnumerable().Select(r => r.Field<string>("ContactNo")).ToList();

                    dgvUser.Columns.Clear();
                    dgvUser.DataSource = null;
                    dgvUser.DataSource = dt;
                   
                    DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
                    dgvLink.HeaderText = "Edit";
                    dgvLink.Name = "Edit";
                    dgvLink.LinkColor = Color.Blue;
                    dgvLink.TrackVisitedState = true;
                    dgvLink.Text = "Edit";
                    dgvLink.UseColumnTextForLinkValue = true;
                    dgvUser.Columns.Add(dgvLink);

                    DataGridViewLinkColumn dgvLink1 = new DataGridViewLinkColumn();
                    dgvLink1.HeaderText = "Delete";
                    dgvLink1.Name = "Delete";
                    dgvLink1.LinkColor = Color.Blue;
                    dgvLink1.TrackVisitedState = true;
                    dgvLink1.Text = "Delete";
                    dgvLink1.UseColumnTextForLinkValue = true;
                    dgvUser.Columns.Add(dgvLink1);

                    dgvUser.Columns["SNo"].Width = 50;
                    dgvUser.Columns["FirstName"].Width = 120;
                    dgvUser.Columns["LastName"].Width = 120;
                    dgvUser.Columns["Role"].Width = 60;
                    dgvUser.Columns["ContactNo"].Width = 120;
                    dgvUser.Columns["UserName"].Width = 120;
                    dgvUser.Columns["Edit"].Width = 60;
                    dgvUser.Columns["Delete"].Width = 60;

                    dgvUser.Columns["FirstName"].HeaderText = "First Name";
                    dgvUser.Columns["LastName"].HeaderText = "Last Name";
                    dgvUser.Columns["ContactNo"].HeaderText = "Contact No";

                    dgvUser.Columns["UserId"].Visible = false;
                    dgvUser.Columns["Password"].Visible = false;


                    for (int i = 0; i < dgvUser.Columns.Count; i++)
                    {
                        dgvUser.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
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
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                ResetUser();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void ResetUser()
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Insert;
                lblUserID.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtContactNo.Text = string.Empty;
                txtUserName.Text = string.Empty;
                mtxtPassword.Text = string.Empty;
                mtxtConfirmPwd.Text = string.Empty;
                cboRole.SelectedIndex = 0;
                mtxtPassword.Enabled = true;
                mtxtConfirmPwd.Enabled = true;
                txtUserName.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvUser.Columns.Count-1)
                {

                    string delMsg = "Are you sure to delete " + dgvUser.Rows[e.RowIndex].Cells["FirstName"].Value + " " + dgvUser.Rows[e.RowIndex].Cells["LastName"].Value + " User ?";
                    DialogResult result = MessageBox.Show(delMsg, "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        DeleteUser(e.RowIndex);
                    }

                }
                else if (e.ColumnIndex == dgvUser.Columns.Count - 2)
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
                    lblUserID.Text = dgvUser.Rows[rowIndex].Cells["UserID"].Value.ToString();
                    txtFirstName.Text = dgvUser.Rows[rowIndex].Cells["FirstName"].Value.ToString();
                    txtLastName.Text = dgvUser.Rows[rowIndex].Cells["LastName"].Value.ToString();
                    cboRole.SelectedItem = dgvUser.Rows[rowIndex].Cells["Role"].Value.ToString();
                    txtContactNo.Text = dgvUser.Rows[rowIndex].Cells["ContactNo"].Value.ToString();
                    txtUserName.Text = dgvUser.Rows[rowIndex].Cells["UserName"].Value.ToString();
                    mtxtPassword.Text = dgvUser.Rows[rowIndex].Cells["Password"].Value.ToString();
                    mtxtConfirmPwd.Text = dgvUser.Rows[rowIndex].Cells["Password"].Value.ToString();
                    txtUserName.Enabled = false;
                    mtxtPassword.Enabled = false;
                    mtxtConfirmPwd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void DeleteUser(int rowIndex)
        {
            try
            {
                currentOperation = (int)BaseClass.CRUDOperations.Delete;
                if (rowIndex >= 0)
                {
                    int result = BaseClass._BAL.SaveUser(currentOperation, Convert.ToInt32(dgvUser.Rows[rowIndex].Cells["UserID"].Value.ToString()),
                        dgvUser.Rows[rowIndex].Cells["FirstName"].Value.ToString(),
                        dgvUser.Rows[rowIndex].Cells["LastName"].Value.ToString(),
                        dgvUser.Rows[rowIndex].Cells["Role"].Value.ToString(),
                        dgvUser.Rows[rowIndex].Cells["ContactNo"].Value.ToString(),
                        dgvUser.Rows[rowIndex].Cells["UserName"].Value.ToString(),
                         dgvUser.Rows[rowIndex].Cells["Password"].Value.ToString());

                    if (result == 1)
                    {
                        MessageBox.Show("User Deleted Successfully");
                        BindRoles();
                        BindGrid();
                        ResetUser();
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

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    lblMsg.Text = "Please enter valid Contact No";
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
                if (ValidateUser())
                {
                    int userID = 0;
                    if (!string.IsNullOrEmpty(lblUserID.Text))
                    {
                        userID = Convert.ToInt32(lblUserID.Text);
                    }

                    int result = BaseClass._BAL.SaveUser(currentOperation, userID, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), cboRole.SelectedItem.ToString(), txtContactNo.Text.Trim(), txtUserName.Text.Trim(), mtxtPassword.Text.Trim());
                    if (result == 1)
                    {
                        MessageBox.Show("User details Saved Successfully");
                        BindRoles();
                        BindGrid();
                        // ResetUser();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        

    }
}
