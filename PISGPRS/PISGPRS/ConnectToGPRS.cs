using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Communication;
using Logger;

namespace PISGPRS
{
    public partial class ConnectToGPRS : Form
    {
        public ConnectToGPRS()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to connect to GPRS?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BaseClass.SRPortComm.ConnectToGPRS();
                
             
            }
            else
            {

            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }
    }
}
