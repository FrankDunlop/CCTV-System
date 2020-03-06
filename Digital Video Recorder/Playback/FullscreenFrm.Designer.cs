namespace DVR.Fullscreen
{
    partial class FullscreenFrm
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
            components = new System.ComponentModel.Container();
            FullscreenPBox = new System.Windows.Forms.PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)(FullscreenPBox)).BeginInit();
            SuspendLayout();
            // 
            // FullscreenPBox
            // 
            FullscreenPBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            FullscreenPBox.Location = new System.Drawing.Point(0, 0);
            FullscreenPBox.Name = "FullscreenPBox";
            FullscreenPBox.Size = new System.Drawing.Size(292, 266);
            FullscreenPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            FullscreenPBox.TabIndex = 0;
            FullscreenPBox.TabStop = false;
            FullscreenPBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(FullscreenPBox_MouseDoubleClick);
            // 
            // timer1
            // 
            timer1.Tick += new System.EventHandler(timer1_Tick);
            // 
            // FullscreenFrm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlText;
            ClientSize = new System.Drawing.Size(292, 266);
            Controls.Add(FullscreenPBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FullscreenFrm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(FullscreenPBox)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox FullscreenPBox;
        private System.Windows.Forms.Timer timer1;
    }
}