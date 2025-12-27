using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace BasicChat
{
    partial class FormProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Controls để bên Logic có thể gọi được
        private Guna2CirclePictureBox pbAvatar;
        private Guna2Button btnSave;
        private Guna2Button btnClose;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblHint;
        private Guna2Elipse guna2Elipse1;
        private Guna2DragControl guna2DragControl1;

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
        /// Hàm khởi tạo giao diện - KHÔNG SỬA LOGIC Ở ĐÂY
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();

            // 
            // Form Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(41))))); // Màu nền tối
            this.ClientSize = new System.Drawing.Size(350, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormProfile";

            // 
            // guna2Elipse1 (Bo tròn Form)
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;

            // 
            // guna2DragControl1 (Cho phép kéo thả Form)
            // 
            this.guna2DragControl1.TargetControl = this;

            // 
            // btnClose (Nút đóng X)
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(300, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✕";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // pbAvatar (Ảnh đại diện)
            // 
            this.pbAvatar.FillColor = System.Drawing.Color.Gray;
            this.pbAvatar.ImageRotate = 0F;
            this.pbAvatar.Location = new System.Drawing.Point(115, 60);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAvatar.Size = new System.Drawing.Size(120, 120);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatar.TabIndex = 1;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // lblUsername (Tên User)
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(0, 220);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(350, 30);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "@Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblHint (Hướng dẫn)
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(112, 190);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(126, 15);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "Click ảnh để thay đổi";

            // 
            // btnSave (Nút Lưu)
            // 
            this.btnSave.BorderRadius = 20;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(36)))), ((int)(((byte)(206))))); // Màu Tím chủ đạo
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(75, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 45);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "LƯU THAY ĐỔI";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // Add Controls
            // 
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.btnClose);

            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}