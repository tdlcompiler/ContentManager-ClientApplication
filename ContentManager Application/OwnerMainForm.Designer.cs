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
            panelUserInfo = new Panel();
            button1 = new Button();
            labelServerStatus = new Label();
            labelOnlineUsersCount = new Label();
            labelStatusServer = new Label();
            labelOnlineUsers = new Label();
            labelUserRole = new Label();
            labelUserNickname = new Label();
            pictureBoxAvatar = new PictureBox();
            panelTableContainer = new Panel();
            dataGridViewUsers = new DataGridView();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonAdd = new Button();
            panelButtonContainer = new FlowLayoutPanel();
            panelUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            panelTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            panelButtonContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panelUserInfo
            // 
            panelUserInfo.Controls.Add(button1);
            panelUserInfo.Controls.Add(labelServerStatus);
            panelUserInfo.Controls.Add(labelOnlineUsersCount);
            panelUserInfo.Controls.Add(labelStatusServer);
            panelUserInfo.Controls.Add(labelOnlineUsers);
            panelUserInfo.Controls.Add(labelUserRole);
            panelUserInfo.Controls.Add(labelUserNickname);
            panelUserInfo.Controls.Add(pictureBoxAvatar);
            panelUserInfo.Dock = DockStyle.Bottom;
            panelUserInfo.Location = new Point(0, 497);
            panelUserInfo.Margin = new Padding(4, 3, 4, 3);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(932, 80);
            panelUserInfo.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(150, 18);
            button1.Name = "button1";
            button1.Size = new Size(99, 40);
            button1.TabIndex = 7;
            button1.Text = "Редактировать профиль";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelServerStatus
            // 
            labelServerStatus.AutoSize = true;
            labelServerStatus.Location = new Point(785, 22);
            labelServerStatus.Margin = new Padding(4, 0, 4, 0);
            labelServerStatus.Name = "labelServerStatus";
            labelServerStatus.Size = new Size(71, 15);
            labelServerStatus.TabIndex = 4;
            labelServerStatus.Text = "Неизвестно";
            // 
            // labelOnlineUsersCount
            // 
            labelOnlineUsersCount.AutoSize = true;
            labelOnlineUsersCount.Location = new Point(853, 3);
            labelOnlineUsersCount.Margin = new Padding(4, 0, 4, 0);
            labelOnlineUsersCount.Name = "labelOnlineUsersCount";
            labelOnlineUsersCount.Size = new Size(71, 15);
            labelOnlineUsersCount.TabIndex = 3;
            labelOnlineUsersCount.Text = "Неизвестно";
            // 
            // labelStatusServer
            // 
            labelStatusServer.AutoSize = true;
            labelStatusServer.Location = new Point(693, 22);
            labelStatusServer.Margin = new Padding(4, 0, 4, 0);
            labelStatusServer.Name = "labelStatusServer";
            labelStatusServer.Size = new Size(96, 15);
            labelStatusServer.TabIndex = 6;
            labelStatusServer.Text = "Статус сервера: ";
            // 
            // labelOnlineUsers
            // 
            labelOnlineUsers.AutoSize = true;
            labelOnlineUsers.Location = new Point(693, 3);
            labelOnlineUsers.Margin = new Padding(4, 0, 4, 0);
            labelOnlineUsers.Name = "labelOnlineUsers";
            labelOnlineUsers.Size = new Size(163, 15);
            labelOnlineUsers.TabIndex = 5;
            labelOnlineUsers.Text = "Количество пользователей: ";
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
            pictureBoxAvatar.Location = new Point(13, 17);
            pictureBoxAvatar.Margin = new Padding(4, 3, 4, 3);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(50, 50);
            pictureBoxAvatar.TabIndex = 0;
            pictureBoxAvatar.TabStop = false;
            // 
            // panelTableContainer
            // 
            panelTableContainer.Controls.Add(dataGridViewUsers);
            panelTableContainer.Dock = DockStyle.Fill;
            panelTableContainer.Location = new Point(0, 0);
            panelTableContainer.Margin = new Padding(4, 3, 4, 3);
            panelTableContainer.Name = "panelTableContainer";
            panelTableContainer.Size = new Size(932, 464);
            panelTableContainer.TabIndex = 1;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(0, 0);
            dataGridViewUsers.Margin = new Padding(4, 3, 4, 3);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.Size = new Size(932, 464);
            dataGridViewUsers.TabIndex = 0;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(196, 3);
            buttonEdit.Margin = new Padding(4, 3, 4, 3);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(99, 27);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Редактировать";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(100, 3);
            buttonDelete.Margin = new Padding(4, 3, 4, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(88, 27);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(4, 3);
            buttonAdd.Margin = new Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(88, 27);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // panelButtonContainer
            // 
            panelButtonContainer.AutoSize = true;
            panelButtonContainer.Controls.Add(buttonAdd);
            panelButtonContainer.Controls.Add(buttonDelete);
            panelButtonContainer.Controls.Add(buttonEdit);
            panelButtonContainer.Dock = DockStyle.Bottom;
            panelButtonContainer.Location = new Point(0, 464);
            panelButtonContainer.Name = "panelButtonContainer";
            panelButtonContainer.Size = new Size(932, 33);
            panelButtonContainer.TabIndex = 2;
            // 
            // OwnerMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 577);
            Controls.Add(panelTableContainer);
            Controls.Add(panelButtonContainer);
            Controls.Add(panelUserInfo);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OwnerMainForm";
            Text = "OwnerMainForm";
            FormClosing += OwnerMainForm_FormClosing;
            Load += OwnerMainForm_Load;
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            panelTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            panelButtonContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label labelUserRole;
        private System.Windows.Forms.Label labelUserNickname;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelStatusServer;
        private System.Windows.Forms.Label labelOnlineUsers;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Label labelOnlineUsersCount;
        private System.Windows.Forms.Panel panelTableContainer;
        private FlowLayoutPanel panelButtonContainer;
        private Button button1;
    }
}