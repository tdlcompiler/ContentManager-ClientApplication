using ContentManager_Application.Utils;
using Newtonsoft.Json;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ContentManager_Application
{
    public partial class UserMainForm : Form, IServerMessageObserver
    {
        private event Action<string> OnSaveRequestMessageReceived;

        private System.Windows.Forms.Timer? serverInfoTimer;
        private int nextAuthorIndex = 0;
        private int nextNovelIndex = 0;
        private bool isLoadingAuthors = false;
        private bool isLoadingNovels = false;
        private BindingList<AuthorData> authorsData = new BindingList<AuthorData>();
        private BindingList<NovelData> novelsData = new BindingList<NovelData>();
        private static readonly int AUTHORS_AND_NOVELS_PER_REQUEST = 50;
        private int userId;
        private bool logout = false;

        public UserMainForm(int userId)
        {
            InitializeComponent();
            InitializeServerInfoTimer();

            authorsData.AllowEdit = true;
            novelsData.AllowEdit = true;
            Program.client?.AddObserver(this);
            this.userId = userId;
            labelServerStatus.Text = "Подключено.";
            labelServerStatus.ForeColor = Color.Green;
            Program.client?.SendMessage("getuserinfo");
            LoadAuthorsData();
            ServerInfoTimer_Tick(null, EventArgs.Empty);
        }

        public bool HandleMessage(string data)
        {
            string[] parts = data.Split("~sp~");
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "setallnovels":
                case "setallauthors":
                case "setallmessages":
                    OnSaveRequestMessageReceived?.Invoke(data);
                    return true;
                case "updateserverinfo":
                    if (args.Length > 0)
                    {
                        UpdateServerInfo(args);
                        return true;
                    }
                    break;
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
                case "setnovels":
                    if (args.Length > 0)
                    {
                        SetNovels(args);
                        return true;
                    }
                    break;
                case "setauthors":
                    if (args.Length > 0)
                    {
                        SetAuthors(args);
                        return true;
                    }
                    break;
                case "addauthor":
                    if (args.Length > 0)
                    {
                        AddAuthor(args);
                        return true;
                    }
                    break;
                case "updateauthor":
                    if (args.Length > 0)
                    {
                        UpdateAuthor(args);
                        return true;
                    }
                    break;
                case "removeauthor":
                    if (args.Length > 0)
                    {
                        RemoveAuthor(args);
                        return true;
                    }
                    break;
                case "addnovel":
                    if (args.Length > 0)
                    {
                        AddNovel(args);
                        return true;
                    }
                    break;
                case "updatenovel":
                    if (args.Length > 0)
                    {
                        UpdateNovel(args);
                        return true;
                    }
                    break;
                case "removenovel":
                    if (args.Length > 0)
                    {
                        RemoveNovel(args);
                        return true;
                    }
                    break;
                case "errorsavenovel":
                    if (args.Length > 0)
                    {
                        ErrorSaveNovel(args);
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

        private void ErrorSaveNovel(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "chaptersrepeat":
                        MessageBox.Show($"Ошибка: Невозможно сохранить данные новеллы, т.к. разные главы не могут иметь одно название!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        foreach (NovelData novel in novelsData)
                        {
                            novel.RestoreChapters();
                        }
                        break;
                }
            }
        }

        private void RemoveAuthor(string[] args)
        {
            if (args.Length > 0)
            {
                if (int.TryParse(args[0], out int authorId))
                {
                    var authorToRemove = authorsData.FirstOrDefault(a => a.Id == authorId);
                    if (authorToRemove != null)
                        authorsData.Remove(authorToRemove);
                }
                else
                    MessageBox.Show($"Ошибка: Невозможно удалить автора с Id: {authorId}, т.к. он отсутствует в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ConfigureAuthorsDataGridView()
        {
            dataGridViewAuthors.Columns["Id"].HeaderText = "ID";
            dataGridViewAuthors.Columns["Name"].HeaderText = "Имя автора";
            dataGridViewAuthors.Columns["Country"].HeaderText = "Страна";

            dataGridViewAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAuthors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAuthors.MultiSelect = false;

            dataGridViewAuthors.Columns["Id"].Width = 50;
            dataGridViewAuthors.Columns["Name"].Width = 100;
            dataGridViewAuthors.Columns["Country"].Width = 150;

            foreach (DataGridViewColumn column in dataGridViewAuthors.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void ConfigureNovelsDataGridView()
        {
            dataGridViewNovels.Columns["Id"].HeaderText = "ID";
            dataGridViewNovels.Columns["Title"].HeaderText = "Название";
            dataGridViewNovels.Columns["CreationDate"].HeaderText = "Дата создания";
            dataGridViewNovels.Columns["ChapterCount"].HeaderText = "Количество глав";
            dataGridViewNovels.Columns["AuthorName"].HeaderText = "Имя Автора";

            dataGridViewNovels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNovels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNovels.MultiSelect = false;

            dataGridViewNovels.Columns["Id"].Width = 50;
            dataGridViewNovels.Columns["Title"].Width = 150;
            dataGridViewNovels.Columns["CreationDate"].Width = 100;
            dataGridViewNovels.Columns["ChapterCount"].Width = 100;
            dataGridViewNovels.Columns["AuthorName"].Width = 150;

            foreach (DataGridViewColumn column in dataGridViewNovels.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridViewNovels.Columns["AuthorId"].Visible = false;
        }

        private void ShowLoadingIndicator()
        {
            pbLoadingAuthors.Visible = true;
            pbLoadingNovels.Visible = true;
        }

        private void HideLoadingIndicator()
        {
            pbLoadingAuthors.Visible = false;
            pbLoadingNovels.Visible = false;
        }

        private void UpdateServerInfo(string[] args)
        {
            if (args.Length > 0)
            {
                labelOnlineUsersCount.Text = args[0];
            }
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

        private void UpdateAuthor(string[] args)
        {
            if (args.Length > 0)
            {
                var authors = JsonConvert.DeserializeObject<BindingList<AuthorData>>(args[0]);
                if (authors == null || authors.Count < 1)
                    return;

                AuthorData author = authors[0];
                var authorToUpdate = authorsData.FirstOrDefault(a => a.Id == author.Id);
                authorToUpdate?.CopyFromAuthor(author);
            }
        }

        private void AddAuthor(string[] args)
        {
            if (args.Length > 0)
            {
                var authors = JsonConvert.DeserializeObject<BindingList<AuthorData>>(args[0]);
                if (authors == null || authors.Count < 1)
                    return;

                nextAuthorIndex = authors[0].Id + 1;
                authorsData.Add(authors[0]);
            }
        }

        private void SetAuthors(string[] args)
        {
            if (args.Length > 0)
            {
                LoadAuthors(args[0]);
                isLoadingAuthors = false;
            }
        }

        private void AddNovel(string[] args)
        {
            if (args.Length > 0)
            {
                var novels = JsonConvert.DeserializeObject<BindingList<NovelData>>(args[0]);
                if (novels == null || novels.Count < 1)
                    return;

                foreach (var novel in novels)
                {
                    var author = authorsData.FirstOrDefault(a => a.Id == novel.AuthorId);
                    if (author != null)
                    {
                        novel.AuthorName = author.Name;
                    }
                }

                nextNovelIndex = novels[0].Id + 1;
                novelsData.Add(novels[0]);
            }
        }

        private void UpdateNovel(string[] args)
        {
            if (args.Length > 0)
            {
                var novels = JsonConvert.DeserializeObject<BindingList<NovelData>>(args[0]);
                if (novels == null || novels.Count < 1)
                    return;

                NovelData novel = novels[0];
                var novelToUpdate = novelsData.FirstOrDefault(n => n.Id == novel.Id);
                if (novelToUpdate != null)
                {
                    novelToUpdate.CopyFromNovel(novel);

                    var author = authorsData.FirstOrDefault(a => a.Id == novelToUpdate.AuthorId);
                    if (author != null)
                    {
                        novelToUpdate.AuthorName = author.Name;
                    }
                }
            }
        }

        private void RemoveNovel(string[] args)
        {
            if (args.Length > 0)
            {
                if (int.TryParse(args[0], out int novelId))
                {
                    var novelToRemove = novelsData.FirstOrDefault(n => n.Id == novelId);
                    if (novelToRemove != null)
                        novelsData.Remove(novelToRemove);
                }
                else
                    MessageBox.Show($"Ошибка: Невозможно удалить новеллу с Id: {novelId}, т.к. она отсутствует в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuthors(string jsonAuthorsList)
        {
            var authors = JsonConvert.DeserializeObject<BindingList<AuthorData>>(jsonAuthorsList);
            if (authors == null || authors.Count < 1)
            {
                HideLoadingIndicator();
                return;
            }

            nextAuthorIndex = authors.Max(a => a.Id) + 1;
            authorsData = authors;
            dataGridViewAuthors.DataSource = authorsData;

            ConfigureAuthorsDataGridView();
            HideLoadingIndicator();
        }

        private void SetNovels(string[] args)
        {
            if (args.Length > 0)
            {
                LoadNovels(args[0]);
                isLoadingNovels = false;
            }
        }

        private void LoadNovels(string jsonNovelsList)
        {
            var novels = JsonConvert.DeserializeObject<BindingList<NovelData>>(jsonNovelsList);
            if (novels == null || novels.Count < 1)
            {
                HideLoadingIndicator();
                return;
            }

            foreach (var novel in novels)
            {
                var author = authorsData.FirstOrDefault(a => a.Id == novel.AuthorId);
                if (author != null)
                {
                    novel.AuthorName = author.Name;
                }
                else
                    novel.AuthorName = $"Unloaded, ID: {novel.AuthorId}";
            }

            nextNovelIndex = novels.Max(n => n.Id) + 1;
            novelsData = novels;
            dataGridViewNovels.DataSource = novelsData;

            ConfigureNovelsDataGridView();
            HideLoadingIndicator();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageNovels)
            {
                novelsData.Clear();
                nextNovelIndex = 0;
                LoadNovelsData();
            }
            else if (tabControl.SelectedTab == tabPageAuthors)
            {
                authorsData.Clear();
                nextAuthorIndex = 0;
                LoadAuthorsData();
            }
        }

        private void LoadNovelsData()
        {
            ShowLoadingIndicator();
            Program.client?.SendMessage($"getnovellist~sp~{nextNovelIndex}~sp~{nextNovelIndex + AUTHORS_AND_NOVELS_PER_REQUEST}");
        }

        private void LoadAuthorsData()
        {
            ShowLoadingIndicator();
            Program.client?.SendMessage($"getauthorlist~sp~{nextAuthorIndex}~sp~{nextAuthorIndex + AUTHORS_AND_NOVELS_PER_REQUEST}");
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            Form newAuthorForm = new NewAuthorForm();
            newAuthorForm.Text = "Новый автор";
            newAuthorForm.ShowDialog();
        }

        private void buttonRemoveAuthor_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthors.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewAuthors.SelectedRows[0];
                int authorId = (int)selectedRow.Cells["Id"].Value;

                Program.client?.SendMessage($"removeauthor~sp~{authorId}");
            }
        }

        private void buttonEditAuthor_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuthors.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewAuthors.SelectedRows[0];
                int authorId = (int)selectedRow.Cells["Id"].Value;
                var author = authorsData.FirstOrDefault(a => a.Id == authorId);
                if (author != null)
                {
                    Form newAuthorForm = new NewAuthorForm(author);
                    newAuthorForm.Text = "Редактирование автора";
                    newAuthorForm.ShowDialog();
                }
            }
        }

        private void btnAddNovel_Click(object sender, EventArgs e)
        {
            Form newNovelForm = new NewNovelForm(authorsData);
            newNovelForm.Text = "Новая новелла";
            newNovelForm.ShowDialog();
        }

        private void btnRemoveNovel_Click(object sender, EventArgs e)
        {
            if (dataGridViewNovels.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewNovels.SelectedRows[0];
                int novelId = (int)selectedRow.Cells["Id"].Value;

                Program.client?.SendMessage($"removenovel~sp~{novelId}");
            }
        }

        private void btnEditNovel_Click(object sender, EventArgs e)
        {
            if (dataGridViewNovels.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewNovels.SelectedRows[0];
                int novelId = (int)selectedRow.Cells["Id"].Value;
                var novel = novelsData.FirstOrDefault(a => a.Id == novelId);
                if (novel != null)
                {
                    Form newNovelForm = new NewNovelForm(authorsData, novel);
                    newNovelForm.Text = "Редактирование новеллы";
                    newNovelForm.ShowDialog();
                }
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            Form editProfileForm = new EditProfileForm(userId, pictureBoxAvatar);
            editProfileForm.ShowDialog();
        }

        private void UserMainForm_Load(object? sender, EventArgs e)
        {
            if (Program.client == null)
                return;
            Program.client.Disconnected += Client_Disconnected;
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
                MessageBox.Show("Ошибка: Нет команды для дальнейшей работы с изображением.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void Client_Disconnected(object? sender, EventArgs e)
        {
            labelServerStatus.Text = "Отключено от сервера.";
            labelServerStatus.ForeColor = Color.Red;
            btnAddNovel.Enabled = false;
            btnEditNovel.Enabled = false;
            btnRemoveNovel.Enabled = false;
            buttonAddAuthor.Enabled = false;
            buttonEditAuthor.Enabled = false;
            buttonRemoveAuthor.Enabled = false;
            btnEditProfile.Enabled = false;
            serverInfoTimer?.Dispose();

            logout = true;
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }

        private void UserMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.client != null)
            {
                Program.client.Disconnected -= Client_Disconnected;
            }
            serverInfoTimer?.Dispose();
            Program.client?.RemoveObserver(this);

            if (!logout)
                Program.CloseConnect();
        }

        private void dataGridViewNovels_Scroll(object sender, ScrollEventArgs e)
        {
            if (!isLoadingNovels && dataGridViewNovels.DisplayedRowCount(false) + dataGridViewNovels.FirstDisplayedScrollingRowIndex >= dataGridViewNovels.RowCount)
            {
                isLoadingNovels = true;
                LoadNovelsData();
            }
        }

        private void dataGridViewAuthors_Scroll(object sender, ScrollEventArgs e)
        {
            if (!isLoadingAuthors && dataGridViewAuthors.DisplayedRowCount(false) + dataGridViewAuthors.FirstDisplayedScrollingRowIndex >= dataGridViewAuthors.RowCount)
            {
                isLoadingAuthors = true;
                LoadAuthorsData();
            }
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

        private async void btnAuthorsToJSON_Click(object sender, EventArgs e)
        {
            try
            {
                ShowLoadingIndicator();
                btnAuthorsToJSON.Enabled = false;
                var authors = await FetchDataFromServer<AuthorData>("getauthorlist", "setallauthors");
                SaveAuthorsToJSON(authors);
                HideLoadingIndicator();
                btnAuthorsToJSON.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnNovelsToJSON_Click(object sender, EventArgs e)
        {
            try
            {
                ShowLoadingIndicator();
                btnNovelsToJSON.Enabled = false;
                var novels = await FetchDataFromServer<NovelData>("getnovellist", "setallnovels");
                foreach (var novel in novels)
                {
                    if (novel.Chapters != null && novel.Chapters.Count > 0)
                        novel.Chapters = await FetchMessages(novel);
                }
                SaveNovelsToJSON(novels);
                HideLoadingIndicator();
                btnNovelsToJSON.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private Task<List<T>> FetchDataFromServer<T>(string requestMessage, string responseType)
        {
            var tcs = new TaskCompletionSource<List<T>>();

            void Handler(string data)
            {
                var parts = data.Split(new[] { "~sp~" }, StringSplitOptions.None);
                var messageType = parts[0];
                if (messageType == responseType)
                {
                    var jsonData = parts[1];
                    var list = JsonConvert.DeserializeObject<List<T>>(jsonData);
                    tcs.SetResult(list);
                    OnSaveRequestMessageReceived -= Handler;
                }
            }

            OnSaveRequestMessageReceived += Handler;
            Program.client?.SendMessage(requestMessage);

            return tcs.Task;
        }

        private async Task<BindingList<Chapter>> FetchMessages(NovelData novel)
        {
            var chapters = novel.Chapters;
            foreach (var chapter in chapters)
            {
                var messages = await FetchDataFromServer<Message>($"getmessages~sp~{chapter.Id}", "setallmessages");
                chapter.Messages = new List<Message>(messages);
            }
            return new BindingList<Chapter>(chapters);
        }

        private void SaveAuthorsToJSON(List<AuthorData> authors)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.Combine(folderDialog.SelectedPath, "Authors");
                    Directory.CreateDirectory(folderPath);

                    foreach (var author in authors)
                    {
                        string filePath = Path.Combine(folderPath, $"{author.Name}.json");
                        string json = JsonConvert.SerializeObject(author, Formatting.Indented);
                        File.WriteAllText(filePath, json);
                    }

                    MessageBox.Show("Конфигурации авторов успешно сохранены локально!", "Сохранение авторов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveNovelsToJSON(List<NovelData> novels)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.Combine(folderDialog.SelectedPath, "Novels");
                    Directory.CreateDirectory(folderPath);

                    foreach (var novel in novels)
                    {
                        string filePath = Path.Combine(folderPath, $"{novel.Title}.json");
                        string json = JsonConvert.SerializeObject(novel, Formatting.Indented);
                        File.WriteAllText(filePath, json);
                    }

                    MessageBox.Show("Конфигурации новелл успешно сохранены локально!", "Сохранение новелл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    public class AuthorData : INotifyPropertyChanged
    {
        private int id;
        private string name = string.Empty;
        private string country = string.Empty;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CopyFromAuthor(AuthorData other)
        {
            if (other == null) return;
            Id = other.Id;
            Name = other.Name;
            Country = other.Country;
        }
    }

    public class Chapter : INotifyPropertyChanged
    {
        private string title = string.Empty;
        private int id;
        public List<Message> Messages = new List<Message>();

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class NovelData : INotifyPropertyChanged
    {
        private int id;
        private string title = string.Empty;
        private DateTime creationDate;
        private int chapterCount;
        private int authorId;
        private string authorName = string.Empty;
        private BindingList<Chapter> chapters = new BindingList<Chapter>();

        [JsonIgnore]
        private BindingList<Chapter>? initialChapters;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set
            {
                if (creationDate != value)
                {
                    creationDate = value;
                    OnPropertyChanged(nameof(CreationDate));
                }
            }
        }

        public int ChapterCount
        {
            get { return chapterCount; }
            set
            {
                if (chapterCount != value)
                {
                    chapterCount = value;
                    OnPropertyChanged(nameof(ChapterCount));
                }
            }
        }

        public void BackupChapters()
        {
            initialChapters = NewNovelForm.CopyBindingList(Chapters);
        }

        public void RestoreChapters()
        {
            Chapters = initialChapters ?? Chapters;
        }

        public BindingList<Chapter> Chapters
        {
            get { return chapters; }
            set
            {
                if (chapters != value)
                {
                    initialChapters ??= chapters;
                    chapters = value;
                    OnPropertyChanged(nameof(Chapters));
                }
            }
        }

        public int AuthorId
        {
            get { return authorId; }
            set
            {
                if (authorId != value)
                {
                    authorId = value;
                    OnPropertyChanged(nameof(AuthorId));
                }
            }
        }

        [JsonIgnore]
        public string AuthorName
        {
            get { return authorName; }
            set
            {
                if (authorName != value)
                {
                    authorName = value;
                    OnPropertyChanged(nameof(AuthorName));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CopyFromNovel(NovelData other)
        {
            if (other == null) return;
            Id = other.Id;
            Title = other.Title;
            CreationDate = other.CreationDate;
            ChapterCount = other.ChapterCount;
            AuthorId = other.AuthorId;
            AuthorName = other.AuthorName;
        }
    }
}