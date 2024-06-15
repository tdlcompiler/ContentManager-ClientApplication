using ContentManager_Application.Utils;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Forms;

namespace ContentManager_Application
{
    public partial class MessagesEditorForm : Form, IServerMessageObserver
    {
        private static readonly int USERS_PER_REQUEST = 50;

        private BindingList<Message>? messages;
        private BindingList<MessageType>? messageTypes;
        private bool isDragging = false;
        private int rowIndexFromMouseDown;
        private NovelData? currentNovel;
        private int currentChapterId;
        private int nextMessageIndex = 0;
        private bool isLoadingMessages = false;

        public MessagesEditorForm(NovelData? novel, int chapterId)
        {
            InitializeComponent();

            Program.client?.AddObserver(this);
            currentNovel = novel;
            currentChapterId = chapterId;
            Program.client?.SendMessage($"getmessages~sp~{currentChapterId}~sp~{nextMessageIndex}~sp~{nextMessageIndex + USERS_PER_REQUEST}");
        }

        public bool HandleMessage(string data)
        {
            string[] parts = data.Split("~sp~");
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "setmessages":
                    {
                        SetMessages(args);
                        return true;
                    }
                default:
                    return false;
            }
        }

        private void SetMessages(string[] args)
        {
            if (args.Length > 0)
            {
                LoadMessages(args[0]);
                isLoadingMessages = false;
            }
        }

        private void LoadMessages(string jsonMessagesList)
        {
            messages = JsonConvert.DeserializeObject<BindingList<Message>>(jsonMessagesList);
            if (messages == null || messages.Count < 1)
            {
                HideLoadingIndicator();
                return;
            }

            nextMessageIndex = messages.Max(m => m.Id + 1);
            dataGridViewMessages.DataSource = messages;
            HideLoadingIndicator();
        }

        private void ShowLoadingIndicator()
        {
            pictureBoxLoading.Visible = true;
        }

        private void HideLoadingIndicator()
        {
            pictureBoxLoading.Visible = false;
        }

        private void MessagesEditorForm_Load(object sender, EventArgs e)
        {
            //InitializeData();
            dataGridViewMessages.DataSource = messages;

            if (dataGridViewMessages.Columns["MessageTypeId"] is DataGridViewComboBoxColumn messageTypeColumn)
            {
                messageTypeColumn.DataSource = messageTypes;
                messageTypeColumn.DisplayMember = "Name";
                messageTypeColumn.ValueMember = "Id";
            }
        }

        private void InitializeData()
        {
            // Пример данных
            messageTypes = new BindingList<MessageType>
            {
                new MessageType { Id = 1, Name = "Text" },
                new MessageType { Id = 2, Name = "Image" },
                new MessageType { Id = 3, Name = "Sticker" }
            };

            messages = new BindingList<Message>
            {
                new Message { Id = 1, Content = "Hello World", ChapterId = 1, MessageTypeId = 1 },
                new Message { Id = 2, Content = "Image123", ChapterId = 1, MessageTypeId = 2 },
                new Message { Id = 3, Content = "Sticker456", ChapterId = 1, MessageTypeId = 3 }
            };
        }

        public List<Message>? DeserializeMessages(string json)
        {
            return JsonConvert.DeserializeObject<List<Message>>(json);
        }

        public string SerializeMessages(List<Message> messages)
        {
            return JsonConvert.SerializeObject(messages);
        }

        private void dataGridViewMessages_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var message = messages?[e.RowIndex];
            if (message == null)
                return;

            if (dataGridViewMessages.Columns[e.ColumnIndex].Name == "Content")
            {
                if (message.MessageTypeId == 3) // Sticker
                {
                    e.Value = "Sticker with ID: " + message.Content;
                }
                else if (message.MessageTypeId == 2) // Image
                {
                    e.Value = "Image with ID: " + message.Content; // Изображение с идентификатором
                }
            }

            if (dataGridViewMessages.Columns[e.ColumnIndex].Name == "ImageCol" && message.MessageTypeId == 2)
            {
                var row = dataGridViewMessages.Rows[e.RowIndex];
                DataGridViewCell avatarCell = row.Cells["ImageCol"];
                LoadImageInCellById(message.Content, avatarCell);
            }
        }

        private void LoadImageInCellById(string? imageId, DataGridViewCell cell)
        {
            if (string.IsNullOrEmpty(imageId))
                return;
            Image? image = ImageUtils.GetImageById(imageId);
            ImageUtils.AddDataGridViewCellToCacheListener(imageId, cell);
            if (image == null || image.Tag?.ToString() == "temp")
                Program.client?.RequestImage(imageId);
            if (image != null)
                cell.Value = image;
            HideLoadingIndicator();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddMessage_Click(object sender, EventArgs e)
        {
            Form newMsgForm = new NewMessageForm(currentChapterId);
            newMsgForm.ShowDialog();
            ShowLoadingIndicator();
        }

        private void MessagesEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.client?.RemoveObserver(this);
            nextMessageIndex = 0;
        }
    }

    public class Message : INotifyPropertyChanged
    {
        private int id;
        private string content = string.Empty;
        private string senderName = string.Empty;
        private int chapterId;
        private int messageTypeId;

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

        public string Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }

        public string SenderName
        {
            get { return senderName; }
            set
            {
                if (senderName != value)
                {
                    senderName = value;
                    OnPropertyChanged(nameof(SenderName));
                }
            }
        }

        public int ChapterId
        {
            get { return chapterId; }
            set
            {
                if (chapterId != value)
                {
                    chapterId = value;
                    OnPropertyChanged(nameof(ChapterId));
                }
            }
        }

        public int MessageTypeId
        {
            get { return messageTypeId; }
            set
            {
                if (messageTypeId != value)
                {
                    messageTypeId = value;
                    OnPropertyChanged(nameof(MessageTypeId));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MessageType
    {
        public int id;
        public string name = string.Empty;

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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}