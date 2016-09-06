namespace PISGPRS
{
    partial class TrainLocation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboTrainNo = new System.Windows.Forms.ComboBox();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cboTrainNo);
            this.panel1.Controls.Add(this.lblTrainName);
            this.panel1.Location = new System.Drawing.Point(1, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 587);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Location = new System.Drawing.Point(11, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(819, 472);
            this.panel2.TabIndex = 114;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(819, 472);
            this.webBrowser1.TabIndex = 110;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(86, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 30);
            this.btnSearch.TabIndex = 113;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // cboTrainNo
            // 
            this.cboTrainNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainNo.FormattingEnabled = true;
            this.cboTrainNo.Location = new System.Drawing.Point(86, 10);
            this.cboTrainNo.Name = "cboTrainNo";
            this.cboTrainNo.Size = new System.Drawing.Size(216, 21);
            this.cboTrainNo.TabIndex = 111;
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(11, 16);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(54, 15);
            this.lblTrainName.TabIndex = 112;
            this.lblTrainName.Text = "Train No";
            // 
            // TrainLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 602);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrainLocation";
            this.Load += new System.EventHandler(this.TrainLocation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboTrainNo;
        private System.Windows.Forms.Label lblTrainName;

    }
}