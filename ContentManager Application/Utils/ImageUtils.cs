namespace ContentManager_Application.Utils
{
    public static class ImageUtils
    {
        public static Image? LoadingImage { get; set; }

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
