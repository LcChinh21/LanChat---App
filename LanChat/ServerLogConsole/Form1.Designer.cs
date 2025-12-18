namespace ServerLogConsole
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rtbLog = new RichTextBox();
            btnStart = new Button();
            txtPort = new TextBox();
            lblPort = new Label();
            pnlTop = new Panel();
            lblTitle = new Label();
            lblStatus = new Label();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(30, 30, 30);
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rtbLog.ForeColor = Color.White;
            rtbLog.Location = new Point(0, 93);
            rtbLog.Margin = new Padding(3, 4, 3, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(686, 440);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.LimeGreen;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(171, 47);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(137, 40);
            btnStart.TabIndex = 3;
            btnStart.Text = "Chay Server";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPort.Location = new Point(63, 52);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(91, 30);
            txtPort.TabIndex = 2;
            txtPort.Text = "9000";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPort.ForeColor = Color.White;
            lblPort.Location = new Point(14, 56);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(45, 23);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port:";
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(45, 45, 48);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblPort);
            pnlTop.Controls.Add(txtPort);
            pnlTop.Controls.Add(btnStart);
            pnlTop.Controls.Add(lblStatus);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(686, 93);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LanChat Server";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(331, 56);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 23);
            lblStatus.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(686, 533);
            Controls.Add(rtbLog);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LanChat Server";
            FormClosing += Form1_FormClosing;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }
    }
}
