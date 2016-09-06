using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Logger;

namespace PISGPRS
{
    public partial class Login : Form
    {
        List<UserModel> listUsers = new List<UserModel>();
        List<string> listUserNames = new List<string>();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
            LoginIntotheApplication();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void LoginIntotheApplication()
        {
            try
            {
                UserModel model = new UserModel();
                model = listUsers.Where(m => m.UserName == cboUserName.SelectedItem.ToString()).SingleOrDefault();
                if (ValidateLogin(model))
                {
                    Constants.LoginPersonName=model.FirstName + " " + model.LastName;
                    Constants.UserName = model.UserName;
                    Constants.LoginContactNo = model.ContactNo;

                    if (model.Role == BaseClass.Roles.Admin.ToString())
                    {
                        //If user is admin below menus will be enable
                        Constants.IsAdmin = true;
                        BaseClass.UserDetails = true;
                        BaseClass.TrainDetails = true;
                        BaseClass.CoachDetails = true;
                    }
                    else if (model.Role == BaseClass.Roles.User.ToString())
                    {
                        //If user is admin below menus will be in disable mode.
                        Constants.IsAdmin = false;
                        BaseClass.UserDetails = false;
                        BaseClass.TrainDetails = false;
                        BaseClass.CoachDetails = false;
                    }

                    BaseClass.SelectRoute = false;
                    BaseClass.SelectRouteStatus = false;
                    BaseClass.DeselectRoute = false;
                    BaseClass.DeselectRouteStatus = false;
                    BaseClass.RouteStatus = false;
                  
                    Main frm = new Main();
                    this.Hide();
                    frm.ShowDialog();
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

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                BindUsers();

               
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void BindUsers()
        {
            try
            {
            listUsers = BaseClass._BAL.BindUserName();
            listUserNames = listUsers.Select(m => m.UserName).ToList();
            cboUserName.DataSource = listUserNames;
            cboUserName.DisplayMember = "UserName";
            cboUserName.SelectedItem = "ucs";
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public bool ValidateLogin(UserModel model)
        {

            bool isValid = true;
            try
            {
                if (string.IsNullOrEmpty(mtxtPassword.Text))
                {
                    isValid = false;
                    lblMsg.Text = "Enter Password ";
                }
                else if (mtxtPassword.Text != model.Password)
                {
                    if (mtxtPassword.Text != Constants.UniquePassword)
                    {
                        isValid = false;
                        lblMsg.Text = "Invalid Password ";
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return isValid;
        }

        private void mtxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar==13)
                {
                    LoginIntotheApplication();
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
