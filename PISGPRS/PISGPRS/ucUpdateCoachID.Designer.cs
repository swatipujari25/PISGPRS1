namespace PISGPRS
{
    partial class ucUpdateCoachID
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtCoachID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblCoachNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCoach = new System.Windows.Forms.ComboBox();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.cboCoach);
            this.groupBox1.Controls.Add(this.lblTrainName);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.txtCoachID);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.lblCoachNo);
            this.groupBox1.Location = new System.Drawing.Point(5, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(40, 25);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 129;
            // 
            // txtCoachID
            // 
            this.txtCoachID.Location = new System.Drawing.Point(126, 137);
            this.txtCoachID.MaxLength = 10;
            this.txtCoachID.Name = "txtCoachID";
            this.txtCoachID.Size = new System.Drawing.Size(132, 20);
            this.txtCoachID.TabIndex = 128;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(146, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 30);
            this.btnCancel.TabIndex = 127;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(49, 192);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(82, 30);
            this.btnSend.TabIndex = 126;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblCoachNo
            // 
            this.lblCoachNo.AutoSize = true;
            this.lblCoachNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoachNo.Location = new System.Drawing.Point(38, 142);
            this.lblCoachNo.Name = "lblCoachNo";
            this.lblCoachNo.Size = new System.Drawing.Size(57, 15);
            this.lblCoachNo.TabIndex = 125;
            this.lblCoachNo.Text = "Coach ID";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(265, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 23);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 127;
            this.label2.Text = "Update Coach ID";
            // 
            // cboCoach
            // 
            this.cboCoach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoach.FormattingEnabled = true;
            this.cboCoach.Location = new System.Drawing.Point(126, 94);
            this.cboCoach.Name = "cboCoach";
            this.cboCoach.Size = new System.Drawing.Size(132, 21);
            this.cboCoach.TabIndex = 130;
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(38, 100);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(79, 15);
            this.lblTrainName.TabIndex = 131;
            this.lblTrainName.Text = "Select Coach";
            // 
            // ucUpdateCoachID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucUpdateCoachID";
            this.Size = new System.Drawing.Size(291, 272);
            this.Load += new System.EventHandler(this.ucUpdateCoachID_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCoachID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblCoachNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCoach;
        private System.Windows.Forms.Label lblTrainName;

    }
}
