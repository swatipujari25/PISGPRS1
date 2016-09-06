using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logger;
using Common;

namespace PISGPRS
{
    public partial class ResetPassword : Form
    {
        List<UserModel> listUsers = new List<UserModel>();

        public ResetPassword()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                listUsers = BaseClass._BAL.BindUserName();
                UserModel model = new UserModel();
                if (listUsers.Count > 0)
                {
                    model = listUsers.Where(m => m.UserName == Constants.UserName).SingleOrDefault();
                    if (Validate(model))
                    {
                        model.UserName = Constants.UserName;
                        model.Password = mtxtNewPassword.Text;

                        BaseClass._BAL.ResetPassword(model.UserName, model.Password);

                        MessageBox.Show("Password updated Successfully" );

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public bool Validate(UserModel model)
        {
            bool isValid = true;
            lblMsg.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(mtxtOldPwd.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Old Password ";
                }
                else if (mtxtOldPwd.Text.Length > 15 || mtxtOldPwd.Text.Length < 3)
                {
                    isValid = false;
                    lblMsg.Text = "Old Password should be 3 to 15 Characters";
                }
                else if ((mtxtOldPwd.Text != model.Password))
                {
                    if (mtxtOldPwd.Text != Constants.UniquePassword)
                    {
                        isValid = false;
                        lblMsg.Text = "Invalid Old Password";
                    }
                }
                else if (string.IsNullOrEmpty(mtxtNewPassword.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter New Password ";
                }
                else if (mtxtNewPassword.Text.Length > 15 || mtxtNewPassword.Text.Length < 3)
                {
                    isValid = false;
                    lblMsg.Text = "New Password should be 3 to 15 Characters";
                }
                else if (string.IsNullOrEmpty(mtxtConfirmPwd.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Confirm Password ";
                }
                else if (mtxtNewPassword.Text != mtxtConfirmPwd.Text)
                {
                    isValid = false;
                    lblMsg.Text = "New Password and Confirm password should be same";
                }


            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return isValid;
        }
    }
}
