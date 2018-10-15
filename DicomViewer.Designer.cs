namespace DicomViewer
{
    partial class DicomViewer
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicomViewer));
            this.panel_Top = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Close = new System.Windows.Forms.PictureBox();
            this.pictureBox_OpenFile = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.pictureBoxStop = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayPause = new System.Windows.Forms.PictureBox();
            this.pictureBoxPrevious = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.radiobtn1 = new System.Windows.Forms.RadioButton();
            this.radiobtn2 = new System.Windows.Forms.RadioButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panelClient = new System.Windows.Forms.Panel();
            this.pictureBox_Display = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OpenFile)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Display)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            this.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Top.Controls.Add(this.pictureBox2);
            this.panel_Top.Controls.Add(this.pictureBox1);
            this.panel_Top.Controls.Add(this.pictureBox_Close);
            this.panel_Top.Controls.Add(this.pictureBox_OpenFile);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(965, 40);
            this.panel_Top.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DicomViewer.Properties.Resources.设置;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = global::DicomViewer.Properties.Resources.设置;
            this.pictureBox2.Location = new System.Drawing.Point(743, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DicomViewer.Properties.Resources.打开目录;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::DicomViewer.Properties.Resources.打开目录;
            this.pictureBox1.Location = new System.Drawing.Point(110, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox_Close
            // 
            this.pictureBox_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox_Close.Image = global::DicomViewer.Properties.Resources.关闭;
            this.pictureBox_Close.Location = new System.Drawing.Point(853, 0);
            this.pictureBox_Close.Name = "pictureBox_Close";
            this.pictureBox_Close.Size = new System.Drawing.Size(110, 38);
            this.pictureBox_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Close.TabIndex = 2;
            this.pictureBox_Close.TabStop = false;
            this.pictureBox_Close.Click += new System.EventHandler(this.pictureBox_Close_Click);
            // 
            // pictureBox_OpenFile
            // 
            this.pictureBox_OpenFile.BackgroundImage = global::DicomViewer.Properties.Resources.打开文件;
            this.pictureBox_OpenFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_OpenFile.Image = global::DicomViewer.Properties.Resources.打开文件;
            this.pictureBox_OpenFile.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_OpenFile.Name = "pictureBox_OpenFile";
            this.pictureBox_OpenFile.Size = new System.Drawing.Size(110, 38);
            this.pictureBox_OpenFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_OpenFile.TabIndex = 0;
            this.pictureBox_OpenFile.TabStop = false;
            this.pictureBox_OpenFile.Click += new System.EventHandler(this.pictureBox_OpenFile_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBoxNext);
            this.panel2.Controls.Add(this.pictureBoxStop);
            this.panel2.Controls.Add(this.pictureBoxPlayPause);
            this.panel2.Controls.Add(this.pictureBoxPrevious);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.radiobtn1);
            this.panel2.Controls.Add(this.radiobtn2);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 760);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(965, 80);
            this.panel2.TabIndex = 1;
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxNext.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNext.Image")));
            this.pictureBoxNext.Location = new System.Drawing.Point(587, 22);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNext.TabIndex = 10;
            this.pictureBoxNext.TabStop = false;
            this.pictureBoxNext.Click += new System.EventHandler(this.pictureBoxNext_Click);
            // 
            // pictureBoxStop
            // 
            this.pictureBoxStop.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxStop.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStop.Image")));
            this.pictureBoxStop.Location = new System.Drawing.Point(447, 21);
            this.pictureBoxStop.Name = "pictureBoxStop";
            this.pictureBoxStop.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStop.TabIndex = 11;
            this.pictureBoxStop.TabStop = false;
            this.pictureBoxStop.Click += new System.EventHandler(this.pictureBoxStop_Click);
            // 
            // pictureBoxPlayPause
            // 
            this.pictureBoxPlayPause.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxPlayPause.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlayPause.Image")));
            this.pictureBoxPlayPause.Location = new System.Drawing.Point(541, 22);
            this.pictureBoxPlayPause.Name = "pictureBoxPlayPause";
            this.pictureBoxPlayPause.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxPlayPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPlayPause.TabIndex = 8;
            this.pictureBoxPlayPause.TabStop = false;
            this.pictureBoxPlayPause.Click += new System.EventHandler(this.pictureBoxPlayPause_Click);
            // 
            // pictureBoxPrevious
            // 
            this.pictureBoxPrevious.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxPrevious.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPrevious.Image")));
            this.pictureBoxPrevious.Location = new System.Drawing.Point(493, 22);
            this.pictureBoxPrevious.Name = "pictureBoxPrevious";
            this.pictureBoxPrevious.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPrevious.TabIndex = 9;
            this.pictureBoxPrevious.TabStop = false;
            this.pictureBoxPrevious.Click += new System.EventHandler(this.pictureBoxPrevious_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::DicomViewer.Properties.Resources.播放进度;
            this.pictureBox5.Image = global::DicomViewer.Properties.Resources.播放进度;
            this.pictureBox5.Location = new System.Drawing.Point(634, 20);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(110, 38);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(746, 28);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(199, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // radiobtn1
            // 
            this.radiobtn1.AutoSize = true;
            this.radiobtn1.Checked = true;
            this.radiobtn1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radiobtn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(179)))), ((int)(((byte)(191)))));
            this.radiobtn1.Location = new System.Drawing.Point(120, 31);
            this.radiobtn1.Name = "radiobtn1";
            this.radiobtn1.Size = new System.Drawing.Size(44, 26);
            this.radiobtn1.TabIndex = 4;
            this.radiobtn1.TabStop = true;
            this.radiobtn1.Text = "否";
            this.radiobtn1.UseVisualStyleBackColor = true;
            this.radiobtn1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radiobtn2
            // 
            this.radiobtn2.AutoSize = true;
            this.radiobtn2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radiobtn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(179)))), ((int)(((byte)(191)))));
            this.radiobtn2.Location = new System.Drawing.Point(176, 31);
            this.radiobtn2.Name = "radiobtn2";
            this.radiobtn2.Size = new System.Drawing.Size(44, 26);
            this.radiobtn2.TabIndex = 3;
            this.radiobtn2.Text = "是";
            this.radiobtn2.UseVisualStyleBackColor = true;
            this.radiobtn2.CheckedChanged += new System.EventHandler(this.radiobtn1_CheckedChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::DicomViewer.Properties.Resources.显示信息;
            this.pictureBox4.Image = global::DicomViewer.Properties.Resources.显示信息;
            this.pictureBox4.Location = new System.Drawing.Point(5, 20);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(110, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::DicomViewer.Properties.Resources.播放速度;
            this.pictureBox3.Image = global::DicomViewer.Properties.Resources.播放速度;
            this.pictureBox3.Location = new System.Drawing.Point(223, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(110, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            this.numericUpDown1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(179)))), ((int)(((byte)(191)))));
            this.numericUpDown1.Location = new System.Drawing.Point(339, 23);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(101, 33);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            this.panelClient.Controls.Add(this.pictureBox_Display);
            this.panelClient.Controls.Add(this.listView1);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(0, 40);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(965, 720);
            this.panelClient.TabIndex = 2;
            // 
            // pictureBox_Display
            // 
            this.pictureBox_Display.Location = new System.Drawing.Point(246, 8);
            this.pictureBox_Display.Name = "pictureBox_Display";
            this.pictureBox_Display.Size = new System.Drawing.Size(700, 700);
            this.pictureBox_Display.TabIndex = 1;
            this.pictureBox_Display.TabStop = false;
            this.pictureBox_Display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Display_MouseDown);
            this.pictureBox_Display.MouseLeave += new System.EventHandler(this.pictureBox_Display_MouseLeave);
            this.pictureBox_Display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Display_MouseMove);
            this.pictureBox_Display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Display_MouseUp);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(74)))), ((int)(((byte)(87)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(221, 720);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(150, 150);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DicomViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 840);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DicomViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OpenFile)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox_OpenFile;
        private System.Windows.Forms.PictureBox pictureBox_Close;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_Display;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton radiobtn1;
        private System.Windows.Forms.RadioButton radiobtn2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBoxNext;
        private System.Windows.Forms.PictureBox pictureBoxStop;
        private System.Windows.Forms.PictureBox pictureBoxPlayPause;
        private System.Windows.Forms.PictureBox pictureBoxPrevious;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

