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
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.LogEntriestxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.Location = new System.Drawing.Point(173, 422);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearLogBtn.TabIndex = 0;
            this.ClearLogBtn.Text = "Clear Log";
            this.ClearLogBtn.UseVisualStyleBackColor = true;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // LogEntriestxt
            // 
            this.LogEntriestxt.Location = new System.Drawing.Point(12, 12);
            this.LogEntriestxt.Multiline = true;
            this.LogEntriestxt.Name = "LogEntriestxt";
            this.LogEntriestxt.ReadOnly = true;
            this.LogEntriestxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogEntriestxt.Size = new System.Drawing.Size(402, 404);
            this.LogEntriestxt.TabIndex = 1;
            // 
            // SystemLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 457);
            this.Controls.Add(this.LogEntriestxt);
            this.Controls.Add(this.ClearLogBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemLog";
            this.ShowIcon = false;
            this.Text = "System Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearLogBtn;
        public System.Windows.Forms.TextBox LogEntriestxt;
    }
}