namespace CxFlatDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cxFlatTabControl1 = new CxFlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cxFlatGroupBox1 = new CxFlatGroupBox();
            this.cxFlatToggle1 = new CxFlatToggle();
            this.cxFlatCheckBox1 = new CxFlatCheckBox();
            this.cxFlatRadioButton1 = new CxFlatRadioButton();
            this.cxFlatRadioButton2 = new CxFlatRadioButton();
            this.cxFlatProgressBar1 = new CxFlatProgressBar();
            this.cxFlatToggle2 = new CxFlatToggle();
            this.cxFlatRoundProgressBar1 = new CxFlatRoundProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cxFlatStatusBar1 = new CxFlatStatusBar();
            this.cxFlatButton1 = new CxFlatButton();
            this.cxFlatButton2 = new CxFlatButton();
            this.cxFlatTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cxFlatGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cxFlatTabControl1
            // 
            this.cxFlatTabControl1.Controls.Add(this.tabPage1);
            this.cxFlatTabControl1.Controls.Add(this.tabPage2);
            this.cxFlatTabControl1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatTabControl1.HotTrack = true;
            this.cxFlatTabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.cxFlatTabControl1.Location = new System.Drawing.Point(0, 61);
            this.cxFlatTabControl1.Name = "cxFlatTabControl1";
            this.cxFlatTabControl1.SelectedIndex = 0;
            this.cxFlatTabControl1.Size = new System.Drawing.Size(802, 386);
            this.cxFlatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.cxFlatTabControl1.TabIndex = 11;
            this.cxFlatTabControl1.ThemeColor = System.Drawing.Color.RoyalBlue;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cxFlatButton2);
            this.tabPage1.Controls.Add(this.cxFlatGroupBox1);
            this.tabPage1.Controls.Add(this.cxFlatProgressBar1);
            this.tabPage1.Controls.Add(this.cxFlatToggle2);
            this.tabPage1.Controls.Add(this.cxFlatRoundProgressBar1);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cxFlatGroupBox1
            // 
            this.cxFlatGroupBox1.Controls.Add(this.cxFlatToggle1);
            this.cxFlatGroupBox1.Controls.Add(this.cxFlatCheckBox1);
            this.cxFlatGroupBox1.Controls.Add(this.cxFlatRadioButton1);
            this.cxFlatGroupBox1.Controls.Add(this.cxFlatRadioButton2);
            this.cxFlatGroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatGroupBox1.Location = new System.Drawing.Point(374, 24);
            this.cxFlatGroupBox1.Name = "cxFlatGroupBox1";
            this.cxFlatGroupBox1.Size = new System.Drawing.Size(330, 252);
            this.cxFlatGroupBox1.TabIndex = 8;
            this.cxFlatGroupBox1.TabStop = false;
            this.cxFlatGroupBox1.Text = "cxFlatGroupBox1";
            this.cxFlatGroupBox1.ThemeColor = System.Drawing.Color.RoyalBlue;
            // 
            // cxFlatToggle1
            // 
            this.cxFlatToggle1.AutoSize = true;
            this.cxFlatToggle1.Checked = true;
            this.cxFlatToggle1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cxFlatToggle1.Enabled = false;
            this.cxFlatToggle1.Location = new System.Drawing.Point(52, 61);
            this.cxFlatToggle1.Name = "cxFlatToggle1";
            this.cxFlatToggle1.Size = new System.Drawing.Size(48, 20);
            this.cxFlatToggle1.TabIndex = 10;
            this.cxFlatToggle1.Text = "cxFlatToggle1";
            this.cxFlatToggle1.ThemeColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatToggle1.UseVisualStyleBackColor = true;
            // 
            // cxFlatCheckBox1
            // 
            this.cxFlatCheckBox1.AutoSize = true;
            this.cxFlatCheckBox1.CheckedColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatCheckBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatCheckBox1.Location = new System.Drawing.Point(56, 158);
            this.cxFlatCheckBox1.Name = "cxFlatCheckBox1";
            this.cxFlatCheckBox1.Size = new System.Drawing.Size(151, 20);
            this.cxFlatCheckBox1.TabIndex = 2;
            this.cxFlatCheckBox1.Text = "cxFlatCheckBox1";
            this.cxFlatCheckBox1.UseVisualStyleBackColor = true;
            // 
            // cxFlatRadioButton1
            // 
            this.cxFlatRadioButton1.AutoSize = true;
            this.cxFlatRadioButton1.CheckedColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatRadioButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatRadioButton1.Location = new System.Drawing.Point(56, 86);
            this.cxFlatRadioButton1.Name = "cxFlatRadioButton1";
            this.cxFlatRadioButton1.Size = new System.Drawing.Size(170, 20);
            this.cxFlatRadioButton1.TabIndex = 1;
            this.cxFlatRadioButton1.TabStop = true;
            this.cxFlatRadioButton1.Text = "cxFlatRadioButton1";
            this.cxFlatRadioButton1.UseVisualStyleBackColor = true;
            // 
            // cxFlatRadioButton2
            // 
            this.cxFlatRadioButton2.AutoSize = true;
            this.cxFlatRadioButton2.CheckedColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatRadioButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatRadioButton2.Location = new System.Drawing.Point(56, 122);
            this.cxFlatRadioButton2.Name = "cxFlatRadioButton2";
            this.cxFlatRadioButton2.Size = new System.Drawing.Size(170, 20);
            this.cxFlatRadioButton2.TabIndex = 3;
            this.cxFlatRadioButton2.TabStop = true;
            this.cxFlatRadioButton2.Text = "cxFlatRadioButton2";
            this.cxFlatRadioButton2.UseVisualStyleBackColor = true;
            // 
            // cxFlatProgressBar1
            // 
            this.cxFlatProgressBar1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cxFlatProgressBar1.Location = new System.Drawing.Point(6, 294);
            this.cxFlatProgressBar1.Name = "cxFlatProgressBar1";
            this.cxFlatProgressBar1.ShowTip = true;
            this.cxFlatProgressBar1.Size = new System.Drawing.Size(790, 32);
            this.cxFlatProgressBar1.TabIndex = 6;
            this.cxFlatProgressBar1.Text = "cxFlatProgressBar1";
            this.cxFlatProgressBar1.ThemeColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatProgressBar1.ValueNumber = 0;
            // 
            // cxFlatToggle2
            // 
            this.cxFlatToggle2.AutoSize = true;
            this.cxFlatToggle2.Location = new System.Drawing.Point(171, 147);
            this.cxFlatToggle2.Name = "cxFlatToggle2";
            this.cxFlatToggle2.Size = new System.Drawing.Size(48, 20);
            this.cxFlatToggle2.TabIndex = 10;
            this.cxFlatToggle2.Text = "cxFlatToggle2";
            this.cxFlatToggle2.ThemeColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatToggle2.UseVisualStyleBackColor = true;
            this.cxFlatToggle2.CheckStateChanged += new System.EventHandler(this.button1_Click);
            // 
            // cxFlatRoundProgressBar1
            // 
            this.cxFlatRoundProgressBar1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxFlatRoundProgressBar1.Location = new System.Drawing.Point(57, 156);
            this.cxFlatRoundProgressBar1.Name = "cxFlatRoundProgressBar1";
            this.cxFlatRoundProgressBar1.RoundWidth = 8F;
            this.cxFlatRoundProgressBar1.Size = new System.Drawing.Size(103, 103);
            this.cxFlatRoundProgressBar1.TabIndex = 7;
            this.cxFlatRoundProgressBar1.Text = "cxFlatRoundProgressBar1";
            this.cxFlatRoundProgressBar1.ThemeColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatRoundProgressBar1.ValueNumber = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cxFlatStatusBar1
            // 
            this.cxFlatStatusBar1.BackColor = System.Drawing.Color.Tomato;
            this.cxFlatStatusBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxFlatStatusBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatStatusBar1.Location = new System.Drawing.Point(0, 0);
            this.cxFlatStatusBar1.Name = "cxFlatStatusBar1";
            this.cxFlatStatusBar1.Size = new System.Drawing.Size(825, 45);
            this.cxFlatStatusBar1.TabIndex = 0;
            this.cxFlatStatusBar1.Text = "cxFlatStatusBar1";
            this.cxFlatStatusBar1.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.cxFlatStatusBar1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // cxFlatButton1
            // 
            this.cxFlatButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatButton1.Location = new System.Drawing.Point(5, 6);
            this.cxFlatButton1.Name = "cxFlatButton1";
            this.cxFlatButton1.Size = new System.Drawing.Size(128, 39);
            this.cxFlatButton1.TabIndex = 9;
            this.cxFlatButton1.Text = "cxFlatButton1";
            this.cxFlatButton1.TextColor = System.Drawing.Color.White;
            this.cxFlatButton1.ThemeColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cxFlatButton2
            // 
            this.cxFlatButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatButton2.Location = new System.Drawing.Point(171, 197);
            this.cxFlatButton2.Name = "cxFlatButton2";
            this.cxFlatButton2.Size = new System.Drawing.Size(130, 37);
            this.cxFlatButton2.TabIndex = 11;
            this.cxFlatButton2.Text = "cxFlatButton2";
            this.cxFlatButton2.TextColor = System.Drawing.Color.White;
            this.cxFlatButton2.ThemeColor = System.Drawing.Color.RoyalBlue;
            this.cxFlatButton2.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 546);
            this.Controls.Add(this.cxFlatTabControl1);
            this.Controls.Add(this.cxFlatStatusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.cxFlatTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cxFlatGroupBox1.ResumeLayout(false);
            this.cxFlatGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CxFlatStatusBar cxFlatStatusBar1;
        private CxFlatRadioButton cxFlatRadioButton1;
        private CxFlatCheckBox cxFlatCheckBox1;
        private CxFlatRadioButton cxFlatRadioButton2;
        private System.Windows.Forms.Timer timer1;
        private CxFlatProgressBar cxFlatProgressBar1;
        private CxFlatRoundProgressBar cxFlatRoundProgressBar1;
        private CxFlatGroupBox cxFlatGroupBox1;
        private CxFlatButton cxFlatButton1;
        private CxFlatToggle cxFlatToggle1;
        private CxFlatToggle cxFlatToggle2;
        private CxFlatTabControl cxFlatTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CxFlatButton cxFlatButton2;
    }
}

