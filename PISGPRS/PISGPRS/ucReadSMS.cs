using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Logger;
using Communication;

namespace PISGPRS
{
    public partial class ucReadSMS : UserControl
    {
        public ucReadSMS()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        
    }
}
