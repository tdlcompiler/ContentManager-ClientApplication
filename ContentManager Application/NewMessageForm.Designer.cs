namespace ContentManager_Application
{
    partial class NewMessageForm
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
            comboBoxMsgTypes = new ComboBox();
            lblSetMessageType = new Label();
            messageInfoPanel = new Panel();
            lblMessageSenderName = new Label();
            lblMessage = new Label();
            lblSetSenderName = new Label();
            textBoxSetSenderName = new TextBox();
            lblSetMessageText = new Label();
            textBoxSetText = new TextBox();
            openFileImageDialog = new OpenFileDialog();
            btnLoadFile = new Button();
            openFileStickerDialog = new OpenFileDialog();
            lblLoadedFile = new Label();
            btnSaveMessage = new Button();
            messageInfoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxMsgTypes
            // 
            comboBoxMsgTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMsgTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMsgTypes.FormattingEnabled = true;
            comboBoxMsgTypes.Items.AddRange(new object[] { "Текст", "Изображение", "Стикер (Unity-префаб)" });
            comboBoxMsgTypes.Location = new Point(12, 124);
            comboBoxMsgTypes.Name = "comboBoxMsgTypes";
            comboBoxMsgTypes.Size = new Size(326, 23);
            comboBoxMsgTypes.TabIndex = 24;
            comboBoxMsgTypes.SelectedIndexChanged += comboBoxMsgTypes_SelectedIndexChanged;
            // 
            // lblSetMessageType
            // 
            lblSetMessageType.AutoSize = true;
            lblSetMessageType.Location = new Point(12, 106);
            lblSetMessageType.Name = "lblSetMessageType";
            lblSetMessageType.Size = new Size(97, 15);
            lblSetMessageType.TabIndex = 23;
            lblSetMessageType.Text = "Тип сообщения:";
            // 
            // messageInfoPanel
            // 
            messageInfoPanel.Controls.Add(lblMessageSenderName);
            messageInfoPanel.Controls.Add(lblMessage);
            messageInfoPanel.Dock = DockStyle.Top;
            messageInfoPanel.Location = new Point(0, 0);
            messageInfoPanel.Name = "messageInfoPanel";
            messageInfoPanel.Size = new Size(348, 83);
            messageInfoPanel.TabIndex = 22;
            // 
            // lblMessageSenderName
            // 
            lblMessageSenderName.Anchor = AnchorStyles.Top;
            lblMessageSenderName.AutoSize = true;
            lblMessageSenderName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessageSenderName.Location = new Point(115, 45);
            lblMessageSenderName.Name = "lblMessageSenderName";
            lblMessageSenderName.Size = new Size(113, 17);
            lblMessageSenderName.TabIndex = 1;
            lblMessageSenderName.Text = "Имя отправителя";
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Top;
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMessage.Location = new Point(115, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(115, 25);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Сообщение";
            lblMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSetSenderName
            // 
            lblSetSenderName.AutoSize = true;
            lblSetSenderName.Location = new Point(12, 159);
            lblSetSenderName.Name = "lblSetSenderName";
            lblSetSenderName.Size = new Size(106, 15);
            lblSetSenderName.TabIndex = 25;
            lblSetSenderName.Text = "Имя отправителя:";
            // 
            // textBoxSetSenderName
            // 
            textBoxSetSenderName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSetSenderName.Location = new Point(12, 177);
            textBoxSetSenderName.Name = "textBoxSetSenderName";
            textBoxSetSenderName.Size = new Size(326, 23);
            textBoxSetSenderName.TabIndex = 26;
            textBoxSetSenderName.TextChanged += textBoxSetSenderName_TextChanged;
            // 
            // lblSetMessageText
            // 
            lblSetMessageText.AutoSize = true;
            lblSetMessageText.Location = new Point(12, 212);
            lblSetMessageText.Name = "lblSetMessageText";
            lblSetMessageText.Size = new Size(39, 15);
            lblSetMessageText.TabIndex = 27;
            lblSetMessageText.Text = "Текст:";
            // 
            // textBoxSetText
            // 
            textBoxSetText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSetText.Location = new Point(12, 230);
            textBoxSetText.Multiline = true;
            textBoxSetText.Name = "textBoxSetText";
            textBoxSetText.Size = new Size(326, 71);
            textBoxSetText.TabIndex = 28;
            // 
            // openFileImageDialog
            // 
            openFileImageDialog.FileName = "openFileImageDialog";
            openFileImageDialog.Filter = "Изображения (png)|*.png";
            openFileImageDialog.FileOk += openFileImageDialog_FileOk;
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(12, 316);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(97, 42);
            btnLoadFile.TabIndex = 29;
            btnLoadFile.Text = "Загрузить файл";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // openFileStickerDialog
            // 
            openFileStickerDialog.Filter = "Unity-префаб|*.prefab";
            openFileStickerDialog.FileOk += openFileStickerDialog_FileOk;
            // 
            // lblLoadedFile
            // 
            lblLoadedFile.AutoSize = true;
            lblLoadedFile.Location = new Point(115, 330);
            lblLoadedFile.Name = "lblLoadedFile";
            lblLoadedFile.Size = new Size(106, 15);
            lblLoadedFile.TabIndex = 30;
            lblLoadedFile.Text = "Файл не загружен";
            // 
            // btnSaveMessage
            // 
            btnSaveMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveMessage.Location = new Point(261, 434);
            btnSaveMessage.Name = "btnSaveMessage";
            btnSaveMessage.Size = new Size(75, 23);
            btnSaveMessage.TabIndex = 31;
            btnSaveMessage.Text = "Сохранить";
            btnSaveMessage.UseVisualStyleBackColor = true;
            btnSaveMessage.Click += btnSaveMessage_Click;
            // 
            // NewMessageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 469);
            Controls.Add(btnSaveMessage);
            Controls.Add(lblLoadedFile);
            Controls.Add(btnLoadFile);
            Controls.Add(textBoxSetText);
            Controls.Add(lblSetMessageText);
            Controls.Add(textBoxSetSenderName);
            Controls.Add(lblSetSenderName);
            Controls.Add(comboBoxMsgTypes);
            Controls.Add(lblSetMessageType);
            Controls.Add(messageInfoPanel);
            MinimumSize = new Size(364, 508);
            Name = "NewMessageForm";
            Text = "Сообщение";
            FormClosing += NewMessageForm_FormClosing;
            messageInfoPanel.ResumeLayout(false);
            messageInfoPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxMsgTypes;
        private Label lblSetMessageType;
        private Panel messageInfoPanel;
        private Label lblMessageSenderName;
        private Label lblMessage;
        private Label lblSetSenderName;
        private TextBox textBoxSetSenderName;
        private Label lblSetMessageText;
        private TextBox textBoxSetText;
        private OpenFileDialog openFileImageDialog;
        private Button btnLoadFile;
        private OpenFileDialog openFileStickerDialog;
        private Label lblLoadedFile;
        private Button btnSaveMessage;
    }
}