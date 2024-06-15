using Newtonsoft.Json;
using System.ComponentModel;

namespace ContentManager_Application
{
    public partial class NewMessageForm : Form, IServerMessageObserver
    {
        private int currentChapterId;

        public NewMessageForm(int chapterId, Message? message = null)
        {
            InitializeComponent();

            Program.client?.AddObserver(this);
            comboBoxMsgTypes.SelectedIndex = 0;
            currentChapterId = chapterId;
            AlignLabels();
            InitUI();
        }

        private void InitUI()
        {
            if (comboBoxMsgTypes.SelectedIndex == 0) // Текст
            {
                btnLoadFile.Enabled = false;
                lblLoadedFile.Enabled = false;
                textBoxSetText.Enabled = true;
            }
            else // Префаб или изображение
            {
                btnLoadFile.Enabled = true;
                lblLoadedFile.Enabled = true;
                textBoxSetText.Enabled = false;
            }
        }

        private void AlignLabels()
        {
            int x = (messageInfoPanel.Width - lblMessage.Width) / 2;
            lblMessage.Location = new Point(x, lblMessage.Location.Y);
            x = (messageInfoPanel.Width - lblMessageSenderName.Width) / 2;
            lblMessageSenderName.Location = new Point(x, lblMessageSenderName.Location.Y);
        }

        private void openFileStickerDialog_FileOk(object sender, CancelEventArgs e)
        {
            lblLoadedFile.Text = openFileStickerDialog.FileName;
        }

        private void openFileImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            lblLoadedFile.Text = openFileImageDialog.FileName;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (comboBoxMsgTypes.SelectedIndex == 0)
                return;

            if (comboBoxMsgTypes.SelectedIndex == 1)
            {
                openFileImageDialog.ShowDialog();
            }
            else
            {
                openFileStickerDialog.ShowDialog();
            }
        }

        public bool HandleMessage(string data)
        {
            return false;
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            var senderName = textBoxSetSenderName.Text;
            string msgType = (string)comboBoxMsgTypes.SelectedItem;
            var fileName = lblLoadedFile.Text;
            string msgText = textBoxSetText.Text;
            if (string.IsNullOrEmpty(senderName) || string.IsNullOrEmpty(msgType) || (comboBoxMsgTypes.SelectedIndex > 0 && fileName == "Файл не загружен") || (comboBoxMsgTypes.SelectedIndex == 0 && string.IsNullOrEmpty(msgText)))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string content;

            if (comboBoxMsgTypes.SelectedIndex == 0)
                content = msgText;
            else if (comboBoxMsgTypes.SelectedIndex == 1)
            {
                byte[] imageBytes = File.ReadAllBytes(openFileImageDialog.FileName);
                string base64String = Convert.ToBase64String(imageBytes);
                content = base64String;
            }
            else
            {
                byte[] prefabBytes = File.ReadAllBytes(openFileStickerDialog.FileName);
                string base64String = Convert.ToBase64String(prefabBytes);
                content = base64String;
            }

            Message message = new Message { ChapterId = currentChapterId, Content = content, MessageTypeId = comboBoxMsgTypes.SelectedIndex + 1, SenderName = senderName, Id = -1 };
            Program.client?.SendMessage($"savemessage~sp~{JsonConvert.SerializeObject(message, Formatting.None)}");

            Close();
        }

        private void comboBoxMsgTypes_SelectedIndexChanged(object sender, EventArgs e) =>
            InitUI();

        private void textBoxSetSenderName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSetSenderName.Text))
                lblMessageSenderName.Text = textBoxSetSenderName.Text;
            else
                lblMessageSenderName.Text = "Отправитель";

            AlignLabels();
        }

        private void NewMessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.client?.RemoveObserver(this);
        }
    }
}
