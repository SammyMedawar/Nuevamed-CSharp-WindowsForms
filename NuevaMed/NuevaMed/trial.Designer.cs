namespace NuevaMed
{
    partial class trial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trial));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.closeApp = new System.Windows.Forms.PictureBox();
            this.gridView = new System.Windows.Forms.FlowLayoutPanel();
            this.currentMonth = new System.Windows.Forms.Label();
            this.currentYear = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addNoteToDay = new System.Windows.Forms.PictureBox();
            this.eventsScrollingView = new System.Windows.Forms.FlowLayoutPanel();
            this.weatherConditionText = new System.Windows.Forms.Label();
            this.weatherDegree = new System.Windows.Forms.Label();
            this.currentDayOfWeek = new System.Windows.Forms.Label();
            this.currentDayOfMonth = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeApp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addNoteToDay)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(35)))));
            this.mainPanel.Controls.Add(this.closeApp);
            this.mainPanel.Controls.Add(this.gridView);
            this.mainPanel.Controls.Add(this.currentMonth);
            this.mainPanel.Controls.Add(this.currentYear);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainPanel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(617, 668);
            this.mainPanel.TabIndex = 7;
            // 
            // closeApp
            // 
            this.closeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeApp.Location = new System.Drawing.Point(8, 5);
            this.closeApp.Margin = new System.Windows.Forms.Padding(4);
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(31, 28);
            this.closeApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeApp.TabIndex = 5;
            this.closeApp.TabStop = false;
            // 
            // gridView
            // 
            this.gridView.AllowDrop = true;
            this.gridView.Font = new System.Drawing.Font("Microsoft YaHei", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridView.Location = new System.Drawing.Point(32, 147);
            this.gridView.Margin = new System.Windows.Forms.Padding(4);
            this.gridView.Name = "gridView";
            this.gridView.Size = new System.Drawing.Size(560, 512);
            this.gridView.TabIndex = 2;
            // 
            // currentMonth
            // 
            this.currentMonth.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonth.ForeColor = System.Drawing.Color.White;
            this.currentMonth.Location = new System.Drawing.Point(36, 88);
            this.currentMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentMonth.Name = "currentMonth";
            this.currentMonth.Size = new System.Drawing.Size(549, 32);
            this.currentMonth.TabIndex = 1;
            this.currentMonth.Text = "December";
            this.currentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentYear
            // 
            this.currentYear.AutoSize = true;
            this.currentYear.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentYear.ForeColor = System.Drawing.Color.White;
            this.currentYear.Location = new System.Drawing.Point(255, 24);
            this.currentYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentYear.Name = "currentYear";
            this.currentYear.Size = new System.Drawing.Size(104, 45);
            this.currentYear.TabIndex = 0;
            this.currentYear.Text = "2018";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.addNoteToDay);
            this.panel1.Controls.Add(this.eventsScrollingView);
            this.panel1.Controls.Add(this.weatherConditionText);
            this.panel1.Controls.Add(this.weatherDegree);
            this.panel1.Controls.Add(this.currentDayOfWeek);
            this.panel1.Controls.Add(this.currentDayOfMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(614, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 668);
            this.panel1.TabIndex = 8;
            // 
            // addNoteToDay
            // 
            this.addNoteToDay.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.addNoteToDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNoteToDay.ErrorImage = ((System.Drawing.Image)(resources.GetObject("addNoteToDay.ErrorImage")));
            this.addNoteToDay.Location = new System.Drawing.Point(8, 116);
            this.addNoteToDay.Margin = new System.Windows.Forms.Padding(4);
            this.addNoteToDay.Name = "addNoteToDay";
            this.addNoteToDay.Size = new System.Drawing.Size(32, 29);
            this.addNoteToDay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addNoteToDay.TabIndex = 6;
            this.addNoteToDay.TabStop = false;
            this.addNoteToDay.Click += new System.EventHandler(this.addNoteToDay_Click);
            // 
            // eventsScrollingView
            // 
            this.eventsScrollingView.AllowDrop = true;
            this.eventsScrollingView.AutoScroll = true;
            this.eventsScrollingView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.eventsScrollingView.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.eventsScrollingView.Location = new System.Drawing.Point(0, 151);
            this.eventsScrollingView.Margin = new System.Windows.Forms.Padding(4);
            this.eventsScrollingView.Name = "eventsScrollingView";
            this.eventsScrollingView.Size = new System.Drawing.Size(453, 517);
            this.eventsScrollingView.TabIndex = 5;
            this.eventsScrollingView.WrapContents = false;
            // 
            // weatherConditionText
            // 
            this.weatherConditionText.AutoSize = true;
            this.weatherConditionText.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherConditionText.ForeColor = System.Drawing.Color.White;
            this.weatherConditionText.Location = new System.Drawing.Point(263, 48);
            this.weatherConditionText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.weatherConditionText.Name = "weatherConditionText";
            this.weatherConditionText.Size = new System.Drawing.Size(0, 20);
            this.weatherConditionText.TabIndex = 4;
            // 
            // weatherDegree
            // 
            this.weatherDegree.AutoSize = true;
            this.weatherDegree.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherDegree.ForeColor = System.Drawing.Color.White;
            this.weatherDegree.Location = new System.Drawing.Point(264, 28);
            this.weatherDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.weatherDegree.Name = "weatherDegree";
            this.weatherDegree.Size = new System.Drawing.Size(0, 20);
            this.weatherDegree.TabIndex = 3;
            // 
            // currentDayOfWeek
            // 
            this.currentDayOfWeek.AutoSize = true;
            this.currentDayOfWeek.Font = new System.Drawing.Font("Microsoft YaHei", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDayOfWeek.ForeColor = System.Drawing.Color.White;
            this.currentDayOfWeek.Location = new System.Drawing.Point(307, 56);
            this.currentDayOfWeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentDayOfWeek.Name = "currentDayOfWeek";
            this.currentDayOfWeek.Size = new System.Drawing.Size(116, 30);
            this.currentDayOfWeek.TabIndex = 1;
            this.currentDayOfWeek.Text = "Thursday";
            // 
            // currentDayOfMonth
            // 
            this.currentDayOfMonth.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentDayOfMonth.ForeColor = System.Drawing.Color.White;
            this.currentDayOfMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentDayOfMonth.Location = new System.Drawing.Point(89, 5);
            this.currentDayOfMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentDayOfMonth.Name = "currentDayOfMonth";
            this.currentDayOfMonth.Size = new System.Drawing.Size(144, 100);
            this.currentDayOfMonth.TabIndex = 0;
            this.currentDayOfMonth.Text = "15";
            this.currentDayOfMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 668);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "trial";
            this.Text = "trial";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeApp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addNoteToDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox closeApp;
        private System.Windows.Forms.FlowLayoutPanel gridView;
        private System.Windows.Forms.Label currentMonth;
        private System.Windows.Forms.Label currentYear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox addNoteToDay;
        private System.Windows.Forms.FlowLayoutPanel eventsScrollingView;
        private System.Windows.Forms.Label weatherConditionText;
        private System.Windows.Forms.Label weatherDegree;
        private System.Windows.Forms.Label currentDayOfWeek;
        private System.Windows.Forms.Label currentDayOfMonth;
    }
}