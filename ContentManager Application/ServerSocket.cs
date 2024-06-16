using Newtonsoft.Json;

namespace ContentManager_Application
{
    public class ServerSocket
    {
        [JsonIgnore]
        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "socket.cfg");

        public string IpAddress { get; set; }
        public int Port { get; set; }

        public ServerSocket()
        {
            IpAddress = "127.0.0.1";
            Port = 12361;
        }

        public static ServerSocket LoadConfig()
        {
            ServerSocket defaultConfig = new ServerSocket();
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    ServerSocket? serverSocket = JsonConvert.DeserializeObject<ServerSocket>(json);
                    if (serverSocket != null) return serverSocket;
                    return new ServerSocket();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки конфигурации для подключения к серверу: {ex.Message}\nБудет произведена попытка подключиться к локальному серверу со стандартными параметрами.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            defaultConfig.SaveConfig(ConfigFilePath);
            return defaultConfig;
        }

        public void SaveConfig(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения конфигурации: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
