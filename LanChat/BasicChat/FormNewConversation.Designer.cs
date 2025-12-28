namespace BasicChat
{
    partial class FormNewConversation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Control
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.ListView lstUsers;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.SuspendLayout();

            // 
            // guna2BorderlessForm1 (Bo tròn và bỏ viền window)
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tạo cuộc hội thoại mới";

            // 
            // lblClose (Nút X)
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClose.ForeColor = System.Drawing.Color.Gray;
            this.lblClose.Location = new System.Drawing.Point(360, 20);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(20, 21);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "✕";

            // 
            // txtSearch (Ô tìm kiếm)
            // 
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.BorderThickness = 0;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(41)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(20, 65);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm người dùng...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(360, 40);
            this.txtSearch.TabIndex = 2;

            // 
            // guna2Separator1 (Đường kẻ ngang)
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(20, 115);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(360, 10);
            this.guna2Separator1.TabIndex = 3;

            // 
            // lstUsers (Danh sách User)
            // 
            this.lstUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstUsers.ForeColor = System.Drawing.Color.White;
            this.lstUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstUsers.HideSelection = false;
            this.lstUsers.Location = new System.Drawing.Point(20, 130);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(360, 350);
            this.lstUsers.TabIndex = 4;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.List;

            // 
            // FormNewConversation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNewConversation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormNewConversation";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}