using ContentManager_Application.Utils;
using FastMember;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ContentManager_Application
{
    public partial class OwnerMainForm : Form, IServerMessageObserver
    {
        private System.Windows.Forms.Timer? serverInfoTimer;
        private int nextUserIndex = 0;
        private static readonly int USERS_PER_REQUEST = 50;
        private int userId;
        private bool sortAscending = true;
        private bool loading = false;
        private bool logout = false;

        public OwnerMainForm(int userId)
        {
            InitializeComponent();

            InitializeServerInfoTimer();
            labelServerStatus.Text = "Подключено.";
            labelServerStatus.ForeColor = Color.Green;
            Program.client?.AddObserver(this);
            this.userId = userId;
            Program.client?.SendMessage("getuserinfo");
            Program.client?.SendMessage($"getusers~sp~{nextUserIndex}~sp~{nextUserIndex + USERS_PER_REQUEST}");
            ServerInfoTimer_Tick(null, EventArgs.Empty);
        }

        private void ConfigureDataGridView()
        {
            dataGridViewUsers.Columns["Id"].HeaderText = "ID";
            dataGridViewUsers.Columns["RoleName"].HeaderText = "Роль пользователя";
            dataGridViewUsers.Columns["Login"].HeaderText = "Логин";
            dataGridViewUsers.Columns["Nickname"].HeaderText = "Ник";

            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;

            dataGridViewUsers.Columns["Id"].Width = 50;
            dataGridViewUsers.Columns["RoleName"].Width = 100;
            dataGridViewUsers.Columns["Login"].Width = 150;
            dataGridViewUsers.Columns["Nickname"].Width = 150;
            dataGridViewUsers.Columns["Avatar"].Width = 50;

            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                string avatarId = row.Cells["AvatarId"].Value?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(avatarId))
                    LoadAvatarInCellById(avatarId, row.Cells["Avatar"]);
            }

            dataGridViewUsers.Columns["AvatarId"].Visible = false;

            foreach (DataGridViewColumn column in dataGridViewUsers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            string columnName = dataGridViewUsers.Columns[e.ColumnIndex].Name;
            if (columnName == "Avatar")
                return;

            if (sortAscending)
                dataGridViewUsers.Sort(dataGridViewUsers.Columns[columnName], ListSortDirection.Ascending);
            else
                dataGridViewUsers.Sort(dataGridViewUsers.Columns[columnName], ListSortDirection.Descending);

            sortAscending = !sortAscending;
            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                DataGridViewCell avatarCell = row.Cells["Avatar"];
                DataGridViewCell avatarIdCell = row.Cells["AvatarId"];
                string avatarId = avatarIdCell.Value?.ToString() ?? string.Empty;
                LoadAvatarInCellById(avatarId, avatarCell);
            }
        }

        private void LoadAvatarInCellById(string? avatarId, DataGridViewCell cell)
        {
            if (string.IsNullOrEmpty(avatarId))
                return;
            Image? avatar = ImageUtils.GetImageById(avatarId);
            ImageUtils.AddDataGridViewCellToCacheListener(avatarId, cell);
            if (avatar == null || avatar.Tag?.ToString() == "temp")
                Program.client?.RequestImage(avatarId);
            if (avatar != null)
                cell.Value = avatar;
            HideLoadingIndicator();
        }

        private void UpdateUserInGridView(string jsonUser)
        {
            ShowLoadingIndicator();
            var users = JsonConvert.DeserializeObject<List<dynamic>>(jsonUser);

            var userData = users?.Select(u => new
            {
                Id = (int)(u.Id ?? 0),
                RoleName = (string)(u.RoleName ?? string.Empty),
                Login = (string)(u.Login ?? string.Empty),
                Nickname = (string)(u.Nickname ?? string.Empty),
                AvatarId = (string)(u.AvatarId ?? string.Empty)
            }).ToList().FirstOrDefault();

            if (userData != null)
            {
                DataGridViewRow? userRow = FindRowByUserId(userData.Id);
                if (userRow != null)
                {
                    userRow.Cells["RoleName"].Value = userData.RoleName;
                    userRow.Cells["Login"].Value = userData.Login;
                    userRow.Cells["Nickname"].Value = userData.Nickname;
                    userRow.Cells["AvatarId"].Value = userData.AvatarId;
                    LoadAvatarInCellById(userData.AvatarId, userRow.Cells["Avatar"]);
                }
            }
        }

        private DataGridViewRow? FindRowByUserId(int userId)
        {
            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                if (row.Cells["ID"].Value != null && (int)row.Cells["ID"].Value == userId)
                {
                    return row;
                }
            }
            return null;
        }

        private void LoadUsers(string jsonUsersList)
        {
            var users = JsonConvert.DeserializeObject<List<dynamic>>(jsonUsersList);
            if (users == null || users.Count < 1)
            {
                HideLoadingIndicator();
                return;
            }

            nextUserIndex = users.Max(u => (int)(u.Id ?? 0)) + 1;
            var userData = users.Select(u => new
            {
                Id = (int)(u.Id ?? 0),
                RoleName = (string)(u.RoleName ?? string.Empty),
                Login = (string)(u.Login ?? string.Empty),
                Nickname = (string)(u.Nickname ?? string.Empty),
                AvatarId = (string)(u.AvatarId ?? string.Empty)
            }).ToList();

            if (dataGridViewUsers.DataSource is DataTable dataTable) // Если у dataGridViewUsers уже есть источник данных
            {
                var newTable = dataTable.Clone();

                foreach (DataRow row in dataTable.Rows)
                {
                    newTable.ImportRow(row);
                }

                foreach (var user in userData)
                {
                    var userRow = FindRowByUserId(user.Id);
                    if (userRow == null)
                    {
                        var newRow = newTable.NewRow();
                        newRow["Id"] = user.Id;
                        newRow["RoleName"] = user.RoleName;
                        newRow["Login"] = user.Login;
                        newRow["Nickname"] = user.Nickname;
                        newRow["AvatarId"] = user.AvatarId;
                        newTable.Rows.Add(newRow);
                    }
                    else
                    {
                        userRow.Cells["Id"].Value = user.Id;
                        userRow.Cells["RoleName"].Value = user.RoleName;
                        userRow.Cells["Login"].Value = user.Login;
                        userRow.Cells["Nickname"].Value = user.Nickname;
                        userRow.Cells["AvatarId"].Value = user.AvatarId;
                    }
                }

                dataGridViewUsers.DataSource = newTable;
                dataGridViewUsers.FirstDisplayedScrollingRowIndex = dataGridViewUsers.RowCount - 1;
            }
            else // Если у dataGridViewUsers нет источника данных
            {
                DataTable table = new DataTable();
                using (var reader = ObjectReader.Create(userData))
                {
                    table.Load(reader);
                }

                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Avatar";
                imgColumn.HeaderText = "Аватар";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridViewUsers.Columns.Add(imgColumn);

                dataGridViewUsers.DataSource = table;
            }

            ConfigureDataGridView();
            HideLoadingIndicator();
        }

        private void DataGridViewUsers_Scroll(object sender, ScrollEventArgs e)
        {
            if (!loading && dataGridViewUsers.DisplayedRowCount(false) + dataGridViewUsers.FirstDisplayedScrollingRowIndex >= dataGridViewUsers.RowCount)
            {
                ShowLoadingIndicator();
                loading = true;
                Program.client?.SendMessage($"getusers~sp~{nextUserIndex}~sp~{nextUserIndex + USERS_PER_REQUEST}");
            }
        }

        private void ShowLoadingIndicator()
        {
            pictureBoxLoading.Visible = true;
        }

        private void HideLoadingIndicator()
        {
            pictureBoxLoading.Visible = false;
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
                case "updateuser":
                    if (args.Length > 0)
                    {
                        UpdateUser(args);
                        return true;
                    }
                    break;
                case "setusers":
                    if (args.Length > 0)
                    {
                        SetUsers(args);
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
                case "logoutconfirm":
                    ConfirmLogout();
                    return true;
                default:
                    return false;
            }
            return false;
        }

        private void ConfirmLogout()
        {
            logout = true;
            Form loginForm = new LoginForm(true);
            loginForm.Show();
            Close();
        }

        private void UpdateUser(string[] args)
        {
            if (args.Length > 0)
                UpdateUserInGridView(args[0]);
        }

        private void SetUsers(string[] args)
        {
            if (args.Length > 0)
            {
                LoadUsers(args[0]);
                loading = false;
            }
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
                ImageUtils.AddPictureBoxToCacheListener(imageId, pictureBoxAvatar);
                if (image == null || image.Tag?.ToString() == "temp")
                    Program.client?.RequestImage(imageId);
                if (image != null)
                    pictureBoxAvatar.Image = image;
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

            if (!logout)
                Program.CloseConnect();
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

            logout = true;
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form editProfileForm = new EditProfileForm(userId, pictureBoxAvatar);
            editProfileForm.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];
                int userId = (int)selectedRow.Cells["Id"].Value;

                Form editProfileForm = new EditProfileForm(userId, null, false, false);
                editProfileForm.ShowDialog();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы точно хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                btnLogout.Enabled = false;
                Program.client?.SendMessage("logout");
            }
        }
    }
}