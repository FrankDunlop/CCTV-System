namespace DVR.Log
{
    partial class SystemLog
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
            ClearLogBtn = new System.Windows.Forms.Button();
            LogEntriestxt = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // ClearLogBtn
            // 
            ClearLogBtn.Location = new System.Drawing.Point(173, 422);
            ClearLogBtn.Name = "ClearLogBtn";
            ClearLogBtn.Size = new System.Drawing.Size(75, 23);
            ClearLogBtn.TabIndex = 0;
            ClearLogBtn.Text = "Clear Log";
            ClearLogBtn.UseVisualStyleBackColor = true;
            ClearLogBtn.Click += new System.EventHandler(ClearLogBtn_Click);
            // 
            // LogEntriestxt
            // 
            LogEntriestxt.Location = new System.Drawing.Point(12, 12);
            LogEntriestxt.Multiline = true;
            LogEntriestxt.Name = "LogEntriestxt";
            LogEntriestxt.ReadOnly = true;
            LogEntriestxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            LogEntriestxt.Size = new System.Drawing.Size(402, 404);
            LogEntriestxt.TabIndex = 1;
            // 
            // SystemLog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(428, 457);
            Controls.Add(LogEntriestxt);
            Controls.Add(ClearLogBtn);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SystemLog";
            ShowIcon = false;
            Text = "System Log";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearLogBtn;
        public System.Windows.Forms.TextBox LogEntriestxt;
    }
}