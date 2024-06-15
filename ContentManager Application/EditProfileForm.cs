using ContentManager_Application.Utils;
using Newtonsoft.Json.Linq;

namespace ContentManager_Application
{
    public partial class EditProfileForm : Form, IServerMessageObserver
    {
        private PictureBox? mainUserAvatarPb;
        private bool isNewUser;
        private bool isEditSelf;
        private int userId;

        public EditProfileForm(int userId, PictureBox? userAvatarPb = null, bool isNewUser = false, bool isEditSelf = true)
        {
            this.isNewUser = isNewUser;
            this.isEditSelf = isEditSelf;
            this.userId = userId;
            InitializeComponent();
            mainUserAvatarPb = userAvatarPb;
            Program.client?.AddObserver(this);
            Program.client?.SendMessage($"geteditprofileinfo~sp~{userId}");
            avatarsGrid.AvatarSelected += AvatarsGrid_AvatarSelected;
        }

        private void AvatarsGrid_AvatarSelected(object sender, EventArgs e)
        {
            avatarsGrid.Enabled = false;
            userAvatarPb.Image = ImageUtils.LoadingImage;
            if (mainUserAvatarPb != null)
                mainUserAvatarPb.Image = ImageUtils.LoadingImage;
            Program.client?.SendMessage($"updateuseravatar~sp~{userId}~sp~{avatarsGrid.selectedPictureBox?.Tag}");
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
                case "setroles":
                    if (args.Length > 0)
                    {
                        SetRoles(args[0]);
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
                textBoxUserNickname.PlaceholderText = args[0];
                lblUserRole.Text = args[1];
                string imageId = args[2];
                Image? image = ImageUtils.GetImageById(imageId);
                if (image == null || image.Tag?.ToString() == "temp")
                    Program.client?.RequestImage(imageId);
                if (image != null)
                    userAvatarPb.Image = image;

                int x = (userInfoPanel.Width - lblUserNick.Width) / 2;
                lblUserNick.Location = new Point(x, lblUserNick.Location.Y);
                x = (userInfoPanel.Width - lblUserRole.Width) / 2;
                lblUserRole.Location = new Point(x, lblUserRole.Location.Y);

                if (!isNewUser)
                {
                    if (isEditSelf)
                        HideRoleEditing();
                    HideLoginAndPasswordEditing();
                }

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

        private void SetRoles(string json)
        {
            try
            {
                var roles = JArray.Parse(json);
                comboBoxRoleUser.Items.Clear();
                int i = 0;
                foreach (var role in roles)
                {
                    string roleName = (string)role["Name"];
                    comboBoxRoleUser.Items.Add(new ComboBoxItem { Text = roleName, Value = (int)role["Id"] });
                    if (roleName == lblUserRole.Text)
                        comboBoxRoleUser.SelectedIndex = i;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ролей: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideRoleEditing()
        {
            lblRoleUser.Enabled = false;
            comboBoxRoleUser.Enabled = false;
        }

        private void HideLoginAndPasswordEditing()
        {
            lblLoginUser.Enabled = false;
            lblPassUser.Enabled = false;
            textBoxLoginUser.Enabled = false;
            textBoxPassUser.Enabled = false;
        }

        private void SaveNewUser()
        {
            var login = textBoxLoginUser.Text;
            var password = textBoxPassUser.Text;
            var role = ((ComboBoxItem)comboBoxRoleUser.SelectedItem)?.Value;
            var nickname = textBoxUserNickname.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || role == null || string.IsNullOrEmpty(nickname))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var message = $"adduser~sp~{login}~sp~{password}~sp~{role}~sp~{nickname}";
            Program.client?.SendMessage(message);
        }

        private void EditExistingUser()
        {
            var role = ((ComboBoxItem)comboBoxRoleUser.SelectedItem)?.Value;
            var nickname = textBoxUserNickname.Text;

            if (role == null || string.IsNullOrEmpty(nickname))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var message = $"edituser~sp~{userId}~sp~{nickname}~sp~{role}";
            Program.client?.SendMessage(message);
        }

        private void btnSaveUserData_Click(object sender, EventArgs e)
        {
            if (isNewUser)
            {
                SaveNewUser();
            }
            else
            {
                EditExistingUser();
            }

            Close();
        }

        private void EditProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.client?.RemoveObserver(this);
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}