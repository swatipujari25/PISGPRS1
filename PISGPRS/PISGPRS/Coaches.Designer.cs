namespace PISGPRS
{
    partial class Coaches
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtHardwareID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCoachID = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvCoach = new System.Windows.Forms.DataGridView();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtPISUnitNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCoachNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.txtSimNo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTrainNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoach)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHardwareID
            // 
            this.txtHardwareID.Location = new System.Drawing.Point(163, 139);
            this.txtHardwareID.MaxLength = 10;
            this.txtHardwareID.Name = "txtHardwareID";
            this.txtHardwareID.Size = new System.Drawing.Size(185, 20);
            this.txtHardwareID.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(12, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "COACH DETAILS";
            // 
            // lblCoachID
            // 
            this.lblCoachID.AutoSize = true;
            this.lblCoachID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoachID.ForeColor = System.Drawing.Color.Red;
            this.lblCoachID.Location = new System.Drawing.Point(166, 44);
            this.lblCoachID.Name = "lblCoachID";
            this.lblCoachID.Size = new System.Drawing.Size(0, 16);
            this.lblCoachID.TabIndex = 94;
            this.lblCoachID.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(373, 102);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 30);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvCoach
            // 
            this.dgvCoach.AllowUserToAddRows = false;
            this.dgvCoach.AllowUserToDeleteRows = false;
            this.dgvCoach.AllowUserToResizeColumns = false;
            this.dgvCoach.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCoach.ColumnHeadersHeight = 50;
            this.dgvCoach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoach.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCoach.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvCoach.Location = new System.Drawing.Point(9, 248);
            this.dgvCoach.MultiSelect = false;
            this.dgvCoach.Name = "dgvCoach";
            this.dgvCoach.ReadOnly = true;
            this.dgvCoach.RowHeadersWidth = 20;
            this.dgvCoach.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoach.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCoach.RowTemplate.Height = 25;
            this.dgvCoach.Size = new System.Drawing.Size(596, 250);
            this.dgvCoach.TabIndex = 8;
            this.dgvCoach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoach_CellClick);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(72, 12);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 15;
            // 
            // txtPISUnitNo
            // 
            this.txtPISUnitNo.Location = new System.Drawing.Point(163, 110);
            this.txtPISUnitNo.MaxLength = 10;
            this.txtPISUnitNo.Name = "txtPISUnitNo";
            this.txtPISUnitNo.Size = new System.Drawing.Size(185, 20);
            this.txtPISUnitNo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hardware No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "PIS Unit No";
            // 
            // txtCoachNo
            // 
            this.txtCoachNo.Location = new System.Drawing.Point(163, 81);
            this.txtCoachNo.MaxLength = 10;
            this.txtCoachNo.Name = "txtCoachNo";
            this.txtCoachNo.Size = new System.Drawing.Size(185, 20);
            this.txtCoachNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Coach No";
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(45, 54);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(54, 15);
            this.lblTrainName.TabIndex = 14;
            this.lblTrainName.Text = "Train No";
            // 
            // txtSimNo
            // 
            this.txtSimNo.Location = new System.Drawing.Point(190, 168);
            this.txtSimNo.MaxLength = 10;
            this.txtSimNo.Name = "txtSimNo";
            this.txtSimNo.Size = new System.Drawing.Size(159, 20);
            this.txtSimNo.TabIndex = 4;
            this.txtSimNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSimNo_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(373, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(373, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "SIM No";
            // 
            // cboTrainNo
            // 
            this.cboTrainNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainNo.FormattingEnabled = true;
            this.cboTrainNo.Location = new System.Drawing.Point(163, 48);
            this.cboTrainNo.Name = "cboTrainNo";
            this.cboTrainNo.Size = new System.Drawing.Size(185, 21);
            this.cboTrainNo.TabIndex = 0;
            this.cboTrainNo.SelectionChangeCommitted += new System.EventHandler(this.cboTrainNo_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 15);
            this.label9.TabIndex = 101;
            this.label9.Text = "+91";
            // 
            // Coaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 508);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboTrainNo);
            this.Controls.Add(this.txtHardwareID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCoachID);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvCoach);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtPISUnitNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCoachNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrainName);
            this.Controls.Add(this.txtSimNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Coaches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coach Information";
            this.Load += new System.EventHandler(this.Coaches_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHardwareID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCoachID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvCoach;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtPISUnitNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCoachNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrainName;
        private System.Windows.Forms.TextBox txtSimNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTrainNo;
        private System.Windows.Forms.Label label9;
    }
}