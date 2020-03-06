namespace DVR.Devices
{
    partial class WebCam_Select
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
            label1 = new System.Windows.Forms.Label();
            btnConnect = new System.Windows.Forms.Button();
            cboUSBDevices = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(92, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(209, 16);
            label1.TabIndex = 1;
            label1.Text = "Select a webcam from the list";
            // 
            // btnConnect
            // 
            btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnConnect.Location = new System.Drawing.Point(137, 87);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(113, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += new System.EventHandler(BtnConnect_Click);
            // 
            // cboUSBDevices
            // 
            cboUSBDevices.FormattingEnabled = true;
            cboUSBDevices.Location = new System.Drawing.Point(12, 42);
            cboUSBDevices.Name = "cboUSBDevices";
            cboUSBDevices.Size = new System.Drawing.Size(371, 21);
            cboUSBDevices.TabIndex = 4;
            // 
            // WebCam_Select
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(395, 122);
            Controls.Add(cboUSBDevices);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WebCam_Select";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "WebCamera Selection";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboUSBDevices;
    }
}