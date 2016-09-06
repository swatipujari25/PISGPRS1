using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using Common;

namespace PISGPRS
{
    public partial class Contactus : Form
    {
        public Contactus()
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateAndSendMail();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private Boolean ValidateEmailID()
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (!Regex.IsMatch(txtEmailID.Text, pattern))
            {
                MessageBox.Show("Please enter valid EmailId");
                return false;
            }
            else
            {
                return true;
            }
        }


        private void ValidateAndSendMail()
        {            
            try
            {
                DialogResult result = new DialogResult();

                if (string.IsNullOrEmpty(txtEmailID.Text))
                {
                    MessageBox.Show("Please enter EmailID");
                }
                else
                {
                    if (ValidateEmailID())
                    {
                        if (string.IsNullOrEmpty(txtSubject.Text) || string.IsNullOrEmpty(txtMessage.Text))
                        {
                            result = MessageBox.Show("Send this message without a subject or message?", "Confirmation",MessageBoxButtons.YesNo);
                        }

                        if (result == DialogResult.Yes|| (!string.IsNullOrEmpty(txtSubject.Text) || !string.IsNullOrEmpty(txtMessage.Text)))
                        {
                            SendEmail();
                            this.Close();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        
        }

        private void SendEmail()
        {
            try
            {
                MailMessage mailMsg = new MailMessage();
                SmtpClient smtpC = new SmtpClient();
                mailMsg.From = new MailAddress(BaseClass.ContactusEmailId, "infoScs8485");
                //m.To.Add(new MailAddress(BaseClass.ContactusEmailId, "Swati P"));
                mailMsg.To.Add(new MailAddress(txtEmailID.Text, "Swati P"));
                mailMsg.Body = txtMessage.Text + Environment.NewLine + Environment.NewLine + "UserName: " + Constants.UserName + Environment.NewLine + "ContactNo: " + Constants.LoginContactNo;
                mailMsg.Subject = txtSubject.Text;

                smtpC.Host = "smtp.gmail.com";
                smtpC.Port = 587;
                smtpC.Credentials = new System.Net.NetworkCredential("infoScs8485@gmail.com", "info$cs8485");
                smtpC.EnableSsl = true;
                smtpC.Send(mailMsg);
                MessageBox.Show("Mail sent successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Send mail operation Fail");
                Logger.Logger.WriteLog(ex);
            }
        }

       
    }
}
