namespace BasicChat
{
    partial class FormCreateGroup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtGroupName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateGroup));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            resources.ApplyResources(this.txtGroupName, "txtGroupName");
            this.txtGroupName.ForeColor = System.Drawing.Color.White;
            this.txtGroupName.Name = "txtGroupName";
            // 
            // lblCreate
            // 
            resources.ApplyResources(this.lblCreate, "lblCreate");
            this.lblCreate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Click += new System.EventHandler(this.lblCreate_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.lblCancel);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // FormCreateGroup
            // 
            this.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtGroupName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateGroup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
