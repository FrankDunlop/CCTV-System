namespace DVR.Search
{
    partial class SearchFrm
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
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            SearchDateBtn = new System.Windows.Forms.Button();
            FileListlst = new System.Windows.Forms.ListBox();
            lblNumFiles = new System.Windows.Forms.Label();
            QueryDate = new System.Windows.Forms.DateTimePicker();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new System.Drawing.Point(18, 18);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowToday = false;
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(monthCalendar1_DateSelected);
            // 
            // SearchDateBtn
            // 
            SearchDateBtn.Location = new System.Drawing.Point(110, 29);
            SearchDateBtn.Name = "SearchDateBtn";
            SearchDateBtn.Size = new System.Drawing.Size(55, 20);
            SearchDateBtn.TabIndex = 1;
            SearchDateBtn.Text = "Search";
            SearchDateBtn.UseVisualStyleBackColor = true;
            SearchDateBtn.Click += new System.EventHandler(SearchDateBtn_Click);
            // 
            // FileListlst
            // 
            FileListlst.FormattingEnabled = true;
            FileListlst.Location = new System.Drawing.Point(251, 31);
            FileListlst.Name = "FileListlst";
            FileListlst.Size = new System.Drawing.Size(499, 225);
            FileListlst.TabIndex = 3;
            FileListlst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(FileListlst_MouseDoubleClick);
            // 
            // lblNumFiles
            // 
            lblNumFiles.AutoSize = true;
            lblNumFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblNumFiles.Location = new System.Drawing.Point(326, 9);
            lblNumFiles.Name = "lblNumFiles";
            lblNumFiles.Size = new System.Drawing.Size(53, 13);
            lblNumFiles.TabIndex = 4;
            lblNumFiles.Text = "numfiles";
            // 
            // QueryDate
            // 
            QueryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            QueryDate.Location = new System.Drawing.Point(10, 29);
            QueryDate.Name = "QueryDate";
            QueryDate.ShowUpDown = true;
            QueryDate.Size = new System.Drawing.Size(89, 20);
            QueryDate.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(SearchDateBtn);
            groupBox1.Controls.Add(QueryDate);
            groupBox1.Location = new System.Drawing.Point(18, 185);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(178, 71);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search By Date";
            // 
            // SearchFrm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(762, 270);
            Controls.Add(groupBox1);
            Controls.Add(lblNumFiles);
            Controls.Add(FileListlst);
            Controls.Add(monthCalendar1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchFrm";
            ShowIcon = false;
            Text = "Calender Search";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button SearchDateBtn;
        private System.Windows.Forms.ListBox FileListlst;
        private System.Windows.Forms.Label lblNumFiles;
        private System.Windows.Forms.DateTimePicker QueryDate;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}