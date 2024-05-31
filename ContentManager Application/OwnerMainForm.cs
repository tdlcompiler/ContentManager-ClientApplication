using ContentManager_Application.Utils;

namespace ContentManager_Application
{
    public partial class OwnerMainForm : Form, IServerMessageObserver
    {
        private System.Windows.Forms.Timer? serverInfoTimer;

        public OwnerMainForm()
        {
            InitializeComponent();
            InitializeServerInfoTimer();
            labelServerStatus.Text = "Подключено.";
            labelServerStatus.ForeColor = Color.Green;
            Program.client?.AddObserver(this);
            Program.client?.SendMessage("getuserinfo");
            ServerInfoTimer_Tick(null, EventArgs.Empty);
        }

        private void InitializeServerInfoTimer()
        {
            serverInfoTimer = new();
            serverInfoTimer.Interval = 5000;
            serverInfoTimer.Tick += ServerInfoTimer_Tick;
            serverInfoTimer.Start();
        }

        private void ServerInfoTimer_Tick(object? sender, EventArgs e) =>
            Program.client?.SendMessage("getserverinfo");

        public bool HandleMessage(string data)
        {
            string[] parts = data.Split("~sp~");
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "setuserinfo":
                    if (args.Length > 0)
                    {
                        SetUserInfo(args);
                        return true;
                    }
                    break;
                case "updateserverinfo":
                    if (args.Length > 0)
                    {
                        UpdateServerInfo(args);
                        return true;
                    }
                    break;
                case ".png":
                    if (args.Length > 0)
                    {
                        ProcessImage(args);
                        return true;
                    }
                    break;
                default:
                    return false;
            }
            return false;
        }

        private void UpdateServerInfo(string[] args)
        {
            if (args.Length > 0)
            {
                labelOnlineUsersCount.Text = args[0];
            }
        }

        private void SetUserInfo(string[] args)
        {
            if (args.Length > 1)
            {
                labelUserNickname.Text = args[0];
                labelUserRole.Text = args[1];
            }
        }

        private void ProcessImage(string[] args)
        {
            string imageId = args[0];
            if (args.Length > 1)
            {
                switch (args[1])
                {
                    case "update_user_avatar":
                        UpdateUserAvatar(imageId);
                        break;
                    default:
                        MessageBox.Show($"Ошибка: Неизвестная команда '{args[1]}' для дальнейшей работы с изображением.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
                MessageBox.Show($"Ошибка: Нет команды для дальнейшей работы с изображением.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UpdateUserAvatar(string imageId)
        {
            try
            {
                Image? image = ImageUtils.GetImageById(imageId);
                if (!ImageUtils.ActivePictureBoxes.ContainsKey(imageId))
                    ImageUtils.ActivePictureBoxes.Add(imageId, pictureBoxAvatar);
                if (image == null || image.Tag?.ToString() == "temp")
                    Program.client?.RequestImage(imageId);
                if (image != null)
                {
                    pictureBoxAvatar.Image = ImageUtils.ResizeAndCropToSquare(image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке изображения: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OwnerMainForm_Load(object? sender, EventArgs e)
        {
            if (Program.client == null)
                return;
            Program.client.Connected += Client_Connected;
            Program.client.Disconnected += Client_Disconnected;
        }

        private void OwnerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.client != null)
            {
                Program.client.Connected -= Client_Connected;
                Program.client.Disconnected -= Client_Disconnected;
            }
            serverInfoTimer?.Dispose();
            Program.client?.RemoveObserver(this);
        }

        private void Client_Connected(object? sender, EventArgs e)
        {
            labelServerStatus.Text = "Подключено.";
            labelServerStatus.ForeColor = Color.Green;
            button1.Enabled = true;
            buttonAdd.Enabled = true;
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void Client_Disconnected(object? sender, EventArgs e)
        {
            labelServerStatus.Text = "Отключено от сервера.";
            labelServerStatus.ForeColor = Color.Red;
            button1.Enabled = false;
            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
            serverInfoTimer?.Dispose();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form editProfileForm = new EditProfileForm();
            editProfileForm.ShowDialog();
        }

        private async void buttonReconnect_Click(object sender, EventArgs e)
        {
            labelServerStatus.Text = "Подключение к серверу...";
            labelServerStatus.ForeColor = Color.Black;
            await Program.ConnectToServer();
        }
    }
}