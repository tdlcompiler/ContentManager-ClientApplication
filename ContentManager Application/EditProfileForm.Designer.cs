namespace ContentManager_Application
{
    partial class EditProfileForm
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
            userInfoPanel = new Panel();
            userAvatarPb = new PictureBox();
            panel2 = new Panel();
            lblUserRole = new Label();
            lblUserNick = new Label();
            avatarsGrid = new ImageGridControl();
            panel3 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            userInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userAvatarPb).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // userInfoPanel
            // 
            userInfoPanel.Controls.Add(userAvatarPb);
            userInfoPanel.Dock = DockStyle.Top;
            userInfoPanel.Location = new Point(0, 0);
            userInfoPanel.Name = "userInfoPanel";
            userInfoPanel.Size = new Size(477, 104);
            userInfoPanel.TabIndex = 0;
            // 
            // userAvatarPb
            // 
            userAvatarPb.Anchor = AnchorStyles.Top;
            userAvatarPb.Location = new Point(187, 2);
            userAvatarPb.Name = "userAvatarPb";
            userAvatarPb.Size = new Size(100, 100);
            userAvatarPb.TabIndex = 0;
            userAvatarPb.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblUserRole);
            panel2.Controls.Add(lblUserNick);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(477, 50);
            panel2.TabIndex = 1;
            // 
            // lblUserRole
            // 
            lblUserRole.Anchor = AnchorStyles.Top;
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserRole.Location = new Point(216, 26);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(37, 17);
            lblUserRole.TabIndex = 1;
            lblUserRole.Text = "Роль";
            // 
            // lblUserNick
            // 
            lblUserNick.Anchor = AnchorStyles.Top;
            lblUserNick.AutoSize = true;
            lblUserNick.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblUserNick.Location = new Point(147, 1);
            lblUserNick.Name = "lblUserNick";
            lblUserNick.Size = new Size(179, 25);
            lblUserNick.TabIndex = 0;
            lblUserNick.Text = "Имя пользователя";
            lblUserNick.TextAlign = ContentAlignment.TopCenter;
            // 
            // avatarsGrid
            // 
            avatarsGrid.Dock = DockStyle.Fill;
            avatarsGrid.Location = new Point(0, 0);
            avatarsGrid.Name = "avatarsGrid";
            avatarsGrid.Size = new Size(212, 407);
            avatarsGrid.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(265, 154);
            panel3.Name = "panel3";
            panel3.Size = new Size(212, 433);
            panel3.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Controls.Add(avatarsGrid);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 26);
            panel5.Name = "panel5";
            panel5.Size = new Size(212, 407);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(212, 26);
            panel4.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 3);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 0;
            label2.Text = "Выберите аватар";
            // 
            // EditProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 587);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(userInfoPanel);
            Name = "EditProfileForm";
            Text = "EditProfileForm";
            FormClosing += EditProfileForm_FormClosing;
            userInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userAvatarPb).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel userInfoPanel;
        private PictureBox userAvatarPb;
        private Panel panel2;
        private Label lblUserNick;
        private ImageGridControl avatarsGrid;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private Label lblUserRole;
    }
}