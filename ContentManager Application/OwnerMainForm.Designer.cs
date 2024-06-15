namespace ContentManager_Application
{
    partial class OwnerMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerMainForm));
            panelTableContainer = new Panel();
            dataGridViewUsers = new DataGridView();
            panelButtonContainer = new FlowLayoutPanel();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonEdit = new Button();
            pictureBoxLoading = new PictureBox();
            pictureBoxAvatar = new PictureBox();
            labelUserNickname = new Label();
            labelUserRole = new Label();
            labelOnlineUsers = new Label();
            labelStatusServer = new Label();
            labelOnlineUsersCount = new Label();
            labelServerStatus = new Label();
            button1 = new Button();
            panelUserInfo = new Panel();
            btnLogout = new Button();
            panelTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            panelButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            panelUserInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelTableContainer
            // 
            panelTableContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTableContainer.Controls.Add(dataGridViewUsers);
            panelTableContainer.Location = new Point(0, 0);
            panelTableContainer.Margin = new Padding(4, 3, 4, 3);
            panelTableContainer.Name = "panelTableContainer";
            panelTableContainer.Size = new Size(870, 448);
            panelTableContainer.TabIndex = 1;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AllowUserToOrderColumns = true;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(0, 0);
            dataGridViewUsers.Margin = new Padding(4, 3, 4, 3);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.Size = new Size(870, 448);
            dataGridViewUsers.TabIndex = 0;
            dataGridViewUsers.ColumnHeaderMouseClick += dataGridViewUsers_ColumnHeaderMouseClick;
            dataGridViewUsers.Scroll += DataGridViewUsers_Scroll;
            // 
            // panelButtonContainer
            // 
            panelButtonContainer.AutoSize = true;
            panelButtonContainer.Controls.Add(buttonAdd);
            panelButtonContainer.Controls.Add(buttonDelete);
            panelButtonContainer.Controls.Add(buttonEdit);
            panelButtonContainer.Controls.Add(pictureBoxLoading);
            panelButtonContainer.Dock = DockStyle.Bottom;
            panelButtonContainer.Location = new Point(0, 451);
            panelButtonContainer.Name = "panelButtonContainer";
            panelButtonContainer.Size = new Size(870, 33);
            panelButtonContainer.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.Image = (Image)resources.GetObject("buttonAdd.Image");
            buttonAdd.ImageAlign = ContentAlignment.MiddleRight;
            buttonAdd.Location = new Point(4, 3);
            buttonAdd.Margin = new Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(87, 27);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = " Добавить";
            buttonAdd.TextAlign = ContentAlignment.MiddleLeft;
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Image = Properties.Resources.pngwing_com__4_;
            buttonDelete.ImageAlign = ContentAlignment.MiddleRight;
            buttonDelete.Location = new Point(99, 3);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(78, 27);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = " Удалить";
            buttonDelete.TextAlign = ContentAlignment.MiddleLeft;
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Image = Properties.Resources.pngwing_com__5_;
            buttonEdit.ImageAlign = ContentAlignment.MiddleRight;
            buttonEdit.Location = new Point(185, 3);
            buttonEdit.Margin = new Padding(4, 3, 4, 3);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(116, 27);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = " Редактировать";
            buttonEdit.TextAlign = ContentAlignment.MiddleLeft;
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // pictureBoxLoading
            // 
            pictureBoxLoading.Anchor = AnchorStyles.None;
            pictureBoxLoading.Image = Properties.Resources.loading_gif1;
            pictureBoxLoading.Location = new Point(308, 8);
            pictureBoxLoading.Name = "pictureBoxLoading";
            pictureBoxLoading.Size = new Size(17, 17);
            pictureBoxLoading.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxLoading.TabIndex = 6;
            pictureBoxLoading.TabStop = false;
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
            // labelUserRole
            // 
            labelUserRole.AutoSize = true;
            labelUserRole.Location = new Point(71, 42);
            labelUserRole.Margin = new Padding(4, 0, 4, 0);
            labelUserRole.Name = "labelUserRole";
            labelUserRole.Size = new Size(59, 15);
            labelUserRole.TabIndex = 2;
            labelUserRole.Text = "Владелец";
            // 
            // labelOnlineUsers
            // 
            labelOnlineUsers.Anchor = AnchorStyles.Right;
            labelOnlineUsers.AutoSize = true;
            labelOnlineUsers.Location = new Point(626, 27);
            labelOnlineUsers.Margin = new Padding(4, 0, 4, 0);
            labelOnlineUsers.Name = "labelOnlineUsers";
            labelOnlineUsers.Size = new Size(163, 15);
            labelOnlineUsers.TabIndex = 5;
            labelOnlineUsers.Text = "Количество пользователей: ";
            // 
            // labelStatusServer
            // 
            labelStatusServer.Anchor = AnchorStyles.Right;
            labelStatusServer.AutoSize = true;
            labelStatusServer.Location = new Point(626, 46);
            labelStatusServer.Margin = new Padding(4, 0, 4, 0);
            labelStatusServer.Name = "labelStatusServer";
            labelStatusServer.Size = new Size(96, 15);
            labelStatusServer.TabIndex = 6;
            labelStatusServer.Text = "Статус сервера: ";
            // 
            // labelOnlineUsersCount
            // 
            labelOnlineUsersCount.Anchor = AnchorStyles.Right;
            labelOnlineUsersCount.AutoSize = true;
            labelOnlineUsersCount.Location = new Point(786, 27);
            labelOnlineUsersCount.Margin = new Padding(4, 0, 4, 0);
            labelOnlineUsersCount.Name = "labelOnlineUsersCount";
            labelOnlineUsersCount.Size = new Size(71, 15);
            labelOnlineUsersCount.TabIndex = 3;
            labelOnlineUsersCount.Text = "Неизвестно";
            // 
            // labelServerStatus
            // 
            labelServerStatus.Anchor = AnchorStyles.Right;
            labelServerStatus.AutoSize = true;
            labelServerStatus.Location = new Point(718, 46);
            labelServerStatus.Margin = new Padding(4, 0, 4, 0);
            labelServerStatus.Name = "labelServerStatus";
            labelServerStatus.Size = new Size(71, 15);
            labelServerStatus.TabIndex = 4;
            labelServerStatus.Text = "Неизвестно";
            // 
            // button1
            // 
            button1.Location = new Point(152, 6);
            button1.Name = "button1";
            button1.Size = new Size(99, 40);
            button1.TabIndex = 7;
            button1.Text = "Редактировать профиль";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelUserInfo
            // 
            panelUserInfo.Controls.Add(btnLogout);
            panelUserInfo.Controls.Add(labelOnlineUsersCount);
            panelUserInfo.Controls.Add(labelServerStatus);
            panelUserInfo.Controls.Add(labelStatusServer);
            panelUserInfo.Controls.Add(labelOnlineUsers);
            panelUserInfo.Controls.Add(button1);
            panelUserInfo.Controls.Add(labelUserRole);
            panelUserInfo.Controls.Add(labelUserNickname);
            panelUserInfo.Controls.Add(pictureBoxAvatar);
            panelUserInfo.Dock = DockStyle.Bottom;
            panelUserInfo.Location = new Point(0, 484);
            panelUserInfo.Margin = new Padding(4, 3, 4, 3);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(870, 80);
            panelUserInfo.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(164, 52);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // OwnerMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 564);
            Controls.Add(panelButtonContainer);
            Controls.Add(panelTableContainer);
            Controls.Add(panelUserInfo);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(886, 603);
            Name = "OwnerMainForm";
            Text = "Управление пользователями";
            FormClosing += OwnerMainForm_FormClosing;
            Load += OwnerMainForm_Load;
            panelTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            panelButtonContainer.ResumeLayout(false);
            panelButtonContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelTableContainer;
        private FlowLayoutPanel panelButtonContainer;
        private PictureBox pictureBoxLoading;
        private PictureBox pictureBoxAvatar;
        private Label labelUserNickname;
        private Label labelUserRole;
        private Label labelOnlineUsers;
        private Label labelStatusServer;
        private Label labelOnlineUsersCount;
        private Label labelServerStatus;
        private Button button1;
        private Panel panelUserInfo;
        private Button btnLogout;
    }
}