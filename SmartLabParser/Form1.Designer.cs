namespace SmartLabParser
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpAddStats = new System.Windows.Forms.DateTimePicker();
            this.bAddStats = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbNcellImages = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnStart = new System.Windows.Forms.Button();
            this.nudNpages = new System.Windows.Forms.NumericUpDown();
            this.pbNimages = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpages)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 103);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(836, 355);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpAddStats);
            this.panel1.Controls.Add(this.bAddStats);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbNcellImages);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bttnStart);
            this.panel1.Controls.Add(this.nudNpages);
            this.panel1.Controls.Add(this.pbNimages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 103);
            this.panel1.TabIndex = 1;
            // 
            // dtpAddStats
            // 
            this.dtpAddStats.Location = new System.Drawing.Point(394, 22);
            this.dtpAddStats.Name = "dtpAddStats";
            this.dtpAddStats.Size = new System.Drawing.Size(117, 20);
            this.dtpAddStats.TabIndex = 8;
            // 
            // bAddStats
            // 
            this.bAddStats.Location = new System.Drawing.Point(517, 19);
            this.bAddStats.Name = "bAddStats";
            this.bAddStats.Size = new System.Drawing.Size(135, 23);
            this.bAddStats.TabIndex = 7;
            this.bAddStats.Text = "Добавить статистику";
            this.bAddStats.UseVisualStyleBackColor = true;
            this.bAddStats.Click += new System.EventHandler(this.bAddStats_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(693, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Распознание ячеек";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выполнение загрузки";
            // 
            // pbNcellImages
            // 
            this.pbNcellImages.Location = new System.Drawing.Point(26, 78);
            this.pbNcellImages.Name = "pbNcellImages";
            this.pbNcellImages.Size = new System.Drawing.Size(783, 10);
            this.pbNcellImages.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Страниц для копирования";
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(261, 19);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(108, 23);
            this.bttnStart.TabIndex = 2;
            this.bttnStart.Text = "Начать загрузку";
            this.bttnStart.UseVisualStyleBackColor = true;
            this.bttnStart.Click += new System.EventHandler(this.bttnStart_Click);
            // 
            // nudNpages
            // 
            this.nudNpages.Location = new System.Drawing.Point(179, 22);
            this.nudNpages.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNpages.Name = "nudNpages";
            this.nudNpages.Size = new System.Drawing.Size(63, 20);
            this.nudNpages.TabIndex = 1;
            this.nudNpages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pbNimages
            // 
            this.pbNimages.Location = new System.Drawing.Point(26, 48);
            this.pbNimages.Name = "pbNimages";
            this.pbNimages.Size = new System.Drawing.Size(783, 10);
            this.pbNimages.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 458);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttnStart;
        private System.Windows.Forms.NumericUpDown nudNpages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar pbNimages;
        public System.Windows.Forms.ProgressBar pbNcellImages;
        private System.Windows.Forms.DateTimePicker dtpAddStats;
        private System.Windows.Forms.Button bAddStats;
    }
}

