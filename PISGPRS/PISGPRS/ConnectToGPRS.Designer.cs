namespace PISGPRS
{
    partial class ConnectToGPRS
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
            this.lblSignalStrength = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSignalStrength
            // 
            this.lblSignalStrength.AutoSize = true;
            this.lblSignalStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignalStrength.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSignalStrength.Location = new System.Drawing.Point(45, 95);
            this.lblSignalStrength.Name = "lblSignalStrength";
            this.lblSignalStrength.Size = new System.Drawing.Size(0, 16);
            this.lblSignalStrength.TabIndex = 127;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(152, 182);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(82, 30);
            this.btnDisconnect.TabIndex = 126;
            this.btnDisconnect.Text = "DisConnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblIPAddress.Location = new System.Drawing.Point(45, 65);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(0, 16);
            this.lblIPAddress.TabIndex = 125;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(42, 182);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(82, 30);
            this.btnConnect.TabIndex = 124;
            this.btnConnect.Text = "Connect ";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ConnectToGPRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblSignalStrength);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblIPAddress);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToGPRS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect To GPRS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSignalStrength;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button btnConnect;
    }
}