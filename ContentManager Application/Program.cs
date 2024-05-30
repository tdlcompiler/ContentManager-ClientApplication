namespace ContentManager_Application
{
    internal static class Program
    {
        public static Client? client { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            ApplicationConfiguration.Initialize();
            InitClient();
            Application.Run(new ModdedApplicationContext(() => new LoginForm()));
        }

        private static void InitClient()
        {
            client ??= new Client();
        }

        public static async Task ConnectToServer()
        {
            if (client == null)
            {
                MessageBox.Show("Static Client not initialized!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await client.ConnectToServer("127.0.0.1", 12361);
        }

        public static void CloseConnect()
        {
            if (client == null)
            {
                MessageBox.Show("Static Client not initialized!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            client.Close();
        }
    }

    public class ModdedApplicationContext : ApplicationContext
    {
        public ModdedApplicationContext(Func<Form> formFactory)
        {
            Form startupForm = formFactory();
            startupForm.FormClosed += OnFormClosed;
            startupForm.Show();
        }

        private void OnFormClosed(object? sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count > 0)
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.FormClosed -= OnFormClosed;
                    form.FormClosed += OnFormClosed;
                }
            }
            else ExitThread();
        }
    }
}