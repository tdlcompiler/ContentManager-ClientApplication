namespace ContentManager_Application
{
    partial class MessagesEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewMessages;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagesEditorForm));
            dataGridViewMessages = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Content = new DataGridViewTextBoxColumn();
            SenderName = new DataGridViewTextBoxColumn();
            ChapterId = new DataGridViewTextBoxColumn();
            MessageTypeId = new DataGridViewTextBoxColumn();
            ImageCol = new DataGridViewImageColumn();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddMessage = new Button();
            btnRemoveMessage = new Button();
            btnEditMessage = new Button();
            pictureBoxLoading = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMessages).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMessages
            // 
            dataGridViewMessages.AllowUserToAddRows = false;
            dataGridViewMessages.AllowUserToDeleteRows = false;
            dataGridViewMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMessages.Columns.AddRange(new DataGridViewColumn[] { Id, Content, SenderName, ChapterId, MessageTypeId, ImageCol });
            dataGridViewMessages.Location = new Point(0, 2);
            dataGridViewMessages.Margin = new Padding(4, 3, 4, 3);
            dataGridViewMessages.Name = "dataGridViewMessages";
            dataGridViewMessages.Size = new Size(958, 483);
            dataGridViewMessages.TabIndex = 0;
            dataGridViewMessages.CellFormatting += dataGridViewMessages_CellFormatting;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "ID";
            Id.Name = "Id";
            // 
            // Content
            // 
            Content.DataPropertyName = "Content";
            Content.HeaderText = "Контент";
            Content.Name = "Content";
            // 
            // SenderName
            // 
            SenderName.DataPropertyName = "SenderName";
            SenderName.HeaderText = "Имя отправителя";
            SenderName.Name = "SenderName";
            // 
            // ChapterId
            // 
            ChapterId.DataPropertyName = "ChapterId";
            ChapterId.HeaderText = "Идентификатор главы";
            ChapterId.Name = "ChapterId";
            // 
            // MessageTypeId
            // 
            MessageTypeId.DataPropertyName = "MessageTypeId";
            MessageTypeId.HeaderText = "Тип сообщения";
            MessageTypeId.Name = "MessageTypeId";
            // 
            // ImageCol
            // 
            ImageCol.HeaderText = "Изображение";
            ImageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            ImageCol.Name = "ImageCol";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnAddMessage);
            flowLayoutPanel1.Controls.Add(btnRemoveMessage);
            flowLayoutPanel1.Controls.Add(btnEditMessage);
            flowLayoutPanel1.Controls.Add(pictureBoxLoading);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 486);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(958, 33);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnAddMessage
            // 
            btnAddMessage.Image = (Image)resources.GetObject("btnAddMessage.Image");
            btnAddMessage.ImageAlign = ContentAlignment.MiddleRight;
            btnAddMessage.Location = new Point(4, 3);
            btnAddMessage.Margin = new Padding(4, 3, 4, 3);
            btnAddMessage.Name = "btnAddMessage";
            btnAddMessage.Size = new Size(87, 27);
            btnAddMessage.TabIndex = 5;
            btnAddMessage.Text = " Добавить";
            btnAddMessage.TextAlign = ContentAlignment.MiddleLeft;
            btnAddMessage.UseVisualStyleBackColor = true;
            btnAddMessage.Click += buttonAddMessage_Click;
            // 
            // btnRemoveMessage
            // 
            btnRemoveMessage.Image = Properties.Resources.pngwing_com__4_;
            btnRemoveMessage.ImageAlign = ContentAlignment.MiddleRight;
            btnRemoveMessage.Location = new Point(99, 3);
            btnRemoveMessage.Margin = new Padding(4, 3, 4, 3);
            btnRemoveMessage.Name = "btnRemoveMessage";
            btnRemoveMessage.Size = new Size(78, 27);
            btnRemoveMessage.TabIndex = 7;
            btnRemoveMessage.Text = " Удалить";
            btnRemoveMessage.TextAlign = ContentAlignment.MiddleLeft;
            btnRemoveMessage.UseVisualStyleBackColor = true;
            // 
            // btnEditMessage
            // 
            btnEditMessage.Image = Properties.Resources.pngwing_com__5_;
            btnEditMessage.ImageAlign = ContentAlignment.MiddleRight;
            btnEditMessage.Location = new Point(185, 3);
            btnEditMessage.Margin = new Padding(4, 3, 4, 3);
            btnEditMessage.Name = "btnEditMessage";
            btnEditMessage.Size = new Size(116, 27);
            btnEditMessage.TabIndex = 3;
            btnEditMessage.Text = " Редактировать";
            btnEditMessage.TextAlign = ContentAlignment.MiddleLeft;
            btnEditMessage.UseVisualStyleBackColor = true;
            btnEditMessage.Click += button4_Click;
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
            // MessagesEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 519);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dataGridViewMessages);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(974, 558);
            Name = "MessagesEditorForm";
            Text = "Messages Editor";
            FormClosing += MessagesEditorForm_FormClosing;
            Load += MessagesEditorForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMessages).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddMessage;
        private Button btnEditMessage;
        private PictureBox pictureBoxLoading;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Content;
        private DataGridViewTextBoxColumn SenderName;
        private DataGridViewTextBoxColumn ChapterId;
        private DataGridViewTextBoxColumn MessageTypeId;
        private DataGridViewImageColumn ImageCol;
        private Button btnRemoveMessage;
    }
}
