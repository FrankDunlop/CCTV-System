namespace DVR
{
    partial class IPCam_Select
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
            cboIPCams = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            chkAutentication = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lblPassword = new System.Windows.Forms.Label();
            lblUsername = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            txtUsername = new System.Windows.Forms.TextBox();
            BtnIPConnect = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cboIPCams
            // 
            cboIPCams.FormattingEnabled = true;
            cboIPCams.Location = new System.Drawing.Point(12, 28);
            cboIPCams.Name = "cboIPCams";
            cboIPCams.Size = new System.Drawing.Size(356, 21);
            cboIPCams.TabIndex = 0;
            cboIPCams.Text = "http://";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(21, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(344, 16);
            label1.TabIndex = 1;
            label1.Text = "Enter the cameras URL or select one from the list";
            // 
            // chkAutentication
            // 
            chkAutentication.AutoSize = true;
            chkAutentication.Location = new System.Drawing.Point(12, 62);
            chkAutentication.Name = "chkAutentication";
            chkAutentication.Size = new System.Drawing.Size(134, 17);
            chkAutentication.TabIndex = 6;
            chkAutentication.Text = "Autentication Required";
            chkAutentication.UseVisualStyleBackColor = true;
            chkAutentication.CheckedChanged += new System.EventHandler(chkAutentication_CheckedChanged);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPassword);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Location = new System.Drawing.Point(14, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(354, 80);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblPassword.Location = new System.Drawing.Point(24, 46);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(65, 13);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblUsername.Location = new System.Drawing.Point(24, 22);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(67, 13);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(95, 46);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(237, 20);
            txtPassword.TabIndex = 7;
            txtPassword.Text = "Dunlop";
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(95, 19);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(237, 20);
            txtUsername.TabIndex = 6;
            txtUsername.Text = "Frank";
            // 
            // BtnIPConnect
            // 
            BtnIPConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            BtnIPConnect.Location = new System.Drawing.Point(250, 58);
            BtnIPConnect.Name = "BtnIPConnect";
            BtnIPConnect.Size = new System.Drawing.Size(118, 23);
            BtnIPConnect.TabIndex = 10;
            BtnIPConnect.Text = "Connect";
            BtnIPConnect.UseVisualStyleBackColor = true;
            BtnIPConnect.Click += new System.EventHandler(BtnIPConnect_Click);
            // 
            // IPCam_Select
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(387, 184);
            Controls.Add(BtnIPConnect);
            Controls.Add(groupBox1);
            Controls.Add(chkAutentication);
            Controls.Add(label1);
            Controls.Add(cboIPCams);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IPCam_Select";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "IP Camera Selection";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboIPCams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutentication;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button BtnIPConnect;

    }
}