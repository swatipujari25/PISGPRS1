namespace PISGPRS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUserName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtPassword = new System.Windows.Forms.MaskedTextBox();
            this.picSCSLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSCSLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(249, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(120, 278);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = " Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(99, 150);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(74, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(323, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "PASSENGER INFORMATION SYSTEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(111, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "UNIVERSAL CONTROLS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "UserName";
            // 
            // cboUserName
            // 
            this.cboUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserName.FormattingEnabled = true;
            this.cboUserName.Location = new System.Drawing.Point(221, 191);
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.Size = new System.Drawing.Size(138, 21);
            this.cboUserName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Password";
            // 
            // mtxtPassword
            // 
            this.mtxtPassword.Location = new System.Drawing.Point(221, 227);
            this.mtxtPassword.Name = "mtxtPassword";
            this.mtxtPassword.Size = new System.Drawing.Size(138, 20);
            this.mtxtPassword.TabIndex = 1;
            this.mtxtPassword.UseSystemPasswordChar = true;
            this.mtxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtPassword_KeyPress);
            // 
            // picSCSLogo
            // 
            this.picSCSLogo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picSCSLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSCSLogo.BackgroundImage")));
            this.picSCSLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSCSLogo.Location = new System.Drawing.Point(199, 5);
            this.picSCSLogo.Name = "picSCSLogo";
            this.picSCSLogo.Size = new System.Drawing.Size(66, 57);
            this.picSCSLogo.TabIndex = 75;
            this.picSCSLogo.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(465, 354);
            this.Controls.Add(this.picSCSLogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.mtxtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboUserName);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passenger Information System";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSCSLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtPassword;
        private System.Windows.Forms.PictureBox picSCSLogo;
    }
}