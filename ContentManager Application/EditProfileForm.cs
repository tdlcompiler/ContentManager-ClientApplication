using ContentManager_Application.Utils;

namespace ContentManager_Application
{
    public partial class EditProfileForm : Form, IServerMessageObserver
    {

        public EditProfileForm()
        {
            InitializeComponent();
            Program.client?.AddObserver(this);
            Program.client?.SendMessage("geteditprofileinfo");
            avatarsGrid.AvatarSelected += AvatarsGrid_AvatarSelected;
        }

        private void AvatarsGrid_AvatarSelected(object sender, EventArgs e)
        {
            avatarsGrid.Enabled = false;
            userAvatarPb.Image = ImageUtils.LoadingImage;
            Program.client?.SendMessage($"updateuseravatar~{avatarsGrid.selectedPictureBox?.Tag}");
        }

        public bool HandleMessage(string data)
        {
            string[] parts = data.Split("~sp~");
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "setuseravatarimages":
                    if (args.Length > 0)
                    {
                        SetUserAvatarImages(args);
                        return true;
                    }
                    break;
                case "seteditprofiledata":
                    if (args.Length > 0)
                    {
                        SetData(args);
                        return true;
                    }
                    break;
                default:
                    return false;
            }
            return false;
        }

        private void SetData(string[] args)
        {
            if (args.Length > 1)
            {
                lblUserNick.Text = args[0];
                lblUserRole.Text = args[1];
                string imageId = args[2];
                Image? image = ImageUtils.GetImageById(imageId);
                if (image == null || image.Tag?.ToString() == "temp")
                    Program.client?.RequestImage(imageId);
                if (image != null)
                    userAvatarPb.Image = ImageUtils.ResizeAndCropToSquare(image, userAvatarPb.Height);

                int x = (userInfoPanel.Width - lblUserNick.Width) / 2;
                lblUserNick.Location = new Point(x, lblUserNick.Location.Y);
                x = (userInfoPanel.Width - lblUserRole.Width) / 2;
                lblUserRole.Location = new Point(x, lblUserRole.Location.Y);

                avatarsGrid.Enabled = true;
            }
        }

        private void SetUserAvatarImages(string[] args)
        {
            if (args.Length > 1)
            {
                try
                {
                    Dictionary<string, Image> avatars = new Dictionary<string, Image>();
                    for (int i = 0; i < args.Length; i++)
                    {
                        string imageId = args[i];
                        Image? image = ImageUtils.GetImageById(imageId);
                        if (image == null || image.Tag?.ToString() == "temp")
                            Program.client?.RequestImage(imageId);
                        if (image != null)
                            avatars.Add(imageId, image);

                    }
                    avatarsGrid.InitializeGrid(3, avatars);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке аватаров: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.client != null)
            {
                //Program.client.Connected -= Client_Connected;
                //Program.client.Disconnected -= Client_Disconnected;
            }
            Program.client?.RemoveObserver(this);
        }
    }
}
