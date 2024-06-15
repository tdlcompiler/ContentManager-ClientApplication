namespace ContentManager_Application
{
    public partial class NewAuthorForm : Form, IServerMessageObserver
    {
        private AuthorData? author;
        private string authorName = "Имя автора";
        private string authorCountry = "Страна";

        public NewAuthorForm(AuthorData? author = null)
        {
            InitializeComponent();
            Program.client?.AddObserver(this);
            this.author = author;
            if (author != null)
                InitAuthor();

            AlignLabels();
        }

        private void InitAuthor()
        {
            if (author == null)
                return;

            authorName = author.Name;
            authorCountry = author.Country;
            lblAuthorName.Text = authorName;
            lblAuthorCountry.Text = authorCountry;
            textBoxAuthorName.PlaceholderText = authorName;
            textBoxAuthorCountry.PlaceholderText = authorCountry;
        }

        public bool HandleMessage(string data)
        {
            return false;
        }

        private void btnSaveAuthor_Click(object sender, EventArgs e)
        {
            var authorName = textBoxAuthorName.Text;
            var authorCountry = textBoxAuthorCountry.Text;
            if (string.IsNullOrEmpty(authorName) || string.IsNullOrEmpty(authorCountry))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (author == null)
                Program.client?.SendMessage($"saveauthor~sp~{authorName}~sp~{authorCountry}");
            else
                Program.client?.SendMessage($"saveauthor~sp~{authorName}~sp~{authorCountry}~sp~{author.Id}");

            Close();
        }

        private void NewAuthorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.client?.RemoveObserver(this);
        }

        private void AlignLabels()
        {
            int x = (authorInfoPanel.Width - lblAuthorName.Width) / 2;
            lblAuthorName.Location = new Point(x, lblAuthorName.Location.Y);
            x = (authorInfoPanel.Width - lblAuthorCountry.Width) / 2;
            lblAuthorCountry.Location = new Point(x, lblAuthorCountry.Location.Y);
        }

        private void textBoxAuthorName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAuthorName.Text))
                lblAuthorName.Text = textBoxAuthorName.Text;
            else
                lblAuthorName.Text = authorName;

            AlignLabels();
        }

        private void textBoxAuthorCountry_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxAuthorCountry.Text))
                lblAuthorCountry.Text = textBoxAuthorCountry.Text;
            else
                lblAuthorCountry.Text = authorCountry;

            AlignLabels();
        }
    }
}
