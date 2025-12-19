namespace BasicChat
{
    partial class DangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSignIn;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.pictrboxLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblExit = new Guna.UI2.WinForms.Guna2Button();
            this.pictrboxUser = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictrboxPassword = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictrboxServerIP = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtSeverIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxServerIP)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(142, 91);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSignIn.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSignIn.Location = new System.Drawing.Point(141, 427);
            this.lblSignIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(175, 16);
            this.lblSignIn.TabIndex = 6;
            this.lblSignIn.Text = "Chưa có tài khoản? Đăng ký.";
            this.lblSignIn.Click += new System.EventHandler(this.lblSignIn_Click);
            // 
            // pictrboxLogo
            // 
            this.pictrboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxLogo.Image")));
            this.pictrboxLogo.ImageRotate = 0F;
            this.pictrboxLogo.InitialImage = null;
            this.pictrboxLogo.Location = new System.Drawing.Point(205, 22);
            this.pictrboxLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictrboxLogo.Name = "pictrboxLogo";
            this.pictrboxLogo.Size = new System.Drawing.Size(69, 58);
            this.pictrboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxLogo.TabIndex = 7;
            this.pictrboxLogo.TabStop = false;
            // 
            // lblExit
            // 
            this.lblExit.BorderRadius = 15;
            this.lblExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lblExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lblExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lblExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lblExit.FillColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Red;
            this.lblExit.IndicateFocus = true;
            this.lblExit.Location = new System.Drawing.Point(410, 2);
            this.lblExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(55, 44);
            this.lblExit.TabIndex = 8;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // pictrboxUser
            // 
            this.pictrboxUser.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxUser.Image")));
            this.pictrboxUser.ImageRotate = 0F;
            this.pictrboxUser.Location = new System.Drawing.Point(48, 147);
            this.pictrboxUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictrboxUser.Name = "pictrboxUser";
            this.pictrboxUser.Size = new System.Drawing.Size(39, 32);
            this.pictrboxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxUser.TabIndex = 9;
            this.pictrboxUser.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 15;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(102, 147);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Nhập tên đăng nhập";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(292, 37);
            this.txtName.TabIndex = 10;
            // 
            // pictrboxPassword
            // 
            this.pictrboxPassword.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxPassword.Image")));
            this.pictrboxPassword.ImageRotate = 0F;
            this.pictrboxPassword.Location = new System.Drawing.Point(48, 222);
            this.pictrboxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictrboxPassword.Name = "pictrboxPassword";
            this.pictrboxPassword.Size = new System.Drawing.Size(39, 32);
            this.pictrboxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxPassword.TabIndex = 11;
            this.pictrboxPassword.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 15;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(102, 222);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(292, 38);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // pictrboxServerIP
            // 
            this.pictrboxServerIP.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxServerIP.Image")));
            this.pictrboxServerIP.ImageRotate = 0F;
            this.pictrboxServerIP.Location = new System.Drawing.Point(48, 298);
            this.pictrboxServerIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictrboxServerIP.Name = "pictrboxServerIP";
            this.pictrboxServerIP.Size = new System.Drawing.Size(39, 32);
            this.pictrboxServerIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxServerIP.TabIndex = 13;
            this.pictrboxServerIP.TabStop = false;
            // 
            // txtSeverIP
            // 
            this.txtSeverIP.BorderRadius = 15;
            this.txtSeverIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSeverIP.DefaultText = "";
            this.txtSeverIP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSeverIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSeverIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSeverIP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSeverIP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSeverIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSeverIP.ForeColor = System.Drawing.Color.Black;
            this.txtSeverIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSeverIP.Location = new System.Drawing.Point(102, 298);
            this.txtSeverIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeverIP.Name = "txtSeverIP";
            this.txtSeverIP.PlaceholderText = "Nhập IP của server";
            this.txtSeverIP.SelectedText = "";
            this.txtSeverIP.Size = new System.Drawing.Size(292, 38);
            this.txtSeverIP.TabIndex = 14;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 15;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(110, 376);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(252, 36);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 468);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtSeverIP);
            this.Controls.Add(this.pictrboxServerIP);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.pictrboxPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pictrboxUser);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.pictrboxLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dang Nhap - LanChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangNhap_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxServerIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2PictureBox pictrboxLogo;
        private Guna.UI2.WinForms.Guna2Button lblExit;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxUser;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxServerIP;
        private Guna.UI2.WinForms.Guna2TextBox txtSeverIP;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
