namespace PISGPRS
{
    partial class SetRoute
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboTrainNo = new System.Windows.Forms.ComboBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvCoach = new System.Windows.Forms.DataGridView();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.rbtnSelect = new System.Windows.Forms.RadioButton();
            this.rbtnDeselect = new System.Windows.Forms.RadioButton();
            this.rbtnStatus = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoach)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTrainNo
            // 
            this.cboTrainNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrainNo.FormattingEnabled = true;
            this.cboTrainNo.Location = new System.Drawing.Point(84, 36);
            this.cboTrainNo.Name = "cboTrainNo";
            this.cboTrainNo.Size = new System.Drawing.Size(216, 21);
            this.cboTrainNo.TabIndex = 95;
            this.cboTrainNo.SelectionChangeCommitted += new System.EventHandler(this.cboTrainNo_SelectionChangeCommitted);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(50, 4);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 97;
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(9, 42);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(54, 15);
            this.lblTrainName.TabIndex = 96;
            this.lblTrainName.Text = "Train No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(9, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 16);
            this.label8.TabIndex = 99;
            this.label8.Text = "COACH DETAILS";
            // 
            // dgvCoach
            // 
            this.dgvCoach.AllowUserToAddRows = false;
            this.dgvCoach.AllowUserToDeleteRows = false;
            this.dgvCoach.AllowUserToResizeColumns = false;
            this.dgvCoach.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCoach.ColumnHeadersHeight = 50;
            this.dgvCoach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoach.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCoach.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvCoach.Location = new System.Drawing.Point(12, 136);
            this.dgvCoach.MultiSelect = false;
            this.dgvCoach.Name = "dgvCoach";
            this.dgvCoach.ReadOnly = true;
            this.dgvCoach.RowHeadersWidth = 20;
            this.dgvCoach.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCoach.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCoach.RowTemplate.Height = 25;
            this.dgvCoach.Size = new System.Drawing.Size(496, 214);
            this.dgvCoach.TabIndex = 98;
            this.dgvCoach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoach_CellClick);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(12, 108);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(47, 19);
            this.chkAll.TabIndex = 100;
            this.chkAll.Text = "ALL";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(426, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 30);
            this.btnCancel.TabIndex = 108;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(329, 436);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(82, 30);
            this.btnSend.TabIndex = 107;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rbtnSelect
            // 
            this.rbtnSelect.AutoSize = true;
            this.rbtnSelect.Checked = true;
            this.rbtnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSelect.Location = new System.Drawing.Point(12, 396);
            this.rbtnSelect.Name = "rbtnSelect";
            this.rbtnSelect.Size = new System.Drawing.Size(107, 19);
            this.rbtnSelect.TabIndex = 109;
            this.rbtnSelect.TabStop = true;
            this.rbtnSelect.Text = "Select Route";
            this.rbtnSelect.UseVisualStyleBackColor = true;
            // 
            // rbtnDeselect
            // 
            this.rbtnDeselect.AutoSize = true;
            this.rbtnDeselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDeselect.Location = new System.Drawing.Point(146, 396);
            this.rbtnDeselect.Name = "rbtnDeselect";
            this.rbtnDeselect.Size = new System.Drawing.Size(123, 19);
            this.rbtnDeselect.TabIndex = 110;
            this.rbtnDeselect.TabStop = true;
            this.rbtnDeselect.Text = "Deselect Route";
            this.rbtnDeselect.UseVisualStyleBackColor = true;
            // 
            // rbtnStatus
            // 
            this.rbtnStatus.AutoSize = true;
            this.rbtnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnStatus.Location = new System.Drawing.Point(296, 396);
            this.rbtnStatus.Name = "rbtnStatus";
            this.rbtnStatus.Size = new System.Drawing.Size(107, 19);
            this.rbtnStatus.TabIndex = 111;
            this.rbtnStatus.TabStop = true;
            this.rbtnStatus.Text = "Route Status";
            this.rbtnStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(9, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 112;
            this.label1.Text = "COMMANDS";
            // 
            // SetRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 474);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnStatus);
            this.Controls.Add(this.rbtnDeselect);
            this.Controls.Add(this.rbtnSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvCoach);
            this.Controls.Add(this.cboTrainNo);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblTrainName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Route";
            this.Load += new System.EventHandler(this.SetRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTrainNo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblTrainName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvCoach;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RadioButton rbtnSelect;
        private System.Windows.Forms.RadioButton rbtnDeselect;
        private System.Windows.Forms.RadioButton rbtnStatus;
        private System.Windows.Forms.Label label1;
    }
}