using ContentManager_Application.Utils;
using System.Diagnostics;
using System.Text;

namespace ContentManager_Application
{
    internal static class Program
    {
        public static Client? client { get; private set; }
        private static int _firstChanceExceptionReentrancyLocked;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            /*AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                if (Interlocked.CompareExchange(ref _firstChanceExceptionReentrancyLocked, 1, 0) == 0)
                {
                    try
                    {
                        StackTrace currentStackTrace;

                        try
                        {
                            currentStackTrace = new StackTrace(1, true);
                        }
                        catch
                        {
                            currentStackTrace = null;
                        }

                        MessageBox.Show(new StringBuilder()
                            .AppendLine($"{DateTime.Now:O} exception thrown: {eventArgs.Exception.Message}")
                            .AppendLine("----- Exception -----")
                            .AppendLine(eventArgs.Exception.ToString().TrimEnd())
                            .AppendLine("----- Full Stack -----")
                            .AppendLine(currentStackTrace?.ToString().TrimEnd())
                            .AppendLine()
                            .ToString());
                    }
                    catch
                    {
                        // ignored
                    }
                    finally
                    {
                        Interlocked.Exchange(ref _firstChanceExceptionReentrancyLocked, 0);
                    }
                }
            };*/

            ApplicationConfiguration.Initialize();
            ImageUtils.LoadingImage.Tag = "temp";
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
            else if (client.client != null && client.client.Connected)
            {
                MessageBox.Show("Client already connected!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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