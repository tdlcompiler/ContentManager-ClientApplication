namespace ContentManager_Application.Utils
{
    public static class ImageUtils
    {
        public static Dictionary<string, Image> ImageResources = new Dictionary<string, Image>();
        public static Dictionary<string, PictureBox> ActivePictureBoxes = new Dictionary<string, PictureBox>();
        public static Image? LoadingImage { get; set; }

        public static Image? GetImageById(string id)
        {

            if (ImageResources.ContainsKey(id))
                return ImageResources[id];
            else
                return LoadingImage;
        }

        public static bool CacheImage(string imageId, Image image)
        {
            PictureBox? pb = ActivePictureBoxes.GetValueOrDefault(imageId);

            if (pb == null)
                return false;
            else
                ImageResources.Add(imageId, image);

            pb.Image = ResizeAndCropToSquare(image);

            return true;
        }

        public static Image ResizeAndCropToSquare(Image image, int newSize = 50)
        {
            int minSize = Math.Min(image.Width, image.Height);

            Bitmap result = new Bitmap(newSize, newSize);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, new Rectangle(0, 0, newSize, newSize), new Rectangle(0, 0, minSize, minSize), GraphicsUnit.Pixel);
            }

            return result;
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
