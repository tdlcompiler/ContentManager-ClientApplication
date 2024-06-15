namespace ContentManager_Application
{
    partial class UserMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabPageNovels;
        private TabPage tabPageAuthors;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            panelUserInfo = new Panel();
            btnLogout = new Button();
            labelServerStatus = new Label();
            labelOnlineUsersCount = new Label();
            labelStatusServer = new Label();
            labelOnlineUsers = new Label();
            btnEditProfile = new Button();
            labelUserRole = new Label();
            labelUserNickname = new Label();
            pictureBoxAvatar = new PictureBox();
            tabControl = new TabControl();
            tabPageAuthors = new TabPage();
            panelButtonContainer = new FlowLayoutPanel();
            buttonAddAuthor = new Button();
            buttonRemoveAuthor = new Button();
            buttonEditAuthor = new Button();
            pbLoadingAuthors = new PictureBox();
            dataGridViewAuthors = new DataGridView();
            tabPageNovels = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddNovel = new Button();
            btnRemoveNovel = new Button();
            btnEditNovel = new Button();
            pbLoadingNovels = new PictureBox();
            dataGridViewNovels = new DataGridView();
            panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            tabControl.SuspendLayout();
            tabPageAuthors.SuspendLayout();
            panelButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadingAuthors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuthors).BeginInit();
            tabPageNovels.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadingNovels).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNovels).BeginInit();
            SuspendLayout();
            // 
            // panelUserInfo
            // 
            panelUserInfo.Controls.Add(btnLogout);
            panelUserInfo.Controls.Add(labelServerStatus);
            panelUserInfo.Controls.Add(labelOnlineUsersCount);
            panelUserInfo.Controls.Add(labelStatusServer);
            panelUserInfo.Controls.Add(labelOnlineUsers);
            panelUserInfo.Controls.Add(btnEditProfile);
            panelUserInfo.Controls.Add(labelUserRole);
            panelUserInfo.Controls.Add(labelUserNickname);
            panelUserInfo.Controls.Add(pictureBoxAvatar);
            panelUserInfo.Dock = DockStyle.Bottom;
            panelUserInfo.Location = new Point(0, 484);
            panelUserInfo.Margin = new Padding(4, 3, 4, 3);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(870, 80);
            panelUserInfo.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Right;
            btnLogout.Location = new Point(439, 34);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 16;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // labelServerStatus
            // 
            labelServerStatus.Anchor = AnchorStyles.Right;
            labelServerStatus.AutoSize = true;
            labelServerStatus.Location = new Point(718, 46);
            labelServerStatus.Margin = new Padding(4, 0, 4, 0);
            labelServerStatus.Name = "labelServerStatus";
            labelServerStatus.Size = new Size(71, 15);
            labelServerStatus.TabIndex = 13;
            labelServerStatus.Text = "Неизвестно";
            // 
            // labelOnlineUsersCount
            // 
            labelOnlineUsersCount.Anchor = AnchorStyles.Right;
            labelOnlineUsersCount.AutoSize = true;
            labelOnlineUsersCount.Location = new Point(786, 27);
            labelOnlineUsersCount.Margin = new Padding(4, 0, 4, 0);
            labelOnlineUsersCount.Name = "labelOnlineUsersCount";
            labelOnlineUsersCount.Size = new Size(71, 15);
            labelOnlineUsersCount.TabIndex = 12;
            labelOnlineUsersCount.Text = "Неизвестно";
            // 
            // labelStatusServer
            // 
            labelStatusServer.Anchor = AnchorStyles.Right;
            labelStatusServer.AutoSize = true;
            labelStatusServer.Location = new Point(626, 46);
            labelStatusServer.Margin = new Padding(4, 0, 4, 0);
            labelStatusServer.Name = "labelStatusServer";
            labelStatusServer.Size = new Size(96, 15);
            labelStatusServer.TabIndex = 15;
            labelStatusServer.Text = "Статус сервера: ";
            // 
            // labelOnlineUsers
            // 
            labelOnlineUsers.Anchor = AnchorStyles.Right;
            labelOnlineUsers.AutoSize = true;
            labelOnlineUsers.Location = new Point(626, 27);
            labelOnlineUsers.Margin = new Padding(4, 0, 4, 0);
            labelOnlineUsers.Name = "labelOnlineUsers";
            labelOnlineUsers.Size = new Size(163, 15);
            labelOnlineUsers.TabIndex = 14;
            labelOnlineUsers.Text = "Количество пользователей: ";
            // 
            // btnEditProfile
            // 
            btnEditProfile.Anchor = AnchorStyles.Right;
            btnEditProfile.Location = new Point(520, 25);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(99, 40);
            btnEditProfile.TabIndex = 7;
            btnEditProfile.Text = "Редактировать профиль";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // labelUserRole
            // 
            labelUserRole.AutoSize = true;
            labelUserRole.Location = new Point(71, 42);
            labelUserRole.Margin = new Padding(4, 0, 4, 0);
            labelUserRole.Name = "labelUserRole";
            labelUserRole.Size = new Size(59, 15);
            labelUserRole.TabIndex = 2;
            labelUserRole.Text = "Владелец\r\n";
            // 
            // labelUserNickname
            // 
            labelUserNickname.AutoSize = true;
            labelUserNickname.Location = new Point(71, 27);
            labelUserNickname.Margin = new Padding(4, 0, 4, 0);
            labelUserNickname.Name = "labelUserNickname";
            labelUserNickname.Size = new Size(30, 15);
            labelUserNickname.TabIndex = 1;
            labelUserNickname.Text = "User";
            // 
            // pictureBoxAvatar
            // 
            pictureBoxAvatar.InitialImage = Properties.Resources.loading_gif;
            pictureBoxAvatar.Location = new Point(13, 17);
            pictureBoxAvatar.Margin = new Padding(4, 3, 4, 3);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(50, 50);
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAvatar.TabIndex = 0;
            pictureBoxAvatar.TabStop = false;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageAuthors);
            tabControl.Controls.Add(tabPageNovels);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(870, 484);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // tabPageAuthors
            // 
            tabPageAuthors.Controls.Add(panelButtonContainer);
            tabPageAuthors.Controls.Add(dataGridViewAuthors);
            tabPageAuthors.Location = new Point(4, 24);
            tabPageAuthors.Name = "tabPageAuthors";
            tabPageAuthors.Padding = new Padding(3);
            tabPageAuthors.Size = new Size(862, 456);
            tabPageAuthors.TabIndex = 1;
            tabPageAuthors.Text = "Авторы";
            tabPageAuthors.UseVisualStyleBackColor = true;
            // 
            // panelButtonContainer
            // 
            panelButtonContainer.AutoSize = true;
            panelButtonContainer.Controls.Add(buttonAddAuthor);
            panelButtonContainer.Controls.Add(buttonRemoveAuthor);
            panelButtonContainer.Controls.Add(buttonEditAuthor);
            panelButtonContainer.Controls.Add(pbLoadingAuthors);
            panelButtonContainer.Dock = DockStyle.Bottom;
            panelButtonContainer.Location = new Point(3, 420);
            panelButtonContainer.Name = "panelButtonContainer";
            panelButtonContainer.Size = new Size(856, 33);
            panelButtonContainer.TabIndex = 5;
            // 
            // buttonAddAuthor
            // 
            buttonAddAuthor.Image = (Image)resources.GetObject("buttonAddAuthor.Image");
            buttonAddAuthor.ImageAlign = ContentAlignment.MiddleRight;
            buttonAddAuthor.Location = new Point(4, 3);
            buttonAddAuthor.Margin = new Padding(4, 3, 4, 3);
            buttonAddAuthor.Name = "buttonAddAuthor";
            buttonAddAuthor.Size = new Size(87, 27);
            buttonAddAuthor.TabIndex = 5;
            buttonAddAuthor.Text = " Добавить";
            buttonAddAuthor.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddAuthor.UseVisualStyleBackColor = true;
            buttonAddAuthor.Click += buttonAddAuthor_Click;
            // 
            // buttonRemoveAuthor
            // 
            buttonRemoveAuthor.Image = Properties.Resources.pngwing_com__4_;
            buttonRemoveAuthor.ImageAlign = ContentAlignment.MiddleRight;
            buttonRemoveAuthor.Location = new Point(99, 3);
            buttonRemoveAuthor.Margin = new Padding(4, 3, 4, 3);
            buttonRemoveAuthor.Name = "buttonRemoveAuthor";
            buttonRemoveAuthor.Size = new Size(78, 27);
            buttonRemoveAuthor.TabIndex = 4;
            buttonRemoveAuthor.Text = " Удалить";
            buttonRemoveAuthor.TextAlign = ContentAlignment.MiddleLeft;
            buttonRemoveAuthor.UseVisualStyleBackColor = true;
            buttonRemoveAuthor.Click += buttonRemoveAuthor_Click;
            // 
            // buttonEditAuthor
            // 
            buttonEditAuthor.Image = Properties.Resources.pngwing_com__5_;
            buttonEditAuthor.ImageAlign = ContentAlignment.MiddleRight;
            buttonEditAuthor.Location = new Point(185, 3);
            buttonEditAuthor.Margin = new Padding(4, 3, 4, 3);
            buttonEditAuthor.Name = "buttonEditAuthor";
            buttonEditAuthor.Size = new Size(116, 27);
            buttonEditAuthor.TabIndex = 3;
            buttonEditAuthor.Text = " Редактировать";
            buttonEditAuthor.TextAlign = ContentAlignment.MiddleLeft;
            buttonEditAuthor.UseVisualStyleBackColor = true;
            buttonEditAuthor.Click += buttonEditAuthor_Click;
            // 
            // pbLoadingAuthors
            // 
            pbLoadingAuthors.Anchor = AnchorStyles.None;
            pbLoadingAuthors.Image = Properties.Resources.loading_gif1;
            pbLoadingAuthors.Location = new Point(308, 8);
            pbLoadingAuthors.Name = "pbLoadingAuthors";
            pbLoadingAuthors.Size = new Size(17, 17);
            pbLoadingAuthors.SizeMode = PictureBoxSizeMode.AutoSize;
            pbLoadingAuthors.TabIndex = 6;
            pbLoadingAuthors.TabStop = false;
            // 
            // dataGridViewAuthors
            // 
            dataGridViewAuthors.AllowUserToAddRows = false;
            dataGridViewAuthors.AllowUserToDeleteRows = false;
            dataGridViewAuthors.AllowUserToOrderColumns = true;
            dataGridViewAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAuthors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAuthors.Location = new Point(0, 0);
            dataGridViewAuthors.Margin = new Padding(4, 3, 4, 3);
            dataGridViewAuthors.Name = "dataGridViewAuthors";
            dataGridViewAuthors.ReadOnly = true;
            dataGridViewAuthors.Size = new Size(862, 417);
            dataGridViewAuthors.TabIndex = 4;
            dataGridViewAuthors.Scroll += dataGridViewAuthors_Scroll;
            // 
            // tabPageNovels
            // 
            tabPageNovels.Controls.Add(flowLayoutPanel1);
            tabPageNovels.Controls.Add(dataGridViewNovels);
            tabPageNovels.Location = new Point(4, 24);
            tabPageNovels.Name = "tabPageNovels";
            tabPageNovels.Padding = new Padding(3);
            tabPageNovels.Size = new Size(862, 456);
            tabPageNovels.TabIndex = 0;
            tabPageNovels.Text = "Новеллы";
            tabPageNovels.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnAddNovel);
            flowLayoutPanel1.Controls.Add(btnRemoveNovel);
            flowLayoutPanel1.Controls.Add(btnEditNovel);
            flowLayoutPanel1.Controls.Add(pbLoadingNovels);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(3, 420);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(856, 33);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnAddNovel
            // 
            btnAddNovel.Image = (Image)resources.GetObject("btnAddNovel.Image");
            btnAddNovel.ImageAlign = ContentAlignment.MiddleRight;
            btnAddNovel.Location = new Point(4, 3);
            btnAddNovel.Margin = new Padding(4, 3, 4, 3);
            btnAddNovel.Name = "btnAddNovel";
            btnAddNovel.Size = new Size(87, 27);
            btnAddNovel.TabIndex = 5;
            btnAddNovel.Text = " Добавить";
            btnAddNovel.TextAlign = ContentAlignment.MiddleLeft;
            btnAddNovel.UseVisualStyleBackColor = true;
            btnAddNovel.Click += btnAddNovel_Click;
            // 
            // btnRemoveNovel
            // 
            btnRemoveNovel.Image = Properties.Resources.pngwing_com__4_;
            btnRemoveNovel.ImageAlign = ContentAlignment.MiddleRight;
            btnRemoveNovel.Location = new Point(99, 3);
            btnRemoveNovel.Margin = new Padding(4, 3, 4, 3);
            btnRemoveNovel.Name = "btnRemoveNovel";
            btnRemoveNovel.Size = new Size(78, 27);
            btnRemoveNovel.TabIndex = 4;
            btnRemoveNovel.Text = " Удалить";
            btnRemoveNovel.TextAlign = ContentAlignment.MiddleLeft;
            btnRemoveNovel.UseVisualStyleBackColor = true;
            btnRemoveNovel.Click += btnRemoveNovel_Click;
            // 
            // btnEditNovel
            // 
            btnEditNovel.Image = Properties.Resources.pngwing_com__5_;
            btnEditNovel.ImageAlign = ContentAlignment.MiddleRight;
            btnEditNovel.Location = new Point(185, 3);
            btnEditNovel.Margin = new Padding(4, 3, 4, 3);
            btnEditNovel.Name = "btnEditNovel";
            btnEditNovel.Size = new Size(116, 27);
            btnEditNovel.TabIndex = 3;
            btnEditNovel.Text = " Редактировать";
            btnEditNovel.TextAlign = ContentAlignment.MiddleLeft;
            btnEditNovel.UseVisualStyleBackColor = true;
            btnEditNovel.Click += btnEditNovel_Click;
            // 
            // pbLoadingNovels
            // 
            pbLoadingNovels.Anchor = AnchorStyles.None;
            pbLoadingNovels.Image = Properties.Resources.loading_gif1;
            pbLoadingNovels.Location = new Point(308, 8);
            pbLoadingNovels.Name = "pbLoadingNovels";
            pbLoadingNovels.Size = new Size(17, 17);
            pbLoadingNovels.SizeMode = PictureBoxSizeMode.AutoSize;
            pbLoadingNovels.TabIndex = 6;
            pbLoadingNovels.TabStop = false;
            // 
            // dataGridViewNovels
            // 
            dataGridViewNovels.AllowUserToAddRows = false;
            dataGridViewNovels.AllowUserToDeleteRows = false;
            dataGridViewNovels.AllowUserToOrderColumns = true;
            dataGridViewNovels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewNovels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNovels.Location = new Point(0, 0);
            dataGridViewNovels.Margin = new Padding(4, 3, 4, 3);
            dataGridViewNovels.Name = "dataGridViewNovels";
            dataGridViewNovels.ReadOnly = true;
            dataGridViewNovels.Size = new Size(862, 417);
            dataGridViewNovels.TabIndex = 4;
            dataGridViewNovels.Scroll += dataGridViewNovels_Scroll;
            // 
            // UserMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 564);
            Controls.Add(tabControl);
            Controls.Add(panelUserInfo);
            MinimumSize = new Size(886, 603);
            Name = "UserMainForm";
            Text = "Редактор контента";
            FormClosing += UserMainForm_FormClosing;
            Load += UserMainForm_Load;
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            tabControl.ResumeLayout(false);
            tabPageAuthors.ResumeLayout(false);
            tabPageAuthors.PerformLayout();
            panelButtonContainer.ResumeLayout(false);
            panelButtonContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadingAuthors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuthors).EndInit();
            tabPageNovels.ResumeLayout(false);
            tabPageNovels.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadingNovels).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNovels).EndInit();
            ResumeLayout(false);
        }

        private Panel panelUserInfo;
        private Button btnEditProfile;
        private Label labelUserRole;
        private Label labelUserNickname;
        private PictureBox pictureBoxAvatar;
        private Label labelServerStatus;
        private Label labelOnlineUsersCount;
        private Label labelStatusServer;
        private Label labelOnlineUsers;
        private DataGridView dataGridViewNovels;
        private DataGridView dataGridViewAuthors;
        private FlowLayoutPanel panelButtonContainer;
        private Button buttonAddAuthor;
        private Button buttonRemoveAuthor;
        private Button buttonEditAuthor;
        private PictureBox pbLoadingAuthors;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddNovel;
        private Button btnRemoveNovel;
        private Button btnEditNovel;
        private PictureBox pbLoadingNovels;
        private Button btnLogout;
    }
}
