namespace PISGPRS
{
    partial class Routes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTrainID = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvRoute = new System.Windows.Forms.DataGridView();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoofCoaches = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrainNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoofHours = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lnkAddCoaches = new System.Windows.Forms.LinkLabel();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(6, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "ROUTE DETAILS";
            // 
            // lblTrainID
            // 
            this.lblTrainID.AutoSize = true;
            this.lblTrainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainID.ForeColor = System.Drawing.Color.Red;
            this.lblTrainID.Location = new System.Drawing.Point(167, 34);
            this.lblTrainID.Name = "lblTrainID";
            this.lblTrainID.Size = new System.Drawing.Size(0, 16);
            this.lblTrainID.TabIndex = 65;
            this.lblTrainID.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(248, 251);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 30);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvRoute
            // 
            this.dgvRoute.AllowUserToAddRows = false;
            this.dgvRoute.AllowUserToDeleteRows = false;
            this.dgvRoute.AllowUserToResizeColumns = false;
            this.dgvRoute.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoute.ColumnHeadersHeight = 50;
            this.dgvRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoute.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoute.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvRoute.Location = new System.Drawing.Point(9, 350);
            this.dgvRoute.MultiSelect = false;
            this.dgvRoute.Name = "dgvRoute";
            this.dgvRoute.ReadOnly = true;
            this.dgvRoute.RowHeadersWidth = 20;
            this.dgvRoute.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoute.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoute.RowTemplate.Height = 25;
            this.dgvRoute.Size = new System.Drawing.Size(692, 206);
            this.dgvRoute.TabIndex = 16;
            this.dgvRoute.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoute_CellClick);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(73, 13);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(333, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "To Time";
            // 
            // txtNoofCoaches
            // 
            this.txtNoofCoaches.Location = new System.Drawing.Point(164, 100);
            this.txtNoofCoaches.MaxLength = 2;
            this.txtNoofCoaches.Name = "txtNoofCoaches";
            this.txtNoofCoaches.Size = new System.Drawing.Size(138, 20);
            this.txtNoofCoaches.TabIndex = 2;
            this.txtNoofCoaches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofCoaches_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Source";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "No of Coaches";
            // 
            // txtTrainName
            // 
            this.txtTrainName.Location = new System.Drawing.Point(164, 71);
            this.txtTrainName.MaxLength = 50;
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.Size = new System.Drawing.Size(138, 20);
            this.txtTrainName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Train Name";
            // 
            // txtTrainNo
            // 
            this.txtTrainNo.Location = new System.Drawing.Point(164, 42);
            this.txtTrainNo.MaxLength = 6;
            this.txtTrainNo.Name = "txtTrainNo";
            this.txtTrainNo.Size = new System.Drawing.Size(138, 20);
            this.txtTrainNo.TabIndex = 0;
            this.txtTrainNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrainNo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Train No";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(164, 158);
            this.txtDestination.MaxLength = 25;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(138, 20);
            this.txtDestination.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(351, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "From Time";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(145, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Destination";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(333, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "No of Hours";
            // 
            // txtNoofHours
            // 
            this.txtNoofHours.Location = new System.Drawing.Point(451, 97);
            this.txtNoofHours.MaxLength = 2;
            this.txtNoofHours.Name = "txtNoofHours";
            this.txtNoofHours.Size = new System.Drawing.Size(138, 20);
            this.txtNoofHours.TabIndex = 8;
            this.txtNoofHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofHours_KeyPress);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(164, 129);
            this.txtSource.MaxLength = 25;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(138, 20);
            this.txtSource.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(451, 37);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(73, 20);
            this.dtpFrom.TabIndex = 6;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "HH:mm:ss";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(451, 67);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(73, 20);
            this.dtpTo.TabIndex = 7;
            // 
            // lnkAddCoaches
            // 
            this.lnkAddCoaches.AutoSize = true;
            this.lnkAddCoaches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddCoaches.Location = new System.Drawing.Point(465, 259);
            this.lnkAddCoaches.Name = "lnkAddCoaches";
            this.lnkAddCoaches.Size = new System.Drawing.Size(101, 16);
            this.lnkAddCoaches.TabIndex = 15;
            this.lnkAddCoaches.TabStop = true;
            this.lnkAddCoaches.Text = "Add Coaches";
            this.lnkAddCoaches.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddCoaches_LinkClicked);
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(451, 127);
            this.txtDistance.MaxLength = 4;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(138, 20);
            this.txtDistance.TabIndex = 9;
            this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistance_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(333, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Distance";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(451, 187);
            this.txtLongitude.MaxLength = 10;
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(138, 20);
            this.txtLongitude.TabIndex = 11;
            this.txtLongitude.Visible = false;
            this.txtLongitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLongitude_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(333, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 69;
            this.label11.Text = "Longitude";
            this.label11.Visible = false;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(451, 157);
            this.txtLatitude.MaxLength = 10;
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(138, 20);
            this.txtLatitude.TabIndex = 10;
            this.txtLatitude.Visible = false;
            this.txtLatitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLatitude_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(334, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 15);
            this.label13.TabIndex = 70;
            this.label13.Text = "Latitude";
            this.label13.Visible = false;
            // 
            // txtVia
            // 
            this.txtVia.Location = new System.Drawing.Point(164, 187);
            this.txtVia.MaxLength = 25;
            this.txtVia.Name = "txtVia";
            this.txtVia.Size = new System.Drawing.Size(138, 20);
            this.txtVia.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(46, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "Via";
            // 
            // Routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 566);
            this.Controls.Add(this.txtVia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lnkAddCoaches);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.txtNoofHours);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTrainID);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvRoute);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNoofCoaches);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrainName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTrainNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Routes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train Information";
            this.Load += new System.EventHandler(this.Routes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTrainID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvRoute;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNoofCoaches;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrainName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrainNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNoofHours;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.LinkLabel lnkAddCoaches;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVia;
        private System.Windows.Forms.Label label12;
    }
}