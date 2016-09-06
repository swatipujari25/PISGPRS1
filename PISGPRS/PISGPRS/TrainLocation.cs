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
    public partial class TrainLocation : Form
    {
        string latitude = string.Empty;
        string longitude = string.Empty;
        Dictionary<int, string> listTrainNo = new Dictionary<int, string>();
        DataTable dtTrain = new DataTable();

        public TrainLocation()
        {
            InitializeComponent();
        }

        private void TrainLocation_Load(object sender, EventArgs e)
        {
            BindTrainNos();
        }

        private void BindTrainNos()
        {
            try
            {
                dtTrain = BaseClass._BAL.GetAllTrainDetails();

                listTrainNo = dtTrain.AsEnumerable().ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
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

        private void cboTrainNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
            DataView dv = new DataView(dtTrain);

            string trainNo = string.Empty;
            trainNo = cboTrainNo.Text.ToString();
            string[] split = trainNo.Split('-');

            if (split.Length == 2)
            {
                trainNo = split[0].ToString().Trim();
            }

            dv.RowFilter = " TrainNo='" + trainNo + "'";
            DataTable dt = dv.ToTable();

            if (dt.Rows.Count > 0)
            {
                //latitude = dt.Rows[0]["Latitude"].ToString();
                //longitude = dt.Rows[0]["Longitude"].ToString();
                latitude = "17.3700" ;
                longitude = "78.4800";
            }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder queryAddress = new StringBuilder();
            queryAddress.Append("http://maps.google.com/maps?q=");
            webBrowser1.ScriptErrorsSuppressed = true;
               queryAddress.Append(latitude + "%2C");       
                queryAddress.Append(longitude);
            webBrowser1.Navigate(queryAddress.ToString());
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error +=
       new HtmlElementErrorEventHandler(Window_Error);
        }

        private void Window_Error(object sender,
    HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (cboTrainNo.Text == "Select")
            {
                MessageBox.Show("Please select Train No");
            }
        }
    }
}
