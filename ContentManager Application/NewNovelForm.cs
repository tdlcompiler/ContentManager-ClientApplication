using Newtonsoft.Json;
using System.ComponentModel;

namespace ContentManager_Application
{
    public partial class NewNovelForm : Form, IServerMessageObserver
    {
        private BindingList<AuthorData> authors;
        private NovelData? novel;
        private BindingList<Chapter> chapters = new BindingList<Chapter>();
        private string novelName = "Название новеллы";
        private string novelAuthor = "Автор";
        private bool saved = false;

        public NewNovelForm(BindingList<AuthorData> authors, NovelData? novel = null)
        {
            InitializeComponent();
            Program.client?.AddObserver(this);
            this.novel = novel;
            this.authors = authors;
            if (novel != null)
                InitNovel();

            ConfigureChaptersDataGridView();
            InitAuthors();
            AlignLabels();
        }

        private void ConfigureChaptersDataGridView()
        {
            if (novel != null)
                dataGridViewChapters.DataSource = CopyBindingList(novel.Chapters) ?? chapters;
            else
                dataGridViewChapters.DataSource = chapters;

            dataGridViewChapters.Columns["Title"].HeaderText = "Название главы";
            dataGridViewChapters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChapters.Columns["Id"].Visible = false;
        }

        public static BindingList<Chapter> CopyBindingList(BindingList<Chapter> source)
        {
            BindingList<Chapter> target = new BindingList<Chapter>();
            target.RaiseListChangedEvents = false;
            foreach (var item in source)
            {
                target.Add(item);
            }
            target.RaiseListChangedEvents = true;
            target.ResetBindings();

            return target;
        }

        private void InitAuthors()
        {
            int i = 0;
            foreach (var author in authors)
            {
                string authorName = author.Name;
                comboBoxAuthors.Items.Add(new ComboBoxItem { Text = authorName, Value = author.Id });
                if (authorName == novel?.AuthorName)
                    comboBoxAuthors.SelectedIndex = i;
                i++;
            }
        }

        private void InitNovel()
        {
            if (novel == null)
                return;

            novel.BackupChapters();
            novelName = novel.Title;
            novelAuthor = novel.AuthorName;
            lblNovelName.Text = novelName;
            lblNovelAuthor.Text = novelAuthor;
            textBoxNovelName.PlaceholderText = novelName;
            dateTimePickerNovel.Value = novel.CreationDate;
        }

        public bool HandleMessage(string data)
        {
            return false;
        }

        private string ChaptersToJson()
        {
            if (novel != null)
            {
                novel.Chapters = new BindingList<Chapter>((BindingList<Chapter>)dataGridViewChapters.DataSource);
                return JsonConvert.SerializeObject(novel.Chapters, Formatting.None);
            }
            else
                return JsonConvert.SerializeObject(dataGridViewChapters.DataSource, Formatting.None);
        }

        private void btnSaveNovel_Click(object sender, EventArgs e)
        {
            var novelName = textBoxNovelName.Text;
            var novelAuthor = ((ComboBoxItem)comboBoxAuthors.SelectedItem)?.Value;
            var novelDate = dateTimePickerNovel.Value;
            if (string.IsNullOrEmpty(novelName) || novelAuthor == null)
            {
                MessageBox.Show("Поля \"Название\" и \"Автор\" должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (novel == null)
                Program.client?.SendMessage($"savenovel~sp~{novelName}~sp~{novelAuthor}~sp~{novelDate}~sp~{ChaptersToJson()}");
            else
                Program.client?.SendMessage($"savenovel~sp~{novelName}~sp~{novelAuthor}~sp~{novelDate}~sp~{ChaptersToJson()}~sp~{novel.Id}");

            saved = true;
            Close();
        }

        private void NewAuthorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.client?.RemoveObserver(this);
        }

        private void AlignLabels()
        {
            int x = (authorInfoPanel.Width - lblNovelName.Width) / 2;
            lblNovelName.Location = new Point(x, lblNovelName.Location.Y);
            x = (authorInfoPanel.Width - lblNovelAuthor.Width) / 2;
            lblNovelAuthor.Location = new Point(x, lblNovelAuthor.Location.Y);
        }

        private void textBoxNovelName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNovelName.Text))
                lblNovelName.Text = textBoxNovelName.Text;
            else
                lblNovelName.Text = novelName;

            AlignLabels();
        }

        private void comboBoxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxAuthors.Text))
                lblNovelAuthor.Text = comboBoxAuthors.Text;
            else
                lblNovelAuthor.Text = novelAuthor;

            AlignLabels();
        }

        private void NewNovelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.client?.RemoveObserver(this);
        }

        private void dataGridViewChapters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewChapters.CurrentRow;
            if (currentRow.DataBoundItem is Chapter selectedChapter)
            {
                Form msgEditor = new MessagesEditorForm(novel, selectedChapter.Id);
                msgEditor.ShowDialog();
            }
        }
    }
}
