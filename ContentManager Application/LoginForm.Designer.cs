namespace ContentManager_Application
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;

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
            loginTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            registerButton = new Button();
            loginLabel = new Label();
            passwordLabel = new Label();
            loginResponseTextBox = new RichTextBox();
            label1 = new Label();
            lblConnectionStateLogin = new Label();
            reconnectButton = new Button();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(65, 20);
            loginTextBox.Margin = new Padding(4, 3, 4, 3);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(186, 23);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(65, 66);
            passwordTextBox.Margin = new Padding(4, 3, 4, 3);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(186, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(65, 115);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(88, 27);
            loginButton.TabIndex = 2;
            loginButton.Text = "Вход";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(164, 115);
            registerButton.Margin = new Padding(4, 3, 4, 3);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(88, 27);
            registerButton.TabIndex = 3;
            registerButton.Text = "Регистрация";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(13, 23);
            loginLabel.Margin = new Padding(4, 0, 4, 0);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(44, 15);
            loginLabel.TabIndex = 4;
            loginLabel.Text = "Логин:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(5, 69);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(52, 15);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Пароль:";
            // 
            // loginResponseTextBox
            // 
            loginResponseTextBox.Location = new Point(269, 12);
            loginResponseTextBox.Name = "loginResponseTextBox";
            loginResponseTextBox.Size = new Size(235, 139);
            loginResponseTextBox.TabIndex = 6;
            loginResponseTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 145);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 7;
            label1.Text = "Статус:";
            // 
            // lblConnectionStateLogin
            // 
            lblConnectionStateLogin.AutoSize = true;
            lblConnectionStateLogin.Location = new Point(54, 145);
            lblConnectionStateLogin.Name = "lblConnectionStateLogin";
            lblConnectionStateLogin.Size = new Size(150, 15);
            lblConnectionStateLogin.TabIndex = 8;
            lblConnectionStateLogin.Text = "Подключение к серверу...";
            // 
            // reconnectButton
            // 
            reconnectButton.Enabled = false;
            reconnectButton.Location = new Point(92, 115);
            reconnectButton.Name = "reconnectButton";
            reconnectButton.Size = new Size(127, 27);
            reconnectButton.TabIndex = 9;
            reconnectButton.Text = "Переподключиться";
            reconnectButton.UseVisualStyleBackColor = true;
            reconnectButton.Visible = false;
            reconnectButton.Click += ReconnectButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 163);
            Controls.Add(reconnectButton);
            Controls.Add(lblConnectionStateLogin);
            Controls.Add(label1);
            Controls.Add(loginResponseTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(registerButton);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Авторизация";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private RichTextBox loginResponseTextBox;
        private Label label1;
        private Label lblConnectionStateLogin;
        private Button reconnectButton;
    }
}
