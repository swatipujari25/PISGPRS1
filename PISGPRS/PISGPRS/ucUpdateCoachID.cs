using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Communication;
using Logger;

namespace PISGPRS
{
    public partial class ucUpdateCoachID : UserControl
    {
        public ucUpdateCoachID()
        {
            InitializeComponent();
        }

        

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
            if (txtCoachID.Text.Length == 0)
            {
                lblMsg.Text = "Enter CoachID";
            }
            else
            { 
            
            }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void BindCoachDetails()
        {
            try
            {
                
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

        private void ucUpdateCoachID_Load(object sender, EventArgs e)
        {
            try
            { }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        
    }
}
