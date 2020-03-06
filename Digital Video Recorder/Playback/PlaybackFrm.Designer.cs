namespace DVR.PlaybackScreen
{
    partial class Playback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playback));
            Cam1Playback = new System.Windows.Forms.GroupBox();
            trackBar1 = new System.Windows.Forms.TrackBar();
            Cam1OpenBtn = new System.Windows.Forms.Button();
            Cam1ExitBtn = new System.Windows.Forms.Button();
            Cam1StopBtn = new System.Windows.Forms.Button();
            Cam1PauseBtn = new System.Windows.Forms.Button();
            Cam1FastBtn = new System.Windows.Forms.Button();
            Cam1SlowBtn = new System.Windows.Forms.Button();
            Cam1PlayBtn = new System.Windows.Forms.Button();
            PlaybackWindow = new System.Windows.Forms.PictureBox();
            TrackBar1Timer = new System.Windows.Forms.Timer(components);
            Cam1Playback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PlaybackWindow)).BeginInit();
            SuspendLayout();
            // 
            // Cam1Playback
            // 
            Cam1Playback.BackColor = System.Drawing.SystemColors.Control;
            Cam1Playback.Controls.Add(trackBar1);
            Cam1Playback.Controls.Add(Cam1OpenBtn);
            Cam1Playback.Controls.Add(Cam1ExitBtn);
            Cam1Playback.Controls.Add(Cam1StopBtn);
            Cam1Playback.Controls.Add(Cam1PauseBtn);
            Cam1Playback.Controls.Add(Cam1FastBtn);
            Cam1Playback.Controls.Add(Cam1SlowBtn);
            Cam1Playback.Controls.Add(Cam1PlayBtn);
            Cam1Playback.Controls.Add(PlaybackWindow);
            Cam1Playback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1Playback.Location = new System.Drawing.Point(24, 2);
            Cam1Playback.Name = "Cam1Playback";
            Cam1Playback.Size = new System.Drawing.Size(332, 326);
            Cam1Playback.TabIndex = 37;
            Cam1Playback.TabStop = false;
            // 
            // trackBar1
            // 
            trackBar1.AutoSize = false;
            trackBar1.Location = new System.Drawing.Point(7, 258);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(320, 22);
            trackBar1.TabIndex = 35;
            trackBar1.Scroll += new System.EventHandler(trackBar1_Scroll);
            // 
            // Cam1OpenBtn
            // 
            Cam1OpenBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1OpenBtn.BackgroundImage")));
            Cam1OpenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1OpenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1OpenBtn.Location = new System.Drawing.Point(36, 286);
            Cam1OpenBtn.Name = "Cam1OpenBtn";
            Cam1OpenBtn.Size = new System.Drawing.Size(32, 34);
            Cam1OpenBtn.TabIndex = 35;
            Cam1OpenBtn.UseVisualStyleBackColor = true;
            Cam1OpenBtn.Click += new System.EventHandler(Cam1OpenBtn_Click);
            // 
            // Cam1ExitBtn
            // 
            Cam1ExitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1ExitBtn.BackgroundImage")));
            Cam1ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1ExitBtn.Location = new System.Drawing.Point(264, 286);
            Cam1ExitBtn.Name = "Cam1ExitBtn";
            Cam1ExitBtn.Size = new System.Drawing.Size(31, 34);
            Cam1ExitBtn.TabIndex = 34;
            Cam1ExitBtn.UseVisualStyleBackColor = true;
            Cam1ExitBtn.Click += new System.EventHandler(Cam1ExitBtn_Click);
            // 
            // Cam1StopBtn
            // 
            Cam1StopBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1StopBtn.BackgroundImage")));
            Cam1StopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1StopBtn.Location = new System.Drawing.Point(150, 286);
            Cam1StopBtn.Name = "Cam1StopBtn";
            Cam1StopBtn.Size = new System.Drawing.Size(32, 34);
            Cam1StopBtn.TabIndex = 33;
            Cam1StopBtn.UseVisualStyleBackColor = true;
            Cam1StopBtn.Click += new System.EventHandler(Cam1StopBtn_Click);
            // 
            // Cam1PauseBtn
            // 
            Cam1PauseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1PauseBtn.BackgroundImage")));
            Cam1PauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1PauseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1PauseBtn.Location = new System.Drawing.Point(112, 286);
            Cam1PauseBtn.Name = "Cam1PauseBtn";
            Cam1PauseBtn.Size = new System.Drawing.Size(32, 34);
            Cam1PauseBtn.TabIndex = 32;
            Cam1PauseBtn.UseVisualStyleBackColor = true;
            Cam1PauseBtn.Click += new System.EventHandler(Cam1PauseBtn_Click);
            // 
            // Cam1FastBtn
            // 
            Cam1FastBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1FastBtn.BackgroundImage")));
            Cam1FastBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1FastBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1FastBtn.Location = new System.Drawing.Point(226, 286);
            Cam1FastBtn.Name = "Cam1FastBtn";
            Cam1FastBtn.Size = new System.Drawing.Size(32, 34);
            Cam1FastBtn.TabIndex = 31;
            Cam1FastBtn.UseVisualStyleBackColor = true;
            Cam1FastBtn.Click += new System.EventHandler(Cam1FastBtn_Click);
            // 
            // Cam1SlowBtn
            // 
            Cam1SlowBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1SlowBtn.BackgroundImage")));
            Cam1SlowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1SlowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1SlowBtn.Location = new System.Drawing.Point(188, 286);
            Cam1SlowBtn.Name = "Cam1SlowBtn";
            Cam1SlowBtn.Size = new System.Drawing.Size(32, 34);
            Cam1SlowBtn.TabIndex = 30;
            Cam1SlowBtn.UseVisualStyleBackColor = true;
            Cam1SlowBtn.Click += new System.EventHandler(Cam1SlowBtn_Click);
            // 
            // Cam1PlayBtn
            // 
            Cam1PlayBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cam1PlayBtn.BackgroundImage")));
            Cam1PlayBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Cam1PlayBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Cam1PlayBtn.Location = new System.Drawing.Point(74, 286);
            Cam1PlayBtn.Name = "Cam1PlayBtn";
            Cam1PlayBtn.Size = new System.Drawing.Size(32, 34);
            Cam1PlayBtn.TabIndex = 29;
            Cam1PlayBtn.UseVisualStyleBackColor = true;
            Cam1PlayBtn.Click += new System.EventHandler(Cam1PlayBtn_Click);
            // 
            // PlaybackWindow
            // 
            PlaybackWindow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlaybackWindow.BackgroundImage")));
            PlaybackWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PlaybackWindow.Location = new System.Drawing.Point(6, 18);
            PlaybackWindow.Name = "PlaybackWindow";
            PlaybackWindow.Size = new System.Drawing.Size(320, 240);
            PlaybackWindow.TabIndex = 28;
            PlaybackWindow.TabStop = false;
            // 
            // TrackBar1Timer
            // 
            TrackBar1Timer.Tick += new System.EventHandler(TrackBar1Timer_Tick);
            // 
            // Playback
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(383, 336);
            Controls.Add(Cam1Playback);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Playback";
            ShowIcon = false;
            Text = "Playback Window";
            Cam1Playback.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PlaybackWindow)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Cam1Playback;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button Cam1OpenBtn;
        private System.Windows.Forms.Button Cam1ExitBtn;
        private System.Windows.Forms.Button Cam1StopBtn;
        private System.Windows.Forms.Button Cam1PauseBtn;
        private System.Windows.Forms.Button Cam1FastBtn;
        private System.Windows.Forms.Button Cam1SlowBtn;
        private System.Windows.Forms.Button Cam1PlayBtn;
        private System.Windows.Forms.PictureBox PlaybackWindow;
        private System.Windows.Forms.Timer TrackBar1Timer;
    }
}