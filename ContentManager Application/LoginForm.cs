namespace ContentManager_Application
{
    public partial class LoginForm : Form, IServerMessageObserver
    {
        private System.Windows.Forms.Timer? loginTimeoutTimer;

        public LoginForm()
        {
            InitializeComponent();
            InitializeLoginTimeoutTimer();
            Program.client?.AddObserver(this);
        }

        public bool HandleMessage(string data)
        {
            loginTimeoutTimer?.Stop();
            loginButton.Enabled = true;
            registerButton.Enabled = true;
            string[] parts = data.Split("~sp~");
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "reg_result":
                    HandleRegistrationResult(args);
                    return true;
                case "auth_result":
                    HandleAuthenticationResult(args);
                    return true;
                default:
                    return false;
            }
        }

        private void HandleRegistrationResult(string[] args)
        {
            if (args.Length != 1)
            {
                MessageBox.Show($"Ошибка: Неизвестная команда '{args}'.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string regState = args[0];

            if (regState == "completed")
            {
                AppendTextToTextBox("Успешная регистрация в системе.");
            }
            else if (regState == "login_is_taken")
            {
                AppendTextToTextBox("Этот логин занят другим пользователем!");
            }
            else if (regState == "internal_error")
                AppendTextToTextBox("Произошла внутренняя ошибка сервера при регистрации. Повторите попытку позже.");
        }

        private void HandleAuthenticationResult(string[] args)
        {
            if (args.Length != 2)
            {
                MessageBox.Show($"Ошибка: Некорректное количество аргументов для HandleAuthenticationResult.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string authState = args[0];
            string userRole = args[1];

            if (authState == "allowed")
            {
                AppendTextToTextBox("Успешный вход в систему.");
                switch (userRole)
                {
                    case "1":
                        OwnerMainForm ownerForm = new OwnerMainForm();
                        ownerForm.Show();
                        Close();
                        break;
                    case "2":
                    default:
                        break;
                }
            }
            else if (authState == "incorrect_pass")
            {
                AppendTextToTextBox("Неверный пароль!");
            }
            else if (authState == "incorrect")
            {
                AppendTextToTextBox("Пользователя с таким логином не существует!");
            }
        }

        private void InitializeLoginTimeoutTimer()
        {
            loginTimeoutTimer = new();
            loginTimeoutTimer.Interval = 5000;
            loginTimeoutTimer.Tick += LoginTimeoutTimer_Tick;
        }

        private void LoginTimeoutTimer_Tick(object? sender, EventArgs e)
        {
            loginTimeoutTimer?.Stop();
            loginButton.Enabled = true;
            registerButton.Enabled = true;
            AppendTextToTextBox("Превышено время ожидания ответа от сервера.");
        }

        private async void LoginForm_Load(object? sender, EventArgs e)
        {
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;

            if (Program.client == null)
                return;
            Program.client.Connected += Client_Connected;
            Program.client.Disconnected += Client_Disconnected;

            await Program.ConnectToServer();
        }

        private void Client_Connected(object? sender, EventArgs e)
        {
            AppendTextToTextBox("Подключено к серверу.");
            lblConnectionStateLogin.Text = "Подключено.";
            lblConnectionStateLogin.ForeColor = Color.Green;

            loginTextBox.ReadOnly = false;
            passwordTextBox.ReadOnly = false;
            loginButton.Visible = true;
            registerButton.Visible = true;
            registerButton.Enabled = true;
            loginButton.Enabled = true;
            reconnectButton.Enabled = false;
            reconnectButton.Visible = false;
        }

        private void Client_Disconnected(object? sender, EventArgs e)
        {
            AppendTextToTextBox("Отключено от сервера.");
            lblConnectionStateLogin.Text = "Отключено.";
            lblConnectionStateLogin.ForeColor = Color.Red;

            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            loginButton.Visible = false;
            registerButton.Visible = false;
            registerButton.Enabled = false;
            loginButton.Enabled = false;
            reconnectButton.Enabled = true;
            reconnectButton.Visible = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            registerButton.Enabled = false;
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loginButton.Enabled = true;
                registerButton.Enabled = true;
                return;
            }

            loginTimeoutTimer?.Start();

            Exception? error = Program.client?.SendMessage($"auth~{login}~{password}");
            if (error != null)
            {
                loginTimeoutTimer?.Stop();
                loginButton.Enabled = true;
                registerButton.Enabled = true;
                AppendTextToTextBox(error.Message);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            registerButton.Enabled = false;
            loginButton.Enabled = false;
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                registerButton.Enabled = true;
                loginButton.Enabled = true;
                return;
            }

            loginTimeoutTimer?.Start();

            Exception? error = Program.client?.SendMessage($"reg~{login}~{password}");
            if (error != null)
            {
                loginTimeoutTimer?.Stop();
                registerButton.Enabled = true;
                loginButton.Enabled = true;
                AppendTextToTextBox(error.Message);
            }
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void AppendTextToTextBox(string text)
        {
            string msg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}]: {text}";
            if (loginResponseTextBox.InvokeRequired)
            {
                loginResponseTextBox.Invoke(new Action<string>(AppendTextToTextBox), msg);
            }
            else
            {
                loginResponseTextBox.AppendText(msg + Environment.NewLine);
            }
            loginResponseTextBox.ScrollToCaret();
        }

        private async void ReconnectButton_Click(object sender, EventArgs e)
        {
            AppendTextToTextBox("Переподключение...");
            reconnectButton.Enabled = false;
            lblConnectionStateLogin.Text = "Подключение к серверу...";
            lblConnectionStateLogin.ForeColor = Color.Black;
            await Program.ConnectToServer();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.client != null)
            {
                Program.client.Connected -= Client_Connected;
                Program.client.Disconnected -= Client_Disconnected;
            }
            Program.client?.RemoveObserver(this);
        }
    }
}