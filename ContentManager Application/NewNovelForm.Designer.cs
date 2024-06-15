namespace ContentManager_Application
{
    partial class NewNovelForm
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
            btnSaveNovel = new Button();
            authorInfoPanel = new Panel();
            lblNovelAuthor = new Label();
            lblNovelName = new Label();
            lblSetNovelDate = new Label();
            textBoxNovelName = new TextBox();
            lblSetNovelName = new Label();
            dateTimePickerNovel = new DateTimePicker();
            lblSetNovelAuthor = new Label();
            comboBoxAuthors = new ComboBox();
            dataGridViewChapters = new DataGridView();
            lblNovelChapters = new Label();
            authorInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChapters).BeginInit();
            SuspendLayout();
            // 
            // btnSaveNovel
            // 
            btnSaveNovel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveNovel.Location = new Point(330, 490);
            btnSaveNovel.Name = "btnSaveNovel";
            btnSaveNovel.Size = new Size(75, 23);
            btnSaveNovel.TabIndex = 18;
            btnSaveNovel.Text = "Сохранить";
            btnSaveNovel.UseVisualStyleBackColor = true;
            btnSaveNovel.Click += btnSaveNovel_Click;
            // 
            // authorInfoPanel
            // 
            authorInfoPanel.Controls.Add(lblNovelAuthor);
            authorInfoPanel.Controls.Add(lblNovelName);
            authorInfoPanel.Dock = DockStyle.Top;
            authorInfoPanel.Location = new Point(0, 0);
            authorInfoPanel.Name = "authorInfoPanel";
            authorInfoPanel.Size = new Size(417, 83);
            authorInfoPanel.TabIndex = 13;
            // 
            // lblNovelAuthor
            // 
            lblNovelAuthor.Anchor = AnchorStyles.Top;
            lblNovelAuthor.AutoSize = true;
            lblNovelAuthor.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNovelAuthor.Location = new Point(166, 44);
            lblNovelAuthor.Name = "lblNovelAuthor";
            lblNovelAuthor.Size = new Size(80, 17);
            lblNovelAuthor.TabIndex = 1;
            lblNovelAuthor.Text = "Имя автора";
            // 
            // lblNovelName
            // 
            lblNovelName.Anchor = AnchorStyles.Top;
            lblNovelName.AutoSize = true;
            lblNovelName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNovelName.Location = new Point(120, 9);
            lblNovelName.Name = "lblNovelName";
            lblNovelName.Size = new Size(182, 25);
            lblNovelName.TabIndex = 0;
            lblNovelName.Text = "Название новеллы";
            lblNovelName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSetNovelDate
            // 
            lblSetNovelDate.AutoSize = true;
            lblSetNovelDate.Location = new Point(12, 155);
            lblSetNovelDate.Name = "lblSetNovelDate";
            lblSetNovelDate.Size = new Size(196, 15);
            lblSetNovelDate.TabIndex = 17;
            lblSetNovelDate.Text = "Дата добавления (необязательно):";
            // 
            // textBoxNovelName
            // 
            textBoxNovelName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxNovelName.Location = new Point(12, 119);
            textBoxNovelName.Name = "textBoxNovelName";
            textBoxNovelName.Size = new Size(393, 23);
            textBoxNovelName.TabIndex = 15;
            textBoxNovelName.TextChanged += textBoxNovelName_TextChanged;
            // 
            // lblSetNovelName
            // 
            lblSetNovelName.AutoSize = true;
            lblSetNovelName.Location = new Point(12, 101);
            lblSetNovelName.Name = "lblSetNovelName";
            lblSetNovelName.Size = new Size(62, 15);
            lblSetNovelName.TabIndex = 14;
            lblSetNovelName.Text = "Название:";
            // 
            // dateTimePickerNovel
            // 
            dateTimePickerNovel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerNovel.Location = new Point(12, 173);
            dateTimePickerNovel.Name = "dateTimePickerNovel";
            dateTimePickerNovel.Size = new Size(393, 23);
            dateTimePickerNovel.TabIndex = 19;
            // 
            // lblSetNovelAuthor
            // 
            lblSetNovelAuthor.AutoSize = true;
            lblSetNovelAuthor.Location = new Point(12, 216);
            lblSetNovelAuthor.Name = "lblSetNovelAuthor";
            lblSetNovelAuthor.Size = new Size(43, 15);
            lblSetNovelAuthor.TabIndex = 20;
            lblSetNovelAuthor.Text = "Автор:";
            // 
            // comboBoxAuthors
            // 
            comboBoxAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxAuthors.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAuthors.FormattingEnabled = true;
            comboBoxAuthors.Location = new Point(12, 234);
            comboBoxAuthors.Name = "comboBoxAuthors";
            comboBoxAuthors.Size = new Size(393, 23);
            comboBoxAuthors.TabIndex = 21;
            comboBoxAuthors.SelectedIndexChanged += comboBoxAuthors_SelectedIndexChanged;
            // 
            // dataGridViewChapters
            // 
            dataGridViewChapters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewChapters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChapters.Location = new Point(12, 290);
            dataGridViewChapters.Name = "dataGridViewChapters";
            dataGridViewChapters.Size = new Size(393, 183);
            dataGridViewChapters.TabIndex = 22;
            dataGridViewChapters.MouseDoubleClick += dataGridViewChapters_MouseDoubleClick;
            // 
            // lblNovelChapters
            // 
            lblNovelChapters.AutoSize = true;
            lblNovelChapters.Location = new Point(12, 272);
            lblNovelChapters.Name = "lblNovelChapters";
            lblNovelChapters.Size = new Size(355, 15);
            lblNovelChapters.TabIndex = 23;
            lblNovelChapters.Text = "Главы (двойной клик по строке откроет редактор сообщений):";
            // 
            // NewNovelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 525);
            Controls.Add(lblNovelChapters);
            Controls.Add(dataGridViewChapters);
            Controls.Add(comboBoxAuthors);
            Controls.Add(lblSetNovelAuthor);
            Controls.Add(dateTimePickerNovel);
            Controls.Add(btnSaveNovel);
            Controls.Add(authorInfoPanel);
            Controls.Add(lblSetNovelDate);
            Controls.Add(textBoxNovelName);
            Controls.Add(lblSetNovelName);
            MinimumSize = new Size(433, 564);
            Name = "NewNovelForm";
            Text = "Новелла";
            FormClosing += NewNovelForm_FormClosing;
            authorInfoPanel.ResumeLayout(false);
            authorInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChapters).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSaveNovel;
        private Panel authorInfoPanel;
        private Label lblNovelAuthor;
        private Label lblNovelName;
        private Label lblSetNovelDate;
        private TextBox textBoxNovelName;
        private Label lblSetNovelName;
        private DateTimePicker dateTimePickerNovel;
        private Label lblSetNovelAuthor;
        private ComboBox comboBoxAuthors;
        private DataGridView dataGridViewChapters;
        private Label lblNovelChapters;
    }
}
