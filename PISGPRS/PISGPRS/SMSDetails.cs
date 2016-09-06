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
    public partial class SMSDetails : Form
    {
        DataTable dtSent = new DataTable();
        DataTable dtReceive = new DataTable();
        public SMSDetails()
        {
            InitializeComponent();
        }

        private void SMSDetails_Load(object sender, EventArgs e)
        {
            try
            {
           // GetSMSDetails();
            BindSMSDetails();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void BindSMSDetails()
        {
            try
            {
               
                dtSent = BaseClass._BAL.GetSentSMSDetails();
                dgvSent.DataSource = dtSent;
             //   dgvSent.Columns["SMSDate"].Width = 80;
                dgvSent.Columns["SMSTime"].Width = 80;
                dgvSent.Columns["CoachNo"].Width = 100;
                dgvSent.Columns["SIMNo"].Width = 100;
                dgvSent.Columns["Message"].Width = 150;

               
                dtReceive = BaseClass._BAL.GetReceivedSMSDetails();
                dgvReceive.DataSource = dtReceive;
               // dgvReceive.Columns["SMSDate"].Width = 80;
                dgvReceive.Columns["SMSTime"].Width = 80;
                dgvReceive.Columns["CoachNo"].Width = 100;
                dgvReceive.Columns["SIMNo"].Width = 100;
                dgvReceive.Columns["Message"].Width = 250;

                dgvSent.Columns["SMSDate"].Visible = false;
                dgvReceive.Columns["SMSDate"].Visible = false;
                //dgvSent.Columns["Message"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dgvReceive.Columns["Message"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvSent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvReceive.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        
    }
}
