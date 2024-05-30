namespace ContentManager_Application
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        public void AppendTextToTextBox(string text)
        {
            string msg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}]: {text}";
            if (responseTextBox.InvokeRequired)
            {
                responseTextBox.Invoke(new Action<string>(AppendTextToTextBox), msg);
            }
            else
            {
                responseTextBox.AppendText(msg + Environment.NewLine);
            }
        }

        private async void TestForm_Load(object? sender, EventArgs e)
        {
            await Program.ConnectToServer();

            if (Program.client == null)
                return;

            Program.client.Connected += Client_Connected;
            Program.client.Disconnected += Client_Disconnected;
        }

        private void Client_Connected(object? sender, EventArgs e)
        {
            AppendTextToTextBox("Подключено к серверу.");
            lblConnectionState.Text = "Подключено.";
            lblConnectionState.ForeColor = Color.Green;
        }

        private void Client_Disconnected(object? sender, EventArgs e)
        {
            AppendTextToTextBox("Отключено от сервера.");
            lblConnectionState.Text = "Отключено.";
            lblConnectionState.ForeColor = Color.Red;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            if (Program.client == null)
                return;
            if (Program.client.client == null || !Program.client.client.Connected)
                await Program.ConnectToServer();

            string message = messageTextBox.Text;
            Exception? error = Program.client.SendMessage(message);
            if (error != null)
                AppendTextToTextBox(error.Message);

            messageTextBox.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CloseConnect();
        }
    }
}