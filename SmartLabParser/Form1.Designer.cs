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
            this.bttnStart = new System.Windows.Forms.Button();
            this.nudNpages = new System.Windows.Forms.NumericUpDown();
            this.pbNpages = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNpages)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 81);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(836, 377);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bttnStart);
            this.panel1.Controls.Add(this.nudNpages);
            this.panel1.Controls.Add(this.pbNpages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 81);
            this.panel1.TabIndex = 1;
            // 
            // bttnStart
            // 
            this.bttnStart.Location = new System.Drawing.Point(444, 19);
            this.bttnStart.Name = "bttnStart";
            this.bttnStart.Size = new System.Drawing.Size(75, 23);
            this.bttnStart.TabIndex = 2;
            this.bttnStart.Text = "button1";
            this.bttnStart.UseVisualStyleBackColor = true;
            this.bttnStart.Click += new System.EventHandler(this.bttnStart_Click);
            // 
            // nudNpages
            // 
            this.nudNpages.Location = new System.Drawing.Point(305, 22);
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
            // pbNpages
            // 
            this.pbNpages.Location = new System.Drawing.Point(26, 65);
            this.pbNpages.Name = "pbNpages";
            this.pbNpages.Size = new System.Drawing.Size(783, 10);
            this.pbNpages.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.nudNpages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttnStart;
        private System.Windows.Forms.NumericUpDown nudNpages;
        private System.Windows.Forms.ProgressBar pbNpages;
    }
}

