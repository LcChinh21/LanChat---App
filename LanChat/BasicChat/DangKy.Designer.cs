namespace BasicChat
{
    partial class DangKy
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBack;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKy));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pictrboxLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblExit = new Guna.UI2.WinForms.Guna2Button();
            this.pictrboxUser = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictrboxPassword = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictrboxEmail = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictrboxIPServer = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtSeverIP = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxIPServer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(166, 124);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(181, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBack.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblBack.Location = new System.Drawing.Point(170, 578);
            this.lblBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(199, 20);
            this.lblBack.TabIndex = 8;
            this.lblBack.Text = "< Quay lại Form đăng nhập";
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // pictrboxLogo
            // 
            this.pictrboxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxLogo.Image")));
            this.pictrboxLogo.ImageRotate = 0F;
            this.pictrboxLogo.InitialImage = null;
            this.pictrboxLogo.Location = new System.Drawing.Point(218, 48);
            this.pictrboxLogo.Name = "pictrboxLogo";
            this.pictrboxLogo.Size = new System.Drawing.Size(78, 73);
            this.pictrboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxLogo.TabIndex = 11;
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
            this.lblExit.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Red;
            this.lblExit.Location = new System.Drawing.Point(433, 12);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(69, 57);
            this.lblExit.TabIndex = 12;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // pictrboxUser
            // 
            this.pictrboxUser.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxUser.Image")));
            this.pictrboxUser.ImageRotate = 0F;
            this.pictrboxUser.Location = new System.Drawing.Point(62, 198);
            this.pictrboxUser.Name = "pictrboxUser";
            this.pictrboxUser.Size = new System.Drawing.Size(46, 41);
            this.pictrboxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxUser.TabIndex = 13;
            this.pictrboxUser.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 15;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(126, 198);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Nhập tên đăng nhập";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(322, 47);
            this.txtUsername.TabIndex = 14;
            // 
            // pictrboxPassword
            // 
            this.pictrboxPassword.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxPassword.Image")));
            this.pictrboxPassword.ImageRotate = 0F;
            this.pictrboxPassword.Location = new System.Drawing.Point(62, 278);
            this.pictrboxPassword.Name = "pictrboxPassword";
            this.pictrboxPassword.Size = new System.Drawing.Size(46, 39);
            this.pictrboxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxPassword.TabIndex = 15;
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
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(126, 278);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(322, 47);
            this.txtPassword.TabIndex = 16;
            // 
            // pictrboxEmail
            // 
            this.pictrboxEmail.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxEmail.Image")));
            this.pictrboxEmail.ImageRotate = 0F;
            this.pictrboxEmail.Location = new System.Drawing.Point(62, 356);
            this.pictrboxEmail.Name = "pictrboxEmail";
            this.pictrboxEmail.Size = new System.Drawing.Size(46, 46);
            this.pictrboxEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxEmail.TabIndex = 17;
            this.pictrboxEmail.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 15;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(126, 356);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Nhập địa chỉ email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(322, 46);
            this.txtEmail.TabIndex = 18;
            // 
            // pictrboxIPServer
            // 
            this.pictrboxIPServer.Image = ((System.Drawing.Image)(resources.GetObject("pictrboxIPServer.Image")));
            this.pictrboxIPServer.ImageRotate = 0F;
            this.pictrboxIPServer.Location = new System.Drawing.Point(62, 431);
            this.pictrboxIPServer.Name = "pictrboxIPServer";
            this.pictrboxIPServer.Size = new System.Drawing.Size(46, 40);
            this.pictrboxIPServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictrboxIPServer.TabIndex = 19;
            this.pictrboxIPServer.TabStop = false;
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
            this.txtSeverIP.ForeColor = System.Drawing.Color.Gray;
            this.txtSeverIP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSeverIP.Location = new System.Drawing.Point(126, 431);
            this.txtSeverIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSeverIP.Name = "txtSeverIP";
            this.txtSeverIP.PlaceholderText = "Nhập IP Server";
            this.txtSeverIP.SelectedText = "";
            this.txtSeverIP.Size = new System.Drawing.Size(322, 48);
            this.txtSeverIP.TabIndex = 20;
            // 
            // btnRegister
            // 
            this.btnRegister.BorderRadius = 20;
            this.btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegister.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(126, 512);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(270, 45);
            this.btnRegister.TabIndex = 21;
            this.btnRegister.Text = "ĐĂNG KÝ";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 622);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtSeverIP);
            this.Controls.Add(this.pictrboxIPServer);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pictrboxEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.pictrboxPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictrboxUser);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.pictrboxLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangKy_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictrboxIPServer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button lblExit;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxLogo;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxUser;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtSeverIP;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxIPServer;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2PictureBox pictrboxEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}
