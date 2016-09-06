namespace PISGPRS
{
    partial class ModemConfiguration
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.cboPortNo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.cboBitsPerSec = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(76, 221);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 30);
            this.btnConnect.TabIndex = 107;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisConnect.Location = new System.Drawing.Point(180, 221);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(81, 30);
            this.btnDisConnect.TabIndex = 111;
            this.btnDisConnect.Text = "Disconnect";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(78, 295);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 112;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.cboPortNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboStopBits);
            this.groupBox1.Controls.Add(this.cboParity);
            this.groupBox1.Controls.Add(this.cboDataBits);
            this.groupBox1.Controls.Add(this.cboBitsPerSec);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTrainName);
            this.groupBox1.Location = new System.Drawing.Point(7, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 149);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(46, 16);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 123;
            // 
            // cboPortNo
            // 
            this.cboPortNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortNo.FormattingEnabled = true;
            this.cboPortNo.Location = new System.Drawing.Point(161, 46);
            this.cboPortNo.Name = "cboPortNo";
            this.cboPortNo.Size = new System.Drawing.Size(121, 21);
            this.cboPortNo.TabIndex = 122;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 121;
            this.label5.Text = "Port No";
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(161, 199);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(121, 21);
            this.cboStopBits.TabIndex = 119;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(161, 183);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 21);
            this.cboParity.TabIndex = 118;
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(161, 167);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 21);
            this.cboDataBits.TabIndex = 117;
            // 
            // cboBitsPerSec
            // 
            this.cboBitsPerSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBitsPerSec.FormattingEnabled = true;
            this.cboBitsPerSec.Location = new System.Drawing.Point(161, 97);
            this.cboBitsPerSec.Name = "cboBitsPerSec";
            this.cboBitsPerSec.Size = new System.Drawing.Size(121, 21);
            this.cboBitsPerSec.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 114;
            this.label3.Text = "Stop Bits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 113;
            this.label2.Text = "Parity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 112;
            this.label1.Text = "Data Bits";
            // 
            // lblTrainName
            // 
            this.lblTrainName.AutoSize = true;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(46, 103);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(57, 15);
            this.lblTrainName.TabIndex = 111;
            this.lblTrainName.Text = "Baudrate";
            // 
            // ModemConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 336);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDisConnect);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModemConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Port Settings";
            this.Load += new System.EventHandler(this.ModemConfiguration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPortNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.ComboBox cboBitsPerSec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrainName;
        private System.Windows.Forms.Label lblMsg;
    }
}