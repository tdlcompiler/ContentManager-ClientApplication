using ContentManager_Application.Utils;

namespace ContentManager_Application
{
    public partial class OwnerMainForm : Form, IServerMessageObserver
    {
        public OwnerMainForm()
        {
            InitializeComponent();
            Program.client?.AddObserver(this);
            Program.client?.SendMessage("getuserinfo");
        }

        public bool HandleMessage(string data)
        {
            string[] parts = data.Split('~');
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
            string base64Image = args[0];
            if (args.Length > 1)
            {
                switch (args[1])
                {
                    case "update_user_avatar":
                        UpdateUserAvatar(base64Image);
                        break;
                    default:
                        MessageBox.Show($"Ошибка: Неизвестная команда '{args[1]}' для дальнейшей работы с изображением.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
                MessageBox.Show($"Ошибка: Нет команды для дальнейшей работы с изображением.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateUserAvatar(string base64Image)
        {
            try
            {
                Image image = ImageUtils.ImageFromBase64(base64Image);
                pictureBoxAvatar.Image = ImageUtils.ResizeAndCropToSquare(image);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке изображения: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OwnerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.client != null)
            {
                //Program.client.Connected -= Client_Connected;
                //Program.client.Disconnected -= Client_Disconnected;
            }
            Program.client?.RemoveObserver(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form editProfileForm = new EditProfileForm();
            editProfileForm.ShowDialog();
        }
    }
}