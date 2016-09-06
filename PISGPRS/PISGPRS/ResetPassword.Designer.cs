namespace PISGPRS
{
    partial class ResetPassword
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtOldPwd = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtConfirmPwd = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtxtNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(37, 15);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Old Password";
            // 
            // mtxtOldPwd
            // 
            this.mtxtOldPwd.Location = new System.Drawing.Point(176, 58);
            this.mtxtOldPwd.Name = "mtxtOldPwd";
            this.mtxtOldPwd.Size = new System.Drawing.Size(138, 20);
            this.mtxtOldPwd.TabIndex = 29;
            this.mtxtOldPwd.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(66, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 30);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "New Password";
            // 
            // mtxtConfirmPwd
            // 
            this.mtxtConfirmPwd.Location = new System.Drawing.Point(176, 126);
            this.mtxtConfirmPwd.Name = "mtxtConfirmPwd";
            this.mtxtConfirmPwd.Size = new System.Drawing.Size(138, 20);
            this.mtxtConfirmPwd.TabIndex = 31;
            this.mtxtConfirmPwd.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Confirm Password";
            // 
            // mtxtNewPassword
            // 
            this.mtxtNewPassword.Location = new System.Drawing.Point(176, 92);
            this.mtxtNewPassword.Name = "mtxtNewPassword";
            this.mtxtNewPassword.Size = new System.Drawing.Size(138, 20);
            this.mtxtNewPassword.TabIndex = 30;
            this.mtxtNewPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(176, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 252);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtOldPwd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtConfirmPwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mtxtNewPassword);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtOldPwd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtConfirmPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtxtNewPassword;
        private System.Windows.Forms.Button btnCancel;
    }
}