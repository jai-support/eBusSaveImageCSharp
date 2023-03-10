namespace wCapture
{
    partial class cap
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
            this.displayControl = new PvGUIDotNet.PvDisplayControl();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnStartstream = new System.Windows.Forms.Button();
            this.btnStopstream = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.chbSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // displayControl
            // 
            this.displayControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayControl.BackColor = System.Drawing.Color.Transparent;
            this.displayControl.BackgroundColor = System.Drawing.Color.DarkGray;
            this.displayControl.Location = new System.Drawing.Point(146, 12);
            this.displayControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.displayControl.Name = "displayControl";
            this.displayControl.ROI = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.displayControl.Size = new System.Drawing.Size(429, 357);
            this.displayControl.TabIndex = 8;
            this.displayControl.TextOverlay = "";
            this.displayControl.TextOverlayColor = System.Drawing.Color.Lime;
            this.displayControl.TextOverlayOffsetX = 10;
            this.displayControl.TextOverlayOffsetY = 10;
            this.displayControl.TextOverlaySize = 18;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(30, 12);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 36);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Enabled = false;
            this.btnConfigure.Location = new System.Drawing.Point(30, 76);
            this.btnConfigure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(95, 38);
            this.btnConfigure.TabIndex = 10;
            this.btnConfigure.Text = "configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnStartstream
            // 
            this.btnStartstream.Enabled = false;
            this.btnStartstream.Location = new System.Drawing.Point(30, 142);
            this.btnStartstream.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStartstream.Name = "btnStartstream";
            this.btnStartstream.Size = new System.Drawing.Size(95, 40);
            this.btnStartstream.TabIndex = 12;
            this.btnStartstream.Text = "startstream";
            this.btnStartstream.UseVisualStyleBackColor = true;
            this.btnStartstream.Click += new System.EventHandler(this.btnStartstream_Click);
            // 
            // btnStopstream
            // 
            this.btnStopstream.Enabled = false;
            this.btnStopstream.Location = new System.Drawing.Point(30, 213);
            this.btnStopstream.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStopstream.Name = "btnStopstream";
            this.btnStopstream.Size = new System.Drawing.Size(95, 40);
            this.btnStopstream.TabIndex = 13;
            this.btnStopstream.Text = "stopstream";
            this.btnStopstream.UseVisualStyleBackColor = true;
            this.btnStopstream.Click += new System.EventHandler(this.btnStopstream_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(30, 284);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(95, 40);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "disconnetct";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refresh_timer_Tick);
            // 
            // chbSave
            // 
            this.chbSave.AutoSize = true;
            this.chbSave.Location = new System.Drawing.Point(30, 341);
            this.chbSave.Name = "chbSave";
            this.chbSave.Size = new System.Drawing.Size(70, 17);
            this.chbSave.TabIndex = 15;
            this.chbSave.Text = "saveBmp";
            this.chbSave.UseVisualStyleBackColor = true;
            // 
            // cap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 381);
            this.Controls.Add(this.chbSave);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnStopstream);
            this.Controls.Add(this.btnStartstream);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.displayControl);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "cap";
            this.Text = "Cap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PvGUIDotNet.PvDisplayControl displayControl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Button btnStartstream;
        private System.Windows.Forms.Button btnStopstream;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.CheckBox chbSave;
    }
}

