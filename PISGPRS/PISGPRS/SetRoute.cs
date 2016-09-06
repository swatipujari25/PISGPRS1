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
using Communication;

namespace PISGPRS
{
    public partial class SetRoute : Form
    {
        List<string> listSIMNo = new List<string>();
        Dictionary<int, string> listTrainNo = new Dictionary<int, string>();
        string requestType = string.Empty;  

        public SetRoute()
        {
            InitializeComponent();
        }

        private void SetRoute_Load(object sender, EventArgs e)
        {
            BindTrainNos();
        }

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

        public void BindGrid()
        {
            try
            {
                if (Convert.ToInt32(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key) != 0)
                {
                    DataTable dt = new DataTable();
                    dt = BaseClass._BAL.GetCoachDetailsByTrainID(((KeyValuePair<int, string>)(cboTrainNo.SelectedItem)).Key);

                    dt.Columns.Add("Status");
                    

                    if (dt.Rows.Count > 0)
                    {
                        listSIMNo = dt.AsEnumerable().Select(r => r.Field<string>("SIMNo")).ToList();

                        dt = BaseClass._BAL.AutoNumberedTable(dt);
                        dgvCoach.Columns.Clear();
                        dgvCoach.DataSource = null;

                        DataGridViewCheckBoxColumn dgvLink = new DataGridViewCheckBoxColumn();
                        dgvLink.HeaderText = "Select";
                        dgvLink.Name = "Select";
                        dgvLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dgvLink.FlatStyle = FlatStyle.Standard;
                        dgvLink.TrueValue = "1";
                        dgvLink.FalseValue = "0";
                        dgvCoach.Columns.Add(dgvLink);

                        dgvCoach.DataSource = dt;

                        dgvCoach.Columns["SNo"].Width = 50;
                        dgvCoach.Columns["Select"].Width = 80;
                        dgvCoach.Columns["CoachNo"].Width = 100;
                        dgvCoach.Columns["PISUnitID"].Width = 100;
                        dgvCoach.Columns["HardwareID"].Width = 100;
                        dgvCoach.Columns["SIMNo"].Width = 100;

                        dgvCoach.Columns["CoachNo"].HeaderText = "Coach No";
                        dgvCoach.Columns["SIMNo"].HeaderText = "SIM No";
                        dgvCoach.Columns["PISUnitID"].HeaderText = "PIS Unit No";

                        dgvCoach.Columns["SNo"].Visible = false;
                        dgvCoach.Columns["CoachID"].Visible = false;
                        dgvCoach.Columns["TrainID"].Visible = false;
                        dgvCoach.Columns["HardwareID"].Visible = false;

                        for (int i = 0; i < dgvCoach.Columns.Count; i++)
                        {
                            dgvCoach.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                        dgvCoach.Columns["SNo"].DisplayIndex = 0;
                        dgvCoach.Columns["Select"].DisplayIndex = 1;
                        dgvCoach.Columns["CoachNo"].DisplayIndex = 2;
                        dgvCoach.Columns["PISUnitID"].DisplayIndex = 3;
                        dgvCoach.Columns["HardwareID"].DisplayIndex = 4;
                        dgvCoach.Columns["SIMNo"].DisplayIndex = 5;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }
    

        private void dgvCoach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dgvCoach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                {
                    dgvCoach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
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


        private void cboTrainNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
            BindGrid();
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
            for (int i = 0; i < dgvCoach.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    dgvCoach.Rows[i].Cells[0].Value = true;
                }
                else
                {
                    dgvCoach.Rows[i].Cells[0].Value = false;
                }
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string trainNo=string.Empty;
                trainNo=cboTrainNo.Text.ToString();
                string[] split=trainNo.Split('-');

                if(split.Length==2)
                {
                 trainNo=split[0].ToString().Trim();
                }

                
                string message = string.Empty;
                if (rbtnSelect.Checked)
                {
                    requestType = Constants.Commands.SelectRoute.ToString();
                    message = "route " +trainNo;
                }
                else if (rbtnDeselect.Checked)
                {
                    requestType = Constants.Commands.DeselectRoute.ToString();
                    message = "deselect";
                }
                else if (rbtnStatus.Checked)
                {
                    requestType = Constants.Commands.RouteStatus.ToString();
                    message = "status";
                }                

                for (int i = 0; i < dgvCoach.Rows.Count; i++)
                {
                    if (Convert.ToBoolean( dgvCoach.Rows[i].Cells["Select"].Value)==true)
                    {
                      dgvCoach.Rows[i].Cells["Status"].Value=  SendSMS( "+91"+dgvCoach.Rows[i].Cells["SIMNo"].Value.ToString(), message);
                    }                    
                }          
                
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private string SendSMS(string phoneno, string message)
        {
            string statusmsg = string.Empty;
            try
            {
            // phoneno = "8885212132";
           //  message = "select 17985";
                SplitMessage outmsg = new SplitMessage();
                

                if (BaseClass.SRPortComm.SendMessage( phoneno, message))
            {
                statusmsg = "Completed";

                int result = BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Insert,0,BaseClass.MessageType.Request.ToString(),
                BaseClass.SMSType.Related.ToString(),DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"),
                phoneno, message, statusmsg);

                if (!string.IsNullOrEmpty(outmsg.Message))
                {
                     BaseClass._BAL.SaveSMSDetails((int)BaseClass.CRUDOperations.Insert, 0, BaseClass.MessageType.Response.ToString(),
                    BaseClass.SMSType.Related.ToString(), DateTime.Now.Date.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm:ss"),
                    phoneno, message, statusmsg);
                }
                
               // MessageBox.Show("Message has sent successfully");                
            }
            else
            {
                statusmsg = "Fail";
                MessageBox.Show("Failed to send message");
            }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
            return statusmsg;
        }

        private void ReadSMS()
        { 
        try
        {
        }
        catch (Exception ex)
        {
            Logger.Logger.WriteLog(ex);
        }
        }

        
    }
}
