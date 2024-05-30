namespace ContentManager_Application
{
    public partial class ImageGridControl : UserControl
    {
        private FlowLayoutPanel? flowLayoutPanel;
        public PictureBox? selectedPictureBox;
        public delegate void AvatarSelectedEventHandler(object sender, EventArgs e);
        public event AvatarSelectedEventHandler? AvatarSelected;

        public ImageGridControl()
        {
            InitializeComponent();
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };
            Controls.Add(flowLayoutPanel);
        }

        public Image? SelectedImage
        {
            get { return selectedPictureBox?.Image; }
        }

        public int SelectedIndex { get; private set; }

        public void InitializeGrid(int columns, Dictionary<string, Image> images, int imageSize = 60, int margin = 5)
        {
            if (columns <= 0)
                throw new ArgumentException("Columns must be greater than 0");
            if (flowLayoutPanel == null)
                return;

            //int rows = (images.Count + columns - 1) / columns;
            //int picBoxesCount = rows * columns;

            SelectedIndex = -1;

            flowLayoutPanel.SuspendLayout();
            flowLayoutPanel.Controls.Clear();

            foreach (var keyImagePair in images)
            {
                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(margin),
                    Size = new Size(imageSize, imageSize),
                    Image = keyImagePair.Value
                };
                pictureBox.Click += PictureBox_Click;
                pictureBox.Tag = keyImagePair.Key;
                flowLayoutPanel.Controls.Add(pictureBox);
            }

            flowLayoutPanel.ResumeLayout();
        }

        private void PictureBox_Click(object? sender, EventArgs e)
        {
            PictureBox? clickedPictureBox = (PictureBox?)sender;
            if (flowLayoutPanel == null || clickedPictureBox == null)
                return;
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }

            clickedPictureBox.BorderStyle = BorderStyle.Fixed3D;
            selectedPictureBox = clickedPictureBox;
            SelectedIndex = flowLayoutPanel.Controls.IndexOf(clickedPictureBox);

            OnAvatarSelected(EventArgs.Empty);
        }

        protected virtual void OnAvatarSelected(EventArgs e)
        {
            AvatarSelected?.Invoke(this, e);
        }
    }
}