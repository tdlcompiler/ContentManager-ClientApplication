using ContentManager_Application.Utils;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace ContentManager_Application
{
    public class Client : IServerMessageObserver
    {
        private readonly List<IServerMessageObserver> observers = new List<IServerMessageObserver>();

        public TcpClient? client;

        private NetworkStream? stream;
        private StreamWriter? writer;
        private Aes aes;

        public event EventHandler? Connected;
        public event EventHandler? Disconnected;

        public Client()
        {
            aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes("KiJvHecdyYCeM2llswHEmQfICiUtdlxk");
            aes.IV = Encoding.UTF8.GetBytes("U9htdlFa3As7n9nD");
        }

        public async Task ConnectToServer(string ip, int port)
        {
            Connected += Client_Connected;
            Disconnected += Client_Disconnected;

            await ConnectAsync(ip, port);
        }

        private void Client_Connected(object? sender, EventArgs e)
        {
            //
        }

        private void Client_Disconnected(object? sender, EventArgs e)
        {
            //
        }

        public void AddObserver(IServerMessageObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IServerMessageObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public bool HandleMessage(string data)
        {
            foreach (var observer in observers)
            {
                if (observer.HandleMessage(data))
                    return true;
            }

            string[] parts = data.Split('~');
            string command = parts[0];
            string[] args = parts.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "setloadingimage":
                    SetLoadingImage(args);
                    return true;
                default:
                    MessageBox.Show($"Ошибка: Неизвестная команда '{command}'.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
        }

        private void SetLoadingImage(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    Image image = ImageUtils.ImageFromBase64(args[0]);
                    ImageUtils.LoadingImage = ImageUtils.ResizeAndCropToSquare(image, 100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обработке изображения: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task ConnectAsync(string serverIp, int serverPort)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(serverIp, serverPort);
                stream = client.GetStream();
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                OnConnected(EventArgs.Empty);

                await ReceiveMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnDisconnected(EventArgs.Empty);
            }
        }

        protected virtual void OnConnected(EventArgs e)
        {
            Connected?.Invoke(this, e);
        }

        protected virtual void OnDisconnected(EventArgs e)
        {
            Disconnected?.Invoke(this, e);
        }

        public void Disconnect()
        {
            if (client != null && client.Connected)
            {
                client.Close();
                OnDisconnected(EventArgs.Empty);
            }
        }

        public Exception? SendMessage(string message)
        {
            if (client == null || !client.Connected)
            {
                return new Exception("The message was not sent because the client is not connected to the server.");
            }
            try
            {
                string encryptedMessage = EncryptMessage(message);
                writer?.WriteLine(encryptedMessage);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task ReceiveMessages()
        {
            try
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        string encryptedMessage;
                        while ((encryptedMessage = await reader.ReadLineAsync()) != null)
                        {
                            HandleMessage(DecryptMessage(encryptedMessage));
                        }
                    }
                }
            }
            catch (IOException ioEx)
            {
                OnDisconnected(EventArgs.Empty);
                MessageBox.Show($"Connection lost: {ioEx.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                OnDisconnected(EventArgs.Empty);
                MessageBox.Show($"Error receiving message: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EncryptMessage(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(messageBytes, 0, messageBytes.Length);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private string DecryptMessage(string encryptedMessage)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);
            using (MemoryStream ms = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cs, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public void Close()
        {
            stream?.Close();
            client?.Close();
        }
    }
}