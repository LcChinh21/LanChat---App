namespace BasicChat
{
    partial class FormChat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRightInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnInvite = new Guna.UI2.WinForms.Guna2Button();
            this.flowMembers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMemberCount = new System.Windows.Forms.Label();
            this.lblGroupNameRight = new System.Windows.Forms.Label();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeaderContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.txtSearchGroup = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlGroupList = new Guna.UI2.WinForms.Guna2Panel();
            this.flowGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlChatArea = new Guna.UI2.WinForms.Guna2Panel();
            this.flowMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlInput = new Guna.UI2.WinForms.Guna2Panel();
            this.txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnEmoji = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendFile = new Guna.UI2.WinForms.Guna2Button();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.pbGroupIconRight = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnTabUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabGroup = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddGroup = new Guna.UI2.WinForms.Guna2Button();
            this.pbAppIcon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlRightInfo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlHeaderContent.SuspendLayout();
            this.pnlGroupList.SuspendLayout();
            this.pnlChatArea.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGroupIconRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.pnlSidebar.Controls.Add(this.btnTabUser);
            this.pnlSidebar.Controls.Add(this.btnTabGroup);
            this.pnlSidebar.Controls.Add(this.btnAddGroup);
            this.pnlSidebar.Controls.Add(this.pbAppIcon);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(4, 4);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(78, 592);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlRightInfo
            // 
            this.pnlRightInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.pnlRightInfo.Controls.Add(this.btnInvite);
            this.pnlRightInfo.Controls.Add(this.flowMembers);
            this.pnlRightInfo.Controls.Add(this.lblMemberCount);
            this.pnlRightInfo.Controls.Add(this.lblGroupNameRight);
            this.pnlRightInfo.Controls.Add(this.pbGroupIconRight);
            this.pnlRightInfo.Controls.Add(this.guna2ControlBox3);
            this.pnlRightInfo.Controls.Add(this.guna2ControlBox2);
            this.pnlRightInfo.Controls.Add(this.guna2ControlBox1);
            this.pnlRightInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightInfo.Location = new System.Drawing.Point(714, 4);
            this.pnlRightInfo.Name = "pnlRightInfo";
            this.pnlRightInfo.Size = new System.Drawing.Size(180, 592);
            this.pnlRightInfo.TabIndex = 1;
            // 
            // btnInvite
            // 
            this.btnInvite.BorderRadius = 15;
            this.btnInvite.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnInvite.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(191)))), ((int)(((byte)(229)))));
            this.btnInvite.Image = global::BasicChat.Properties.Resources.add;
            this.btnInvite.ImageSize = new System.Drawing.Size(12, 12);
            this.btnInvite.Location = new System.Drawing.Point(135, 125);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(35, 33);
            this.btnInvite.TabIndex = 2;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click_1);
            // 
            // flowMembers
            // 
            this.flowMembers.AutoScroll = true;
            this.flowMembers.Location = new System.Drawing.Point(10, 160);
            this.flowMembers.Name = "flowMembers";
            this.flowMembers.Size = new System.Drawing.Size(160, 430);
            this.flowMembers.TabIndex = 7;
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.AutoSize = true;
            this.lblMemberCount.ForeColor = System.Drawing.Color.Gray;
            this.lblMemberCount.Location = new System.Drawing.Point(12, 135);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.Size = new System.Drawing.Size(98, 20);
            this.lblMemberCount.TabIndex = 8;
            this.lblMemberCount.Text = "Members (0)";
            // 
            // lblGroupNameRight
            // 
            this.lblGroupNameRight.AutoSize = true;
            this.lblGroupNameRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupNameRight.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblGroupNameRight.Location = new System.Drawing.Point(60, 80);
            this.lblGroupNameRight.Name = "lblGroupNameRight";
            this.lblGroupNameRight.Size = new System.Drawing.Size(124, 22);
            this.lblGroupNameRight.TabIndex = 6;
            this.lblGroupNameRight.Text = "No Selection";
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(30, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 9;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(81, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 10;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(132, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 11;
            this.guna2ControlBox1.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderContent);
            this.pnlHeader.Controls.Add(this.txtSearchGroup);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(82, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(632, 50);
            this.pnlHeader.TabIndex = 2;
            // 
            // pnlHeaderContent
            // 
            this.pnlHeaderContent.Controls.Add(this.lblHeaderTitle);
            this.pnlHeaderContent.Location = new System.Drawing.Point(210, 0);
            this.pnlHeaderContent.Name = "pnlHeaderContent";
            this.pnlHeaderContent.Size = new System.Drawing.Size(430, 50);
            this.pnlHeaderContent.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(248, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Welcome to LanChat";
            // 
            // txtSearchGroup
            // 
            this.txtSearchGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.txtSearchGroup.BorderRadius = 10;
            this.txtSearchGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchGroup.DefaultText = "";
            this.txtSearchGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
            this.txtSearchGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchGroup.ForeColor = System.Drawing.Color.White;
            this.txtSearchGroup.Location = new System.Drawing.Point(10, 10);
            this.txtSearchGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.PlaceholderText = "Search...";
            this.txtSearchGroup.SelectedText = "";
            this.txtSearchGroup.Size = new System.Drawing.Size(190, 30);
            this.txtSearchGroup.TabIndex = 0;
            // 
            // pnlGroupList
            // 
            this.pnlGroupList.Controls.Add(this.flowGroups);
            this.pnlGroupList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGroupList.Location = new System.Drawing.Point(82, 54);
            this.pnlGroupList.Name = "pnlGroupList";
            this.pnlGroupList.Size = new System.Drawing.Size(210, 542);
            this.pnlGroupList.TabIndex = 3;
            // 
            // flowGroups
            // 
            this.flowGroups.AutoScroll = true;
            this.flowGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.flowGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowGroups.Location = new System.Drawing.Point(0, 0);
            this.flowGroups.Name = "flowGroups";
            this.flowGroups.Size = new System.Drawing.Size(210, 542);
            this.flowGroups.TabIndex = 0;
            this.flowGroups.WrapContents = false;
            // 
            // pnlChatArea
            // 
            this.pnlChatArea.Controls.Add(this.flowMessages);
            this.pnlChatArea.Controls.Add(this.pnlInput);
            this.pnlChatArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChatArea.Location = new System.Drawing.Point(292, 54);
            this.pnlChatArea.Name = "pnlChatArea";
            this.pnlChatArea.Size = new System.Drawing.Size(422, 542);
            this.pnlChatArea.TabIndex = 4;
            // 
            // flowMessages
            // 
            this.flowMessages.AutoScroll = true;
            this.flowMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
            this.flowMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMessages.Location = new System.Drawing.Point(0, 0);
            this.flowMessages.Name = "flowMessages";
            this.flowMessages.Size = new System.Drawing.Size(422, 492);
            this.flowMessages.TabIndex = 0;
            this.flowMessages.WrapContents = false;
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(53)))));
            this.pnlInput.Controls.Add(this.btnEmoji);
            this.pnlInput.Controls.Add(this.btnSendFile);
            this.pnlInput.Controls.Add(this.btnSend);
            this.pnlInput.Controls.Add(this.txtMessage);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInput.Location = new System.Drawing.Point(0, 492);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(422, 50);
            this.pnlInput.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.txtMessage.BorderRadius = 15;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.DefaultText = "";
            this.txtMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(6, 8);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "Type a message...";
            this.txtMessage.SelectedText = "";
            this.txtMessage.Size = new System.Drawing.Size(281, 36);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlHeader;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // btnEmoji
            // 
            this.btnEmoji.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEmoji.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEmoji.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEmoji.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEmoji.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEmoji.FillColor = System.Drawing.Color.Transparent;
            this.btnEmoji.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEmoji.ForeColor = System.Drawing.Color.White;
            this.btnEmoji.Image = global::BasicChat.Properties.Resources.happy;
            this.btnEmoji.ImageSize = new System.Drawing.Size(25, 25);
            this.btnEmoji.Location = new System.Drawing.Point(294, 8);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(36, 36);
            this.btnEmoji.TabIndex = 3;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSendFile.BorderRadius = 15;
            this.btnSendFile.FillColor = System.Drawing.Color.Transparent;
            this.btnSendFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSendFile.Image")));
            this.btnSendFile.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSendFile.Location = new System.Drawing.Point(336, 8);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(35, 36);
            this.btnSendFile.TabIndex = 0;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSend.BorderRadius = 15;
            this.btnSend.FillColor = System.Drawing.Color.Transparent;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = global::BasicChat.Properties.Resources.send;
            this.btnSend.Location = new System.Drawing.Point(377, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(38, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pbGroupIconRight
            // 
            this.pbGroupIconRight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(125)))), ((int)(((byte)(93)))));
            this.pbGroupIconRight.ImageRotate = 0F;
            this.pbGroupIconRight.Location = new System.Drawing.Point(15, 70);
            this.pbGroupIconRight.Name = "pbGroupIconRight";
            this.pbGroupIconRight.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbGroupIconRight.Size = new System.Drawing.Size(40, 40);
            this.pbGroupIconRight.TabIndex = 3;
            this.pbGroupIconRight.TabStop = false;
            this.pbGroupIconRight.Click += new System.EventHandler(this.pbGroupIconRight_Click);
            // 
            // btnTabUser
            // 
            this.btnTabUser.BorderRadius = 10;
            this.btnTabUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnTabUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTabUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(191)))), ((int)(((byte)(229)))));
            this.btnTabUser.Image = ((System.Drawing.Image)(resources.GetObject("btnTabUser.Image")));
            this.btnTabUser.Location = new System.Drawing.Point(12, 135);
            this.btnTabUser.Name = "btnTabUser";
            this.btnTabUser.Size = new System.Drawing.Size(50, 50);
            this.btnTabUser.TabIndex = 3;
            this.btnTabUser.Click += new System.EventHandler(this.btnTabUser_Click);
            // 
            // btnTabGroup
            // 
            this.btnTabGroup.BorderRadius = 10;
            this.btnTabGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnTabGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTabGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(191)))), ((int)(((byte)(229)))));
            this.btnTabGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnTabGroup.Image")));
            this.btnTabGroup.Location = new System.Drawing.Point(12, 70);
            this.btnTabGroup.Name = "btnTabGroup";
            this.btnTabGroup.Size = new System.Drawing.Size(50, 50);
            this.btnTabGroup.TabIndex = 2;
            this.btnTabGroup.Click += new System.EventHandler(this.btnTabGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BorderRadius = 10;
            this.btnAddGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(191)))), ((int)(((byte)(229)))));
            this.btnAddGroup.Image = global::BasicChat.Properties.Resources.add;
            this.btnAddGroup.Location = new System.Drawing.Point(12, 204);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(50, 50);
            this.btnAddGroup.TabIndex = 1;
            this.btnAddGroup.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // pbAppIcon
            // 
            this.pbAppIcon.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.pbAppIcon.ImageRotate = 0F;
            this.pbAppIcon.Location = new System.Drawing.Point(16, 12);
            this.pbAppIcon.Name = "pbAppIcon";
            this.pbAppIcon.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAppIcon.Size = new System.Drawing.Size(40, 40);
            this.pbAppIcon.TabIndex = 0;
            this.pbAppIcon.TabStop = false;
            // 
            // FormChat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(898, 600);
            this.Controls.Add(this.pnlChatArea);
            this.Controls.Add(this.pnlGroupList);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlRightInfo);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChat";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "LanChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlRightInfo.ResumeLayout(false);
            this.pnlRightInfo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeaderContent.ResumeLayout(false);
            this.pnlHeaderContent.PerformLayout();
            this.pnlGroupList.ResumeLayout(false);
            this.pnlChatArea.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGroupIconRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAppIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2Panel pnlRightInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlGroupList;
        private Guna.UI2.WinForms.Guna2Panel pnlChatArea;

        // Sidebar controls
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAppIcon;
        private Guna.UI2.WinForms.Guna2Button btnAddGroup;

        // Group List
        private Guna.UI2.WinForms.Guna2TextBox txtSearchGroup;
        private System.Windows.Forms.FlowLayoutPanel flowGroups;

        // Chat Area
        private Guna.UI2.WinForms.Guna2Panel pnlInput;
        private Guna.UI2.WinForms.Guna2TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2Button btnSendFile;
        private System.Windows.Forms.FlowLayoutPanel flowMessages;
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderContent;
        private System.Windows.Forms.Label lblHeaderTitle;

        // Right Info
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbGroupIconRight;
        private System.Windows.Forms.Label lblGroupNameRight;
        private System.Windows.Forms.FlowLayoutPanel flowMembers;
        private System.Windows.Forms.Label lblMemberCount;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btnInvite;
        private Guna.UI2.WinForms.Guna2Button btnTabUser;
        private Guna.UI2.WinForms.Guna2Button btnTabGroup;
        private Guna.UI2.WinForms.Guna2Button btnEmoji;
    }
}