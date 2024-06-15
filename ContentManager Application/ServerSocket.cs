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
                    else return defaultConfig;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            defaultConfig.SaveConfig(ConfigFilePath);
            return defaultConfig;
        }

        public void SaveConfig(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(this);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
