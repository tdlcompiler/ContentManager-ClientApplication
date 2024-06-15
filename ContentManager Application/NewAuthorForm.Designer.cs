namespace ContentManager_Application
{
    partial class NewAuthorForm
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
            authorInfoPanel = new Panel();
            lblAuthorCountry = new Label();
            lblAuthorName = new Label();
            lblSetAuthorCountry = new Label();
            textBoxAuthorCountry = new TextBox();
            textBoxAuthorName = new TextBox();
            lblSetAuthorName = new Label();
            btnSaveAuthor = new Button();
            authorInfoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // authorInfoPanel
            // 
            authorInfoPanel.Controls.Add(lblAuthorCountry);
            authorInfoPanel.Controls.Add(lblAuthorName);
            authorInfoPanel.Dock = DockStyle.Top;
            authorInfoPanel.Location = new Point(0, 0);
            authorInfoPanel.Name = "authorInfoPanel";
            authorInfoPanel.Size = new Size(302, 83);
            authorInfoPanel.TabIndex = 7;
            // 
            // lblAuthorCountry
            // 
            lblAuthorCountry.Anchor = AnchorStyles.Top;
            lblAuthorCountry.AutoSize = true;
            lblAuthorCountry.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblAuthorCountry.Location = new Point(127, 43);
            lblAuthorCountry.Name = "lblAuthorCountry";
            lblAuthorCountry.Size = new Size(50, 17);
            lblAuthorCountry.TabIndex = 1;
            lblAuthorCountry.Text = "Страна";
            // 
            // lblAuthorName
            // 
            lblAuthorName.Anchor = AnchorStyles.Top;
            lblAuthorName.AutoSize = true;
            lblAuthorName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAuthorName.Location = new Point(96, 9);
            lblAuthorName.Name = "lblAuthorName";
            lblAuthorName.Size = new Size(117, 25);
            lblAuthorName.TabIndex = 0;
            lblAuthorName.Text = "Имя автора";
            lblAuthorName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSetAuthorCountry
            // 
            lblSetAuthorCountry.AutoSize = true;
            lblSetAuthorCountry.Location = new Point(12, 157);
            lblSetAuthorCountry.Name = "lblSetAuthorCountry";
            lblSetAuthorCountry.Size = new Size(49, 15);
            lblSetAuthorCountry.TabIndex = 11;
            lblSetAuthorCountry.Text = "Страна:";
            // 
            // textBoxAuthorCountry
            // 
            textBoxAuthorCountry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAuthorCountry.Location = new Point(12, 175);
            textBoxAuthorCountry.Name = "textBoxAuthorCountry";
            textBoxAuthorCountry.Size = new Size(278, 23);
            textBoxAuthorCountry.TabIndex = 10;
            textBoxAuthorCountry.TextChanged += textBoxAuthorCountry_TextChanged;
            // 
            // textBoxAuthorName
            // 
            textBoxAuthorName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAuthorName.Location = new Point(12, 121);
            textBoxAuthorName.Name = "textBoxAuthorName";
            textBoxAuthorName.Size = new Size(278, 23);
            textBoxAuthorName.TabIndex = 9;
            textBoxAuthorName.TextChanged += textBoxAuthorName_TextChanged;
            // 
            // lblSetAuthorName
            // 
            lblSetAuthorName.AutoSize = true;
            lblSetAuthorName.Location = new Point(12, 103);
            lblSetAuthorName.Name = "lblSetAuthorName";
            lblSetAuthorName.Size = new Size(34, 15);
            lblSetAuthorName.TabIndex = 8;
            lblSetAuthorName.Text = "Имя:";
            // 
            // btnSaveAuthor
            // 
            btnSaveAuthor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveAuthor.Location = new Point(215, 226);
            btnSaveAuthor.Name = "btnSaveAuthor";
            btnSaveAuthor.Size = new Size(75, 23);
            btnSaveAuthor.TabIndex = 12;
            btnSaveAuthor.Text = "Сохранить";
            btnSaveAuthor.UseVisualStyleBackColor = true;
            btnSaveAuthor.Click += btnSaveAuthor_Click;
            // 
            // NewAuthorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 261);
            Controls.Add(btnSaveAuthor);
            Controls.Add(authorInfoPanel);
            Controls.Add(lblSetAuthorCountry);
            Controls.Add(textBoxAuthorCountry);
            Controls.Add(textBoxAuthorName);
            Controls.Add(lblSetAuthorName);
            MinimumSize = new Size(318, 300);
            Name = "NewAuthorForm";
            Text = "Автор Control";
            FormClosing += NewAuthorForm_FormClosing;
            authorInfoPanel.ResumeLayout(false);
            authorInfoPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel authorInfoPanel;
        private Label lblAuthorCountry;
        private Label lblAuthorName;
        private Label lblSetAuthorCountry;
        private TextBox textBoxAuthorCountry;
        private TextBox textBoxAuthorName;
        private Label lblSetAuthorName;
        private Button btnSaveAuthor;
    }
}