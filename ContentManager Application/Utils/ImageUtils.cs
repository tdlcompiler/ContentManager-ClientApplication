namespace ContentManager_Application.Utils
{
    public static class ImageUtils
    {
        public static Dictionary<string, Image> ImageResources = new Dictionary<string, Image>();
        public static Dictionary<string, List<PictureBox>> ActivePictureBoxes = new Dictionary<string, List<PictureBox>>();
        public static Dictionary<string, List<DataGridViewCell>> ActiveDataGridViewCells = new Dictionary<string, List<DataGridViewCell>>();
        public static Image LoadingImage = Properties.Resources.pngwing_com__6_;

        public static Image? GetImageById(string id)
        {

            if (ImageResources.ContainsKey(id))
                return ImageResources[id];
            else
                return LoadingImage;
        }

        public static void AddPictureBoxToCacheListener(string key, PictureBox pb)
        {
            if (!ActivePictureBoxes.ContainsKey(key))
                ActivePictureBoxes.Add(key, new List<PictureBox>());
            ActivePictureBoxes[key].Add(pb);
        }

        public static void AddDataGridViewCellToCacheListener(string key, DataGridViewCell dgvc)
        {
            if (!ActiveDataGridViewCells.ContainsKey(key))
                ActiveDataGridViewCells.Add(key, new List<DataGridViewCell>());
            ActiveDataGridViewCells[key].Add(dgvc);
        }

        public static bool CacheImage(string imageId, Image image)
        {
            List<PictureBox>? pbs = ActivePictureBoxes.GetValueOrDefault(imageId);
            List<DataGridViewCell>? dgvcs = ActiveDataGridViewCells.GetValueOrDefault(imageId);

            if (pbs == null && dgvcs == null)
                return false;
            else if (!ImageResources.ContainsKey(imageId))
                ImageResources.Add(imageId, image);

            if (pbs != null)
                foreach (PictureBox pb in pbs)
                {
                    if (pb != null)
                        pb.Image = image;
                }
            if (dgvcs != null)
                foreach (DataGridViewCell dgvc in dgvcs)
                {
                    if (dgvc != null)
                        dgvc.Value = image;
                }

            return true;
        }

        public static Image ImageFromBase64(string base64Image)
        {
            byte[] imageBytes = Convert.FromBase64String(base64Image);
            using MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms);
            return image;
        }
    }
}
