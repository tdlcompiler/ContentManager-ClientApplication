namespace ContentManager_Application
{
    partial class TestForm
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
            lblMessageReceived = new Label();
            responseTextBox = new RichTextBox();
            lblMessageSend = new Label();
            messageTextBox = new RichTextBox();
            sendButton = new Button();
            lblConnectionStatus = new Label();
            lblConnectionState = new Label();
            SuspendLayout();
            // 
            // lblMessageReceived
            // 
            lblMessageReceived.AutoSize = true;
            lblMessageReceived.Location = new Point(36, 15);
            lblMessageReceived.Name = "lblMessageReceived";
            lblMessageReceived.Size = new Size(138, 15);
            lblMessageReceived.TabIndex = 0;
            lblMessageReceived.Text = "Сообщение от сервера:";
            // 
            // responseTextBox
            // 
            responseTextBox.Location = new Point(36, 33);
            responseTextBox.Name = "responseTextBox";
            responseTextBox.ReadOnly = true;
            responseTextBox.Size = new Size(327, 96);
            responseTextBox.TabIndex = 1;
            responseTextBox.Text = "";
            // 
            // lblMessageSend
            // 
            lblMessageSend.AutoSize = true;
            lblMessageSend.Location = new Point(36, 185);
            lblMessageSend.Name = "lblMessageSend";
            lblMessageSend.Size = new Size(154, 15);
            lblMessageSend.TabIndex = 2;
            lblMessageSend.Text = "Ваше сообщение серверу:";
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(36, 203);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(327, 96);
            messageTextBox.TabIndex = 3;
            messageTextBox.Text = "";
            // 
            // sendButton
            // 
            sendButton.Location = new Point(288, 305);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 4;
            sendButton.Text = "Отправить";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Location = new Point(54, 309);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(46, 15);
            lblConnectionStatus.TabIndex = 5;
            lblConnectionStatus.Text = "Статус:";
            // 
            // lblConnectionState
            // 
            lblConnectionState.AutoSize = true;
            lblConnectionState.Location = new Point(103, 309);
            lblConnectionState.Name = "lblConnectionState";
            lblConnectionState.Size = new Size(71, 15);
            lblConnectionState.TabIndex = 6;
            lblConnectionState.Text = "Неизвестно";
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblConnectionState);
            Controls.Add(lblConnectionStatus);
            Controls.Add(sendButton);
            Controls.Add(messageTextBox);
            Controls.Add(lblMessageSend);
            Controls.Add(responseTextBox);
            Controls.Add(lblMessageReceived);
            Name = "TestForm";
            Text = "TestForm";
            FormClosing += Form1_FormClosing;
            Load += new EventHandler(TestForm_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessageReceived;
        private RichTextBox responseTextBox;
        private Label lblMessageSend;
        private RichTextBox messageTextBox;
        private Button sendButton;
        private Label lblConnectionStatus;
        private Label lblConnectionState;
    }
}